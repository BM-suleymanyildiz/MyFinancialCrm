using MyFinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MyFinancialCrm
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db =new FinancialCrmDbEntities();
        private void btnLoginToForm_Click(object sender, EventArgs e)
        {
            var username= txtUsername.Text;
            var password = txtPassword.Text;
            var loginStatus = db.Users.Any(x => x.Username == username && x.Password == password);
            if (loginStatus)
            {
                
                FrmBanks frm = new FrmBanks();
                frm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error); 
            }
        }

        private void lblExit_MouseHover(object sender, EventArgs e)
        {
            lblExit.Cursor = Cursors.Hand;
            lblExit.BackColor = Color.Red;
        }

        private void lblExit_MouseLeave(object sender, EventArgs e)
        {
            lblExit.BackColor = Color.Transparent;
        }

        private void lblExit_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }







        
    }
}
