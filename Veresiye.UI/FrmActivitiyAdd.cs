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
using static Veresiye.Service.ActivityService;

namespace Veresiye.UI
{
    
    public partial class FrmActivitiyAdd : Form
    {
        private int CompanyId;
        public FrmCompanyUpdate MasterForm { get; set; }
        private readonly IActivityService activityService;
        public FrmActivitiyAdd(IActivityService activityService)
        {
            this.activityService = activityService;
            InitializeComponent();
        }

        public void LoadForm(int companyId)
        {
            this.CompanyId = companyId;
            this.txtName.Clear();
            this.txtAmount.Clear();
            this.dtmTransaction.Value=DateTime.Now;
            this.cmbActivityType.SelectedIndex = -1;
        }

        private void CmbActivityType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmActivitiyAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("İşlem adı gereklidir.");
                return;
            } else if (txtAmount.Text == "")
            {
                MessageBox.Show("Miktar gereklidir.");
                return;
            } else if (cmbActivityType.SelectedIndex < 0)
            {
                MessageBox.Show("İşlem tipi gereklidir.");
                return;
            }
            var activity = new Activity();
            activity.CompanyId = this.CompanyId;
            activity.Name = txtName.Text;
            activity.Amount = Convert.ToDecimal(txtAmount.Text);
            activity.ActivityType = (ActivityType)cmbActivityType.SelectedIndex;
            activity.TransactionDate = dtmTransaction.Value;
            activityService.Insert(activity);
            MasterForm.LoadActivities();
            this.Hide();
        }
    }
}
