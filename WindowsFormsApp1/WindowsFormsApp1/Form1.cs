using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.NetworkInformation;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            shag(22);
        }
        private bool _isLogIn = true;
        private bool _isSignUp = false;
        class User
        {
            private string _username;
            private string _password;
            public User(string username, string password)
            {
                _username = username;
                _password = password;
            }
        }
        public void shag(int sh)
        {
            if (sh < 0)
                sh = (sh * 2 + characters.Length) / 2;
            int z = 0, c = sh, max;
            max = characters.Length / (sh + 1);
            max = max * (sh + 1);
            for (int i = 0; i < max; i++)
            {

                characters1 = characters1 + characters[sh - z];
                Console.Write(characters[sh - z] + ",");
                z++;
                if (c + 1 == z)
                {
                    sh = sh + c + 1;
                    z = 0;
                }
            }
            for (int i = characters.Length - 1; i > max - 1; i--)
            {
                characters1 = characters1 + characters[i];
            }
        }
        string characters = "#IJKQRSTUcdefABCDEFGHghijklmnopqVWXYZabrstuvwxyz 12345LMNOP67890";
        string characters1 = "";
        private string Chiper(string text) 
        {
            string ciphertext = "";

            for (int i = 0; i < text.Length; i++)
                for (int j = 0; j < characters.Length + 1; j++)
                {
                    if (j == characters.Length)
                    {
                        ciphertext = ciphertext + text[i];
                        break;
                    }
                    if (text[i] == characters[j])
                    {
                        ciphertext = ciphertext + characters1[j];
                        break;
                    }
                }
            return ciphertext;
        }
        private void WriteFile(string username, string password)
        {
            string path = @"D:\visual_projects\WindowsFormsApp1\WindowsFormsApp1\Resources\1.txt";   // путь к файлу

            string text = username+"\n"+password; // строка для записи

            // запись в файл
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLineAsync(Chiper(text));
            }
        }
        private string DeChiper(string text)
        {
            string plaintext = "";

            for (int i = 0; i < text.Length; i++)
                for (int j = 0; j < characters1.Length + 1; j++)
                {
                    if (j == characters1.Length)
                    {
                        plaintext = plaintext + text[i];
                        break;
                    }
                    if (text[i] == characters1[j])
                    {
                        plaintext = plaintext + characters[j];
                        break;
                    }
                }


            return plaintext;
        }
        private bool IsFound(string username,string password)
        {
            string path = @"D:\visual_projects\WindowsFormsApp1\WindowsFormsApp1\Resources\1.txt";   // путь к файлу
            bool isFound=false;
            using (StreamReader reader = new StreamReader(path))
            {
                string line, line2;
                while ((line =reader.ReadLine()) != null && (line2 = reader.ReadLine()) != null)
                {
                    if(username== DeChiper(line) && password== DeChiper(line2))
                    {
                        isFound = true;
                    }
                }
            }
            return isFound;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_isLogIn)
            {
                if (IsFound(textBox1.Text,textBox2.Text))
                {
                    button1.Enabled = false;
                    button1.Visible = false;
                    textBox1.Enabled = false;
                    textBox1.Visible = false;
                    textBox2.Enabled = false;
                    textBox2.Visible = false;
                    label1.Enabled = false;
                    label1.Visible = false;
                    label2.Enabled = false;
                    label2.Visible = false;
                    pictureBox1.Enabled = true;
                    pictureBox1.Visible = true;
                    button3.Visible = false;
                    button3.Enabled=false;
                    label3.Enabled = false;
                    label3.Visible = false;
                    label4.Enabled = false;
                    label4.Visible = false;
                    label5.Enabled = false;
                    label5.Visible = false;
                }
                else
                {
                    label1.Text = "Неправильно введен логин или пароль";
                }
            }
            else 
            {
                _isLogIn = true;
                _isSignUp = false;
                textBox3.Enabled = false;
                textBox3.Visible = false;
                label5.Visible = false;
                label5.Enabled = false;
                button3.Location = new Point(548, 315);
                button1.Location = new Point(467, 315);
                label1.Location = new Point(467, 300);
                label1.Enabled = false;
                label1.Visible = false;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }
        private bool IsStrong(string password)
        {
            bool isStrong = true;
            string up =   "IJKQRSTUABCDEFGHVWXYZLMNOP";
            string down = "cdefghijklmnopqabrstuvwxyz";
            string numbers = "1234567890";
            int t = 0;
            
            for (int i = 0;i<password.Length;i++)
            {
                for (int j = 0;j<up.Length;j++)
                {
                    if (password[i] == up[j])
                    {
                        t++;
                        break;
                    }
                }
            }
            for (int i = 0; i < password.Length; i++)
            {
                for (int j = 0; j < down.Length; j++)
                {
                    if (password[i] == down[j])
                    {
                        t++;
                        break;
                    }
                }
            }
            for (int i = 0; i < password.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (password[i] == numbers[j])
                    {
                        t++;
                        break;
                    }
                }
            }
            if(t<password.Length)
            {
                isStrong = false;
            }    
            if (password.Length < 8)
            {
                isStrong = false;
            }
            return isStrong;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (_isSignUp)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    if (IsStrong(textBox2.Text))
                    {
                        WriteFile(textBox1.Text, textBox2.Text);
                        _isLogIn = true;
                        _isSignUp = false;
                        textBox3.Enabled = false;
                        textBox3.Visible = false;
                        label5.Visible = false;
                        label5.Enabled = false;
                        button3.Location = new Point(548, 315);
                        button1.Location = new Point(467, 315);
                        label1.Location = new Point(467, 300);
                        label1.Enabled = false;
                        label1.Visible = false;
                        textBox1.Text = "";
                        textBox2.Text = "";
                        button4.Enabled = true;
                        button4.Visible = true;
                    }
                    else
                    {
                        label1.Text = "Пароль должен содеражать не менее 8 символов, заглавную букву, прописную букву,цифру";
                    }
                }
                else
                {
                    label1.Text = "Пароли не совпадают";
                }
            }
            else
            {
                _isLogIn = false;
                _isSignUp = true;
                textBox3.Enabled = true;
                textBox3.Visible = true;
                label5.Visible = true;
                label5.Enabled = true;
                button3.Location = new Point(506, 354);
                button1.Location = new Point(564, 504);
                label1.Location = new Point(467, 339);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            button4.Visible = false;
        }
    }
}
