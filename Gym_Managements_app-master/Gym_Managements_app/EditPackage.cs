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
    public partial class EditPackage : Form
    {
        public EditPackage()
        {
            InitializeComponent();

            LoadPackageData();
        }

        private void LoadPackageData()
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lovin\Documents\Gym_management_1 (1).mdf"";Integrated Security=True;Connect Timeout=30";

            string qry = "select * from MembershipType";

            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "MembershipType");
            dataGridView1.DataSource = ds.Tables["MembershipType"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double amount;
            int ID;

            if (txtID.Text != "" && txtAmount.Text != "")
            {
                try
                {
                    amount = double.Parse(txtAmount.Text);
                    ID = int.Parse(txtID.Text);

                    SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lovin\Documents\Gym_management_1 (1).mdf"";Integrated Security=True;Connect Timeout=30");

                    string query = "Update MembershipType set price='" + amount + "' where TypeId='" + ID + "'";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfullty updated package amount");
                        LoadPackageData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                        txtID.Text = "";
                        txtAmount.Text = "";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Fll ID and package amount");
            }
        }
    }
}
