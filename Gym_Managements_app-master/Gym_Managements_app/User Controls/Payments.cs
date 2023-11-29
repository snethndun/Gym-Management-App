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
using System.Xml;

namespace Gym_Managements_app.User_Controls
{
    public partial class Payments : UserControl
    {


        public Payments()
        {
            InitializeComponent();
        }

        string personalTraining;
        int Amount, totalAmount, memberId;

        private void button1_Click(object sender, EventArgs e)
        {

            int searchID = int.Parse(txtNic.Text);

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lovin\Documents\Gym_management_1 (1).mdf"";Integrated Security=True;Connect Timeout=30");
            string sql = "Select * from Member where memberId='" + searchID + "'";

            SqlCommand cmd = new SqlCommand(sql, conn);




            try
            {
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();

                lblName.Text = sdr["firstName"].ToString() + " " + sdr["lastName"].ToString();
                memberId = int.Parse(sdr["memberId"].ToString());
                lblID.Text = memberId.ToString();
                lblPackage.Text = sdr["membershipType"].ToString();

                personalTraining = sdr["personalTraining"].ToString();
                lblPersonalTraining.Text = personalTraining;

                lblPaymentType.Text = sdr["paymentType"].ToString();

                Amount = int.Parse(sdr["packageAmount"].ToString());

                //implementing amount logic for including/excluding personal training


                if (personalTraining == "yes")
                {
                    totalAmount = Amount + 7000;
                    lblAmount.Text = totalAmount.ToString();
                }
                else
                {
                    totalAmount = Amount - 7000;
                    lblAmount.Text = totalAmount.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNic_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            txtNic.Text = "";
            lblName.Text = "";
            lblID.Text = "";
            lblPackage.Text = "";
            lblPersonalTraining.Text = "";
            lblPaymentType.Text = "";
            lblAmount.Text = "";

            lblMessage.Text = "Payment Successful";
            await Task.Delay(3000);

            lblMessage.Text = "";

            //inserting data into table
            DateTime dateTime = DateTime.Now;
            int payment = totalAmount;
            int id = memberId;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lovin\Documents\Gym_management_1 (1).mdf"";Integrated Security=True;Connect Timeout=30");
            string qry = "INSERT INTO Transactions (transactionDate, amount, memberId) VALUES ('" + dateTime + "', '" + payment + "', '" + id + "')";
            SqlCommand cmd = new SqlCommand(qry, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
            }
            //check primary key incrementation



        }

        private void lblAmount_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblPaymentType_Click(object sender, EventArgs e)
        {

        }

        private void lblPersonalTraining_Click(object sender, EventArgs e)
        {

        }

        private void lblPackage_Click(object sender, EventArgs e)
        {

        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {


        }
    }
}
