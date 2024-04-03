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
    public class RoleWindowViewModel: ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<Role> Roles { get; set; }

        private Role selectedRole;

        public Role SelectedRole
        {
            get { return selectedRole; }
            set
            {
                if (value != null)
                {
                    selectedRole = new Role()
                    {
                        RoleName = value.RoleName,
                        RoleId = value.RoleId
                    };
                    OnPropertyChanged();
                    (DeleteRoleCommand as RelayCommand).NotifyCanExecuteChanged();
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


        public ICommand CreateRoleCommand { get; set; }
        public ICommand DeleteRoleCommand { get; set; }
        public ICommand UpdateRoleCommand { get; set; }

        public RoleWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Roles = new RestCollection<Role>("http://localhos" +
                    "t:57195/", "Role", "hub");
                CreateRoleCommand = new RelayCommand(() =>
                {
                    Roles.Add(new Role()
                    {
                        RoleName = SelectedRole.RoleName
                    });
                });

                UpdateRoleCommand = new RelayCommand(() =>
                {

                    Roles.Update(SelectedRole);

                });

                DeleteRoleCommand = new RelayCommand(() =>
                {
                    Roles.Delete(SelectedRole.RoleId);
                },
                () =>
                {
                    return SelectedRole != null;
                });
                SelectedRole = new Role();
            }
        }
    }
}
