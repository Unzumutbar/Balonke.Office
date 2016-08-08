using Balonek.Office.Controls;
using Balonek.Office.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Balonek.Office.Utils.Enums;

namespace Balonek.Office.Forms
{
    public partial class AutoPositionsForm : Form
    {
        private List<BillPosition> _periodicalPositionList;
        private List<BillPosition> _singlePositionList;
        private List<BillPosition> _newPositions;
        private UserControl _parentControl;

        public AutoPositionsForm()
        {
            InitializeComponent();
            pickerDateFrom.Value = DateTime.Now.Date;
            pickerDateEnd.Value = pickerDateFrom.Value.AddMonths(1);
        }

        public void SetPositionList(List<BillPosition> positionList)
        {
            _periodicalPositionList = positionList.Where(p => p.Type == PositionType.Periodical).ToList();

            _singlePositionList = positionList.Where(p => p.Type == PositionType.Single).ToList();

            this.listBoxPositions.Items.Clear();
            foreach (var position in _periodicalPositionList)
            {
                this.listBoxPositions.Items.Add(position.ToPeriodicalString(), true);
            }
        }

        public void SetParentControl(UserControl control)
        {
            _parentControl = control;
        }

        private void CreateSinglePositions()
        {
            var startDate = this.pickerDateFrom.Value.Date;
            var endDate = this.pickerDateEnd.Value.Date;
            if (startDate > endDate)
                return;

            var checkedPeriodicalPositions = GetCheckedPositions();
            if (!checkedPeriodicalPositions.Any())
                return;

            var nextId = GetStartId();
            _newPositions = new List<BillPosition>();
            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                foreach (var pos in checkedPeriodicalPositions)
                {
                    if (PositionIsEligible(date, pos))
                    {
                        var singlePosition = ConvertToSinglePosition(pos);
                        singlePosition.Id = nextId;
                        singlePosition.Date = date;
                        if (!PositionExists(singlePosition))
                        {
                            _newPositions.Add(singlePosition);
                            nextId++;
                        }
                    }
                }
            }

            var source = new BindingSource(_newPositions, null);
            dataGridPositions.DataSource = source;
        }

        private int GetStartId()
        {
            var positionList = new List<BillPosition>();
            positionList.AddRange(_periodicalPositionList);
            positionList.AddRange(_singlePositionList);
            return positionList.Max(c => c.Id) + 1;
        }

        private BillPosition ConvertToSinglePosition(BillPosition periodPosition)
        {
            var singlePosition = new BillPosition();
            singlePosition.Client = periodPosition.Client;
            singlePosition.Description = periodPosition.Description;
            singlePosition.Rate = periodPosition.Rate;
            singlePosition.Time = periodPosition.Time;
            singlePosition.Type = PositionType.Single;
            singlePosition.Period = Period.None;
            return singlePosition;
        }

        private bool PositionIsEligible(DateTime currentDate, BillPosition pos)
        {
            if (currentDate.DayOfWeek != pos.Date.DayOfWeek)
                return false;

            if (pos.Period == Period.None)
                return false;

            var days = (currentDate.Date - pos.Date.Date).TotalDays;
            if (pos.Period == Period.Weekly)
                return days % 7 == 0;

            else if (pos.Period == Period.BiWeekly)
                return days % 14 == 0;

            else if (pos.Period == Period.TriWeekly)
                return days % 21 == 0;

            else if (pos.Period == Period.Monthly)
                return days % 28 == 0;

            return false;
        }


        private bool PositionExists(BillPosition pos)
        {
            return _singlePositionList.Any(sp => sp.Client.Id == pos.Client.Id && sp.Date.Date == pos.Date.Date);
        }

        public List<BillPosition> GetCheckedPositions()
        {
            var checkedPeriodicalPositions = new List<BillPosition>();
            for (int i = 0; i < listBoxPositions.Items.Count; i++)
            {
                if (listBoxPositions.GetItemChecked(i))
                    checkedPeriodicalPositions.Add(_periodicalPositionList[i]);
            }
            return checkedPeriodicalPositions;
        }

        private void pickerDateFrom_ValueChanged(object sender, EventArgs e)
        {
            CreateSinglePositions();
        }

        private void listBoxPositions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            List<string> checkedItems = new List<string>();
            foreach (var item in listBoxPositions.CheckedItems)
                checkedItems.Add(item.ToString());

            if (e.NewValue == CheckState.Checked)
                checkedItems.Add(listBoxPositions.Items[e.Index].ToString());

            CreateSinglePositions();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var pos in _newPositions)
                Program.Database.AddBillPosition(pos);

            if (_parentControl is ControlBillPosition)
                (_parentControl as ControlBillPosition).UpdatePositionList();

            this.Close();
        }
    }
}
