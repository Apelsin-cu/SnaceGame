using SnaceGame.ViewModels;
using System.Windows;

namespace SnaceGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MaindWndVM();
        }
    }
}