using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Memory
{
    class Card
    {
        private ImageSource image;
        private int number;
        public Card(ImageSource image, int number) {
            this.image = image;
            this.number = number;
        }
        public int getNumber()
        {
            return number;
        }
        public ImageSource getImage()
        {
            return image;
        }
    }
}
