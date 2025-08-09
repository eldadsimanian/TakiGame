using System;
//using System.Collections.Generic;
using Unit4.CollectionsLib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Taki
{
    //השתמשתי בעצם בחוליה פיקטבית כי במידה ואני רוצה להוציא את הקלף הראשון שלי
    //אז שלא אסתבך עם ההצבעות ובעצם בבדיקות מסויימות אשתמש בהצצה קדימה
    class Yad
    {
        //שרשרת חוליות מטיפוס קלף
        private Node<Card> chain;

        public Yad(CardBox cardBox)//הפעולה תקבל את הקופה
        {
            //יוצר שרשרת חדשה
            chain = new Node<Card>(new Card());//יוצרים חוליה פיקטיבית
            Node<Card> pos = chain;
            //לולאה של 8
            for (int i = 0; i < 8; i++)
            {
                //יוצרים קלף חדש
                Card c = new Card();
                // בכל פעם להוציא מהקופה
                c = cardBox.GetCardBox().Pop();
                //להכניס לשרשרת החוליות
                pos.SetNext(new Node<Card>(c));
                pos = pos.GetNext();
            }
        }

        //פעולה שמחזירה את היד
        public Node<Card> GetNode()
        {
            return this.chain;
        }
        //פעולה שתצייר את הקלפים של המחשב 
        public void PaintCardsComputer(Graphics g)
        {
            int num = 0;// המספר הסידורי של הקלפים של השחקן מתחיל מ0
            int x = 500;
            int y = 10;
            Node<Card> pos = this.chain;
            while (pos.GetNext() != null)
            {
                Card c = pos.GetNext().GetInfo();
                c.SetKopa(true);
                c.SetX(x);
                c.SetY(y);
                c.SetSerialNum(num);
                //c.BackPaintCard(g);
                c.PaintCard(g);
                x = x + 30;
                pos = pos.GetNext();
                num++;
            }
        }
        //פעולה שתצייר את הקלפים של השחקן
        public void PaintCardsplayer(Graphics g)
        {
            int num = 0;// המספר הסידורי של הקלפים של השחקן מתחיל מ0
            int x = 500;
            int y = 500;
            Node<Card> pos = this.chain;
            while (pos.GetNext() != null)
            {
                Card c = pos.GetNext().GetInfo();
                c.SetKopa(true);
                c.SetX(x);
                c.SetY(y);
                c.SetSerialNum(num);
                c.PaintCard(g);
                x = x + 30;
                pos = pos.GetNext();
                num++;
            }
        }

        //פעולה המקבלת קלף ומוסיפה אותו ליד
        public void AddCard(Card c)
        {
            Node<Card> pos = this.chain;
            Node<Card> temp = new Node<Card>(c);
            while (pos.GetNext() != null)
            {
                pos = pos.GetNext();
            }
            //מוסיפים את הקלף לסוף
            pos.SetNext(temp);
        }

        // פעולה המקבלת מספר ומחזירה את הקלף הראשון שביד המתאים למספר
        public Card GetOneCard(int num)
        {
            Node<Card> pos = this.chain;
            Card c;
            while (pos.GetNext() != null)
            {
                if (pos.GetNext().GetInfo().GetSerialNum() == num)
                {
                    c = pos.GetNext().GetInfo();
                    return c;
                }
                pos = pos.GetNext();
            }
            return (pos.GetInfo());
        }

        //פעול המונה של מספר הקלפים שביד
        public int CounterCard()
        {
            Node<Card> pos = this.chain;
            pos = pos.GetNext();
            int count = 0;
            while (pos != null)
            {
                count++;
                pos = pos.GetNext();
            }
            return count;
        }

        //פעולה המקבלת מספר ומוחקת את הקלף המתאים למספר מהיד
        public void DelCard(int num)
        {
            Node<Card> pos = this.chain;
            while (pos.GetNext() != null)
            {
                if (pos.GetNext().GetInfo().GetSerialNum() == num)
                {
                    pos.SetNext(pos.GetNext().GetNext());
                    return;
                }
                pos = pos.GetNext();
            }
        }

        public bool GetCardByNum(int num)
        {
            //פעולה שמקבלת מספר ומחזירה אמת אם יש ביד קלף של המספר הזה
            Node<Card> pos = this.chain;
            while (pos != null)
            {
                if (pos.GetInfo().GetNum() == num)
                    return true;
                pos = pos.GetNext();
            }
            return false;
        }


        // פעולה שמחזירה את מספר האינדקס של הצבע שנמצא הכי הרבה ביד
        //זאת אומרת שאם צהוב נמצא הכי הרבה פעמים הוא יחזיר 1 כי קבעתי שזה 
        // האינדקס שלו
        public int GetMaxColor()
        {
            //צהוב = 1
            //אדום = 2
            //3 = ירוק
            //כחול - 4
            //יוצר מערך של 5 תאים מטיפוס מספר
            int[] arr = new int[5];
            //תא מספר 0 מאופס מכיוון וצבעים ממסופרים החל מ1
            arr[0] = 0;
            //רץ על כל היד ומקדם מונה מתאים
            Node<Card> pos = this.chain;
            pos = pos.GetNext();//מדלגים על החוליה הפיקטיבית
            while (pos != null)
            {
                if (pos.GetInfo().GetNum() != 14 && pos.GetInfo().GetNum() != 15)
                {
                    //כול עוד הקלף שאנחנו עומדים שונה מטאקי שינוי צבע אנחנו רוצים להוסיף אותו למערך
                    arr[pos.GetInfo().GetSidra()]++;
                }   
                pos = pos.GetNext();
            }
            // מוצא מקסימום
            //מחזיר את מספר האינדקס של המקסימום
            int max = arr[1];
            int index = 1;
            for (int i = 2; i < 5; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    index = i;
                }
            }
            return index;
        }


        //פעולה המקבלת מספר ומחזירה שרשרת חוליות מטיפוס קלף
        //המכיל את כול הקלפים שמספר הצבע שלהם (סדרה) שווה למספר שהתקבל 
        public Node<Card> GetAllCardSame(int num)
        {
            Node<Card> temp2 = null;
            Node<Card> node = new Node<Card>(null);
            Node<Card> temp = node;
            Node<Card> pos = this.chain;
            while (pos != null)
            {
                Card c = pos.GetInfo();
                int serialnum = c.GetSerialNum();
                if ((c.GetSidra() == num /*&& pos.GetInfo().GetNum() != 10*/)
                    && pos.GetInfo().GetNum() != 14 && pos.GetInfo().GetNum() != 15)
                {
                    if (c.GetNum() != 2)
                    {
                        Node<Card> n = new Node<Card>(c);
                        temp.SetNext(n);
                        temp = temp.GetNext();
                    }
                    else
                    {
                        temp2 = new Node<Card>(c);
                    }
                }
                pos = pos.GetNext();
            }
            if (temp2 != null)
            {
                temp.SetNext(temp2);//בעצם את הקלף פלוס 2 הוספנו לסוף
            }
            return node;
        }


        public bool CheckWin()
        {
            if (this.chain.GetNext() == null)
                return true;
            return false;
        }

        public bool GetCardByNumAndColor(int num, int sidra)
        {
            //מקבלת מספר של קלף ומספר הצבע ומחזירה אמת במידה ומצאה את הקלף מאותו הצבע 
            Node<Card> pos = this.chain;
            while (pos != null)
            {
                //אני בודק  האם קיים ביד שלי קלף ששווה לצבע ששלחתי לו ולמספר ששלחתי 
                if (pos.GetInfo().GetSidra() == sidra && pos.GetInfo().GetNum() == num
                    && pos.GetInfo().GetNum() != 14 && pos.GetInfo().GetNum() != 15)
                    return true;
                pos = pos.GetNext();
            }
            return false;
        }

        public bool GetCardByNumAndDominantNum(int num, int num1)
        {
            //פעולה המקבלת מספר של קלף ביד ובנוסף את המספר הדומניטטי
            // זאת אומרת המספר של הקלף שמופיע בלמעלה של חפיסת הקלפים
            // שנמצאת באמצע ובודקת האם קיים קלף ששווה לאותו מספר
            // אם כן מחזירה נכון
            Node<Card> pos = this.chain;
            while (pos != null)
            {
                if (pos.GetInfo().GetNum() == num1 && pos.GetInfo().GetNum() == num)
                    return true;
                pos = pos.GetNext();
            }
            return false;
        }

        public bool GetCardByColor(int sidra)
        {
            //פעולה שמקבלת מספר ומחזירה אמת אם יש ביד קלף של בצבע של המספר ששלחתי 
            Node<Card> pos = this.chain;
            while (pos != null)
            {
                if (pos.GetInfo().GetSidra() == sidra)
                    return true;
                pos = pos.GetNext();
            }
            return false;
        }

        public Card BringCardByColor(int sidra)
        {
            //פעולה שמקבלת מספר ומחזירה את הקלף הראשון ביד של המספר הזה
            Node<Card> pos = this.chain;
            while (pos != null)
            {
                if (pos.GetInfo().GetSidra() == sidra)
                {
                    Card c = pos.GetInfo();
                    DelCard(pos.GetInfo().GetNum());
                    return c;
                }
                pos = pos.GetNext();
            }
            return null;// במידה והוא לא מצא קלף מתאים הוא לא מחזיר כלום
        }

    }

}
