using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Pairs.ViewModel;


namespace Pairs.Models
{
    public class Buttons
    {
        private UserVM UserVM;

        public Buttons(UserVM uservm)
        {
            this.UserVM = uservm;
        }
    }
}
