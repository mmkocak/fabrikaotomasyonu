namespace fabrikaotomasyonu
{
    partial class Anasayfa
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.personelBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Location = new System.Drawing.Point(730, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 652);
            this.panel1.TabIndex = 1;
            // 
            // personelBtn
            // 
            this.personelBtn.BackColor = System.Drawing.Color.DarkBlue;
            this.personelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.personelBtn.ForeColor = System.Drawing.Color.White;
            this.personelBtn.Location = new System.Drawing.Point(60, 123);
            this.personelBtn.Name = "personelBtn";
            this.personelBtn.Size = new System.Drawing.Size(241, 63);
            this.personelBtn.TabIndex = 7;
            this.personelBtn.Text = "Personel";
            this.personelBtn.UseVisualStyleBackColor = false;
            this.personelBtn.Click += new System.EventHandler(this.personelBtn_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkBlue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(60, 372);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(241, 63);
            this.button2.TabIndex = 8;
            this.button2.Text = "Gider-Gelir";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkBlue;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(60, 250);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(241, 63);
            this.button3.TabIndex = 9;
            this.button3.Text = "Üretim";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // Anasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.personelBtn);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Anasayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anasayfa";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button personelBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}