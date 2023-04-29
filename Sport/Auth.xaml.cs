using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sport
{
    public partial class Auth : Window
    {
        SportDbContext sportDb = new SportDbContext();

        public Auth()
        {
            InitializeComponent();
        }

        private string GenerateCapcha()
        {
            var allowedChars = "abcdefghijkmnopqrstuvwxyz0123456789";
            var length = 4;
            
            var chars = new char[length];
            var rd = new Random();

            for (var i = 0; i < length; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

        private void AddCapcha()
        {
            string capchaValue = GenerateCapcha();

            Label errorLabel = new Label();
            errorLabel.Content = "Неправильный логин либо пароль!";
            stackPanel.Children.Add(errorLabel);

            Label labelСapcha = new Label();
            labelСapcha.Content = "Введите капчу: " + capchaValue;
            stackPanel.Children.Add(labelСapcha);

            TextBox textBox = new TextBox();
            stackPanel.Children.Add(textBox);

            Button button = new Button();
            button.Content = "OK";
            stackPanel.Children.Add(button);
        }

        private void AuthSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool CheckShown = false;
            var users = sportDb.Users.ToList();
            
            foreach (User u in users)
            {
                if (u.UserLogin == Login.Text)
                {
                    if (u.UserPassword == Password.Text)
                    {
                        if (u.RoleId == 1) 
                        {
                            MainWindow mainWindow = new MainWindow(u.UserName);
                            mainWindow.Show();
                        }
                        if (u.RoleId == 2)
                        {
                            AdminWindow adminWindow = new AdminWindow();
                            adminWindow.Show();
                        }
                        if (u.RoleId == 3)
                        {
                            ManagerWindow managerWindow = new ManagerWindow();
                            managerWindow.Show();
                        }
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Неправильный пароль");
                    }
                }
                else
                {
                    if (!CheckShown)
                    {
                        CheckShown = true;
                        AddCapcha();
                    }
                }
            }
        }
    }
}
