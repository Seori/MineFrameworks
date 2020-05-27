using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MineFramework;

namespace MineTestForm
{
    public partial class PasswordExe : Form
    {
        public PasswordExe()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSecureText.Text))
            {
                MessageBox.Show("변환할 String을 입력하여주세요.");
                tbSecureText.Focus();
                return;
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSecureText.Text))
            {
                MessageBox.Show("변환할 String을 입력하여주세요.");
                tbSecureText.Focus();
                return;
            }

            string secureText = tbSecureText.Text.Replace(" ", "");
            tbOriginalText.Text = EncryptCls.decryptAES128(secureText);
        }

        private void PasswordExe_Load(object sender, EventArgs e)
        {
            // Focus
            tbSecureText.Focus();
        }
    }
}
