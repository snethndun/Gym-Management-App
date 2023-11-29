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
using System.Xml.Linq;

namespace Gym_Managements_app.User_Controls
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            DisplayNewMembers();
            currentInstructor();
        }

        private void DisplayNewMembers()
        {
            DateTime currentDate = DateTime.Now;
            int monthToCheck = currentDate.Month;

            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lovin\Documents\Gym_management_1 (1).mdf"";Integrated Security=True;Connect Timeout=30";

            string sql = "SELECT * FROM Member WHERE MONTH(registrationDate) = '"+monthToCheck+"'";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, constring);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Member");
            dataGridNewMembers.DataSource = ds.Tables["Member"];

        }

        private void currentInstructor()
        {
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lovin\Documents\Gym_management_1 (1).mdf"";Integrated Security=True;Connect Timeout=30";

            DateTime currentTime = DateTime.Now;
            TimeSpan morningStartTime = TimeSpan.Parse("06:00");
            TimeSpan morningEndTime = TimeSpan.Parse("12:00");
            TimeSpan nightStartTime = TimeSpan.Parse("18:00");
            TimeSpan nightEndTime = TimeSpan.Parse("23:59");

            string name = "";

            if (currentTime.TimeOfDay >= morningStartTime && currentTime.TimeOfDay <= morningEndTime)
            {
                // Console.WriteLine("It's morning time.");

                string qry = "SELECT firstName FROM Staff WHERE shift = @Shift";

                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand(qry, con))
                    {
                        try
                        {
                            con.Open();
                            cmd.Parameters.AddWithValue("@shift", "Morning");
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                name = reader["firstName"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Trainer not found.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else if (currentTime.TimeOfDay >= nightStartTime || currentTime.TimeOfDay <= nightEndTime)
            {
                // Console.WriteLine("It's nighttime.");

                string qry = "SELECT firstName FROM Staff WHERE shift = @Shift";

                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand(qry, con))
                    {
                        try
                        {
                            con.Open();
                            cmd.Parameters.AddWithValue("@shift", "Night");
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                name = reader["firstName"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Trainer not found.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else
            {

                lblAvailableInstructor.Text = "No instructor Available";
            }

            lblAvailableInstructor.Text = name;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
