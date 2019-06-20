using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veresiye.Service;

namespace Veresiye.UI
{
    public partial class FrmMain : Form
    {
        private readonly IUserService userService;
        private readonly FrmRegister frmRegister;
        private readonly FrmCompanies frmCompanies;
        private readonly FrmLogin frmLogin;
        private readonly FrmCompanyAdd frmCompanyAdd;
        public FrmMain(IUserService userService,FrmRegister frmRegister,FrmCompanies frmCompanies,
            FrmLogin frmLogin, FrmCompanyAdd frmCompanyAdd)
        {
            this.userService = userService;
            this.frmRegister = frmRegister;
            this.frmCompanies = frmCompanies;
            this.frmLogin = frmLogin;
            this.frmCompanyAdd = frmCompanyAdd;
            InitializeComponent();
            this.frmRegister.MdiParent=this;
            this.frmRegister.FormClosed += FrmRegister_FormClosed;
            this.frmLogin.MdiParent = this; //formun içinde gelmesini sağlıyor
            this.frmLogin.MasterForm = this;
            this.frmCompanies.MdiParent = this;
          
           

        }

      

        private void FrmRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin.Show();
        }

       
        public void ShowFrmCompanies()
        {
            frmCompanies.Show();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            var userCount = userService.GetAll().Count();
            if (userCount == 0)
            {
                frmRegister.Show();
            }
            else
            { 
               frmLogin.Show();

            }
        }
    }
}
