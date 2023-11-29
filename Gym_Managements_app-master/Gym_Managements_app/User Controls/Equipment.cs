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
    public partial class Equipment : UserControl
    {

        public Equipment()
        {
            InitializeComponent();

            LoadEquipmentGrid();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadEquipmentGrid()
        {

            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lovin\Documents\Gym_management_1 (1).mdf"";Integrated Security=True;Connect Timeout=30";
            string qry = "select * from Equipment";

            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Equipment");
            dataGridView1.DataSource = ds.Tables["Equipment"];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add equipment code
            int ID;
            string Name = textBox2.Text;
            string Type = textBox3.Text;
            string Manufacturer = textBox4.Text;
            int Price;
            string Pdate = textBox6.Text;
            string Edate = textBox7.Text;
            string Description = textBox8.Text;

            try
            {
                ID = int.Parse(textBox1.Text);
                Price = int.Parse(textBox5.Text);

                if (Name != "" && textBox1.Text != "" && Type != "" && Manufacturer != "" && textBox5.Text != "" && Pdate != ""
                    && Edate != "" && Description != "")
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lovin\Documents\Gym_management_1 (1).mdf"";Integrated Security=True;Connect Timeout=30");

                    string qry = "INSERT INTO Equipment (equipmentID, equipmentName, equipmentType,manufacturer,purchaseDate,purchasePrice,warrentyExpire,avalabilityStatus) VALUES ('" + ID + "', '" + Name + "', '" + Type + "', '" + Manufacturer + "',  '" + Pdate + "','" + Price + "', '" + Edate + "', '" + Description + "')";

                    SqlCommand cmd = new SqlCommand(qry, con);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully inserted");

                        textBox2.Text = "";
                        textBox1.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Fill all Fields");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }

            //Add a refresh button




            /*private void button2_Click(object sender, EventArgs e)
            {
                AddToMaintenance addMaintenance = new AddToMaintenance();
                addMaintenance.Show();

            }*/
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AddToMaintenance addMaintenance = new AddToMaintenance();
            addMaintenance.Show();
        }
    }
}
