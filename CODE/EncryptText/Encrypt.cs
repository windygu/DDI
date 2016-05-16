using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DDIV2.UI
{
    public partial class Encrypt : Form
    {
        public Encrypt()
        {
            InitializeComponent();
        }

        private void buttonEx1_Click(object sender, EventArgs e)
        {
            if (textBoxEx1.Text.Trim() != "")
            {
                textBoxEx2.Text = DESEncrypt.Encrypt(textBoxEx1.Text.Trim());
            }
        }

        private void buttonEx2_Click(object sender, EventArgs e)
        {
            if (textBoxEx2.Text.Trim() != "")
            {
               textBoxEx1.Text= DESEncrypt.Decrypt(textBoxEx2.Text.Trim());
            }
        }

        private void buttonEx4_Click(object sender, EventArgs e)
        {
            string sKey = "pangweigao";
            string Text = textBoxEx2.Text.Trim();
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = Text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            textBoxEx1.Text= Encoding.Default.GetString(ms.ToArray());

        }

        private void buttonEx3_Click(object sender, EventArgs e)
        {
            string Text = textBoxEx1.Text.Trim();
            using (MD5 md5 = MD5.Create())
            {
                byte[] buffer = md5.ComputeHash(Encoding.UTF8.GetBytes(Text));
                md5.Clear();

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < buffer.Length; i++)
                {
                    stringBuilder.Append(buffer[i].ToString("x2"));
                }
                textBoxEx2.Text= stringBuilder.ToString();
            }
           
        }
    }
}
