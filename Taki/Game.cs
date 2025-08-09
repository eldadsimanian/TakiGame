using System;
//using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unit4.CollectionsLib;
using System.Threading;//השהייה



namespace Taki
{
    public partial class Game : Form
    {
        Graphics g;//משתנה גרפי

        CardBox kopa = new CardBox();//קופת המשחק

        Yad cardscomputer;// (היד של המחשב(שרשרת חוליות מסוג קלף

        Yad cardsplayer;// (היד של המשתמש(שרשרת חוליות מסוג קלף

        Card temp = new Card();//משתנה קלף, בו נשמור את הקלף שהשחקן בחר כול פעם

        Stack<Card> st = new Stack<Card>();//מחסנית שתשמש אותנו כחפיסה שנמצאת באמצע

        bool tor = false;//משתנה זה מסמל של מי התור, המשתמש הוא הראשון שמתחיל
                         //false=משתמש
                         //true=מחשב

        int numdom = -1;//המספר הדומיננטי של השחקן זאת אומרת כאשר התור אצלו
                        //יכול להיות או טאקי צבע או טאקי פתוח 

        int colordom = -1;//הצבע הדומיננטי במשחק,נקבע כאשר המשתמש בוחר צבע מטאקי שינוי צבע

        bool check2 = false;//מסמל האם המחשב שם לשחקן קלף של פלוס שתיים
                            //false=המחשב לא שם לשחקן קלף של פלוס שתיים
                            //true=המחשב שם לשחקן קלף לכן חובה עליו לקחת שני קלפים
        int time1 = 00;

        int countkopa = 0;//עד שלא אגיע ל2 לא אוכל לעבור הלאה זאת אומרת
                          //התור של השחקן ישאר עד אשר ייקח שני קלפים

        public Game()
        {
            InitializeComponent();
        }


        private void Game_Load(object sender, EventArgs e)
        {
            kopa = new CardBox();
            cardsplayer = new Yad(kopa);
            cardscomputer = new Yad(kopa);
            Card c = new Card();
            c = kopa.GetCardBox().Pop();
            c.SetX(625);
            c.SetY(255);
            st.Push(c);
            Thread.Sleep(200);
            while (st.Top().GetNum() == 14 || st.Top().GetNum() == 15)
            {
                c = kopa.GetCardBox().Pop();
                c.SetX(625);
                c.SetY(255);
                st.Push(c);
            }
            timer1.Start();

        }


        public void PaintKopa()
        {
            g = CreateGraphics();
            int x = 100;
            int y = 250;
            for (int i = 0; i <= 10; i++)
            {
                Card c = new Card();
                c.SetX(x);
                c.SetY(y);
                c.BackPaintCard(g);
                x = x + 5;
            }
        }


        private void Game_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            PaintKopa();
            cardsplayer.PaintCardsplayer(g);
            cardscomputer.PaintCardsComputer(g);
            st.Top().PaintCard(g);
        }

        private void Game_MouseClick(object sender, MouseEventArgs e)
        {
            //עשיתי את הבדיקה הזאת מכיוון שבמידה והמשתמש שם קלף של שינוי צבע
            //אז שלא יבחר שום קלף כול עוד לא בוחר צבע 
            if (st.Top().GetNum() != 15 && st.Top().GetNum() != 14)
            {
                g = CreateGraphics();
                int x = e.X;
                int y = e.Y;
                if (x >= 100 && x <= 235 && y >= 250 && y <= 380)//הלחיצה התקבלה בתחומי הקופה
                {

                    Card c = kopa.GetCardBox().Pop();
                    cardsplayer.AddCard(c);
                    cardsplayer.PaintCardsplayer(g);
                    if (check2 == true)
                    {
                        countkopa++;
                        if (countkopa == 2)
                        {
                            countkopa = 0;
                            check2 = false;
                        }
                    }
                    if (check2 == false)
                    {
                        MessageBox.Show("תור המחשב");
                        tor = true;
                        button2.Visible = false;
                        Thread.Sleep(1500);
                        Comp();
                    }
                }
                else
                {
                    //אם לחצנו בתחומי היד שלנו 
                    //לקרוא לפעולה שסופרת כמה קלפים יש לי ביד
                    //לזהות על איזה קלף לחצנו 
                    if (check2 == true)
                    {
                        MessageBox.Show("עליך לקחת שני קלפים מהקופה");
                    }
                    else
                    {
                        Invalidate();
                        int numcards = cardsplayer.CounterCard();//מחזירה את מספר הקלפים
                                                                 //גבולות היד של השחקן בהתאם למספר הקלפים שלו
                        if (e.X >= 500 && e.X <= 500 + (numcards * 30) + 90 && e.Y >= 500 && e.Y <= 630)
                        {
                            int num = (e.X - 500) / 30;//מספר הקלף שהמשתמש לחץ עליו
                            if (num >= numcards)
                                num = numcards - 1;//במידה ומתקבל שהמספר גדול ממספר הקלפים מחסרים אחד
                            //מחסרים באחד מכיוון שהמספר הסידורי מתחיל מ0
                            temp = cardsplayer.GetOneCard(num);//מקבלים את הקלף שהמשתמש לחץ עליו
                            if (Check(temp))
                            {
                                tor = true;
                                temp.SetY(255);
                                temp.SetX(625);
                                st.Push(temp);
                                st.Top().PaintCard(g);
                                cardsplayer.DelCard(num);

                                if (st.Top().GetSidra() != colordom)
                                {
                                    //הצבע של הקלף העליון שונה מהצבע של הקלף הדומיננטי לכן להחליף את התור
                                    tor = true;
                                    colordom = -1;
                                    numdom = -1;
                                    button2.Visible = false;
                                }
                                if ((st.Top().GetNum() == 14 && numdom == 15) || (st.Top().GetNum() == 14 && numdom == 10))
                                {
                                    button2.Visible = false;
                                    colordom = -1;
                                }

                                if (temp.GetNum() == 15)
                                {
                                    numdom = 15;
                                    string message = "בחר צבע מתאים";
                                    string title = "שינוי צבע";
                                    DialogResult result = MessageBox.Show(message, title);
                                    pictureBox1.Visible = true;
                                    pictureBox2.Visible = true;
                                    pictureBox3.Visible = true;
                                    pictureBox4.Visible = true;
                                    tor = false;
                                    Invalidate();
                                }
                                else
                                {
                                    if (temp.GetNum() == 14)
                                    {
                                        numdom = 14;
                                        string message = "בחר צבע מתאים";
                                        string title = "שינוי צבע";
                                        DialogResult result = MessageBox.Show(message, title);
                                        pictureBox1.Visible = true;
                                        pictureBox2.Visible = true;
                                        pictureBox3.Visible = true;
                                        pictureBox4.Visible = true;
                                        tor = false;
                                    }
                                    else
                                    {
                                        if (temp.GetNum() == 2)
                                        {
                                            for (int i = 0; i < 2; i++)
                                            {
                                                Card ca = kopa.GetCardBox().Pop();
                                                cardscomputer.AddCard(ca);
                                            }
                                            MessageBox.Show("התור נשאר אצלך");
                                            tor = false;
                                            Invalidate();
                                            //המחשב לוקח שני קלפים ועכשיו תורו של המשתמש 
                                        }
                                        else
                                        {
                                            if (temp.GetNum() == 12)
                                            {
                                                if (numdom != 15 && numdom != 10)
                                                {
                                                    numdom = 12;
                                                }
                                                MessageBox.Show("עליך לשים קלף נוסף,במידה ואין לך קלף מתאים קח מהקופה");
                                                tor = false;//התור נשאר אצל השחקן 

                                            }
                                            else
                                            {
                                                if (temp.GetNum() == 11)
                                                {
                                                    if (numdom != 15 && numdom != 10)
                                                    {
                                                        numdom = 11;
                                                    }

                                                    MessageBox.Show("עצרת את התור של המחשב, תורך לשים קלף נוסף,במידה ואין לך קלף מתאים קח מהקופה");
                                                    tor = false;//התור נשאר אצל השחקן
                                                }
                                                else
                                                {
                                                    if (temp.GetNum() == 13)
                                                    {
                                                        if (numdom != 15 && numdom != 10)
                                                        {
                                                            numdom = 13;
                                                        }
                                                        MessageBox.Show("שמת קלף שנה כיוון, תורך לשים קלף נוסף ,במידה ואין לך קלף מתאים קח מהקופה");
                                                        tor = false;//התור נשאר אצל השחקן
                                                    }
                                                    else
                                                    {
                                                        if (temp.GetNum() == 10)
                                                        {
                                                            tor = false;
                                                            numdom = 10;
                                                            colordom = temp.GetSidra();
                                                            Invalidate();

                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                            else
                            {
                                string text1 = "הקלף אינו מתאים , בחר קלף אחר";
                                MessageBox.Show(text1);
                                tor = false;
                            }

                            Invalidate();
                            //קלפים של שינוי צבע
                            if (numdom == 15 || numdom == 10)
                            {
                                tor = false;
                                button2.Visible = true;
                                //אם הייתה לחיצה על הקופה השחקן מקבל קלף
                                //והוא לא יכול לשים יותר קלפים ונגמר תורו
                            }
                            else
                            {
                                if ((numdom == 11 || numdom == 12 || numdom == 13 || numdom == 14))
                                {
                                    //(כאשר המשתמש שם את אחד הקלפים (שנה כיוון,עצור,פלוס,טאקי שינוי צבע
                                    //התור נשאר אצלו עדיין
                                    tor = false;
                                    numdom = -1;
                                }
                                else
                                {
                                    if (tor == false)
                                    {
                                        tor = false;// עשיתי את זה כי אם במקרה ולא מצאנו קלף מתאים
                                                    // התור נשאר אצל השחקן ואם לא מצאנו את המספר הדומיננטי 
                                                    // שהתור לא יעבור אלה עדיין ישאר אצל השחקן
                                                    //במקרה של קלף פלוס 2
                                    }
                                    else
                                    {
                                        tor = true;
                                        numdom = -1;
                                    }
                                }
                            }
                            //התור של השחקן הסתיים
                        }
                        if (tor == true)
                        {
                            MessageBox.Show("התור של המחשב");
                            Thread.Sleep(1000);
                            button2.Visible = false;//כאשר מגיעים לתור של המחשב אז לסגור את הכפתור של טאקי סגור
                            Comp();
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("עליך לבחור צבע מתאים");
            }

            if (cardsplayer.CheckWin() == true)
            {
                timer1.Stop();
                PutName a = new PutName(this.time1);
                a.Show();
                Thread.Sleep(1000);
                this.Close();
            }

        }

        private bool Check(Card temp)
        {
            //שני התנאים הראשונים מיותרים כי הריטורן בסוף מסכם את הכול
            //אבל השארתי זאת בכול מקרה על מנת שיעזור לי להסביר יותר טוב מה צריך לקרות
            //במידה ויש לנו טאקי פתוח או טאקי שינוי צבע 
            if (numdom == 10 && temp.GetSidra() == colordom || numdom == 10 && temp.GetNum() == st.Top().GetNum())
                return true;
            if (numdom == 15 && temp.GetSidra() == colordom || numdom == 15 && temp.GetNum() == st.Top().GetNum())
                return true;
            return (temp.GetSidra() == st.Top().GetSidra()) ||
                    (temp.GetNum() == st.Top().GetNum()) ||
                    (temp.GetNum() == 14) || (temp.GetNum() == 15);
        }

        public void Comp()
        {
            //בטאקי יש שתי בדיקות עיקריות על מנת לשים את הקלף באמצע
            //אופציה ראשונה שהצבע של הקלף הרצוי תואם את הצבע של הקלף שנמצא באמצע
            //אופציה שנייה שמספר של הקלף באמצע תואם את הקלף הרצוי
            //בבדיקה של הפעולה הזאת אני בדקתי בעצם קודם כול האם קיים את הקלפים המיוחדים
            //ואז טיפלתי במקרים שבהם אין קלפים מיוחדים אבל יש מספרים רגילים
            //והתבצעה בדיקה אם הם מתאימים או לא
            //זאת אומרת בחלק השני של הפעולה בדקתי את המספר שבאמצע,ואז חיפשתי ביד שלי אם קיים לי מספר זהה ביד
            if (cardsplayer.CheckWin() == true)
            {
                MessageBox.Show("השחקן ניצח");
                timer1.Stop();
                Thread.Sleep(1000);
                this.Close();
            }
            else
            {
                while (tor == true)
                {
                    if (cardscomputer.GetCardByNum(15) == true || st.Top().GetNum() == 15)
                    {
                        Do15();
                        Invalidate();
                        //אם הקלף האחרון הוא  עצור או שנה כיוון המחשב ממשיך לשחק 
                        if (st.Top().GetNum() == 11 || st.Top().GetNum() == 12 || st.Top().GetNum() == 13)
                        {
                            tor = true;
                            MessageBox.Show("התור נשאר אצל המחשב ");//עכשיו התור של המחשב
                        }
                        else
                        {
                            if (st.Top().GetNum() == 2)
                            {
                                tor = false;//מעבירים את התור לשחקן על מנת שהוא ייקח שני קלפים
                                check2 = true;
                                MessageBox.Show("התור שלך ");
                            }

                            else
                            {
                                MessageBox.Show("התור שלך ");//עכשיו התור של השחקן
                                tor = false;
                            }
                        }

                    }
                    //לא מצאנו את העדיפות הראשונה שלנו או שהקלף האחרון ששמנו משאיר את התור אצלנו
                    if (tor == true)
                    {
                        if (cardscomputer.GetCardByNumAndColor(10, st.Top().GetSidra()) == true || cardscomputer.GetCardByNumAndDominantNum(10, st.Top().GetNum()) == true)
                        {
                            if (st.Top().GetNum() == 10)
                            {
                                play10Option1();
                            }
                            else
                            {
                                play10Option2();
                            }
                            Refresh();   
                            if (st.Top().GetNum() == 11 || st.Top().GetNum() == 12 || st.Top().GetNum() == 13)
                            {
                                tor = true;
                                MessageBox.Show("התור נשאר אצל המחשב ");//עכשיו התור של המחשב
                                Thread.Sleep(500);
                            }
                            else
                            {
                                if (st.Top().GetNum() == 2)
                                {
                                    tor = false;//מעבירים את התור לשחקן על מנת שהוא ייקח שני קלפים
                                    check2 = true;
                                    MessageBox.Show("התור שלך ");
                                }
                                else
                                {
                                    MessageBox.Show("התור שלך ");//עכשיו התור של השחקן
                                    tor = false;
                                }
                            }
                        }
                        else
                        {
                            if (cardscomputer.GetCardByNumAndColor(2, st.Top().GetSidra()) == true || cardscomputer.GetCardByNumAndDominantNum(2, st.Top().GetNum()) == true)
                            {
                                //בפעולה של DO2
                                //שלחתי את פרמטר זה משתי סיבות:
                                //סיבה ראשונה שאין סיכוי שהקלף העליון לאחר התור של השחקן יהיה פלוס 2
                                //ודבר שני שאם יש למחשב שני קלפים של פלוס שתיים אז שהוא יגיע לקלף
                                //שנמצא באותו צבע של הקלף העליון שבאמצע
                                if (st.Top().GetNum() != 2)
                                {
                                    //אם יש לי באמצע שתיים אז זה לא משנה מה הצבע
                                    //של הקלף פלוס שתיים שיש לי ביד אני יכול לשים אותו
                                    //לכן עשיתי פעולה נוספת ככה שזה יהיה יותר מובן לי
                                    Do2(st.Top().GetSidra());
                                }
                                else
                                {
                                    Play2();
                                }
                                //הסיבה לחלוקה לשתי פעולות שבמידה ויש לי שני קלפים של פלוס 2 אז אני אוכל בעצם
                                //לגשת לקלף הפלוס 2 שמתאים לי לצבע שבאמצע 
                                //במידה והקלף באמצע לא היה פלוס 2
                                //אם אם הוא היה פלוס 2 זה לא משנה איזה צבע של קלף משני הקלפים שביד שלי אני אבחר
                                Refresh();
                                //על השחקן חובה לקחת שני קלפים
                                tor = false; ;
                                check2 = true;
                                MessageBox.Show("התור שלך");
                            }
                            else
                            {
                                //קלף של שינוי צבע
                                if (cardscomputer.GetCardByNum(14) == true || st.Top().GetNum() == 14)
                                {
                                    Do14();
                                    Refresh();
                                    tor = true;//התור נשאר אצל המחשב מותר לו לשים עוד קלף אחד
                                    Thread.Sleep(500);
                                }
                                else
                                {
                                    if (cardscomputer.GetCardByNumAndColor(11, st.Top().GetSidra()) == true || cardscomputer.GetCardByNumAndDominantNum(11, st.Top().GetNum()) == true)
                                    {
                                        if (st.Top().GetNum() == 11)
                                        {
                                            Do11();
                                        }
                                        else
                                        {
                                            Play11(st.Top().GetSidra());
                                        }
                                        Refresh();
                                        tor = true;//התור נשאר אצל המחשב מכיוון שהוא שם עצור על השחקן 
                                        Thread.Sleep(500);
                                    }
                                    else
                                    {
                                        if (cardscomputer.GetCardByNumAndColor(12, st.Top().GetSidra()) == true || cardscomputer.GetCardByNumAndDominantNum(12, st.Top().GetNum()) == true)
                                        {
                                            if (st.Top().GetNum() == 12)
                                            {
                                                Do12();
                                            }
                                            else
                                            {
                                                Play12(st.Top().GetSidra());
                                            }
                                            Refresh();
                                            tor = true;
                                            Thread.Sleep(500);
                                            MessageBox.Show("התור נשאר של המחשב");
                                        }
                                        else
                                        {
                                            if (cardscomputer.GetCardByNumAndColor(13, st.Top().GetSidra()) == true || cardscomputer.GetCardByNumAndDominantNum(13, st.Top().GetNum()) == true)
                                            {
                                                if (st.Top().GetNum() == 13)
                                                {
                                                    Do13();
                                                }
                                                else
                                                {
                                                    Play13(st.Top().GetSidra());
                                                }
                                                Refresh();
                                                tor = true;
                                                Thread.Sleep(500);
                                                MessageBox.Show("כיוון המשחק משתנה,למחשב יש תור נוסף");

                                            }
                                        }

                                    }

                                }
                            }

                        }
                    }
                    // יש שתי אופציות כאשר אני מגיע לכאן
                    // כאשר לא מצאנו את הקלפים שהיו בתנאי השני
                    // או שיש לי את הקלפים המיוחדים שאחרי זה התור נשאר אצלי
                    // הקלפים האלו: עצור פלוס ושנה כיוון, שאחריהם התור נשאר אצלי
                    Thread.Sleep(100);
                    if (tor == true)
                    {
                        //הבורר שלי זה הקלף שנמצא באמצע
                        //זאת אומרת שהכול תלוי במספרו של הקלף שבאמצע
                        //במידה וקיים לי מספר מסויים אז בכול אחד מהמקרים אני בודק אם בכלל
                        //קיים לי את המספר הזה ביד
                        switch (st.Top().GetNum())
                        {
                            //דוגמא: אם המספר באמצע שלי אחד אז אני בודק האם קיים לי ביד קלף שמספרו 1 גם וצבעו אותו צבע כמו של קלף באמצע
                            // או שביד שלי קיים קלף שמספרו 1 זאת אומרת בלי קשר לצבע נגיד ואם יש לי באמצע 1 צהוב
                            //וביד שלי 1 אדום אז עדיין ניתן לשים אותו למרות שהם לא באותו צבע

                            //כעיקרון ניתן למחוק את הבדיקה הראשונה של אותו צבע אך השארתי זאת ליתר ביטחון
                            case 1:
                                if (cardscomputer.GetCardByNumAndColor(1, st.Top().GetSidra()) == true || cardscomputer.GetCardByNumAndDominantNum(1, st.Top().GetNum()) == true)
                                {
                                    DoAll(1);
                                    tor = false;
                                    Invalidate();
                                }
                                break;
                            case 3:
                                if (cardscomputer.GetCardByNumAndColor(3, st.Top().GetSidra()) == true || cardscomputer.GetCardByNumAndDominantNum(3, st.Top().GetNum()) == true)
                                {
                                    DoAll(3);
                                    tor = false;
                                    Invalidate();
                                }
                                break;
                            case 4:
                                if (cardscomputer.GetCardByNumAndColor(4, st.Top().GetSidra()) == true || cardscomputer.GetCardByNumAndDominantNum(4, st.Top().GetNum()) == true)
                                {
                                    DoAll(4);
                                    tor = false;
                                    Invalidate();
                                }
                                break;
                            case 5:
                                if (cardscomputer.GetCardByNumAndColor(5, st.Top().GetSidra()) == true || cardscomputer.GetCardByNumAndDominantNum(5, st.Top().GetNum()) == true)
                                {
                                    DoAll(5);
                                    tor = false;
                                    Invalidate();
                                }
                                break;
                            case 6:
                                if (cardscomputer.GetCardByNumAndColor(6, st.Top().GetSidra()) == true || cardscomputer.GetCardByNumAndDominantNum(6, st.Top().GetNum()) == true)
                                {
                                    DoAll(6);
                                    tor = false;
                                    Invalidate();
                                }
                                break;
                            case 7:
                                if (cardscomputer.GetCardByNumAndColor(7, st.Top().GetSidra()) == true || cardscomputer.GetCardByNumAndDominantNum(7, st.Top().GetNum()) == true)
                                {
                                    DoAll(7);
                                    tor = false;
                                    Invalidate();
                                }
                                break;
                            case 8:
                                if (cardscomputer.GetCardByNumAndColor(8, st.Top().GetSidra()) == true || cardscomputer.GetCardByNumAndDominantNum(8, st.Top().GetNum()) == true)
                                {
                                    DoAll(8);
                                    tor = false;
                                    Invalidate();
                                }
                                break;
                            case 9:
                                if (cardscomputer.GetCardByNumAndColor(9, st.Top().GetSidra()) == true || cardscomputer.GetCardByNumAndDominantNum(9, st.Top().GetNum()) == true)
                                {
                                    DoAll(9);
                                    tor = false;
                                    Invalidate();
                                }
                                break;
                        }
                    }

                    if (cardscomputer.CheckWin() == true)
                    {
                        MessageBox.Show("המחשב ניצח");
                        Thread.Sleep(1000);
                        this.Close();
                    }
                    if (tor == true)// לא מצאנו לפי מספר ונחפש לפי צבע וגם לפי מספר
                    {
                        bool sw1 = false;//לא מצאנו קלף מתאים
                                         //נעבור על כל הקלפים שיש ביד של המחשב ונשווה אם הצבע של הקלף הנוכחי עם הצבע של  הקלף שיש בקופה וגם במספר 
                        Node<Card> pos = cardscomputer.GetNode();
                        pos = pos.GetNext();//מדלגים על החוליה הפיקטבית
                        Card c = st.Top();
                        while (pos != null && sw1 == false)
                        {
                            //זאת אומרת שהתנאי הראשון הוא לפי צבע אך אם עוברים על היד
                            //והקלף שעליו אנו עומדים לא באותו צבע של הקלף באמצע
                            //אך באותו מספר הוא ישים את הקלף שבאותו מספר
                            //השוואה בין הצבע של הקלף בחפיסת המחשב לבי הקלף שיש בקופה
                            if (pos.GetInfo().GetSidra() == c.GetSidra() && (pos.GetInfo().GetNum() != 14 && pos.GetInfo().GetNum() != 15))
                            {
                                sw1 = true;
                            }
                            else
                            {
                                //השוואה בין המספר של הקלף בחפיסת המחשב לבין הקלף שיש בקופה 
                                if (pos.GetInfo().GetNum() == c.GetNum() && (pos.GetInfo().GetNum() != 14 && pos.GetInfo().GetNum() != 15))
                                {
                                    sw1 = true;
                                }
                                else
                                {
                                    pos = pos.GetNext();
                                }
                            }

                        }
                        if (sw1 == true)
                        {
                            //מצאנו קלף מתאים
                            //נשים את הקלף בקופת הקלפים
                            Card ca = pos.GetInfo();
                            ca.SetX(625);
                            ca.SetY(255);
                            this.st.Push(ca);
                            st.Top().PaintCard(g);
                            cardscomputer.DelCard(ca.GetSerialNum());
                            Refresh();
                            if (st.Top().GetNum() == 10)
                            {
                                if (cardscomputer.GetCardByColor(st.Top().GetSidra()) == true)
                                {
                                    Thread.Sleep(500);
                                    Do10(st.Top().GetSidra());
                                    Refresh();
                                }
                            }
                            if (st.Top().GetNum() == 11 || st.Top().GetNum() == 12 || st.Top().GetNum() == 13)
                            {
                                tor = true;//כאשר אני מגיע לפה והקלף העליון זה היה
                                           //עצור או פלוס או שנה כיוון התור צריך להישאר אצל המחשב
                                           //אך אם הגענו לפה והקלף העליון היה אחד מאלה (במקרים כאשר יש שינוי צבע) אז
                                           //חייב שהשחקן לא ייקח קלף מהקופה ואז התור נשאר 

                                //מצב כזה עלול להיווצר כאשר המחשב שם שינוי צבע שם קלף
                                //ובמידה וזה אחד מהקלפים המיוחדים אז התור אמור להישאר לא לעבור הלאה 

                            }
                            else
                            {
                                if (st.Top().GetNum() == 2)
                                {
                                    tor = false;
                                    check2 = true;
                                }
                                else
                                {
                                    //כאשר הגעתי לכאן זה אומר שהמחשב לא צריך להמשיך בתור
                                    tor = false;
                                }
                            }
                        }
                        else
                        {
                            //לא מצאנו קלף מתאים ולכן צריך לקחת קלף מהקופה ונעביר את התור  לשחקן 
                            Card c2 = kopa.GetCardBox().Pop();
                            cardscomputer.AddCard(c2);
                            tor = false;
                            Invalidate();
                        }
                    }
                    Thread.Sleep(500);
                    if (cardscomputer.CheckWin() == true)
                    {
                        MessageBox.Show("המחשב ניצח");
                        Thread.Sleep(1000);
                        this.Close();
                    }
                }
            }
        }

        public void Do15()
        {
            Node<Card> pos = cardscomputer.GetNode();
            pos = pos.GetNext();
            while (pos.GetInfo().GetNum() != 15 && pos != null)
            {
                pos = pos.GetNext();
            }
            if (pos.GetInfo().GetNum() == 15)//זה מיותר כי במידה והגענו לפעולה זו קיים קלף של 15 אבל עשיתי זאת ליתר ביטחון
            {

                Card c = pos.GetInfo();
                c.SetX(625);
                c.SetY(255);
                st.Push(c);
                st.Top().PaintCard(g);
                cardscomputer.DelCard(c.GetSerialNum());
                Invalidate();
            }
            Thread.Sleep(1000);

            int maxcolor = cardscomputer.GetMaxColor();
            Card ca = new Card();
            Image pic = Image.FromFile((maxcolor) + "/" + (10) + ".png");
            ca.SetPic(pic);
            ca.SetSidra(maxcolor);
            ca.SetNum(10);
            ca.SetX(625);
            ca.SetY(255);
            st.Push(ca);
            st.Top().PaintCard(g);
            Thread.Sleep(1000);
            int sidra = ca.GetSidra();
            Do10(sidra);
            Invalidate();
        }

        public void Do14()
        {
            Node<Card> pos = cardscomputer.GetNode();
            pos = pos.GetNext();
            while (pos.GetInfo().GetNum() != 14 && pos != null)
            {
                pos = pos.GetNext();
            }
            if (pos.GetInfo().GetNum() == 14)
            {

                Card c = pos.GetInfo();
                c.SetX(625);
                c.SetY(255);
                st.Push(c);
                st.Top().PaintCard(g);
                cardscomputer.DelCard(c.GetSerialNum());
                Invalidate();
            }
            Thread.Sleep(1000);
            int maxcolor = cardscomputer.GetMaxColor();
            Card ca = new Card();
            Image pic = Image.FromFile((maxcolor) + "/" + (16) + ".jpg");
            ca.SetPic(pic);
            ca.SetSidra(maxcolor);
            ca.SetNum(16);
            ca.SetX(625);
            ca.SetY(255);
            st.Push(ca);
            st.Top().PaintCard(g);
        }

        public void Do10(int sidra)
        {
            //לאחר מכן שמים את הקלפים שמתאימים לצבע של הטאקי פתוח
            Node<Card> temp = cardscomputer.GetAllCardSame(sidra);
            //החוליה הראשונה היא NULL לכן התשמשתי בחוליה הבאה
            Node<Card> ntemp = temp.GetNext();
            Card ca;
            while (ntemp != null)
            {
                ca = ntemp.GetInfo();
                int serialnum = ca.GetSerialNum();
                ca.SetX(625);
                ca.SetY(255);
                st.Push(ca);
                ca.PaintCard(g);
                cardscomputer.DelCard(serialnum);
                Invalidate();
                ntemp = ntemp.GetNext();
                Thread.Sleep(500);
            }
        }

        public void Do11()
        {
            Node<Card> pos = cardscomputer.GetNode();
            while (pos.GetInfo().GetNum() != 11 && pos != null)
            {

                pos = pos.GetNext();
            }
            if ((pos.GetInfo().GetNum() == 11))
            {

                Card c = pos.GetInfo();
                c.SetX(625);
                c.SetY(255);
                st.Push(c);
                st.Top().PaintCard(g);
                cardscomputer.DelCard(c.GetSerialNum());
                Invalidate();
            }
        }

        public void Play11(int sidra)
        {
            bool flag = true;//עשיתי את המשתנה הבוליאני על זה על מנת שאדע 
            //מתי לצאת מהלולאה גם לפני
            Node<Card> pos = cardscomputer.GetNode();
            while (pos != null && flag == true)
            {
                if (pos.GetInfo().GetSidra() == sidra && pos.GetInfo().GetNum() == 11)
                {
                    flag = false;
                }
                else
                {
                    pos = pos.GetNext();
                }
            }
            if ((pos.GetInfo().GetNum() == 11 && pos.GetInfo().GetSidra() == st.Top().GetSidra())
                        || (pos.GetInfo().GetNum() == 11 && pos.GetInfo().GetNum() == st.Top().GetNum()))
            {

                Card c = pos.GetInfo();
                c.SetX(625);
                c.SetY(255);
                st.Push(c);
                st.Top().PaintCard(g);
                cardscomputer.DelCard(c.GetSerialNum());
                Invalidate();
            }
        }

        public void Do2(int sidra)
        {
            bool flag = true;//עשיתי את המשתנה הבוליאני על זה על מנת שאדע 
            //מתי לצאת מהלולאה גם לפני
            Node<Card> pos = cardscomputer.GetNode();
            while (pos != null && flag == true)
            {
                if (pos.GetInfo().GetSidra() == sidra && pos.GetInfo().GetNum() == 2)
                {
                    flag = false;
                }
                else
                {
                    pos = pos.GetNext();
                }
            }
            //ביצעתי בדיקה חוזרת ליתר ביטחון
            //האופציה השנייה לא אפשרית מכיוון שלא ניתן שיהיה קלף +2 באמצע
            //המשתמש תמיד חייב לשים קלף נוסף לאחר שהוא שם +2
            if ((pos.GetInfo().GetNum() == 2 && pos.GetInfo().GetSidra() == st.Top().GetSidra())
                        || (pos.GetInfo().GetNum() == 2 && pos.GetInfo().GetNum() == st.Top().GetNum()))
            {

                Card c = pos.GetInfo();
                c.SetX(625);
                c.SetY(255);
                st.Push(c);
                st.Top().PaintCard(g);
                cardscomputer.DelCard(c.GetSerialNum());
                Invalidate();
            }
        }

        public void Play2()
        {
            Node<Card> pos = cardscomputer.GetNode();
            while (pos != null && pos.GetInfo().GetNum() != 2)
            {
                pos = pos.GetNext();
            }
            if (pos.GetInfo().GetNum() == 2)
            {

                Card c = pos.GetInfo();
                c.SetX(625);
                c.SetY(255);
                st.Push(c);
                st.Top().PaintCard(g);
                cardscomputer.DelCard(c.GetSerialNum());
                Invalidate();
            }
        }

        public void Do12()
        {
            Node<Card> pos = cardscomputer.GetNode();
            while (pos.GetInfo().GetNum() != 12 && pos != null)
            {
                pos = pos.GetNext();
            }
            if ((pos.GetInfo().GetNum() == 12))
            {

                Card c = pos.GetInfo();
                c.SetX(625);
                c.SetY(255);
                st.Push(c);
                st.Top().PaintCard(g);
                cardscomputer.DelCard(c.GetSerialNum());
            }
            Thread.Sleep(300);
        }

        public void Play12(int sidra)
        {
            bool flag = true;//עשיתי את המשתנה הבוליאני על זה על מנת שאדע 
            //מתי לצאת מהלולאה גם לפני
            Node<Card> pos = cardscomputer.GetNode();
            while (pos != null && flag == true)
            {
                if (pos.GetInfo().GetSidra() == sidra && pos.GetInfo().GetNum() == 12)
                {
                    flag = false;
                }
                else
                {
                    pos = pos.GetNext();
                }
            }
            if ((pos.GetInfo().GetNum() == 12 && pos.GetInfo().GetSidra() == st.Top().GetSidra())
                        || (pos.GetInfo().GetNum() == 12 && pos.GetInfo().GetNum() == st.Top().GetNum()))
            {

                Card c = pos.GetInfo();
                c.SetX(625);
                c.SetY(255);
                st.Push(c);
                st.Top().PaintCard(g);
                cardscomputer.DelCard(c.GetSerialNum());
                Invalidate();
            }
        }

        public void Do13()
        {
            Node<Card> pos = cardscomputer.GetNode();
            while (pos.GetInfo().GetNum() != 13 && pos != null)
            {
                pos = pos.GetNext();
            }
            if ((pos.GetInfo().GetNum() == 13))
            {

                Card c = pos.GetInfo();
                c.SetX(625);
                c.SetY(255);
                st.Push(c);
                st.Top().PaintCard(g);
                cardscomputer.DelCard(c.GetSerialNum());
                Refresh();
            }
        }

        public void Play13(int sidra)
        {
            bool flag = true;//עשיתי את המשתנה הבוליאני על זה על מנת שאדע 
            //מתי לצאת מהלולאה גם לפני
            Node<Card> pos = cardscomputer.GetNode();
            while (pos != null && flag == true)
            {
                if (pos.GetInfo().GetSidra() == sidra && pos.GetInfo().GetNum() == 13)
                {
                    flag = false;
                }
                else
                {
                    pos = pos.GetNext();
                }
            }
            if ((pos.GetInfo().GetNum() == 13 && pos.GetInfo().GetSidra() == st.Top().GetSidra())
                        || (pos.GetInfo().GetNum() == 13 && pos.GetInfo().GetNum() == st.Top().GetNum()))
            {

                Card c = pos.GetInfo();
                c.SetX(625);
                c.SetY(255);
                st.Push(c);
                st.Top().PaintCard(g);
                cardscomputer.DelCard(c.GetSerialNum());
                Invalidate();
            }
        }

        public void DoAll(int num)
        {
            Node<Card> pos = cardscomputer.GetNode();
            while (pos.GetInfo().GetNum() != num && pos != null)
            {
                pos = pos.GetNext();
            }
            if ((pos.GetInfo().GetNum() == num && pos.GetInfo().GetSidra() == st.Top().GetSidra())
                        || (pos.GetInfo().GetNum() == num && pos.GetInfo().GetNum() == st.Top().GetNum()))
            {

                Card c = pos.GetInfo();
                c.SetX(625);
                c.SetY(255);
                st.Push(c);
                st.Top().PaintCard(g);
                cardscomputer.DelCard(c.GetSerialNum());
                Invalidate();
            }
        }

        public void play10Option1()
        {
            //אופציה כאשר הקלף העליון שלנו הוא טאקי לכן לא משנה לנו צבע הטאקי
            Node<Card> pos = cardscomputer.GetNode();
            while (pos != null && pos.GetInfo().GetNum() != 10)
            {
                pos = pos.GetNext();
            }
            if (pos.GetInfo().GetNum() == 10)
            {
                Card c = pos.GetInfo();
                int sidra = c.GetSidra();
                c.SetX(625);
                c.SetY(255);
                st.Push(c);
                st.Top().PaintCard(g);
                cardscomputer.DelCard(c.GetSerialNum());
                Invalidate();
                Thread.Sleep(1000);
                Do10(sidra);
            }
        }

        public void play10Option2()
        {
            bool flag = true;//עשיתי את המשתנה הבוליאני על זה על מנת שאדע 
            //מתי לצאת מהלולאה גם לפני
            Node<Card> pos = cardscomputer.GetNode();
            while (pos != null && flag == true)
            {
                if (pos.GetInfo().GetSidra() == st.Top().GetSidra() && pos.GetInfo().GetNum() == 10)
                {
                    flag = false;
                }
                else
                {
                    pos = pos.GetNext();
                }
            }
            if ((pos.GetInfo().GetNum() == 10 && pos.GetInfo().GetSidra() == st.Top().GetSidra())
                        || (pos.GetInfo().GetNum() == 10 && pos.GetInfo().GetNum() == st.Top().GetNum()))
            {
                Card c = pos.GetInfo();
                int sidra = c.GetSidra();
                c.SetX(625);
                c.SetY(255);
                st.Push(c);
                st.Top().PaintCard(g);
                cardscomputer.DelCard(c.GetSerialNum());
                Invalidate();
                Thread.Sleep(1000);
                Do10(sidra);
            }
        }



        //פעולה זו קשורה לקלפים של שינוי צבע
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            g = CreateGraphics();
            Card c = new Card();
            Image pic;
            if (temp.GetNum() == 14)
            {
                pic = Image.FromFile(2 + "/" + 16 + ".jpg");
                colordom = 2;
            }
            else
            {
                pic = Image.FromFile(2 + "/" + 10 + ".png");
                colordom = 2;
            }

            c.SetPic(pic);
            c.SetX(625);
            c.SetY(255);
            c.SetSidra(2);
            st.Push(c);
            st.Top().PaintCard(g);
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;

        }

        // פעולה זו קשורה לקלפים של שינוי צבע 
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            g = CreateGraphics();
            Card c = new Card();
            Image pic;
            if (temp.GetNum() == 14)
            {
                pic = Image.FromFile(4 + "/" + 16 + ".jpg");
                colordom = 4;
            }
            else
            {
                pic = Image.FromFile(4 + "/" + 10 + ".png");
                colordom = 4;
            }
            c.SetPic(pic);
            c.SetX(625);
            c.SetY(255);
            c.SetSidra(4);
            st.Push(c);
            st.Top().PaintCard(g);
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;

        }


        // פעולה זו קשורה לקלפים של שינוי צבע 
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            g = CreateGraphics();
            Card c = new Card();
            Image pic;
            if (temp.GetNum() == 14)
            {
                pic = Image.FromFile(1 + "/" + 16 + ".jpg");
            }
            else
            {
                pic = Image.FromFile(1 + "/" + 10 + ".png");
            }
            colordom = 1;
            c.SetPic(pic);
            c.SetX(625);
            c.SetY(255);
            c.SetSidra(1);
            st.Push(c);
            st.Top().PaintCard(g);
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;

        }


        // פעולה זו קשורה לקלפים של שינוי צבע 
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            g = CreateGraphics();
            Card c = new Card();
            Image pic;
            if (temp.GetNum() == 14)
            {
                pic = Image.FromFile(3 + "/" + 16 + ".jpg");
            }
            else
            {
                pic = Image.FromFile(3 + "/" + 10 + ".png");
            }
            colordom = 3;
            c.SetPic(pic);
            c.SetX(625);
            c.SetY(255);
            c.SetSidra(3);
            st.Push(c);
            st.Top().PaintCard(g);
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //כפתור היציאה למסך הבית
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //כפתור טאקי סגור,כאשר השחקן סיים לשים את כול הקלפים שלו מאותו צבע שבחר
            //הוא צריך להודיע על טאקי סגור
            if (st.Top().GetNum() != 2 && st.Top().GetNum() != 11 && st.Top().GetNum() != 12 && st.Top().GetNum() != 13 && st.Top().GetNum() != 14 && st.Top().GetNum() != 15)
            {
                tor = true;//התור עובר למחשב
                button2.Visible = false;
                numdom = -1;
                colordom = -1;
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                Thread.Sleep(1500);
                Comp();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.time1++;
            label1.Text = time1.ToString();
            label1.Refresh();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}






