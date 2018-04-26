using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Pairs.Models;
using Pairs.Commands;

namespace Pairs.ViewModel
{
    public class MenuViewModel
    {
        public MenuButtons buttons;

        public MenuViewModel()
        {
            buttons = new MenuButtons(this);
        }

        private bool canExecuteCommand = true;

        public bool CanExecuteCommand
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

        private ICommand newGame;
        public ICommand NewGame
        {
            get
            {
                if (newGame == null)
                {
                    newGame = new RelayCommand(buttons.NewGame, param => CanExecuteCommand);
                }
                return newGame;
            }
        }
        private ICommand exit;
        public ICommand Exit
        {
            get
            {
                if (exit == null)
                {
                    exit = new RelayCommand(buttons.Exit, param => CanExecuteCommand);
                }
                return exit;
            }
        }

        private ICommand about;
        public ICommand About
        {
            get
            {
                if (about == null)
                {
                    about = new RelayCommand(buttons.About, param => CanExecuteCommand);
                }
                return about;
            }
        }
    }
}
