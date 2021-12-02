using App.Services.GetContactDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_WinForm.Forms
{
    public partial class frmContactDetails : Form
    {
        private readonly IGetContactDetailsService getContactDetailsService;
        private readonly int conatctId;

        public frmContactDetails(IGetContactDetailsService getContactDetailsService, int conatctId)
        {
            InitializeComponent();
            this.getContactDetailsService = getContactDetailsService;
            this.conatctId = conatctId;
        }

        private void frmContactDetails_Load(object sender, EventArgs e)
        {
            var contact = getContactDetailsService.Execute(conatctId);
            if (!contact.IsSuccess)
            {
                MessageBox.Show(contact.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblId.Text = contact.Data.Id.ToString();
            lblName.Text = contact.Data.Name;
            lblLastName.Text = contact.Data.LastName;
            lblCompany.Text = contact.Data.Company;
            lblPhoneNumber.Text = contact.Data.PhoneNumber;
            lblDescription.Text = contact.Data.Description;
            lblCreatedAt.Text = contact.Data.CreateAt.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
