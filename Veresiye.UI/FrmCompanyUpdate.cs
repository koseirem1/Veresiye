using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veresiye.Model;
using Veresiye.Service;

namespace Veresiye.UI
{
    public partial class FrmCompanyUpdate : Form
    {
        private readonly ICompanyService companyService;
        public FrmCompanyUpdate(ICompanyService companyService)
        {
            this.companyService = companyService;
            InitializeComponent();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            
            var addCompany = new Company();
            txtName.Text=addCompany.Name;
            txtPhone.Text=addCompany.Phone;
            txtRegion.Text=addCompany.Region;
            txtCity.Text=addCompany.City;
            companyService.Update(addCompany);
        }
    }
}
