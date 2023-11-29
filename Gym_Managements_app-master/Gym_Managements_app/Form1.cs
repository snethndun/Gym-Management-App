using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gym_Managements_app.User_Controls;

namespace Gym_Managements_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadFirstScreen();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void loadFirstScreen()
        {
            Home objHm = new Home();
            addUserControl(objHm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewMember newMember = new NewMember();
            addUserControl(newMember);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            addUserControl(home);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Payments payment = new Payments();
            addUserControl(payment);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Equipment equipment = new Equipment();
            addUserControl(equipment);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MemberDetails memberDetails = new MemberDetails();
            addUserControl(memberDetails);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PersonalTraining training = new PersonalTraining();
            addUserControl(training);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Announcements announcements = new Announcements();
            addUserControl(announcements);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Finance finance = new Finance();
            addUserControl(finance);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Staff objstf = new Staff();
            addUserControl(objstf);
        }
    }
}
