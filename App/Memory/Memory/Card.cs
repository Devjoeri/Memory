﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Memory
{
    class Card
    {
        private ImageSource image;
        private int number;
        private bool flipped = false;
        private ImageSource front;

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
    }
}
