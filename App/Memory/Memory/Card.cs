using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Memory
{
    public class Card
    {
        public ImageSource image;
        public int number;
        public bool flipped = false;
        public ImageSource front;
        public bool selected = false;

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
        public ImageSource flipCard()
        {
            if(flipped != false)
            {
                front = new BitmapImage(new Uri("Images/front.png", UriKind.Relative));
                flipped = false;
            }
            else
            {
                front = image;
                flipped = true;
            }
            return front;
        }
        public void deselect()
        {
            selected = false;
        }
        public void select()
        {
            selected = true;
        }
        public bool isSelected()
        {
            return selected;
        }
    }
}
