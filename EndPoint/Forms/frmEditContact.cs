using App.Services.EditConatct;
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
    public partial class frmEditContact : Form
    {
        private readonly IGetContactDetailsService getContactDetailsService;
        private readonly IEditConatctService editConatctServie;
        private readonly int contactId;

        public frmEditContact(IGetContactDetailsService getContactDetailsService,
            IEditConatctService editConatctServie, int contactId)
        {
            InitializeComponent();
            this.getContactDetailsService = getContactDetailsService;
            this.editConatctServie = editConatctServie;
            this.contactId = contactId;
        }

        private void frmEditContact_Load(object sender, EventArgs e)
        {
            var contact = getContactDetailsService.Execute(contactId);

            if (!contact.IsSuccess)
            {
                MessageBox.Show(contact.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtName.Text = contact.Data.Name;
                txtLastName.Text = contact.Data.LastName;
                txtCompany.Text = contact.Data.Company;
                txtDescription.Text = contact.Data.Description;
                txtPhoneNumber.Text = contact.Data.PhoneNumber;
            }
        }

        private void btnEditContact_Click(object sender, EventArgs e)
        {
            var result = editConatctServie.Execute(new EditContactDto
            {
                Id = contactId,
                Name = txtName.Text,
                LastName = txtLastName.Text,
                Company = txtCompany.Text,
                Description = txtDescription.Text,
                PhoneNumber = txtPhoneNumber.Text
            });

            if (result.IsSuccess)
            {
                MessageBox.Show(result.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(result.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
