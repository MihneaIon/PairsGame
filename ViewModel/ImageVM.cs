using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pairs.ViewModel
{
    public class ImageVM
    {
        public List<String> userImages { get; set; }
        public int Index { get; set; }


        public ImageVM()
        {
            userImages = new List<string>();
            for(int i=0;i<9;i++)
            {
                String str = @"\Resources\img" + i + ".png";
                userImages.Add(str);
            }
            Index = -1;
        }

        public String Next()
        {
            if(Index==8)
            {
                Index = -1;
            }
            Index++;

            return userImages[Index];
        }

        public String Previous()
        {
            if(Index==0)
            {
                Index = 9;
            }
            Index--;
            return userImages[Index];
        }
    }
}
