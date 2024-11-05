namespace CSharpMinesweeper
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlTop = new Panel();
            pctFlag = new PictureBox();
            lblFlagCount = new Label();
            pctMine = new PictureBox();
            lblMineCount = new Label();
            btnStart = new Button();
            cmbSize = new ComboBox();
            btnExit = new Button();
            pnlCanvas = new Panel();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctFlag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pctMine).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTop.BackColor = Color.Khaki;
            pnlTop.Controls.Add(pctFlag);
            pnlTop.Controls.Add(lblFlagCount);
            pnlTop.Controls.Add(pctMine);
            pnlTop.Controls.Add(lblMineCount);
            pnlTop.Controls.Add(btnStart);
            pnlTop.Controls.Add(cmbSize);
            pnlTop.Controls.Add(btnExit);
            pnlTop.Location = new Point(5, 5);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(640, 30);
            pnlTop.TabIndex = 0;
            pnlTop.MouseDown += pnlTop_MouseDown;
            // 
            // pctFlag
            // 
            pctFlag.BackgroundImageLayout = ImageLayout.Stretch;
            pctFlag.Location = new Point(365, 0);
            pctFlag.Name = "pctFlag";
            pctFlag.Size = new Size(30, 30);
            pctFlag.TabIndex = 5;
            pctFlag.TabStop = false;
            // 
            // lblFlagCount
            // 
            lblFlagCount.AutoSize = true;
            lblFlagCount.ForeColor = Color.ForestGreen;
            lblFlagCount.Location = new Point(401, 5);
            lblFlagCount.Name = "lblFlagCount";
            lblFlagCount.Size = new Size(17, 20);
            lblFlagCount.TabIndex = 4;
            lblFlagCount.Text = "0";
            // 
            // pctMine
            // 
            pctMine.BackgroundImageLayout = ImageLayout.Stretch;
            pctMine.Location = new Point(289, 0);
            pctMine.Name = "pctMine";
            pctMine.Size = new Size(30, 30);
            pctMine.TabIndex = 3;
            pctMine.TabStop = false;
            // 
            // lblMineCount
            // 
            lblMineCount.AutoSize = true;
            lblMineCount.ForeColor = Color.ForestGreen;
            lblMineCount.Location = new Point(325, 5);
            lblMineCount.Name = "lblMineCount";
            lblMineCount.Size = new Size(17, 20);
            lblMineCount.TabIndex = 2;
            lblMineCount.Text = "0";
            // 
            // btnStart
            // 
            btnStart.Dock = DockStyle.Left;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStart.ForeColor = Color.ForestGreen;
            btnStart.Location = new Point(166, 0);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(90, 30);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // cmbSize
            // 
            cmbSize.BackColor = Color.Khaki;
            cmbSize.Dock = DockStyle.Left;
            cmbSize.FlatStyle = FlatStyle.Flat;
            cmbSize.ForeColor = Color.ForestGreen;
            cmbSize.FormattingEnabled = true;
            cmbSize.Items.AddRange(new object[] { "10 x 10", "20 x 20" });
            cmbSize.Location = new Point(0, 0);
            cmbSize.Name = "cmbSize";
            cmbSize.Size = new Size(166, 28);
            cmbSize.TabIndex = 1;
            // 
            // btnExit
            // 
            btnExit.Dock = DockStyle.Right;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = Color.ForestGreen;
            btnExit.Location = new Point(607, 0);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(33, 30);
            btnExit.TabIndex = 0;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // pnlCanvas
            // 
            pnlCanvas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlCanvas.BackColor = Color.LemonChiffon;
            pnlCanvas.Location = new Point(5, 40);
            pnlCanvas.Name = "pnlCanvas";
            pnlCanvas.Size = new Size(640, 640);
            pnlCanvas.TabIndex = 1;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(650, 685);
            Controls.Add(pnlCanvas);
            Controls.Add(pnlTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Minesweeper";
            Load += frmMain_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pctFlag).EndInit();
            ((System.ComponentModel.ISupportInitialize)pctMine).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Panel pnlCanvas;
        private Button btnStart;
        private ComboBox cmbSize;
        private Button btnExit;
        private PictureBox pctMine;
        private Label lblMineCount;
        private PictureBox pctFlag;
        private Label lblFlagCount;
    }
}
