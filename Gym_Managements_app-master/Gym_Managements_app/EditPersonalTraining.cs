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
    public partial class EditPersonalTraining : Form
    {
        public EditPersonalTraining()
        {
            InitializeComponent();
            LoadPersonalTrainingGrid();
        }

        private void LoadPersonalTrainingGrid()
        {

            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lovin\Documents\Gym_management_1 (1).mdf"";Integrated Security=True;Connect Timeout=30";
            string qry = "select * from PersonalTraining";

            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "PersonalTraining");
            dataGridView1.DataSource = ds.Tables["PersonalTraining"];


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string trainerName = txtTainerName.Text;
            int ID;

            if (txtID.Text != "" && txtTainerName.Text != "")
            {
                try
                {
                    ID = int.Parse(txtID.Text);

                    SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lovin\Documents\Gym_management_1 (1).mdf"";Integrated Security=True;Connect Timeout=30");

                    string query = "Update PersonalTraining set trainerName='" + trainerName + "' where trainingID='" + ID + "'";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfullty updated package amount");
                        LoadPersonalTrainingGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                        txtID.Text = "";
                        txtTainerName.Text = "";
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

        private void txtTainerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
