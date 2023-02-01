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

namespace Group_IS_21zp
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
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
    }
}
