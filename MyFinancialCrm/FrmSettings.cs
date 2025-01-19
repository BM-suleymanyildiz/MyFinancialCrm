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

namespace MyFinancialCrm
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db =new FinancialCrmDbEntities();
        private void button2_Click(object sender, EventArgs e)
        {
           FrmBanks frm=new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmBilling frm=new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashboard frm=new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInformationUpdate_Click(object sender, EventArgs e)
        {
            string username = txtUsername1.Text;
            var updatedValue = db.Users.SingleOrDefault(x => x.Username == username); 

            if (updatedValue != null) 
            {
                if (txtPassword1.Text == txtPassword2.Text)
                {
                    updatedValue.Password = txtPassword2.Text;
                    db.SaveChanges();

                    MessageBox.Show("Güncelleme İşlemi Başarılı");
                }
                else
                {
                    MessageBox.Show("Şifreler eşleşmiyor","Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı bulunamadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string username = txtUsername2.Text;
            
            string Password = txtPassword3.Text;

            
            var userDelete = db.Users.SingleOrDefault(x => x.Username == username);

            if (userDelete != null) 
            {
                
                if (userDelete.Password == Password)
                {
                    
                    db.Users.Remove(userDelete);
                    db.SaveChanges(); 

               
                    MessageBox.Show("Hesap başarıyla silindi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Girilen şifre hatalı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                
                MessageBox.Show("Bu kullanıcı bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
