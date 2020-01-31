using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Homebrew;

namespace HomebrewTemplate
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Default settings
        public MainWindow()
        {
            InitializeComponent();
            Controls.DebugBox = DebugBox;
            Controls.WorkProgress = WorkProgress;
            Controls.WorkProgressLabel = WorkProgressLabel;
        }

        private void ProgramWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ExitProgram_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void TelegramButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://t.me/iKolesDev");
        }

        private void Developer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TelegramButton_MouseDown(sender, e);
        }
        private void EnableStartBtn()
        {
            Application.Current.Dispatcher.Invoke(new Action(() => {
                StartBtn.IsEnabled = true;
            }));
        }
        #endregion

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            StartBtn.IsEnabled = false;
            new Thread(()=>
            {
                Thread.Sleep(2000);
                EnableStartBtn();
            }).Start();
        }
    }
}
