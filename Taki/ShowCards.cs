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
    public partial class ShowCards : Form
    {
        Graphics g;
        Deck deck = new Deck();
        

        public ShowCards()
        {
            InitializeComponent();
        }

        private void ShowCards_Load(object sender, EventArgs e)
        {

        }

        private void ShowCards_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            deck.PaintDeck(g);
        }

        private void ShowCards_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
