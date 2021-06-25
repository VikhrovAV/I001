using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstrarctClass
{
    public partial class FormProduct : Form
    {
        int IDCell;
        public FormProduct()
        {
            InitializeComponent();
            labName.Text = "Название продукта";
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDCell = Convert.ToInt32(dataGrid[0, e.RowIndex].Value);
                txtData.Text = dataGrid[1, e.RowIndex].Value.ToString();
            }

            catch { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtData.Text != string.Empty)
            {
                var client = new Client(dataGrid, txtData.Text);
                client.Add();
                txtData.Text = "";
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (IDCell == 0) IDCell = Convert.ToInt32(dataGrid[0, 0].Value);
                var client = new Client(dataGrid, txtData.Text);
                client.Delete(IDCell);
                IDCell = 0;
                txtData.Text = "";
            }
            catch { }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtData.Text != string.Empty)
            {
                if (IDCell == 0) IDCell = Convert.ToInt32(dataGrid[0, 0].Value);
                var client = new Client(dataGrid, txtData.Text);
                client.Create(IDCell);
                txtData.Text = "";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
            var main = new FormMain();
            main.Show();
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            var product = new Product(dataGrid,txtData.Text);
            product.Read();
        }
    }
}
