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
    public partial class FrmCompanies : Form
    {
        private readonly ICompanyService companyService;
        private readonly FrmCompanyAdd frmCompanyAdd;
        private readonly FrmCompanyUpdate frmCompanyUpdate;
        public FrmCompanies MasterForm { get; set; }
       
        public FrmCompanies(ICompanyService companyService,FrmCompanyAdd frmCompanyAdd,FrmCompanyUpdate frmCompanyUpdate)
        {
            this.companyService = companyService;
            this.frmCompanyAdd = frmCompanyAdd;
            this.frmCompanyUpdate = frmCompanyUpdate;
            InitializeComponent();
            this.frmCompanyAdd.MdiParent = this.MdiParent;
            this.frmCompanyAdd.MasterForm = this;
            this.frmCompanyUpdate.MdiParent = this.MdiParent;
            this.frmCompanyUpdate.MasterForm = this;
        }

        private void FrmCompanies_Load(object sender, EventArgs e)
        {
            LoadCompanies();
        }

        public void LoadCompanies()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = companyService.GetAll();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
           // MasterForm.ShowFrmCompanyAdd();
            this.frmCompanyAdd.Show();
            this.frmCompanyAdd.LoadForm();
         
       
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
           
            if (dataGridView1.SelectedRows.Count > 0)
            {
              int selectedId =int.Parse(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                this.frmCompanyUpdate.Show();
                this.frmCompanyUpdate.LoadForm(selectedId);

            } else
            {
                MessageBox.Show("Id seçiniz.");
            }


        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int sil = int.Parse(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
               
                companyService.Delete(sil);
                LoadCompanies();

            }
            else
            {
                MessageBox.Show("Satır seçiniz.");
            }
          

        }
    }
}
