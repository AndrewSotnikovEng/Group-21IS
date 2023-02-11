using System.Windows;
using Group_IS_21zp.ViewModels;
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
            MessengerStatic.FindWindowShowed += ShowSeachWin;

        }

        private void SetFocusStudentEditMode(object obj)
        {
            StudentLastNameTextBox.Focus();
        }

        private void SetFocusTeacherEditMode(object obj)
        {
            TeacherLastNameTextBox.Focus();
        }

        private void ConfirmInput(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ((MainWinViewModel)DataContext).OkAction();
            } else if (e.Key == Key.Escape)
            {
                ((MainWinViewModel)DataContext).CancelAction();
            }
        }


        private void ProcessKeys(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                AboutWindow aboutWin = new AboutWindow();
                aboutWin.Show();
            } else if (e.Key == Key.F11)
            {
                HelpWindow helpWin = new HelpWindow();
                helpWin.Show();

            } else if (Keyboard.Modifiers == ModifierKeys.Control && Keyboard.IsKeyDown(Key.F))
            {
                ShowSeachWin(null);
            }
        }

        private void ShowSeachWin(object obj)
        {
            SearchWindow findWin = new SearchWindow();
            findWin.Show();
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
