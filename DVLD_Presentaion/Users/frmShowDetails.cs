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
    public partial class frmShowDetails : Form
    {
        public frmShowDetails(Person person, User user)
        {
            InitializeComponent();
            ctrlPersonWithLoggedUserDetails1.person = person;
            ctrlPersonWithLoggedUserDetails1.user = user;
        }
    }
}
