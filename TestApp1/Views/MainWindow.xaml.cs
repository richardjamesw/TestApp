using System.Windows;
using TestApp1.ViewModels;

namespace TestApp1.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = TestVM.Instance;
        }
    }
}
