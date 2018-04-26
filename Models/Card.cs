using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Serialization;
using Pairs.ViewModel;

namespace Pairs.Models
{
    [Serializable]
    public class Card : BaseVM
    {
        private String cover;
        private String image;
        private bool isShown;

        
        public string Cover
        {
            get
            {
                return cover;
            }

            set
            {
                cover = value;
                OnPropertyChanged("Cover");
            }
        }

        
        public string Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }
        
        public bool IsShown
        {
            get
            {
                return isShown;
            }

            set
            {
                isShown = value;
                OnPropertyChanged("IsShown");
            }
        }

    }
}
