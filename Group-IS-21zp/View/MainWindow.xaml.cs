using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Windows;
using Group_IS_21zp;
using Group_IS_21zp.ViewModels;
using Group_IS_21zp.Repository;
using System.Windows.Input;
using Group_IS_21zp.ViewModel;
using Group_IS_21zp.View;
using System.IO;

namespace Group_IS_21zp
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            CheckIfStorageExists();
            DataContext = new MainWinViewModel();
            MessengerStatic.ActivatedStudentEditMode += SetFocusStudentEditMode;
            MessengerStatic.ActivatedTeacherEditMode += SetFocusTeacherEditMode;

        }

        private void SetFocusStudentEditMode(object obj)
        {
            StudentLastNameTextBox.Focus();
        }

        private void SetFocusTeacherEditMode(object obj)
        {
            TeacherLastNameTextBox.Focus();
        }

        private void ConfirmAction(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ((MainWinViewModel)DataContext).OkAction();
            } else if (e.Key == Key.Escape)
            {
                ((MainWinViewModel)DataContext).CancelAction();
            }
        }


        private void ShowAbout(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                AboutWindow aboutWin = new AboutWindow();
                aboutWin.Show();
            }
        }

        public void CheckIfStorageExists()
        {
            const string STORAGE_PATH = "data.xlsx";
            if (!File.Exists(STORAGE_PATH))
            {
                MessageBoxResult result = MessageBox.Show("Database missing! Please check file data.xlsx", "Group-IS-21zp", MessageBoxButton.OK, MessageBoxImage.Error);
                if (result == MessageBoxResult.OK)
                {
                    this.Close();
                }
            }
        }
    }
}
