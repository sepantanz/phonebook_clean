using App.Services.AddNewContact;
using App.Services.DeleteContact;
using App.Services.EditConatct;
using App.Services.GetContactDetails;
using App.Services.GetListContact;
using EndPoint;
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
    public partial class frmMain : Form
    {
        private readonly IGetListContactService getListContactService;
        private readonly IDeleteContactService deleteContactService;
        private readonly IGetContactDetailsService getContactDetailsService;
        private readonly IEditConatctService editConatctService;

        public frmMain(IGetListContactService getListContactService,
            IDeleteContactService deleteContactService,
            IGetContactDetailsService getContactDetailsService,
            IEditConatctService editConatctService)
        {
            InitializeComponent();
            this.getListContactService = getListContactService;
            this.deleteContactService = deleteContactService;
            this.getContactDetailsService = getContactDetailsService;
            this.editConatctService = editConatctService;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            var listConatct = getListContactService.Execute();
            GridViewSetting(listConatct);

            this.Cursor = Cursors.Default;

        }

        private void GridViewSetting(List<ContactListDto> contactList)
        {
            dgvContacts.DataSource = contactList;
            dgvContacts.Columns[0].HeaderText = "شناسه";
            dgvContacts.Columns[1].HeaderText = "نام";
            dgvContacts.Columns[2].HeaderText = "شماره تلفن";

            dgvContacts.Columns[1].Width = 200;
            dgvContacts.Columns[2].Width = 200;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            var contactList = getListContactService.Execute(txtSearchKey.Text);
            GridViewSetting(contactList);

            this.Cursor = Cursors.Default;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = int.Parse(dgvContacts.CurrentRow.Cells[0].Value.ToString());
            var result = deleteContactService.Execute(id);

            if (result.IsSuccess)
            {
                MessageBox.Show(result.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmMain_Load(null, null);
            }
            else
            {
                MessageBox.Show(result.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            ShowDetails();
        }

        private void ShowDetails()
        {
            var id = int.Parse(dgvContacts.CurrentRow.Cells[0].Value.ToString());
            frmContactDetails frmContactDetails = new frmContactDetails(getContactDetailsService, id);
            frmContactDetails.ShowDialog();
        }

        private void dgvContacts_DoubleClick(object sender, EventArgs e)
        {
            ShowDetails();
        }

        private void btnAddNewContact_Click(object sender, EventArgs e)
        {
            var serviceAdd = (IAddNewContactService)Program.ServiceProvider.GetService(typeof(IAddNewContactService));

            frmAddContact frmAddContact = new frmAddContact(serviceAdd);
            frmAddContact.ShowDialog();
            frmMain_Load(null, null);
        }

        private void btnEditContact_Click(object sender, EventArgs e)
        {
            var id = int.Parse(dgvContacts.CurrentRow.Cells[0].Value.ToString());
            frmEditContact frmEditContact = new frmEditContact(getContactDetailsService, editConatctService, id);
            frmEditContact.ShowDialog();
            frmMain_Load(null, null);

        }
    }
}
