using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginApp.Controllers;
using LoginApp.Domain.Models;
using LoginApp.Domain.Repository;
using LoginApp.Services;

namespace LoginApp
{
    public partial class Form1 : Form
    {
        private readonly AccountController _accountController;
        public Form1()
        {
            InitializeComponent();
            _accountController = new AccountController(new LoginService(new UserRepository( new ironmountainEntities())));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var decision = _accountController.Login(usernameText.Text, passwordText.Text);
            MessageBox.Show(decision.Equals("error")
                ? "Please provide UserName and Password"
                : decision.Equals("ok") ? "Login successful" : "Login failed");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
