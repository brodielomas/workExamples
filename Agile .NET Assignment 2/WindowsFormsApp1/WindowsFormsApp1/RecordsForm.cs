using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ISQuote
{

    // Authors: Brodie Lomas lombl001
    // Authors: Jackson Tucker tucjy008

    public partial class RecordsForm : Form
    {

        SqlConnection myConnection = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\\ISQuoteData.mdf; Integrated Security = True");

        public RecordsForm()
        {
            InitializeComponent();
        }

        private void RecordsForm_Load(object sender, EventArgs e)
        {
            myConnection.Open();

            // Displays all of the records from the client table in the gridview
            string selectClients = "SELECT * FROM clients";
            SqlDataAdapter adapter = new SqlDataAdapter(selectClients, myConnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

            var ds = new DataSet();
            adapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];


            // Displays all of the records from the jobs table in the gridview
            string selectJobs = "SELECT * FROM jobs";
            SqlDataAdapter adapter2 = new SqlDataAdapter(selectJobs, myConnection);
            SqlCommandBuilder commandBuilder2 = new SqlCommandBuilder(adapter2);

            var ds2 = new DataSet();
            adapter2.Fill(ds2);
            dataGridView1.DataSource = ds2.Tables[0];
        
            myConnection.Close();



 
            // Previous code using table adapters 

            //DateTime date = new DateTime(2019, 3, 15);

            //clientsTableAdapter.Insert("Brodie Lomas", "0404554554", "56 Robert Ave Braodview");
            //jobsTableAdapter.Insert("False", date, date, false, true, false, true, false, true, 100, false, false, false, false, false, false, false, false, 200, 10, 180);

            // jobsTableAdapter.Insert("", #5/1/2008 8:30:52AM#, #5/1/2008 8:30:52AM#, false, true, false, true, false, true, 100, false, false, false, false, true,
            //false, false, false, 200, 10, 180);

            // TODO: This line of code loads data into the 'iSQuoteDataDataSet.Jobs' table. You can move, or remove it, as needed.
            //this.jobsTableAdapter.Fill(this.iSQuoteDataDataSet.Jobs);
            // TODO: This line of code loads data into the 'iSQuoteDataDataSet.Clients' table. You can move, or remove it, as needed.
            //this.clientsTableAdapter.Fill(this.iSQuoteDataDataSet.Clients);

            

        }


        public void addClient(String name, String phoneNo, String address)
        {
            // Issue inserting the values in the method parameters (Test values inserted instead to check if new values are added to database)
            // Issue with having new values save to the database
            string insert = "Insert into Clients ([clientName], [phoneNumber], [address]) values ('Test Name', '00001111', 'Test Address')";

            SqlCommand InsertCommand = new SqlCommand(insert, myConnection);

            myConnection.Open();

            // Executes the insert query
            InsertCommand.ExecuteNonQuery();

            myConnection.Close();




            // Old code using table adapters 
            //clientsTableAdapter.Insert(name, phoneNo, address);
            //clientsTableAdapter.Update(iSQuoteDataDataSet.Clients);
        }

        public void addJob(String priority, Boolean guarantee, Boolean noGuarantee, Boolean corporate, Boolean personal, Boolean adelaideCBD, Boolean metropolitan,
            int km, Boolean orderPriority, Boolean over5kg, Boolean over40kg, Boolean unusualShape, Boolean fragile, Boolean dangerous, Boolean living, Boolean other,
            int otherCost, decimal discount, decimal total)
        {

            // Issues trying to insert values into the boolean columns
            /*
            string insert = "Insert into Jobs ([priority], [dateSubmitted], [dateCompleted], [guarentee], [noGuarentee], [corporate], [personal], [adelaideCBD], " +
                "[metropolitan], [metroKilometres], [orderPriority], [over5KG], [over40KG], [unusualShape], [fragile], [dangerous], [living], [other], [otherCost], " +
                "[discount], [total]) values ('No', 2019-03-03, 2019-04-01, True, False, False, False, False, True, 20, False, True, False, True, False, False," +
                "false, false, 0, 20, 100)";

            SqlCommand InsertCommand = new SqlCommand(insert, myConnection);

            myConnection.Open();
            InsertCommand.ExecuteNonQuery();

            myConnection.Close();
            */








            // Old code using table adapters 

            //DateTime today = DateTime.Today;

            //jobsTableAdapter.Insert(priority, today, today, guarantee, noGuarantee, corporate, personal, adelaideCBD, metropolitan, km, orderPriority, over5kg,
            //    over40kg, unusualShape, fragile, dangerous, living, other, otherCost, discount, total);

            //jobsTableAdapter.Update(iSQuoteDataDataSet);
            
        }













        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
