using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstrarctClass
{
    class Client:Entity
    {
        public DataGridView dataGrid { get; set; }

        public string Name { get; set; }
       
        public Client(DataGridView grid,string data)
        {
            dataGrid = grid;
            Name = data;

        }
      
        public override void Read()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=AYE\SQLEXPRESS;Initial Catalog=I001;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Client";
                    SqlCommand cmdRead = new SqlCommand(query,conn);
                    SqlDataReader reader = cmdRead.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();
                    dataGrid.DataSource = dt;
                    dataGrid.Update();
                    dataGrid.Columns[0].Visible = false;
                    dataGrid.Columns[1].HeaderText = "Имя";
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public override void Add()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=AYE\SQLEXPRESS;Initial Catalog=I001;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Client values (@Name)";
                    SqlCommand cmdAdd = new SqlCommand(query, conn);
                    cmdAdd.Parameters.AddWithValue(@"Name", Name);
                    cmdAdd.ExecuteNonQuery();
                    Read();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public override void Delete(int ID)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=AYE\SQLEXPRESS;Initial Catalog=I001;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Client WHERE [IdClient] = @ID";
                    SqlCommand cmdAdd = new SqlCommand(query, conn);
                    cmdAdd.Parameters.AddWithValue(@"ID", ID);
                    cmdAdd.ExecuteNonQuery();
                    Read();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public override void Create(int ID)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=AYE\SQLEXPRESS;Initial Catalog=I001;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Client SET [NameClient] = @Name WHERE [IdClient] = @ID";
                    SqlCommand cmdAdd = new SqlCommand(query, conn);
                    cmdAdd.Parameters.AddWithValue(@"ID", ID);
                    cmdAdd.Parameters.AddWithValue(@"Name", Name);
                    cmdAdd.ExecuteNonQuery();
                    Read();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
