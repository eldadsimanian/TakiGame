using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Taki
{
    class CardBox
    {
        private Stack<Card> st1;              
        Random rnd = new Random();

        public CardBox()
        {
            st1 = new Stack<Card>();
            int counter = 0;
            Deck d = new Deck();
            int i;
            int j;
            while (counter < 60)
            {
                i = rnd.Next(0, 4);
                j = rnd.Next(0, 15);
                while (d.GetDeck()[i, j].GetKopa() == true)//אם הקלף שהגרלנו כבר נמצא בקופת הקלפים אז מגרילים קלף חדש
                {
                    i = rnd.Next(0, 4);
                    j = rnd.Next(0, 15);
                }
                //להכניס אותו לקופה
                this.st1.Push(d.GetDeck()[i, j]);
                //להגדיל את המונה
                counter++;
                //לסמן את הקלף שהוא כבר נכנס לקופה
                d.GetDeck()[i, j].SetKopa(true);
            }
        }
       public Stack<Card> GetCardBox()
        {
            return this.st1;
        }
    }
}
