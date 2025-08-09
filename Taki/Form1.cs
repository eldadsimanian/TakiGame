using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game a = new Game();
            a.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Instructions a = new Instructions();
            a.Show();//כאשר נלחץ על הכפתור זה מעביר אותנו לפורם של ההוראות
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Do you really want to exit the game?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);//מגדירים בעצם איך יראה לאחר שנלחץ על יציאה.. ככה בעצם הסדר שלו
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("תודה שבחרת להישאר", "איזה כיף", MessageBoxButtons.OK, MessageBoxIcon.Information);//נותן הודעה לאחר שבחרנו כן להישאר במשחק
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           ShowCards a = new ShowCards();
           a.Show();//כאשר נלחץ על הכפתור זה מעביר אותנו לפורם של הצגת הקלפים
           
        }

        private void startGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game a = new Game();
            a.Show();
        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Instructions a = new Instructions();
            a.Show();//כאשר נלחץ על הכפתור זה מעביר אותנו לפורם של ההוראות
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Do you really want to exit the game?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);//מגדירים בעצם איך יראה לאחר שנלחץ על יציאה.. ככה בעצם הסדר שלו
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("תודה שבחרת להישאר", "איזה כיף", MessageBoxButtons.OK, MessageBoxIcon.Information);//נותן הודעה לאחר שבחרנו כן להישאר במשחק
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCards a = new ShowCards();
            a.Show();//כאשר נלחץ על הכפתור זה מעביר אותנו לפורם של הצגת הקלפים
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            RecordTable a = new RecordTable();
            a.Show();
        }

        private void tableOfRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecordTable a = new RecordTable();
            a.Show();
        }
    }
}
