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

namespace ZZVMYW_SZTGUI_2023242.WpfClient.WindowModels
{
    public class CoachWindowViewModel:ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<Coach> Coaches { get; set; }

        private Coach selectedCoach;

        public Coach SelectedCoach
        {
            get { return selectedCoach; }
            set
            {
                if (value != null)
                {
                    selectedCoach = new Coach()
                    {
                        CoachName = value.CoachName,
                        CoachId = value.CoachId
                    };
                    OnPropertyChanged();
                    (DeleteCoachCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public ICommand CreateCoachCommand { get; set; }
        public ICommand DeleteCoachCommand { get; set; }
        public ICommand UpdateCoachCommand { get; set; }

        public CoachWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Coaches = new RestCollection<Coach>("http://localhos" +
                    "t:57195/", "Coach", "hub");
                CreateCoachCommand = new RelayCommand(() =>
                {
                    Coaches.Add(new Coach()
                    {
                        CoachName = SelectedCoach.CoachName
                    });
                });

                UpdateCoachCommand = new RelayCommand(() =>
                {

                    Coaches.Update(SelectedCoach);

                });

                DeleteCoachCommand = new RelayCommand(() =>
                {
                    Coaches.Delete(SelectedCoach.CoachId);
                },
                () =>
                {
                    return SelectedCoach != null;
                });
                SelectedCoach = new Coach();
            }
        }
    }
}
