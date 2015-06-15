using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    public partial class ReportsScreen : Form
    {
        public ReportsScreen()
        {
            InitializeComponent();
        }

        private void ReportsScreen_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cramDataSet.Movie' table. You can move, or remove it, as needed.
            this.MovieTableAdapter.Fill(this.cramDataSet.Movie);

            this.reportViewer1.RefreshReport();
        }
    }
}
