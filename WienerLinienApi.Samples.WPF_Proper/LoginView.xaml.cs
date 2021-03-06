﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WienerLinienApi;

namespace WienerLinienApi.Samples.WPF_Proper
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public bool isLogin { get; set; }
        public MainWindow mW { set; get; }
        public LoginView(MainWindow ThisMainWindow)
        {
            mW = ThisMainWindow;
            isLogin = true;
            InitializeComponent();
            Storyboard sb = (this.FindResource("LoginPrep") as Storyboard);
            sb.Begin();
            
        }

        private void LoginPrep_Storyboard_Completed(object sender, EventArgs e)
        {
            Storyboard sb = (this.FindResource("LoginApear") as Storyboard);
            sb.Begin();
        }

        private void SignUpPrep_Storyboard_Completed(object sender, EventArgs e)
        {
            Storyboard sb = (this.FindResource("SignUpAnimation") as Storyboard);
            sb.Begin();
        }
        
        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            if (isLogin) {
                ToggleMenu();
            }
            else
            {
               
                UserManagement usermanagement = new UserManagement();
               if(usermanagement.Signup(Username.Text, Password.Password, Firstname.Text, Lastname.Text))
                {
                    MessageBox.Show("Signup successful");
                }
               else
                {
                    MessageBox.Show("Signup unsuccessful");
                }
            }
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            if (!isLogin)
            {
                ToggleMenu();
            }
            else
            {
                UserManagement usermanagement = new UserManagement();
                var b = usermanagement.Login(Username.Text, Password.Password);
                if (b != null)
                {
                    Background = new SolidColorBrush(Colors.LightGreen);
                    MainWindow.loggedInBenutzer = b;
                    mW.changeToMain();
                }
                else
                {
                    Background = new SolidColorBrush(Colors.Red);
                    await PutTaskDelay();
                    Background = null;
                }

            }
  
        }

        async Task PutTaskDelay()
        {
            await Task.Delay(300);
        }

        private void ToggleMenu() {
            if (isLogin)
            {
                TextBlock tb = (this.FindName("TextBlock") as TextBlock);
                tb.Text = "Sign Up";
                Storyboard sb = (this.FindResource("SignUpPrep") as Storyboard);
                sb.Begin();

            }
            else {
                TextBlock tb = (this.FindName("TextBlock") as TextBlock);
                tb.Text = "Login";
                Storyboard sb = (this.FindResource("LoginPrep") as Storyboard);
                sb.Begin();
            }

            isLogin = !isLogin;
        }

        public void toMainView() {
            mW.changeToMain();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            mW.changeToMain();
        }

        private void Password_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox pwb = (PasswordBox)sender;
            pwb.Password = "";
        }

        private void Textbox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox pwb = (PasswordBox)sender;
            pwb.Password = "";
        }
    }
}
