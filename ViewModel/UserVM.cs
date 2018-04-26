using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;
using Pairs.Models;
using Pairs.Commands;
using Pairs.Views;

namespace Pairs.ViewModel
{
    public class UserVM : BaseVM
    {

        private User currentUser;
        public User CurrentUser
        {
            get
            {
                return currentUser;
            }
            set
            {
                currentUser = value;
                Avatar = currentUser.Avatar;
                OnPropertyChanged("CurrentUser");
            }
        }
        private String avatar;
        public String Avatar
        {
            get
            {
                return avatar;
            }
            set
            {
                avatar = value;
                OnPropertyChanged("Avatar");
            }
        }

        public ObservableCollection<User> UserList { get; set; }

        public ImageVM ImageVM { get; set; }

        public UserVM()
        {
            UserList = Serializer.Deserialize<ObservableCollection<User>>("users.xml");

            Avatar = "";

            ImageVM = new ImageVM();
        }

        private bool canExecuteCommand;

        public bool CanExecuteComman
        {
            get
            {
                return canExecuteCommand;
            }
            set
            {
                if(canExecuteCommand== value)
                {
                    return;
                }
                canExecuteCommand = value;
            }
        }
    }
}
