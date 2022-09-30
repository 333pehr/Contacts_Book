using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class Form1 : Form
    {
        IContact contact;
        public Form1()
        {
            InitializeComponent();
            contact = new Contacts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Table();
        }

        private void Table()
        {
            contactData.Columns[0].Visible = false;
            contactData.AutoGenerateColumns = false;
            contactData.DataSource = contact.selectAll();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddorUpdateForm add = new AddorUpdateForm();
            add.ShowDialog();
            if(add.DialogResult == DialogResult.OK)
            {
                Table();
            }
        }

        private void Refreshbtn_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            if(contactData.CurrentRow != null)
            {
                AddorUpdateForm edit = new AddorUpdateForm();
                edit.contactId = int.Parse(contactData.CurrentRow.Cells[0].Value.ToString());
                edit.ShowDialog();
                if(edit.DialogResult == DialogResult.OK)
                {
                    Table();
                }
            }
            else
            {
                MessageBox.Show("Please Select a Contact!","Attention",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if(contactData.CurrentRow != null)
            {
                string name = contactData.CurrentRow.Cells[1].Value.ToString();
                string lastName = contactData.CurrentRow.Cells[2].Value.ToString();
                string fullName = name + " " + lastName;
                if(MessageBox.Show($"Do You Really Want to Delete {fullName}", "Delete Contact", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int contactID = int.Parse(contactData.CurrentRow.Cells[0].Value.ToString());
                    contact.Delete(contactID);
                    Table();
                }
            }
            else
            {
                MessageBox.Show("Please Select a Contact!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchTXT(object sender, EventArgs e)
        {
            contactData.DataSource = contact.Search(txtSearch.Text);

        }
    }
}
