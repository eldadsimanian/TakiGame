namespace Taki
{
    partial class RecordTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordTable));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.db1DataSet = new Taki.Db1DataSet();
            this.fillBy11ToolStrip = new System.Windows.Forms.ToolStrip();
            this.fillBy11ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fillBy3ToolStrip = new System.Windows.Forms.ToolStrip();
            this.fillBy3ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.scoresTableAdapter = new Taki.Db1DataSetTableAdapters.ScoresTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db1DataSet)).BeginInit();
            this.fillBy11ToolStrip.SuspendLayout();
            this.fillBy3ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn,
            this.pointsDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.scoresBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 169);
            this.dataGridView1.TabIndex = 0;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.userNameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.userNameDataGridViewTextBoxColumn.FillWeight = 1500F;
            this.userNameDataGridViewTextBoxColumn.HeaderText = "שם המשתמש";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.Width = 700;
            // 
            // pointsDataGridViewTextBoxColumn
            // 
            this.pointsDataGridViewTextBoxColumn.DataPropertyName = "Points";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pointsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.pointsDataGridViewTextBoxColumn.HeaderText = "זמן ";
            this.pointsDataGridViewTextBoxColumn.Name = "pointsDataGridViewTextBoxColumn";
            this.pointsDataGridViewTextBoxColumn.Width = 700;
            // 
            // scoresBindingSource
            // 
            this.scoresBindingSource.DataMember = "Scores";
            this.scoresBindingSource.DataSource = this.db1DataSet;
            // 
            // db1DataSet
            // 
            this.db1DataSet.DataSetName = "Db1DataSet";
            this.db1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fillBy11ToolStrip
            // 
            this.fillBy11ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillBy11ToolStripButton});
            this.fillBy11ToolStrip.Location = new System.Drawing.Point(0, 194);
            this.fillBy11ToolStrip.Name = "fillBy11ToolStrip";
            this.fillBy11ToolStrip.Size = new System.Drawing.Size(800, 25);
            this.fillBy11ToolStrip.TabIndex = 3;
            this.fillBy11ToolStrip.Text = "fillBy11ToolStrip";
            this.fillBy11ToolStrip.Visible = false;
            // 
            // fillBy11ToolStripButton
            // 
            this.fillBy11ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillBy11ToolStripButton.Name = "fillBy11ToolStripButton";
            this.fillBy11ToolStripButton.Size = new System.Drawing.Size(51, 22);
            this.fillBy11ToolStripButton.Text = "FillBy11";
            // 
            // fillBy3ToolStrip
            // 
            this.fillBy3ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillBy3ToolStripButton});
            this.fillBy3ToolStrip.Location = new System.Drawing.Point(0, 169);
            this.fillBy3ToolStrip.Name = "fillBy3ToolStrip";
            this.fillBy3ToolStrip.Size = new System.Drawing.Size(800, 25);
            this.fillBy3ToolStrip.TabIndex = 5;
            this.fillBy3ToolStrip.Text = "fillBy3ToolStrip";
            // 
            // fillBy3ToolStripButton
            // 
            this.fillBy3ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillBy3ToolStripButton.Name = "fillBy3ToolStripButton";
            this.fillBy3ToolStripButton.Size = new System.Drawing.Size(45, 22);
            this.fillBy3ToolStripButton.Text = "FillBy3";
            this.fillBy3ToolStripButton.Visible = false;
            this.fillBy3ToolStripButton.Click += new System.EventHandler(this.fillBy3ToolStripButton_Click);
            // 
            // scoresTableAdapter
            // 
            this.scoresTableAdapter.ClearBeforeFill = true;
            // 
            // RecordTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fillBy3ToolStrip);
            this.Controls.Add(this.fillBy11ToolStrip);
            this.Controls.Add(this.dataGridView1);
            this.Name = "RecordTable";
            this.Text = "RecordTable";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RecordTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db1DataSet)).EndInit();
            this.fillBy11ToolStrip.ResumeLayout(false);
            this.fillBy11ToolStrip.PerformLayout();
            this.fillBy3ToolStrip.ResumeLayout(false);
            this.fillBy3ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Db1DataSet db1DataSet;
        private System.Windows.Forms.BindingSource scoresBindingSource;
        private Db1DataSetTableAdapters.ScoresTableAdapter scoresTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointsDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStrip fillBy11ToolStrip;
        private System.Windows.Forms.ToolStripButton fillBy11ToolStripButton;
        private System.Windows.Forms.ToolStrip fillBy3ToolStrip;
        private System.Windows.Forms.ToolStripButton fillBy3ToolStripButton;
    }
}