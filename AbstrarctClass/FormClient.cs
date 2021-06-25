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
    public partial class FormClient : Form
    {
        int IDCell = 0;
        public FormClient()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
            var main = new FormMain();
            main.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labName.Text = "Введите имя клиента";
            var client = new Client(dataGrid,txtData.Text);
            client.Read();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtData.Text != string.Empty)
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

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            { 
                IDCell = Convert.ToInt32(dataGrid[0, e.RowIndex].Value);
                txtData.Text = dataGrid[1, e.RowIndex].Value.ToString();
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
    }
}
