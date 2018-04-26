using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pairs.Views;
using System.Windows;
using Pairs.ViewModel;

namespace Pairs.Models
{
    public class MenuButtons
    {
        private MenuViewModel MenuVM;
        public MenuButtons(MenuViewModel menuvm)
        {
            this.MenuVM = menuvm;
        }

        public void NewGame(object param)
        {
            Pairs.Views.Pairs menu = new Pairs.Views.Pairs();
                if(!menu.IsActive)
                menu.Show();
        }

        public void Exit(object param)
        {
            Application.Current.Shutdown();
        }

        public void About(object param)
        {
            MessageBox.Show("Ion Alexandru-Mihnea , Grupa 10LF262 Informatica");
        }
    }
}
