﻿using System;
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
        public FrmCompanies MasterForm { get; set; }
        public FrmCompanyUpdate(ICompanyService companyService)
        {
            this.companyService = companyService;
            InitializeComponent();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            //validasyonlar
            if (txtName.Text == "")
            {
                MessageBox.Show("Firma adı gereklidir.");
                return;
            }
            else if (txtPhone.Text == "")
            {
                MessageBox.Show("Telefon adı gereklidir.");
                return;
            }

            var addCompany = companyService.Get(this.Id);
            addCompany.Name = txtName.Text;
            addCompany.Phone = txtPhone.Text;
            addCompany.Region = txtRegion.Text;
            addCompany.City = txtCity.Text;
            companyService.Update(addCompany);
            MessageBox.Show("Firma başarıyla güncellendi.");
            MasterForm.LoadCompanies();
            this.Hide();
        }

        private int Id;
        public void LoadForm(int id) //formu dolu getirmek için
        {
            var company = companyService.Get(id);
            txtName.Text = company.Name;
            txtPhone.Text = company.Phone;
            txtRegion.Text = company.Region;
            txtCity.Text = company.City;

        }

        private void FrmCompanyUpdate_Load(object sender, EventArgs e)
        {
            
         

        }

        private void FrmCompanyUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            this.Hide();
        }
    }
}