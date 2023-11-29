using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Managements_app.User_Controls
{
    public partial class NewMember : UserControl
    {
        public NewMember()
        {
            InitializeComponent();

            LoadValuesToComboBox();
        }

        

        public string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lovin\Documents\Gym_management_1 (1).mdf"";Integrated Security=True;Connect Timeout=30";
        //public int ID;

        public double calculateMembeshipFee(string paymentType, string membershipType, double membershipTypePrice, string personalTraining, double personalTrainingPrice)
        {
            // individual = 4000, per month
            // family = 12000 per month
            // couple = 6000 per month
            // if personal trainig is yes add 4000 more
            // if the payment method is per year multiply and give 25% off discount

            // double finalPrice;
             double finalPrice = 0;

            if (paymentType == "Monthly")
            {
                if (membershipType == "Individual" && personalTraining == "yes")
                {
                    finalPrice = membershipTypePrice + personalTrainingPrice;
                }
                else if (membershipType == "Individual" && personalTraining == "no")
                {
                    finalPrice = membershipTypePrice;
                }

                if (membershipType == "Family" && personalTraining == "yes")
                {
                    finalPrice = membershipTypePrice + personalTrainingPrice;
                }
                else if (membershipType == "Family" && personalTraining == "no")
                {
                    finalPrice = membershipTypePrice;
                }

                if (membershipType == "Couple" && personalTraining == "yes")
                {
                    finalPrice = membershipTypePrice + personalTrainingPrice;
                }
                else if (membershipType == "Couple" && personalTraining == "no")
                {
                    finalPrice = membershipTypePrice;
                }
            }
            else
            {
                if (membershipType == "Individual" && personalTraining == "yes")
                {
                    finalPrice = ((membershipTypePrice * 12) - ((membershipTypePrice / 100) * 25)) + (personalTrainingPrice * 12);
                }
                else if (membershipType == "Individual" && personalTraining == "no")
                {
                    finalPrice = ((membershipTypePrice * 12) - ((membershipTypePrice / 100) * 25));
                }

                if (membershipType == "Family" && personalTraining == "yes")
                {
                    finalPrice = ((membershipTypePrice * 12) - ((membershipTypePrice / 100) * 25)) + (personalTrainingPrice * 12);
                }
                else if (membershipType == "Family" && personalTraining == "no")
                {
                    finalPrice = ((membershipTypePrice * 12) - ((membershipTypePrice / 100) * 25));
                }

                if (membershipType == "Couple" && personalTraining == "yes")
                {
                    finalPrice = ((membershipTypePrice * 12) - ((membershipTypePrice / 100) * 25)) + (personalTrainingPrice * 12);
                }
                else if (membershipType == "Couple" && personalTraining == "no")
                {
                    finalPrice = ((membershipTypePrice * 12) - ((membershipTypePrice / 100) * 25));
                }
            }
            return finalPrice;
        }

        private void LoadValuesToComboBox()
        {
            SqlConnection con = new SqlConnection(conString);
            string qry = "select firstName from Staff";

            SqlCommand cmd = new SqlCommand(qry, con);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                comboBoxTrainer.Items.Clear();

                while (reader.Read())
                {
                    string value = reader.GetString(0);
                    comboBoxTrainer.Items.Add(value);
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int getTrainerId(string name)
        {
            int staffID = -1; // Default staff ID in case of any errors or if the trainer is not found

            string qry = "SELECT staffID FROM Staff WHERE firstName = @Name";

            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(qry, con))
                {
                    try
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@Name", name);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            staffID = Convert.ToInt32(reader["staffID"]);
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

            return staffID;
        }

        private double GetMembershipTypePrice(string type)
        {
            double price = 1; // Default price in case of any errors or if the membership type is not found

            string sql = "select price from MembershipType where TypeName = @Type";

            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@Type", type);
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            price = Convert.ToDouble(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            return price;
        }

       /* private double getMembershipTypePrice(string type)
        {
            string amt;
            double amount = 0;
            SqlConnection con = new SqlConnection(conString);

            string sql = "select price from MembershipType where TypeName = '"+type+"'";

            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                amt = sdr["price"].ToString();

                amount = double.Parse(amt);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return amount;
        } */
        
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //selecting the last id column
            /*SqlConnection con = new SqlConnection(conString);

            string sql = "SELECT * FROM Member ORDER BY memberId DESC LIMIT 1";

            SqlCommand cmd1 = new SqlCommand(sql, con);
             try
            {
                con.Open();
                SqlDataReader sdr = cmd1.ExecuteReader();
                sdr.Read();
                ID = int.Parse(sdr["memberId"].ToString());
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } finally
            {
                con.Close();
            }*/

            

            string Fname = txtFName.Text;
            string Lname = txtLName.Text;
            string Address = textBox2.Text;
            int ContactNo;
            double Weight;
            int Height;
            string Email = textBox7.Text; 
            bool emailCheck = Regex.IsMatch(Email, @"^[a-zA-Z0-9_.+-]+@[a-zAZ0-9-]+\.[a-zA-Z0-9-.]+$");
            int NIC;
            string emergencyName = textBox6.Text;
            string Relationship = textBox9.Text;
            int emergencyContact;
            string Illness = textBox10.Text;
            string Reason = textBox11.Text;
            string Trainer = comboBoxTrainer.Text;
            int Age;
            string registrationDate = DateTime.Now.ToString("MM/dd/yyyy");
            string membershipType;
            string paymentType;
            string personaltraining;
            double packageAmount;
            // int memberID = ID + 1;

            try
            {
                Age = int.Parse(textBox1.Text);
                ContactNo = int.Parse(textBox3.Text);
                Height = int.Parse(textBox5.Text);
                Weight = int.Parse(textBox4.Text);
                NIC = int.Parse(textBox13.Text);
                emergencyContact = int.Parse(textBox8.Text);

                if (Fname != " " && Lname != " " && textBox1.Text != " " && Address != " " && textBox3.Text != " " &&
                    textBox4.Text != " " && textBox5.Text != "" && Email != "" && textBox13.Text != " " && emergencyName != " " &&
                    Relationship != " " && textBox8.Text != " " && Illness != "" && Reason != "" && Trainer != " ")

                {

                    if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
                    {
                        if(radioButton1.Checked)
                        {
                            membershipType = radioButton1.Text;
                        } else if(radioButton2.Checked)
                        {
                            membershipType = "family";
                        } else { 
                            membershipType = radioButton3.Text;
                        }

                        double membershipPriceType = GetMembershipTypePrice(membershipType);
                        packageAmount = GetMembershipTypePrice(membershipType);

                        if (radioButton4.Checked || radioButton5.Checked)
                        {
                            if (radioButton4.Checked)
                            {
                                paymentType = radioButton4.Text;
                            } else
                            {
                                paymentType = radioButton5.Text;
                            }

                            
                            if (radioButton6.Checked || radioButton7.Checked)
                            {
                                if(radioButton6.Checked)
                                {
                                    personaltraining = "yes";

                                    int trainerID = getTrainerId(Trainer);

                                    SqlConnection sendCon = new SqlConnection(conString);
                                    string fullName = Fname + " " + Lname;
                                    string qrySend = "insert into PersonalTraining (trainerId, memeberId, trainingID, trainerName, memberName) values('"+trainerID+"', '"+NIC+"', '"+NIC+"', '"+Trainer+"', '"+fullName+"')";

                                    SqlCommand cmdsend = new SqlCommand(qrySend, sendCon);

                                    try
                                    {
                                        sendCon.Open();
                                        cmdsend.ExecuteNonQuery();

                                    }catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                } else
                                {
                                    personaltraining = "no";
                                }


                                SqlConnection conn = new SqlConnection(conString);

                                string qry = "insert into Member (memberId, firstName, lastName, age, AddressNumber, contactNumber, weight, height, registrationDate, emergencyName, emergenncyContact, emergencyRelation, medicalCondition, reasonForJoin, membershipType, paymentType, personalTraining, personalTrainer, packageAmount) values('"+NIC+"', '"+Fname+"', '"+Lname+"', '"+Age+"', '"+Address+"', '"+ContactNo+"', '"+Weight+"', '"+Height+"', '"+ registrationDate + "', '"+emergencyName+"', '"+emergencyContact+"', '"+Relationship+"', '"+ Illness + "', '"+Reason+"', '"+membershipType+"', '"+paymentType+"', '"+personaltraining+"', '"+Trainer+"', '"+packageAmount+"')"; 

                                SqlCommand cmd = new SqlCommand(qry, conn);

                                try
                                {
                                    conn.Open();
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("SUCCESSFUL");
                                } catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                                
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please fill all the information");
                }
            }
            catch (Exception X)
            {
                MessageBox.Show(X.Message);
            }
            finally
            {
                txtFName.Text = " ";
                txtLName.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = " ";
                textBox5.Text = "";
                textBox7.Text = "";
                textBox13.Text = "";
                textBox6.Text = "";
                textBox9.Text = "";
                textBox8.Text = " ";
                textBox10.Text = "";
                textBox11.Text = "";
                comboBoxTrainer.Text = "";
                textBox1.Text = "";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                radioButton6.Checked = false;
                radioButton7.Checked = false;

            }

        }
    }
}
