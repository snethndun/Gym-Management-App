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

namespace Gym_Managements_app
{
    public partial class EditMember : Form
    {
        public EditMember()
        {
            InitializeComponent();

            LoadMemberGrid();
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
            string memberName = txtMemberName.Text;
            int ID;

            if (txtID.Text != "" && txtMemberName.Text != "")
            {
                try
                {
                    ID = int.Parse(txtID.Text);

                    SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lovin\Documents\Gym_management_1 (1).mdf"";Integrated Security=True;Connect Timeout=30");

                    string query = "Update Member set fnameName='" + memberName + "' where memberId='" + ID + "'";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfullty updated package amount");
                        LoadMemberGrid(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                        txtID.Text = "";
                        txtMemberName.Text = "";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Fll ID and trainer name");
            }
        }
    }
}
