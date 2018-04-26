using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pairs.ViewModel
{
    public class FileViewModel 
    {
        public FileViewModel File { get; set; }

        public ICommand NewGame { get; set; }

        public ICommand SaveGAme { get; set; }

        public void NewFile()
        {
          
        }
    }
}
