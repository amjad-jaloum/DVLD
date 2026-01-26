using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace _19___Project___DVLD.Users
{
    public partial class ctrlPersonWithLoggedUserDetails : UserControl
    {
        public Person person = null;
        public User loggedUser = null;

        public ctrlPersonWithLoggedUserDetails()
        {
            InitializeComponent();
        }

        private void ctrlPersonWithLoggedUserDetails_Load(object sender, EventArgs e)
        {
            ctrlShowPersonDetails1.person = person;
            ctrlShowPersonDetails1.ctrlShowPersonDetails_Load(sender,e);
            if (loggedUser != null)
            {
                lblUserID.Text = loggedUser.UserID.ToString();
                lblUsername.Text = loggedUser.UserName;
                lblIsActive.Text = loggedUser.IsActive ? "true" : "false";
            }
        }
    }
}
