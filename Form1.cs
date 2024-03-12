using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Using_SQLDataAdapter_DataSet.DataAccess;

namespace Using_SQLDataAdapter_DataSet {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            DatabaseHelper.Initialisation();
            booksDataGridView.DataSource = DatabaseHelper.booksDataSet.Tables["carti"].DefaultView;

        }
    }
}
