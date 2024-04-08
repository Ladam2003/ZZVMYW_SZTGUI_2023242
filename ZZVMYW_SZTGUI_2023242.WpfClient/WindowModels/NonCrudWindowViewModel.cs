using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ZZVMYW_HFT_2023241.Models;
using System.Net.Http;

namespace ZZVMYW_SZTGUI_2023242.WpfClient.WindowModels
{
    public class NonCrudWindowViewModel : ObservableRecipient
    {
        private string _inputAvgAge;
        private string _inputOldestPlayer;
        private string _inputTeamNationalityForCoach;
        private string _inputPlayerCount;
        private string _inputYoungestPlayer;
        private string _result;

        public NonCrudWindowViewModel()
        {
            GetAvgAgeCommand = new RelayCommand(GetAvgAge);
            GetOldestPlayerCommand = new RelayCommand(GetOldestPlayer);
            GetCoachByTeamNationalityCommand = new RelayCommand(GetCoachByTeamNationality);
            GetPlayerCountCommand = new RelayCommand(GetPlayerCount);
            GetYoungestPlayerCommand = new RelayCommand(GetYoungestPlayer);
        }

        public ICommand GetAvgAgeCommand { get; }
        public ICommand GetOldestPlayerCommand { get; }
        public ICommand GetCoachByTeamNationalityCommand { get; }
        public ICommand GetPlayerCountCommand { get; }
        public ICommand GetYoungestPlayerCommand { get; }

        public string InputAvgAge
        {
            get => _inputAvgAge;
            set => SetProperty(ref _inputAvgAge, value);
        }

        public string InputOldestPlayer
        {
            get => _inputOldestPlayer;
            set => SetProperty(ref _inputOldestPlayer, value);
        }

        public string InputTeamNationalityForCoach
        {
            get => _inputTeamNationalityForCoach;
            set => SetProperty(ref _inputTeamNationalityForCoach, value);
        }

        public string InputPlayerCount
        {
            get => _inputPlayerCount;
            set => SetProperty(ref _inputPlayerCount, value);
        }

        public string InputYoungestPlayer
        {
            get => _inputYoungestPlayer;
            set => SetProperty(ref _inputYoungestPlayer, value);
        }

        public string Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }

        private async void GetResultAsync(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("http://localhost:57195" + url);
                    response.EnsureSuccessStatusCode();
                    Result = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching data: " + ex.Message);
            }
        }

        private void GetAvgAge()
        {
            GetResultAsync("/NonCrud/getAvgPlayersAgeByTeamId?teamId=" + InputAvgAge);
        }

        private void GetOldestPlayer()
        {
            GetResultAsync("/NonCrud/getTheOldestPlayerByTeamId?teamId=" + InputOldestPlayer);
        }

        private void GetCoachByTeamNationality()
        {
            GetResultAsync("/NonCrud/GetCoachsByTeamNationality?nationality=" + InputTeamNationalityForCoach);
        }

        private void GetPlayerCount()
        {
            GetResultAsync("/NonCrud/GetPlayersCountByTeamId?teamId=" + InputPlayerCount);
        }

        private void GetYoungestPlayer()
        {
            GetResultAsync("/NonCrud/getTheYoungestPlayerByTeamId?teamId=" + InputYoungestPlayer);
        }
    }
}
