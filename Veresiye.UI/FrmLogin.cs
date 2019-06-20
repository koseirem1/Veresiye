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
    public partial class FrmLogin : Form
    {   public FrmMain MasterForm { get; set; }
        private readonly IUserService userService;
        
         
        public FrmLogin(IUserService userService)
        {
            this.userService = userService;
            
            InitializeComponent();
          
          
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var kullanici = userService.Login(txtUserName.Text, txtPassword.Text);

            if (kullanici != null)
            {
                MessageBox.Show("Kullanıcı girişi başarılı");
                MasterForm.ShowFrmCompanies();
                this.Close();
            } else
            { MessageBox.Show("Kullanıcı adı veya şifre hatalı"); }
        }
    }
}
