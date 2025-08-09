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
    public partial class RecordTable : Form
    {
        string name = "";
        int score = 0;

        public RecordTable()
        {
            InitializeComponent();
        }

        public RecordTable(string name,int score)
        {
            InitializeComponent();
            this.name = name;
            this.score = score;
        }

        private void RecordTable_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db1DataSet.Scores' table. You can move, or remove it, as needed.
            if (name != "")
            {
                this.scoresTableAdapter.Insert(name, score);
            }  
            this.scoresTableAdapter.Fill(this.db1DataSet.Scores);
            this.scoresTableAdapter.Update(this.db1DataSet.Scores);
            try
            {
                this.scoresTableAdapter.FillBy3(this.db1DataSet.Scores);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        
     
        private void fillBy3ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.scoresTableAdapter.FillBy3(this.db1DataSet.Scores);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
