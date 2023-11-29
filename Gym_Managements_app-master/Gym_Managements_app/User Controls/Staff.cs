using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Managements_app.User_Controls
{
    public partial class Staff : UserControl
    {
        public Staff()
        {
            InitializeComponent();
            LoadStaffGrid();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadStaffGrid()
        {

            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lovin\Documents\Gym_management_1 (1).mdf"";Integrated Security=True;Connect Timeout=30";
            string qry = "select * from Staff";

            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Staff");
            dataGridView1.DataSource = ds.Tables["Staff"];




        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewStaff objNewStaff = new NewStaff();
            objNewStaff.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int iD = int.Parse(txtStaff_Search.Text);
                DialogResult result = MessageBox.Show("Are you sure you want to delete this data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\acer\Downloads\Gym_management (1).mdf"";Integrated Security=True;Connect Timeout=30");
                    string qry = "delete from Staff where staffID = '" + iD + "'";
                    SqlCommand cmd = new SqlCommand(qry, conn);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data deleted Succesfully");
                        }
                        else
                        {
                            MessageBox.Show("Sorry! Data not found ");
                        }
                    }
                    catch (Exception ex)
                    {

                        ex.Message.ToString();

                    }

                    finally { 
                        conn.Close();
                        txtStaff_Search.Text = ""; 
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid ID format. Please enter a valid integer ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadStaffGrid();
        }
    }
}