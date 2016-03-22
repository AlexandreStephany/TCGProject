namespace TcgTournament
{
    partial class Players
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
            this.DgvPlayers = new System.Windows.Forms.DataGridView();
            this.DgvPlayersTo = new System.Windows.Forms.DataGridView();
            this.btnCreatePlayer = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPlayersLeft = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPlayerCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlayersTo)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvPlayers
            // 
            this.DgvPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPlayers.Location = new System.Drawing.Point(12, 87);
            this.DgvPlayers.Name = "DgvPlayers";
            this.DgvPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPlayers.Size = new System.Drawing.Size(266, 339);
            this.DgvPlayers.TabIndex = 1;
            this.DgvPlayers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Players_doubleclick);
            // 
            // DgvPlayersTo
            // 
            this.DgvPlayersTo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPlayersTo.Location = new System.Drawing.Point(396, 87);
            this.DgvPlayersTo.Name = "DgvPlayersTo";
            this.DgvPlayersTo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPlayersTo.Size = new System.Drawing.Size(279, 339);
            this.DgvPlayersTo.TabIndex = 2;
            this.DgvPlayersTo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_PlayersTo_doubleclick);
            // 
            // btnCreatePlayer
            // 
            this.btnCreatePlayer.Location = new System.Drawing.Point(2, 12);
            this.btnCreatePlayer.Name = "btnCreatePlayer";
            this.btnCreatePlayer.Size = new System.Drawing.Size(105, 24);
            this.btnCreatePlayer.TabIndex = 3;
            this.btnCreatePlayer.Text = "Create New Player";
            this.btnCreatePlayer.UseVisualStyleBackColor = true;
            this.btnCreatePlayer.Click += new System.EventHandler(this.btnCreatePlayer_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(299, 233);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(299, 262);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(396, 432);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(245, 34);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(393, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Players";
            // 
            // lblPlayersLeft
            // 
            this.lblPlayersLeft.AutoSize = true;
            this.lblPlayersLeft.Location = new System.Drawing.Point(434, 71);
            this.lblPlayersLeft.Name = "lblPlayersLeft";
            this.lblPlayersLeft.Size = new System.Drawing.Size(30, 13);
            this.lblPlayersLeft.TabIndex = 8;
            this.lblPlayersLeft.Text = "0/12";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Players";
            // 
            // lblPlayerCount
            // 
            this.lblPlayerCount.AutoSize = true;
            this.lblPlayerCount.Location = new System.Drawing.Point(46, 68);
            this.lblPlayerCount.Name = "lblPlayerCount";
            this.lblPlayerCount.Size = new System.Drawing.Size(19, 13);
            this.lblPlayerCount.TabIndex = 10;
            this.lblPlayerCount.Text = "12";
            // 
            // Players
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(749, 521);
            this.Controls.Add(this.lblPlayerCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPlayersLeft);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCreatePlayer);
            this.Controls.Add(this.DgvPlayersTo);
            this.Controls.Add(this.DgvPlayers);
            this.Name = "Players";
            this.Text = "Players";

            this.Load += new System.EventHandler(this.Players_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlayersTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView DgvPlayers;
        private System.Windows.Forms.DataGridView DgvPlayersTo;
        private System.Windows.Forms.Button btnCreatePlayer;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPlayersLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPlayerCount;
    }
}

