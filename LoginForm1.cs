using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Handbook_numismatist
{
    public partial class LoginForm1 : Form
    {
        internal Handbook list;
        public LoginForm1()
        {
            InitializeComponent();
            list = new Handbook();
        }
        // Метод для регистрации пользователя
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(loginField.Text) || string.IsNullOrWhiteSpace(passField.Text))
            {               
                MessageBox.Show("Заполните все сторки!");
                loginField.BackColor = Color.White;
                passField.BackColor = Color.White;
            }         
            else
            {
                string nickname;
                int number;
                int password;
                bool isInt = int.TryParse(passField.Text, out number);
                bool isIntName = int.TryParse(loginField.Text, out number);
                // Данные с полей
                if (isIntName == true || isInt == false)
                {
                    if (isIntName == true)
                    {

                        loginField.BackColor = Color.MediumSeaGreen;
                        MessageBox.Show("Имя состоит только из цифр, попробуйте еще раз!");
                        loginField.Text = string.Empty;
                        loginField.BackColor = Color.White;
                    }
                    else
                    {
                        nickname = loginField.Text;
                    }
                    if (isInt == false)
                    {

                        passField.BackColor = Color.MediumSeaGreen;
                        MessageBox.Show("Пароль состоит не только из цифр, попробуйте еще раз!");
                        passField.Text = string.Empty;
                        passField.BackColor = Color.White;
                    }
                    else
                    {
                        password = Convert.ToInt32(passField.Text);
                    }
                }
                else
                {
                    nickname = loginField.Text;
                    password = Convert.ToInt32(passField.Text);
                    // Проверяем, нет ли уже такого пользователя
                    if (list.Users.FirstOrDefault(u => u.Name == nickname) != null)
                    {
                        MessageBox.Show($"Добро пожаловать,{nickname}!");
                        MainForm frm2 = new MainForm(ref list);
                        frm2.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Такаго пользлвателя нет, попробуйте ещё раз!");
                        loginField.Text = string.Empty;
                        passField.Text = string.Empty;
                    }
                }

            }
        }
        // Метод для перехода на регистрацию
        private void RegisterLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }
        // Метод для перемещения формы с помощью курсора
        Point lastPoint;
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void LoginForm1_Load(object sender, EventArgs e)
        {
            list.Load();
        }

    }
}

