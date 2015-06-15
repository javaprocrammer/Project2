namespace Project2
{
    partial class ReportsScreen
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.MovieBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cramDataSet = new Project2.cramDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.MovieTableAdapter = new Project2.cramDataSetTableAdapters.MovieTableAdapter();
            this.cramDataSet1 = new Project2.cramDataSet1();
            ((System.ComponentModel.ISupportInitialize)(this.MovieBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cramDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cramDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // MovieBindingSource
            // 
            this.MovieBindingSource.DataMember = "Movie";
            this.MovieBindingSource.DataSource = this.cramDataSet;
            // 
            // cramDataSet
            // 
            this.cramDataSet.DataSetName = "cramDataSet";
            this.cramDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.MovieBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Project2.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(885, 491);
            this.reportViewer1.TabIndex = 0;
            // 
            // MovieTableAdapter
            // 
            this.MovieTableAdapter.ClearBeforeFill = true;
            // 
            // cramDataSet1
            // 
            this.cramDataSet1.DataSetName = "cramDataSet1";
            this.cramDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ReportsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 491);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportsScreen";
            this.Text = "ReportsScreen";
            this.Load += new System.EventHandler(this.ReportsScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MovieBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cramDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cramDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource MovieBindingSource;
        private cramDataSet cramDataSet;
        private cramDataSetTableAdapters.MovieTableAdapter MovieTableAdapter;
        private cramDataSet1 cramDataSet1;
    }
}