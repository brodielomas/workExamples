using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISQuote
{

    // Authors: Brodie Lomas lombl001
    // Authors: Jackson Tucker tucjy008

    public partial class ISQuote : Form
    {
        // Set the various rates. Double is used in case more precision is required for 
        // prices late. They're public in case of issues later.

        public double InitialFee = 20;
        public double GuarenteeFee = 10;
        public double KMTravelFee = 2;
        public double PriorityFee = 30;

        public double Over5kgFee = 10;
        public double Over40kgFee = 80;
        public double UnusualShapeFee = 10;
        public double FragileFee = 10;
        public double DangerousFee = 100;
        public double LivingFee = 50;

        public string PriorityCheck = "No";

        RecordsForm recordForum = new RecordsForm();

        // Discount rates
        public double CorporateDiscount = 0.5;

        #region "Constructor"

        public ISQuote()
        {
            InitializeComponent();

            ClearButton.Click += new EventHandler(this.ClearButton_Click);

            CBD.CheckedChanged += new EventHandler(this.ValueChanged);
            Priority.CheckedChanged += new EventHandler(this.ValueChanged);
            Dangerous.CheckedChanged += new EventHandler(this.ValueChanged);
            Over5Kg.CheckedChanged += new EventHandler(this.ValueChanged);
            Living.CheckedChanged += new EventHandler(this.ValueChanged);
            Guarantee.CheckedChanged += new EventHandler(this.ValueChanged);
            NoGuarantee.CheckedChanged += new EventHandler(this.ValueChanged);
            Corporate.CheckedChanged += new EventHandler(this.ValueChanged);
            UnusualShape.CheckedChanged += new EventHandler(this.ValueChanged);
            Over40kg.CheckedChanged += new EventHandler(this.ValueChanged);
            Fragile.CheckedChanged += new EventHandler(this.ValueChanged);

            Travelkm.TextChanged += new EventHandler(this.TextValueChanged);
            OtherCost.TextChanged += new EventHandler(this.TextValueChanged);

            Metropolitan.CheckedChanged += new EventHandler(this.Metropolitan_CheckedChanged);

            Other.CheckedChanged += new EventHandler(this.Other_CheckedChanged);

            this.CalculateQuote();

        }

        #endregion

        #region "Main Code"

        // Main method to calculate and display the final quote.
        public void CalculateQuote()
        {
            double orderCost = 0; //Covers the call out fee and priority rates
            double jobsCost = 0; //Covers the cost of the various details

            //Zero the boxes
            this.zeroCosts();

            //This is embedded in a try...catch in case boxes don't contain numbers.
            try
            {
                //Check to see if this needs travel time
                if (Metropolitan.Checked == true)
                {
                    double costOfTravel = 0;
                    //Travel time is calculated in lots of 30
                    if (Travelkm.Text != "")
                    {
                        costOfTravel = Math.Ceiling(Convert.ToDouble(Travelkm.Text) / 30);
                    }
                    orderCost = InitialFee + orderCost + costOfTravel;
                    TravelCost.Text = (InitialFee + costOfTravel).ToString("F");
                }

                //Check to see if they want a guarentee
                //Calculate priority fee
                if (Guarantee.Checked == true)
                {
                    orderCost += GuarenteeFee;
                }

                // Calculate priority fee
                if (Priority.Checked == true)
                {
                    PriorityCost.Text = PriorityFee.ToString("F");
                    orderCost += PriorityFee;
                }

                // Is it over 5kg?
                if (Over5Kg.Checked == true)
                {
                    jobsCost += Over5kgFee;
                    Over5KGCost.Text = Over5kgFee.ToString("F");
                }

                // Is it over 40kg?
                if (Over40kg.Checked == true)
                {
                    jobsCost += Over40kgFee;
                    Over40kgCost.Text = Over40kgFee.ToString("F");
                }

                // Unusual shape?
                if (UnusualShape.Checked == true)
                {
                    jobsCost += UnusualShapeFee;
                    UnusualShapeCost.Text = UnusualShapeFee.ToString("F");
                }

                // Fragile?
                if(Fragile.Checked == true) 
                {
                    jobsCost += FragileFee;
                    FragileCost.Text = FragileFee.ToString("F");
                }

                // Dangerous?
                if(Dangerous.Checked == true)
                {
                    jobsCost += DangerousFee;
                    DangerousCost.Text = DangerousFee.ToString("F");
                }

                // Do we need to upgrade the HD?
                if (Living.Checked == true)
                {
                    jobsCost += LivingFee;
                    LivingCost.Text = LivingFee.ToString("F");
                }

                // Any other costs?
                if(Other.Checked == true)
                {
                    if(OtherCost.Text != "")
                    {
                        jobsCost += Convert.ToDouble(OtherCost.Text);
                    }
                }

                // Now it is time to calculate the final cost

                double finalCost = orderCost; // Included the cost of travel, etc.

                // If this is for a corporation, we need to include the discount, otherwise we just add the price
                if (Corporate.Checked == true) {
                    Discount.Text = CorporateDiscount.ToString("F");
                    finalCost += (jobsCost * CorporateDiscount);
                }
                else{
                    finalCost += jobsCost;
                }
                Quote.Text = (finalCost).ToString("F");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Values need to be entered as whole numbers");
            }
        }

        // When calculating the new cost, or staring a new quote, we may need to zero the various
        // text boxes for costs
        private void zeroCosts()
        {
            TravelCost.Text = "0.00";
            PriorityCost.Text = "0.00";

            Over5KGCost.Text = "0.00";
            Over40kgCost.Text = "0.00";
            UnusualShapeCost.Text = "0.00";
            FragileCost.Text = "0.00";
            DangerousCost.Text = "0.00";
            LivingCost.Text = "0.00";

            Discount.Text = "0";
            Quote.Text = "0.00";
        }

        public void ClearForm()
        {
            this.zeroCosts();

            //Reset the radio button
            NoGuarantee.Checked = true;
            CBD.Checked = true;

            //Reset the text boxes
            Travelkm.Text = "";
            NameText.Text = "";
            AddressText.Text = "";
            PhoneText.Text = "";

            //Reset the checkboxes
            Priority.Checked = false;
            Over5Kg.Checked = false;
            Over40kg.Checked = false;
            UnusualShape.Checked = false;
            Fragile.Checked = false;
            Dangerous.Checked = false;
            Living.Checked = false;
            Other.Checked = false;
        }

        #endregion

        #region "Events"

        private void ValueChanged(object sender, EventArgs e)
        {
            this.CalculateQuote();
        }

        private void TextValueChanged(object sender, EventArgs e)
        {
            int travel = 0;
            Int32.TryParse(Travelkm.Text, out travel);
            int other = 0;
            Int32.TryParse(OtherCost.Text, out other);

            if (travel < 0 || other < 0 )
            {
                MessageBox.Show("Please enter a positive integer");
            }
            else
            {
                this.CalculateQuote();
            }
        }

        private void Other_CheckedChanged(object sender, EventArgs e)
        {
            OtherCost.Enabled = Other.Checked; // If the checkbox is enabled, the text box should be too
            if (OtherCost.Enabled && OtherCost.Text == "")
            {
                OtherCost.Text = "0"; //Add 0 if and only if it didn't already have a value (don't want to overwrite an existing value)
            }
            this.CalculateQuote();
        }

        private void Metropolitan_CheckedChanged(object sender, EventArgs e)
        {
            Travelkm.Enabled = Metropolitan.Checked; //If the checkbox is enabled, the text box should be too
            if (Travelkm.Enabled && Travelkm.Text == "")
            {
                Travelkm.Text = "0"; //Add 0 if and only if it didn't already have a value (don't want to overwrite an existing value)
            }
            this.CalculateQuote();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        #endregion

        private void RecordsButton_Click(object sender, EventArgs e)
        {
            recordForum.Show();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {

          
            int travelKm = 0;
            int OCost = 0;


            if (Travelkm.Text != "")
            {
                travelKm = Convert.ToInt32(Travelkm.Text);
            }

            if (OtherCost.Text != "")
            {
                OCost = Convert.ToInt32(OtherCost.Text);
            }

            if (Priority.Checked == true)
            {
                PriorityCheck = "Yes";
            }

            decimal discount = Convert.ToDecimal(Discount.Text);
            decimal total = Convert.ToDecimal(Quote.Text);

            recordForum.addClient(NameText.Text, PhoneText.Text, AddressText.Text);
            recordForum.addJob(PriorityCheck, Guarantee.Checked, NoGuarantee.Checked, Corporate.Checked, Personal.Checked, CBD.Checked, Metropolitan.Checked, travelKm, Priority.Checked, Over5Kg.Checked,
                Over40kg.Checked, UnusualShape.Checked, Fragile.Checked, Dangerous.Checked, Living.Checked, Other.Checked, OCost, discount, total);

            
        }
    }
}
