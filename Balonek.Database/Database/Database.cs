using Balonek.Database.Tables;
using System.IO;
using Unzumutbar.Logging;

namespace Balonek.Database
{
    public class Database
    {
        private const int DATABASEVERSION = 1;
        public ILogger Logger;

        public Clients Clients;
        public BillPositions BillPositions;
        public Bills Bills;
        public Texts Texts;
        public Companies Company;


        public Database(string databaseDirectory, ILogger logger)
        {
            Logger = logger;
            databaseDirectory = Path.Combine(databaseDirectory, "Data");
            if (!Directory.Exists(databaseDirectory))
                Directory.CreateDirectory(databaseDirectory);

            InitilizeTables(databaseDirectory);
        }

        private void InitilizeTables(string databaseDirectory)
        {
            Company = new Companies(databaseDirectory, this);
            if (Company.Get() == null)
                Company.CreateDefaultValue();

            Clients = new Clients(databaseDirectory, this);
            BillPositions = new BillPositions(databaseDirectory, this);
            Bills = new Bills(databaseDirectory, this);
            Texts = new Texts(databaseDirectory, this);
        }

        //private void AddDefaultBillPositionText()
        //{
        //    var newText = new BillPositionText();
        //    newText.Id = 1;
        //    newText.Text = "Haushaltshilfe";
        //    AddBillPositionText(newText);
        //}
    }
}
