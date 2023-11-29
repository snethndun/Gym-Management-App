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
    public partial class MemberDetails : UserControl
    {
        public MemberDetails()
        {
            InitializeComponent();
            LoadMemberGrid();

            textSearch.TextChanged += textBox1_TextChanged;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadMemberGrid()
        {

            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lovin\Documents\Gym_management_1 (1).mdf"";Integrated Security=True;Connect Timeout=30";
            string qry = "select * from Member";

            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Member");
            dataGridView1.DataSource = ds.Tables["Member"];

           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textSearch.Text != "")
            {
                string memberName = textSearch.Text;

                string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lovin\Documents\Gym_management_1 (1).mdf"";Integrated Security=True;Connect Timeout=30";

                string qry = "select * from Member where firstName like '" + memberName + "' or lastName like '" + memberName + "'";

                SqlDataAdapter da = new SqlDataAdapter(qry, constring);

                DataSet ds = new DataSet();

                da.Fill(ds, "Member");
                dataGridView1.DataSource = ds.Tables["Member"];
            } else
            {
                LoadMemberGrid();
            }
           
        }

        private void MemberDetails_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int iD = int.Parse(txtMember_Search.Text);
                DialogResult result = MessageBox.Show("Are you sure you want to delete this data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lovin\Documents\Gym_management_1 (1).mdf"";Integrated Security=True;Connect Timeout=30");
                    string qry = "delete from Member where memberId = '" + iD + "'";
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
                    catch (SqlException ex)
                    {

                        ex.Message.ToString();

                    }

                    finally { 
                        conn.Close();
                        txtMember_Search.Text = "";
                        LoadMemberGrid();
                    }
                }
            }
            catch (FormatException)
            {

                MessageBox.Show("Invalid ID format. Please enter a valid integer ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditMember objEdit = new EditMember();
            objEdit.Show();
        }
    }
}
