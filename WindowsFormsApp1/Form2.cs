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

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;

                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            richTextBox1.Text = fileContent;
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    myStream.Write(Encoding.Default.GetBytes(richTextBox2.Text), 0, richTextBox2.Text.Length);
                    myStream.Close();
                }
            }
        }
    }
}
