namespace TcgTournament
{
    partial class TournamentView
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
            this.TimerTournament = new System.Windows.Forms.Timer(this.components);
            this.tabCTournament = new System.Windows.Forms.TabControl();
            this.tabTournament = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.DgvTournament = new System.Windows.Forms.DataGridView();
            this.lblTimer = new System.Windows.Forms.Label();
            this.tabModify = new System.Windows.Forms.TabPage();
            this.lblError = new System.Windows.Forms.Label();
            this.lblModify = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtModifyTimer = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.tabCTournament.SuspendLayout();
            this.tabTournament.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTournament)).BeginInit();
            this.tabModify.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimerTournament
            // 
            this.TimerTournament.Enabled = true;
            this.TimerTournament.Interval = 1000;
            this.TimerTournament.Tick += new System.EventHandler(this.TimerTournament_Tick);
            // 
            // tabCTournament
            // 
            this.tabCTournament.Controls.Add(this.tabTournament);
            this.tabCTournament.Controls.Add(this.tabModify);
            this.tabCTournament.Location = new System.Drawing.Point(3, 5);
            this.tabCTournament.Name = "tabCTournament";
            this.tabCTournament.SelectedIndex = 0;
            this.tabCTournament.Size = new System.Drawing.Size(799, 469);
            this.tabCTournament.TabIndex = 1;
            // 
            // tabTournament
            // 
            this.tabTournament.BackColor = System.Drawing.SystemColors.HotTrack;
            this.tabTournament.Controls.Add(this.button4);
            this.tabTournament.Controls.Add(this.button3);
            this.tabTournament.Controls.Add(this.button2);
            this.tabTournament.Controls.Add(this.button1);
            this.tabTournament.Controls.Add(this.DgvTournament);
            this.tabTournament.Controls.Add(this.lblTimer);
            this.tabTournament.Location = new System.Drawing.Point(4, 22);
            this.tabTournament.Name = "tabTournament";
            this.tabTournament.Padding = new System.Windows.Forms.Padding(3);
            this.tabTournament.Size = new System.Drawing.Size(791, 443);
            this.tabTournament.TabIndex = 0;
            this.tabTournament.Text = "Tournament";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(190, 400);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Start round";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(18, 400);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Regenerate matches";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Regen_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(509, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Save_Click);
            // 
            // DgvTournament
            // 
            this.DgvTournament.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTournament.Location = new System.Drawing.Point(6, 6);
            this.DgvTournament.Name = "DgvTournament";
            this.DgvTournament.ReadOnly = true;
            this.DgvTournament.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvTournament.Size = new System.Drawing.Size(779, 375);
            this.DgvTournament.TabIndex = 1;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(323, 384);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(150, 55);
            this.lblTimer.TabIndex = 0;
            this.lblTimer.Text = "00:00";
            // 
            // tabModify
            // 
            this.tabModify.Controls.Add(this.lblError);
            this.tabModify.Controls.Add(this.lblModify);
            this.tabModify.Controls.Add(this.label2);
            this.tabModify.Controls.Add(this.label1);
            this.tabModify.Controls.Add(this.txtModifyTimer);
            this.tabModify.Location = new System.Drawing.Point(4, 22);
            this.tabModify.Name = "tabModify";
            this.tabModify.Padding = new System.Windows.Forms.Padding(3);
            this.tabModify.Size = new System.Drawing.Size(791, 443);
            this.tabModify.TabIndex = 1;
            this.tabModify.Text = "Modify";
            this.tabModify.UseVisualStyleBackColor = true;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(6, 3);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 20);
            this.lblError.TabIndex = 4;
            // 
            // lblModify
            // 
            this.lblModify.AutoSize = true;
            this.lblModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModify.ForeColor = System.Drawing.Color.LightGreen;
            this.lblModify.Location = new System.Drawing.Point(3, 3);
            this.lblModify.Name = "lblModify";
            this.lblModify.Size = new System.Drawing.Size(21, 20);
            this.lblModify.TabIndex = 3;
            this.lblModify.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Change data by enter in the textbox";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Modify Timer";
            // 
            // txtModifyTimer
            // 
            this.txtModifyTimer.Location = new System.Drawing.Point(76, 49);
            this.txtModifyTimer.MaxLength = 5;
            this.txtModifyTimer.Name = "txtModifyTimer";
            this.txtModifyTimer.Size = new System.Drawing.Size(100, 20);
            this.txtModifyTimer.TabIndex = 0;
            this.txtModifyTimer.Text = "50:00";
            this.txtModifyTimer.Click += new System.EventHandler(this.Click_Time);
            this.txtModifyTimer.TextChanged += new System.EventHandler(this.txtModifyTimer_TextChanged);
            this.txtModifyTimer.Enter += new System.EventHandler(this.Focus_Enter_Time);
            this.txtModifyTimer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.modify_Timer_KeyUp);
            this.txtModifyTimer.Validating += new System.ComponentModel.CancelEventHandler(this.Focus_Enter_Time);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(648, 400);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "End Tournament";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // TournamentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(807, 475);
            this.Controls.Add(this.tabCTournament);
            this.Name = "TournamentView";
            this.Text = "Tournament";
            this.tabCTournament.ResumeLayout(false);
            this.tabTournament.ResumeLayout(false);
            this.tabTournament.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTournament)).EndInit();
            this.tabModify.ResumeLayout(false);
            this.tabModify.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer TimerTournament;
        private System.Windows.Forms.TabControl tabCTournament;
        private System.Windows.Forms.TabPage tabTournament;
        private System.Windows.Forms.TabPage tabModify;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModifyTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblModify;
        private System.Windows.Forms.DataGridView DgvTournament;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}