using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taki
{
    class Deck
    {
        private Card[,] d;
        public Deck()
        {
            this.d = new Card[4, 15];
            int x = 5;
            int y = 150;
            Image pic;
            for (int i = 0; i < d.GetLength(0); i++)
            {
                for (int j = 0; j < d.GetLength(1); j++)
                {
                    Card cd = new Card();
                    cd.SetX(x);
                    cd.SetY(y);
                    cd.SetNum(j+1);
                    cd.SetSidra(i + 1);
                    pic = Image.FromFile(i + 1 + "/" + (j+1) + ".png");
                    cd.SetPic(pic);
                    d[i, j] = cd;
                    x = x + 90;
                }
                //סיימנו שורה ראשונה עוברים לשורה הבא 
                x = 5;
                y = y + 132;//מגדילים את הy
            }
        }
        public Card[,] GetDeck()
        {
            return d;
        }
        public void PaintDeck(Graphics g)
        {
            for (int i = 0; i < d.GetLength(0); i++)
            {
                for (int j = 0; j < d.GetLength(1); j++)
                {
                    d[i, j].PaintCard(g);
                }
            }

        } 
        
    }  
    
}
