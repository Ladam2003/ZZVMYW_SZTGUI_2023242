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
        private CoachWindow coachWindow;
        private TeamWindow teamWindow;
        private RoleWindow roleWindow;
        private NonCrudWindow nonCrudWindow;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Player_Click(object sender, RoutedEventArgs e)
        {
            if (playerWindow == null || !playerWindow.IsVisible)
            {
                playerWindow = new PlayerWindow();
                playerWindow.Closed += PlayerWindow_Closed;
                playerWindow.Show();
            }
        }

        private void Coach_Click(object sender, RoutedEventArgs e)
        {
            if (coachWindow == null || !coachWindow.IsVisible)
            {
                coachWindow = new CoachWindow();
                coachWindow.Closed += CoachWindow_Closed;
                coachWindow.Show();
            }
        }

        private void Team_Click(object sender, RoutedEventArgs e)
        {
            if (teamWindow == null || !teamWindow.IsVisible)
            {
                teamWindow = new TeamWindow();
                teamWindow.Closed += TeamWindow_Closed;
                teamWindow.Show();
            }
        }

        private void Role_Click(object sender, RoutedEventArgs e)
        {
            if (roleWindow == null || !roleWindow.IsVisible)
            {
                roleWindow = new RoleWindow();
                roleWindow.Closed += RoleWindow_Closed;
                roleWindow.Show();
            }
        }

        private void PlayerWindow_Closed(object sender, EventArgs e)
        {
            if (playerWindow != null)
            {
                playerWindow.Closed -= PlayerWindow_Closed;
                playerWindow = null;
            }
        }

        private void CoachWindow_Closed(object sender, EventArgs e)
        {
            if (coachWindow != null)
            {
                coachWindow.Closed -= CoachWindow_Closed;
                coachWindow = null;
            }
        }

        private void TeamWindow_Closed(object sender, EventArgs e)
        {
            if (teamWindow != null)
            {
                teamWindow.Closed -= TeamWindow_Closed;
                teamWindow = null;
            }
        }

        private void RoleWindow_Closed(object sender, EventArgs e)
        {
            if (roleWindow != null)
            {
                roleWindow.Closed -= RoleWindow_Closed;
                roleWindow = null;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Biztosan be szeretnéd zárni az alkalmazást?", "Megerősítés", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void NonCruds_Click(object sender, RoutedEventArgs e)
        {
            if (nonCrudWindow == null || !nonCrudWindow.IsVisible)
            {
                nonCrudWindow = new NonCrudWindow();
                nonCrudWindow.Closed += NonCrudWindow_Closed;
                nonCrudWindow.Show();
            }
        }
        private void NonCrudWindow_Closed(object sender, EventArgs e)
        {
            if (nonCrudWindow != null)
            {
                nonCrudWindow.Closed -= NonCrudWindow_Closed;
                nonCrudWindow = null;
            }
        }
    }
}
