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
    public partial class frmUserInfo : Form
    {
        public frmUserInfo(int PersonID, int UserID)
        {
            InitializeComponent();
            ctrlPersonWithLoggedUserDetails1.person = clsPerson.Find(PersonID);
            ctrlPersonWithLoggedUserDetails1.user = clsUser.FindByUserID(UserID);
        }
    }
}
