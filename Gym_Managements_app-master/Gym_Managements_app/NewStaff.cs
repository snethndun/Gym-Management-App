using System;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;

namespace Gym_Managements_app
{
    public partial class NewStaff : Form
    {
        public NewStaff()
        {
            InitializeComponent();
        }

        public string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lovin\Documents\Gym_management_1 (1).mdf"";Integrated Security=True;Connect Timeout=30";

        public double returnSalary(string EmStatus, string title)
        {
            SqlConnection con = new SqlConnection(conString);

            string query = "Select salary from StaffSalary Where type='"+EmStatus+"' and category='"+title+"'" ;

            SqlCommand cmd = new SqlCommand(query, con);

            double sal;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                sal = double.Parse(reader["salary"].ToString());
                return sal;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return 0;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            int age;
            int contactNumber;
            string addressNumber = txtAddressNumber.Text;
            string addressLane = txtAddressLane.Text;
            string addressCity = txtAddressCity.Text;
            string shift = comboBox1.Text;
            string employementStatus;
            string jobTitle = comboBoxJob.Text;
            double salary;
            int NIC;

            if(firstName != "" && lastName != "" && txtAge.Text != "" && txtContact.Text != "" && addressNumber != "" && addressLane != "" && addressCity != "" && shift != "" && jobTitle != "" && txtNic.Text != "")
            {
                if(radioFulltime.Checked || radioParttime.Checked)
                {
                    if (radioFulltime.Checked)
                    {
                        employementStatus = radioFulltime.Text;
                    } else
                    {
                        employementStatus = radioParttime.Text;
                    }


                    try
                    {
                        salary = returnSalary(employementStatus, jobTitle);
                        age = int.Parse(txtAge.Text);
                        contactNumber = int.Parse(txtContact.Text);
                        NIC = int.Parse(txtNic.Text);

                        SqlConnection conn = new SqlConnection(conString);

                        string sql = "insert into Staff (staffID, firstName, lastName, age, contactNumber, addressNumber, addressLane, addressCity, shift, employementStatus, jobTitle, salary) values('"+NIC+"', '"+firstName+"', '"+lastName+"', '"+age+"', '"+contactNumber+"', '"+addressNumber+"', '"+addressLane+"', '"+addressCity+"', '"+shift+"', '"+employementStatus+"', '"+jobTitle+"', '"+salary+"')";

                        SqlCommand cmd = new SqlCommand(sql, conn);

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Successfully added new member");
                            this.Close();
                        }catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }finally
                        {
                            conn.Close();
                        }

                    } catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                } else
                {
                    MessageBox.Show("Select employement status");
                }
            } else
            {
                MessageBox.Show("Fill all data!");
            }


            
            
        }
    }
}
