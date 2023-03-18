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

            lblFullName.Text = Resource1.FullName;
            btnAdd.Text = Resource1.Add;
            btnFajlbaIras.Text = Resource1.FajlbaIras;
            btnDelete.Text = Resource1.Delete;

            listBoxUsers.DataSource = users;
            listBoxUsers.ValueMember = "ID";
            listBoxUsers.DisplayMember = "FullName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new Entities.User()
            {
                FullName = txtFullName.Text
            };
            users.Add(u);
        }

        private void btnFajlbaIras_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
