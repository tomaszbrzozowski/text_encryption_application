using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 forms = new Form2();
            Form1 forms1 = new Form1();
            string[,] tablica = new string[5, 2];
            tablica[0,0] = "Jan";
            tablica[0,1] = "Kowalski";
            tablica[1, 0] = "admin";
            tablica[1, 1] = "admin";
            string path = @"c:\pliki/x.txt";
            StreamWriter sw = new StreamWriter(path);

            if (textBox1.Text==tablica[0,0] && textBox2.Text==tablica[0,1] || textBox1.Text == tablica[1, 0] && textBox2.Text == tablica[1, 1])
            {
                MD5 md5Hash = MD5.Create();
                MD5 md5Hash1 = MD5.Create();
                string login = GetMd5Hash(md5Hash, textBox1.Text);
                string haslo = GetMd5Hash(md5Hash, textBox2.Text);
                sw.WriteLine(login);
                sw.WriteLine(haslo);
                sw.Close();
                forms.Show();
            }
            else
            {
                string message = "Wpisałeś zły login lub hasło. Jeżeli chcesz wyjść z aplikacji wciśnij tak a jeżeli ponownie zalogować wciśnij nie";
                string caption = "Zły login lub hasło";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

    }
}
