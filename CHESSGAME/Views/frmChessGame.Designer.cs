namespace CHESSGAME.Views
{
    partial class frmChessGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChessGame));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNamePlayerBlack = new System.Windows.Forms.Label();
            this.pctPlayerBlack = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStartTime = new System.Windows.Forms.Button();
            this.mnuChessGame = new System.Windows.Forms.MenuStrip();
            this.tlsNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNamePlayerPink = new System.Windows.Forms.Label();
            this.pctPlayerPink = new System.Windows.Forms.PictureBox();
            this.lblTimePink = new System.Windows.Forms.Label();
            this.pnlChessBoard = new System.Windows.Forms.Panel();
            this.lblTimeBlack = new System.Windows.Forms.Label();
            this.tmrBlack = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvListMove = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Move = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLAN = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctPlayerBlack)).BeginInit();
            this.mnuChessGame.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctPlayerPink)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMove)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.lblNamePlayerBlack);
            this.panel2.Controls.Add(this.pctPlayerBlack);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(429, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(281, 119);
            this.panel2.TabIndex = 1;
            // 
            // lblNamePlayerBlack
            // 
            this.lblNamePlayerBlack.AutoSize = true;
            this.lblNamePlayerBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamePlayerBlack.Location = new System.Drawing.Point(187, 97);
            this.lblNamePlayerBlack.Name = "lblNamePlayerBlack";
            this.lblNamePlayerBlack.Size = new System.Drawing.Size(91, 20);
            this.lblNamePlayerBlack.TabIndex = 2;
            this.lblNamePlayerBlack.Text = "user black";
            // 
            // pctPlayerBlack
            // 
            this.pctPlayerBlack.BackgroundImage = global::CHESSGAME.Properties.Resources.iconUser;
            this.pctPlayerBlack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctPlayerBlack.Location = new System.Drawing.Point(187, 3);
            this.pctPlayerBlack.Name = "pctPlayerBlack";
            this.pctPlayerBlack.Size = new System.Drawing.Size(91, 91);
            this.pctPlayerBlack.TabIndex = 1;
            this.pctPlayerBlack.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Time:";
            // 
            // btnStartTime
            // 
            this.btnStartTime.Location = new System.Drawing.Point(431, 222);
            this.btnStartTime.Name = "btnStartTime";
            this.btnStartTime.Size = new System.Drawing.Size(75, 23);
            this.btnStartTime.TabIndex = 11;
            this.btnStartTime.Text = "StartTime";
            this.btnStartTime.UseVisualStyleBackColor = true;
            this.btnStartTime.Click += new System.EventHandler(this.btnStartTime_Click);
            // 
            // mnuChessGame
            // 
            this.mnuChessGame.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsNewGame,
            this.tlsUndo,
            this.tlsQuit});
            this.mnuChessGame.Location = new System.Drawing.Point(0, 0);
            this.mnuChessGame.Name = "mnuChessGame";
            this.mnuChessGame.Size = new System.Drawing.Size(720, 24);
            this.mnuChessGame.TabIndex = 4;
            this.mnuChessGame.Text = "menuStrip1";
            // 
            // tlsNewGame
            // 
            this.tlsNewGame.Image = global::CHESSGAME.Properties.Resources.iconNewGame;
            this.tlsNewGame.Name = "tlsNewGame";
            this.tlsNewGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tlsNewGame.Size = new System.Drawing.Size(93, 20);
            this.tlsNewGame.Text = "New Game";
            this.tlsNewGame.Click += new System.EventHandler(this.tlsNewGame_Click);
            // 
            // tlsUndo
            // 
            this.tlsUndo.Image = global::CHESSGAME.Properties.Resources.undo_271;
            this.tlsUndo.Name = "tlsUndo";
            this.tlsUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.tlsUndo.Size = new System.Drawing.Size(64, 20);
            this.tlsUndo.Text = "Undo";
            this.tlsUndo.Click += new System.EventHandler(this.tlsUndo_Click);
            // 
            // tlsQuit
            // 
            this.tlsQuit.Image = global::CHESSGAME.Properties.Resources.iconExit;
            this.tlsQuit.Name = "tlsQuit";
            this.tlsQuit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.tlsQuit.Size = new System.Drawing.Size(58, 20);
            this.tlsQuit.Text = "Quit";
            this.tlsQuit.Click += new System.EventHandler(this.tlsQuit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lblNamePlayerPink);
            this.panel1.Controls.Add(this.pctPlayerPink);
            this.panel1.Location = new System.Drawing.Point(429, 313);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 121);
            this.panel1.TabIndex = 2;
            // 
            // lblNamePlayerPink
            // 
            this.lblNamePlayerPink.AutoSize = true;
            this.lblNamePlayerPink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamePlayerPink.Location = new System.Drawing.Point(192, 97);
            this.lblNamePlayerPink.Name = "lblNamePlayerPink";
            this.lblNamePlayerPink.Size = new System.Drawing.Size(82, 20);
            this.lblNamePlayerPink.TabIndex = 3;
            this.lblNamePlayerPink.Text = "user pink";
            // 
            // pctPlayerPink
            // 
            this.pctPlayerPink.BackColor = System.Drawing.Color.Transparent;
            this.pctPlayerPink.BackgroundImage = global::CHESSGAME.Properties.Resources.iconUser;
            this.pctPlayerPink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctPlayerPink.Location = new System.Drawing.Point(187, 3);
            this.pctPlayerPink.Name = "pctPlayerPink";
            this.pctPlayerPink.Size = new System.Drawing.Size(91, 91);
            this.pctPlayerPink.TabIndex = 3;
            this.pctPlayerPink.TabStop = false;
            // 
            // lblTimePink
            // 
            this.lblTimePink.AutoSize = true;
            this.lblTimePink.BackColor = System.Drawing.Color.Silver;
            this.lblTimePink.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTimePink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimePink.Location = new System.Drawing.Point(433, 289);
            this.lblTimePink.Name = "lblTimePink";
            this.lblTimePink.Size = new System.Drawing.Size(48, 18);
            this.lblTimePink.TabIndex = 10;
            this.lblTimePink.Text = "Time:";
            // 
            // pnlChessBoard
            // 
            this.pnlChessBoard.BackgroundImage = global::CHESSGAME.Properties.Resources.ChessBoard;
            this.pnlChessBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlChessBoard.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlChessBoard.Location = new System.Drawing.Point(0, 24);
            this.pnlChessBoard.Name = "pnlChessBoard";
            this.pnlChessBoard.Size = new System.Drawing.Size(421, 422);
            this.pnlChessBoard.TabIndex = 0;
            // 
            // lblTimeBlack
            // 
            this.lblTimeBlack.AutoSize = true;
            this.lblTimeBlack.BackColor = System.Drawing.Color.Silver;
            this.lblTimeBlack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTimeBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeBlack.Location = new System.Drawing.Point(433, 161);
            this.lblTimeBlack.Name = "lblTimeBlack";
            this.lblTimeBlack.Size = new System.Drawing.Size(48, 18);
            this.lblTimeBlack.TabIndex = 8;
            this.lblTimeBlack.Text = "Time:";
            // 
            // tmrBlack
            // 
            this.tmrBlack.Interval = 1000;
            this.tmrBlack.Tick += new System.EventHandler(this.tmrBlack_Tick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvListMove);
            this.panel3.Location = new System.Drawing.Point(511, 158);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(199, 149);
            this.panel3.TabIndex = 5;
            // 
            // dgvListMove
            // 
            this.dgvListMove.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListMove.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.Name,
            this.Move});
            this.dgvListMove.Location = new System.Drawing.Point(3, 3);
            this.dgvListMove.Name = "dgvListMove";
            this.dgvListMove.Size = new System.Drawing.Size(193, 143);
            this.dgvListMove.TabIndex = 0;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.Width = 30;
            // 
            // Name
            // 
            this.Name.HeaderText = "NAME";
            this.Name.Name = "Name";
            this.Name.Width = 80;
            // 
            // Move
            // 
            this.Move.HeaderText = "MOVE";
            this.Move.Name = "Move";
            this.Move.Width = 42;
            // 
            // btnLAN
            // 
            this.btnLAN.Location = new System.Drawing.Point(429, 0);
            this.btnLAN.Name = "btnLAN";
            this.btnLAN.Size = new System.Drawing.Size(75, 23);
            this.btnLAN.TabIndex = 12;
            this.btnLAN.Text = "LAN";
            this.btnLAN.UseVisualStyleBackColor = true;
            this.btnLAN.Click += new System.EventHandler(this.btnLAN_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(511, 1);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 20);
            this.txtIP.TabIndex = 13;
            // 
            // frmChessGame
            // 
            this.ClientSize = new System.Drawing.Size(720, 446);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnLAN);
            this.Controls.Add(this.btnStartTime);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblTimePink);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblTimeBlack);
            this.Controls.Add(this.pnlChessBoard);
            this.Controls.Add(this.mnuChessGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuChessGame;
            this.Text = "ChessGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChessGame_FormClosing);
            this.Load += new System.EventHandler(this.frmChessGame_Load);
            this.Shown += new System.EventHandler(this.frmChessGame_Shown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctPlayerBlack)).EndInit();
            this.mnuChessGame.ResumeLayout(false);
            this.mnuChessGame.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctPlayerPink)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMove)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlChessBoard;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip mnuChessGame;
        private System.Windows.Forms.ToolStripMenuItem tlsNewGame;
        private System.Windows.Forms.ToolStripMenuItem tlsUndo;
        private System.Windows.Forms.ToolStripMenuItem tlsQuit;
        private System.Windows.Forms.PictureBox pctPlayerBlack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pctPlayerPink;
        private System.Windows.Forms.Label lblNamePlayerBlack;
        private System.Windows.Forms.Label lblNamePlayerPink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTimeBlack;
        private System.Windows.Forms.Label lblTimePink;
        private System.Windows.Forms.Button btnStartTime;
        private System.Windows.Forms.Timer tmrBlack;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvListMove;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Move;
        private System.Windows.Forms.Button btnLAN;
        private System.Windows.Forms.TextBox txtIP;
    }
}

