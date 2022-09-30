using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class AddorUpdateForm : Form
    {
        IContact contact;
        public int contactId = 0;
        public AddorUpdateForm()
        {
            InitializeComponent();
            contact = new Contacts();
        }

        private void AddorUpdateForm_Load(object sender, EventArgs e)
        {
            if(contactId == 0)
            {
                this.Text = "Add New Contact";
                groupBox.Text = "Add New Contact";
            }
            else
            {
                this.Text = "Edit Contact";
                DataTable selected = contact.SelectRow(contactId);
                txtName.Text = selected.Rows[0][1].ToString();
                txtLastName.Text = selected.Rows[0][2].ToString();
                txtNumber.Text = selected.Rows[0][3].ToString();
                txtEmail.Text=selected.Rows[0][4].ToString();
                txtAddress.Text = selected.Rows[0][6].ToString();
                numericAge.Value = int.Parse(selected.Rows[0][5].ToString());
                groupBox.Text = "Edit Contact";
            }
        }
        public bool validator()
        {
            if(txtName.Text == "")
            {
                MessageBox.Show("Please Enter the Name!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }
            if(txtLastName.Text == "")
            {
                MessageBox.Show("Please Enter the Last Name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtNumber.Text == "")
            {
                MessageBox.Show("Please Enter the Number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (numericAge.Value == 0)
            {
                MessageBox.Show("Please Enter the Age!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if(txtEmail.Text == "")
            {
                MessageBox.Show("Please Enter the Email!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            bool isSuccess;
            if (validator()) {
                if (contactId == 0)
                {
                    isSuccess = contact.Insert(txtName.Text, txtLastName.Text, txtNumber.Text, (int)numericAge.Value, txtAddress.Text, txtEmail.Text);
                    if (isSuccess)
                    {
                        MessageBox.Show("New Contact Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Task Failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    isSuccess = contact.Update(contactId, txtName.Text, txtLastName.Text, txtNumber.Text, (int)numericAge.Value, txtAddress.Text, txtEmail.Text);
                    if (isSuccess)
                    {
                        MessageBox.Show("Contact Changed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Task Failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
    }
}
