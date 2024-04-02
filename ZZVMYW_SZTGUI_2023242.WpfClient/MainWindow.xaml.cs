using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZZVMYW_SZTGUI_2023242.WpfClient.WindowModels;

namespace ZZVMYW_SZTGUI_2023242.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PlayerWindow playerWindow;
        private NonCrudWindow nonCrudWindow;
        private CoachWindow coachWindow;
        private TeamWindow teamWindow;
        private RoleWindow roleWindow;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Player_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Coach_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Team_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Role_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NonCrud_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
