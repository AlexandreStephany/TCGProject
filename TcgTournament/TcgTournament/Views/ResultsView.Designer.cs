namespace TcgTournament.Views
{
    public partial class ResultsView
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
            this.PlayerList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // PlayerList
            // 
            this.PlayerList.Location = new System.Drawing.Point(12, 12);
            this.PlayerList.Name = "PlayerList";
            this.PlayerList.Size = new System.Drawing.Size(376, 279);
            this.PlayerList.TabIndex = 0;
            this.PlayerList.UseCompatibleStateImageBehavior = false;
            // 
            // ResultsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 303);
            this.Controls.Add(this.PlayerList);
            this.Name = "ResultsView";
            this.Text = "ResultsView";
            this.Load += new System.EventHandler(this.ResultsView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView PlayerList;
    }
}