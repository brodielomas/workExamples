namespace ISQuote
{
    partial class RecordsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.jobIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priorityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateSubmittedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCompleatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guarenteeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.noGuarenteeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.corporateDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.personalDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.adelaideCBDDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.metropolitanDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.metroKilometresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderPriorityDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.over5KGDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.over40KGDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.unusualShapeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fragileDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dangerousDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.livingDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.otherDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.otherCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iSQuoteDataDataSet = new WindowsFormsApp1.ISQuoteDataDataSet();
            this.iSQuoteDataDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.clientIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientsTableAdapter = new WindowsFormsApp1.ISQuoteDataDataSetTableAdapters.ClientsTableAdapter();
            this.jobsTableAdapter = new WindowsFormsApp1.ISQuoteDataDataSetTableAdapters.JobsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSQuoteDataDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSQuoteDataDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.jobIDDataGridViewTextBoxColumn,
            this.priorityDataGridViewTextBoxColumn,
            this.dateSubmittedDataGridViewTextBoxColumn,
            this.dateCompleatedDataGridViewTextBoxColumn,
            this.guarenteeDataGridViewCheckBoxColumn,
            this.noGuarenteeDataGridViewCheckBoxColumn,
            this.corporateDataGridViewCheckBoxColumn,
            this.personalDataGridViewCheckBoxColumn,
            this.adelaideCBDDataGridViewCheckBoxColumn,
            this.metropolitanDataGridViewCheckBoxColumn,
            this.metroKilometresDataGridViewTextBoxColumn,
            this.orderPriorityDataGridViewCheckBoxColumn,
            this.over5KGDataGridViewCheckBoxColumn,
            this.over40KGDataGridViewCheckBoxColumn,
            this.unusualShapeDataGridViewCheckBoxColumn,
            this.fragileDataGridViewCheckBoxColumn,
            this.dangerousDataGridViewCheckBoxColumn,
            this.livingDataGridViewCheckBoxColumn,
            this.otherDataGridViewCheckBoxColumn,
            this.otherCostDataGridViewTextBoxColumn,
            this.discountDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn});
            this.dataGridView1.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.jobsBindingSource, "jobID", true));
            this.dataGridView1.DataMember = "Jobs";
            this.dataGridView1.DataSource = this.iSQuoteDataDataSetBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 220);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(443, 174);
            this.dataGridView1.TabIndex = 0;
            // 
            // jobIDDataGridViewTextBoxColumn
            // 
            this.jobIDDataGridViewTextBoxColumn.DataPropertyName = "jobID";
            this.jobIDDataGridViewTextBoxColumn.HeaderText = "jobID";
            this.jobIDDataGridViewTextBoxColumn.Name = "jobIDDataGridViewTextBoxColumn";
            this.jobIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priorityDataGridViewTextBoxColumn
            // 
            this.priorityDataGridViewTextBoxColumn.DataPropertyName = "priority";
            this.priorityDataGridViewTextBoxColumn.HeaderText = "priority";
            this.priorityDataGridViewTextBoxColumn.Name = "priorityDataGridViewTextBoxColumn";
            // 
            // dateSubmittedDataGridViewTextBoxColumn
            // 
            this.dateSubmittedDataGridViewTextBoxColumn.DataPropertyName = "dateSubmitted";
            this.dateSubmittedDataGridViewTextBoxColumn.HeaderText = "dateSubmitted";
            this.dateSubmittedDataGridViewTextBoxColumn.Name = "dateSubmittedDataGridViewTextBoxColumn";
            // 
            // dateCompleatedDataGridViewTextBoxColumn
            // 
            this.dateCompleatedDataGridViewTextBoxColumn.DataPropertyName = "dateCompleated";
            this.dateCompleatedDataGridViewTextBoxColumn.HeaderText = "dateCompleated";
            this.dateCompleatedDataGridViewTextBoxColumn.Name = "dateCompleatedDataGridViewTextBoxColumn";
            // 
            // guarenteeDataGridViewCheckBoxColumn
            // 
            this.guarenteeDataGridViewCheckBoxColumn.DataPropertyName = "guarentee";
            this.guarenteeDataGridViewCheckBoxColumn.HeaderText = "guarentee";
            this.guarenteeDataGridViewCheckBoxColumn.Name = "guarenteeDataGridViewCheckBoxColumn";
            // 
            // noGuarenteeDataGridViewCheckBoxColumn
            // 
            this.noGuarenteeDataGridViewCheckBoxColumn.DataPropertyName = "noGuarentee";
            this.noGuarenteeDataGridViewCheckBoxColumn.HeaderText = "noGuarentee";
            this.noGuarenteeDataGridViewCheckBoxColumn.Name = "noGuarenteeDataGridViewCheckBoxColumn";
            // 
            // corporateDataGridViewCheckBoxColumn
            // 
            this.corporateDataGridViewCheckBoxColumn.DataPropertyName = "corporate";
            this.corporateDataGridViewCheckBoxColumn.HeaderText = "corporate";
            this.corporateDataGridViewCheckBoxColumn.Name = "corporateDataGridViewCheckBoxColumn";
            // 
            // personalDataGridViewCheckBoxColumn
            // 
            this.personalDataGridViewCheckBoxColumn.DataPropertyName = "personal";
            this.personalDataGridViewCheckBoxColumn.HeaderText = "personal";
            this.personalDataGridViewCheckBoxColumn.Name = "personalDataGridViewCheckBoxColumn";
            // 
            // adelaideCBDDataGridViewCheckBoxColumn
            // 
            this.adelaideCBDDataGridViewCheckBoxColumn.DataPropertyName = "adelaideCBD";
            this.adelaideCBDDataGridViewCheckBoxColumn.HeaderText = "adelaideCBD";
            this.adelaideCBDDataGridViewCheckBoxColumn.Name = "adelaideCBDDataGridViewCheckBoxColumn";
            // 
            // metropolitanDataGridViewCheckBoxColumn
            // 
            this.metropolitanDataGridViewCheckBoxColumn.DataPropertyName = "metropolitan";
            this.metropolitanDataGridViewCheckBoxColumn.HeaderText = "metropolitan";
            this.metropolitanDataGridViewCheckBoxColumn.Name = "metropolitanDataGridViewCheckBoxColumn";
            // 
            // metroKilometresDataGridViewTextBoxColumn
            // 
            this.metroKilometresDataGridViewTextBoxColumn.DataPropertyName = "metroKilometres";
            this.metroKilometresDataGridViewTextBoxColumn.HeaderText = "metroKilometres";
            this.metroKilometresDataGridViewTextBoxColumn.Name = "metroKilometresDataGridViewTextBoxColumn";
            // 
            // orderPriorityDataGridViewCheckBoxColumn
            // 
            this.orderPriorityDataGridViewCheckBoxColumn.DataPropertyName = "orderPriority";
            this.orderPriorityDataGridViewCheckBoxColumn.HeaderText = "orderPriority";
            this.orderPriorityDataGridViewCheckBoxColumn.Name = "orderPriorityDataGridViewCheckBoxColumn";
            // 
            // over5KGDataGridViewCheckBoxColumn
            // 
            this.over5KGDataGridViewCheckBoxColumn.DataPropertyName = "over5KG";
            this.over5KGDataGridViewCheckBoxColumn.HeaderText = "over5KG";
            this.over5KGDataGridViewCheckBoxColumn.Name = "over5KGDataGridViewCheckBoxColumn";
            // 
            // over40KGDataGridViewCheckBoxColumn
            // 
            this.over40KGDataGridViewCheckBoxColumn.DataPropertyName = "over40KG";
            this.over40KGDataGridViewCheckBoxColumn.HeaderText = "over40KG";
            this.over40KGDataGridViewCheckBoxColumn.Name = "over40KGDataGridViewCheckBoxColumn";
            // 
            // unusualShapeDataGridViewCheckBoxColumn
            // 
            this.unusualShapeDataGridViewCheckBoxColumn.DataPropertyName = "unusualShape";
            this.unusualShapeDataGridViewCheckBoxColumn.HeaderText = "unusualShape";
            this.unusualShapeDataGridViewCheckBoxColumn.Name = "unusualShapeDataGridViewCheckBoxColumn";
            // 
            // fragileDataGridViewCheckBoxColumn
            // 
            this.fragileDataGridViewCheckBoxColumn.DataPropertyName = "fragile";
            this.fragileDataGridViewCheckBoxColumn.HeaderText = "fragile";
            this.fragileDataGridViewCheckBoxColumn.Name = "fragileDataGridViewCheckBoxColumn";
            // 
            // dangerousDataGridViewCheckBoxColumn
            // 
            this.dangerousDataGridViewCheckBoxColumn.DataPropertyName = "dangerous";
            this.dangerousDataGridViewCheckBoxColumn.HeaderText = "dangerous";
            this.dangerousDataGridViewCheckBoxColumn.Name = "dangerousDataGridViewCheckBoxColumn";
            // 
            // livingDataGridViewCheckBoxColumn
            // 
            this.livingDataGridViewCheckBoxColumn.DataPropertyName = "living";
            this.livingDataGridViewCheckBoxColumn.HeaderText = "living";
            this.livingDataGridViewCheckBoxColumn.Name = "livingDataGridViewCheckBoxColumn";
            // 
            // otherDataGridViewCheckBoxColumn
            // 
            this.otherDataGridViewCheckBoxColumn.DataPropertyName = "other";
            this.otherDataGridViewCheckBoxColumn.HeaderText = "other";
            this.otherDataGridViewCheckBoxColumn.Name = "otherDataGridViewCheckBoxColumn";
            // 
            // otherCostDataGridViewTextBoxColumn
            // 
            this.otherCostDataGridViewTextBoxColumn.DataPropertyName = "otherCost";
            this.otherCostDataGridViewTextBoxColumn.HeaderText = "otherCost";
            this.otherCostDataGridViewTextBoxColumn.Name = "otherCostDataGridViewTextBoxColumn";
            // 
            // discountDataGridViewTextBoxColumn
            // 
            this.discountDataGridViewTextBoxColumn.DataPropertyName = "discount";
            this.discountDataGridViewTextBoxColumn.HeaderText = "discount";
            this.discountDataGridViewTextBoxColumn.Name = "discountDataGridViewTextBoxColumn";
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            // 
            // jobsBindingSource
            // 
            this.jobsBindingSource.DataMember = "Jobs";
            this.jobsBindingSource.DataSource = this.iSQuoteDataDataSet;
            // 
            // iSQuoteDataDataSet
            // 
            this.iSQuoteDataDataSet.DataSetName = "ISQuoteDataDataSet";
            this.iSQuoteDataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // iSQuoteDataDataSetBindingSource
            // 
            this.iSQuoteDataDataSetBindingSource.DataSource = this.iSQuoteDataDataSet;
            this.iSQuoteDataDataSetBindingSource.Position = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clientIDDataGridViewTextBoxColumn,
            this.clientNameDataGridViewTextBoxColumn,
            this.phoneNumberDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn});
            this.dataGridView2.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.clientsBindingSource, "clientID", true));
            this.dataGridView2.DataMember = "Clients";
            this.dataGridView2.DataSource = this.iSQuoteDataDataSetBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(12, 36);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(443, 150);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // clientIDDataGridViewTextBoxColumn
            // 
            this.clientIDDataGridViewTextBoxColumn.DataPropertyName = "clientID";
            this.clientIDDataGridViewTextBoxColumn.HeaderText = "clientID";
            this.clientIDDataGridViewTextBoxColumn.Name = "clientIDDataGridViewTextBoxColumn";
            this.clientIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clientNameDataGridViewTextBoxColumn
            // 
            this.clientNameDataGridViewTextBoxColumn.DataPropertyName = "clientName";
            this.clientNameDataGridViewTextBoxColumn.HeaderText = "clientName";
            this.clientNameDataGridViewTextBoxColumn.Name = "clientNameDataGridViewTextBoxColumn";
            this.clientNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // phoneNumberDataGridViewTextBoxColumn
            // 
            this.phoneNumberDataGridViewTextBoxColumn.DataPropertyName = "phoneNumber";
            this.phoneNumberDataGridViewTextBoxColumn.HeaderText = "phoneNumber";
            this.phoneNumberDataGridViewTextBoxColumn.Name = "phoneNumberDataGridViewTextBoxColumn";
            this.phoneNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "address";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clientsBindingSource
            // 
            this.clientsBindingSource.DataMember = "Clients";
            this.clientsBindingSource.DataSource = this.iSQuoteDataDataSet;
            // 
            // clientsTableAdapter
            // 
            this.clientsTableAdapter.ClearBeforeFill = true;
            // 
            // jobsTableAdapter
            // 
            this.jobsTableAdapter.ClearBeforeFill = true;
            // 
            // RecordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 436);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "RecordsForm";
            this.Text = "RecordsForm";
            this.Load += new System.EventHandler(this.RecordsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSQuoteDataDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSQuoteDataDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priorityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateSubmittedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCompleatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn guarenteeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn noGuarenteeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn corporateDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn personalDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn adelaideCBDDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn metropolitanDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn metroKilometresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn orderPriorityDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn over5KGDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn over40KGDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn unusualShapeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fragileDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dangerousDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn livingDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn otherDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn otherCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource iSQuoteDataDataSetBindingSource;
        private WindowsFormsApp1.ISQuoteDataDataSet iSQuoteDataDataSet;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource clientsBindingSource;
        private WindowsFormsApp1.ISQuoteDataDataSetTableAdapters.ClientsTableAdapter clientsTableAdapter;
        private System.Windows.Forms.BindingSource jobsBindingSource;
        private WindowsFormsApp1.ISQuoteDataDataSetTableAdapters.JobsTableAdapter jobsTableAdapter;
    }
}