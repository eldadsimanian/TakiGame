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
    public partial class PutName : Form
    {
        string name;
        int timer;
        public PutName(int timer)
        {
            InitializeComponent();
            this.timer = timer;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.name = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("עליך להקליד שם");
            }
            else
            {
                this.Close();
                RecordTable a = new RecordTable(this.name, this.timer);
                a.Show();
            }
        }

        private void PutName_Load(object sender, EventArgs e)
        {

        }
    }
}
