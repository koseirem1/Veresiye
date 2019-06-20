﻿using System;
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
    public partial class FrmCompanies : Form
    {
        private readonly ICompanyService companyService;
       
        public FrmCompanies(ICompanyService companyService)
        {
            this.companyService = companyService;
            InitializeComponent();
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
           
          

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            //companyService.Update();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            //companyService.Delete();
        }
    }
}