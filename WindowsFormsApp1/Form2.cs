using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Form1.ActiveForm.Hide();
        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));


            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
        static string GetSha512Hash(SHA512 sha512Hash, string input)
        {
            byte[] data = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string path = @"c:\pliki/x.txt";
            StreamReader sr = new StreamReader(path);
            string s;
            do
            {
                s = sr.ReadLine();
                sb.AppendLine(s);
            } while (s != null);
            sr.Close();

            richTextBox1.Text = sb.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MD5 md5Hash = MD5.Create();
            string wiadomosc = GetMd5Hash(md5Hash, richTextBox1.Text);
            richTextBox2.Text = wiadomosc;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SHA512 sha512Hash = SHA512.Create();
            string wiadomosc1 = GetSha512Hash(sha512Hash, richTextBox1.Text);
            richTextBox2.Text = wiadomosc1;
        }
    }
}
