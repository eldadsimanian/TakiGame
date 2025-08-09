using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taki
{
    class Card
    {
        private int x;
        private int y;
        private int num ;

        // מ 1-9 מסמל כול מספר כפי שהוא על הקלף. 
        //הקלף טאקי פתוח- 10, הקלף עצור - 11, הקלף פלוס -12, הקלף שינוי כיוון -13,  הקלף שינוי צבע- 14 הקלף טאקי צבעוני (SUPERTAKI) – 15.
        private int sidra;
        //1-צהוב
        //אדום-2
        //ירוק-3
        //4-כחול
        private Image pic;
        private bool kopa;//אומר האם הקלף נמצא בקופה או לא
        private int Serialnum;//קובע את המספר הסידורי של הקלף ביד



        //פעולה בונה ריקה
        public Card()
        {
            this.x = 0;
            this.y = 0;
            this.num = 0;
            this.sidra = 0;
            this.pic = Image.FromFile("back.jpg");
            this.kopa = false;//בהתחלה הקלף לא נמצא בקופה
            this.Serialnum = 0;
        }
        public bool GetKopa()
        {
            return (this.kopa);
        }
        public void SetKopa(bool kopa)
        {
            this.kopa = kopa;
        }

        public int GetX()
        {
            return (this.x);
        }
        public int GetY()
        {
            return (this.y);
        }

        public void SetX(int x)
        {
            this.x = x;
        }

        public void SetY(int y)
        {
            this.y = y;
        }

        public void SetNum(int num)
        {
            this.num = num;

        }

        public int GetNum()
        {
            return this.num;
        }

        public int GetSidra()
        {
            return this.sidra;
        }

        public void SetSidra(int sidra)
        {
            this.sidra = sidra;
        }


        public void SetPic(Image pic)
        {
            this.pic = pic;
        }
        
        public int GetSerialNum()
        {
            return (this.Serialnum);
        }
        public void SetSerialNum(int num)
        {
            this.Serialnum = num;
        }

        public void PaintCard(Graphics g)
        {
            Point p = new Point(this.x, this.y);
            g.DrawImage(this.pic, p);
        }

        public void BackPaintCard(Graphics g)
        {
            Image pic = Image.FromFile("BackCard.png");
            Point p = new Point(this.x, this.y);
            g.DrawImage(pic, p);    
        }

        

       

    }
}
