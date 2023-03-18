using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<Entities.User> users = new BindingList<Entities.User>();
        
        public Form1()
        {
            InitializeComponent();

            lblLastName.Text = Resource1.LastName;
            lblFirstName.Text = Resource1.FirstName;
            btnAdd.Text = Resource1.Add;

            listBoxUsers.DataSource = users;
            listBoxUsers.ValueMember = "ID";
            listBoxUsers.DisplayMember = "FullName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new Entities.User()
            {
                LastName = txtLastName.Text,
                FisrtName = txtFirstName.Text
            };
            users.Add(u);
        }
    }
}
