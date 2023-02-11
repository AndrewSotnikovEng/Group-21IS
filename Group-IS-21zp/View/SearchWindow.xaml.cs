using Group_IS_21zp.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace Group_IS_21zp.View
{
    public partial class SearchWindow : Window
    {
        public SearchWindow()
        {
            InitializeComponent();
            DataContext = new SearchWinViewModel();
            SearchTextBox.Focus();
        }

        private void ConfirmInput(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MessengerStatic.NotifyFindElementRequesting(SearchTextBox.Text);
            }
        }

        private void Quit(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
