namespace Scraper
{
    partial class ScrapeResult
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
            this.ScrapeBtn = new System.Windows.Forms.Button();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ScrapeBtn
            // 
            this.ScrapeBtn.Location = new System.Drawing.Point(12, 21);
            this.ScrapeBtn.Name = "ScrapeBtn";
            this.ScrapeBtn.Size = new System.Drawing.Size(123, 26);
            this.ScrapeBtn.TabIndex = 0;
            this.ScrapeBtn.Text = "TX Scrape";
            this.ScrapeBtn.UseVisualStyleBackColor = true;
            this.ScrapeBtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(12, 71);
            this.txt1.Multiline = true;
            this.txt1.Name = "txt1";
            this.txt1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt1.Size = new System.Drawing.Size(1281, 268);
            this.txt1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(152, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "Scrape2";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ScrapeResult
            // 
            this.ClientSize = new System.Drawing.Size(1314, 351);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.ScrapeBtn);
            this.Name = "ScrapeResult";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ScrapeBtn;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Button button1;
    }
}

