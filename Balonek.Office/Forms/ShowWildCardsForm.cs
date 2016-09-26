using Balonek.Database.Entities;
using Balonek.Office.Controls;
using Balonek.Office.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Unzumutbar.Extensions;

namespace Balonek.Office.Forms
{
    public partial class ShowWildCardsForm : Form
    {
        private UserControl _parentControl;
        private DateTime _firstDayOfMonth;
        public ShowWildCardsForm()
        {
            InitializeComponent();
            _firstDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        }

        public void CreateWildCards(Company company)
        {
            try
            {
                Client client = CreateClient();
                List<BillPosition> positionList = CreatePositionList(client, 3);
                Bill bill = CreateBill(client, positionList);
                var wildcardsDictionary = bill.StringReplacementDictionary(company);

                var wildcardsArray = from row in wildcardsDictionary select new { Wildcard = row.Key, Example = row.Value };
                dataGridView1.DataSource = wildcardsArray.ToArray();
            }
            catch (Exception ex)
            {
                BalonekMessageBox.ShowError(Program.Logger, ex);
            }
        }

        private Bill CreateBill(Client client, List<BillPosition> positionList)
        {
            var bill = new Bill();
            bill.Id = 1;
            bill.Client = client;
            bill.Status = BillStatus.Printed;
            bill.DateFrom = _firstDayOfMonth;
            bill.DateTo = _firstDayOfMonth.AddMonths(1).AddDays(-1); ;
            bill.Positions = positionList;
            bill.Total = positionList.Sum(pos => pos.Total);
            return bill;
        }

        private List<BillPosition> CreatePositionList(Client client, int count)
        {
            var positionList = new List<BillPosition>();
            for (int i = 1; i <= count; i++)
            {
                var position = new BillPosition();
                position.Id = i;
                position.Type = i % 2 == 0 ? PositionType.Periodical : PositionType.Single;
                position.Period = i % 2 == 0 ? Period.BiWeekly : Period.Weekly;
                position.Client = client;
                position.Date = _firstDayOfMonth.AddDays(i);
                position.Description = GetDescription().Random();
                position.Time = (Decimal)(i *0.5);
                position.Rate = (Decimal)(i*1.2);
                positionList.Add(position);
            }
            return positionList;
        }

        private Client CreateClient()
        {
            var client = new Client();
            client.Id = 1;
            client.Name = "Max Mustermann";
            client.Street = "Musterstraße 1";
            client.Zip = "10115";
            client.City = "Berlin";
            client.Telephone = "030-123456";
            client.Fax = "030-654321";
            client.Email = "MaxMuster@Mann.de";
            client.Deleted = false;
            return client;
        }

        private Company CreateCompany()
        {
            return new Company();
        }

        private List<String> GetDescription()
        {
            var descriptions = new List<String>();
            descriptions.Add("Haushaltshilfe");
            descriptions.Add("Altenpflege");
            descriptions.Add("Reinigung");
            descriptions.Add("Tätigkeit");
            descriptions.Add("Fahrrad fahren");
            descriptions.Add("Essen kochen");
            return descriptions;
        }

        public void SetParentControl(UserControl control)
        {
            _parentControl = control;
        }
    }
}
