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
using System.Windows.Shapes;
using Pairs.ViewModel;

namespace Pairs.Views
{
    /// <summary>
    /// Interaction logic for Pairs.xaml
    /// </summary>
    public partial class Pairs : Window
    {
        public Pairs()
        {
            InitializeComponent();
            DataContext = new CardViewModel();
        }
    }
}
