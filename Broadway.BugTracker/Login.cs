﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Broadway.BugTracker.Model;
using Broadway.BugTracker.Service;

namespace Broadway.BugTracker
{
    public partial class Login : Form
    {
        public LoginService login = new LoginService();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginModel = new User() {
                UserName = textBox1.Text,
                Password=textBox2.Text
            };

            var loginResult = login.Login(loginModel);

            if (loginResult.Item1)
            {
                MainForm main = new MainForm();
                this.Hide();
                main.Show();
            }
            else
            {
                MessageBox.Show(loginResult.Item2);
            }

        }
    }
}
