﻿namespace fabrikaotomasyonu
{
    partial class pmuhasebe
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.giderlistele = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.giderGuncelle = new System.Windows.Forms.Button();
            this.giderSil = new System.Windows.Forms.Button();
            this.giderEkle = new System.Windows.Forms.Button();
            this.birimAdTb = new System.Windows.Forms.TextBox();
            this.birimNotRTB = new System.Windows.Forms.RichTextBox();
            this.birimTarihDTP = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.birimUcretTb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.alinanGuncelle = new System.Windows.Forms.Button();
            this.alinanSil = new System.Windows.Forms.Button();
            this.utarihDTP = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.alinanEkle = new System.Windows.Forms.Button();
            this.ubrimfiyatTb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uadetTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uadTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.hesapla = new System.Windows.Forms.Button();
            this.listeleBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Moccasin;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(41, 293);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(796, 421);
            this.dataGridView1.TabIndex = 70;
            // 
            // giderlistele
            // 
            this.giderlistele.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.giderlistele.BackgroundImage = global::fabrikaotomasyonu.Properties.Resources.expenses;
            this.giderlistele.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.giderlistele.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.giderlistele.ForeColor = System.Drawing.Color.White;
            this.giderlistele.Location = new System.Drawing.Point(549, 39);
            this.giderlistele.Name = "giderlistele";
            this.giderlistele.Size = new System.Drawing.Size(159, 162);
            this.giderlistele.TabIndex = 73;
            this.giderlistele.UseVisualStyleBackColor = false;
            this.giderlistele.Click += new System.EventHandler(this.giderlistele_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImage = global::fabrikaotomasyonu.Properties.Resources.arkaplan1;
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox2.Controls.Add(this.giderGuncelle);
            this.groupBox2.Controls.Add(this.giderSil);
            this.groupBox2.Controls.Add(this.giderEkle);
            this.groupBox2.Controls.Add(this.birimAdTb);
            this.groupBox2.Controls.Add(this.birimNotRTB);
            this.groupBox2.Controls.Add(this.birimTarihDTP);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.birimUcretTb);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(896, 403);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 311);
            this.groupBox2.TabIndex = 72;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Giderler";
            // 
            // giderGuncelle
            // 
            this.giderGuncelle.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.giderGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.giderGuncelle.ForeColor = System.Drawing.Color.White;
            this.giderGuncelle.Location = new System.Drawing.Point(258, 252);
            this.giderGuncelle.Name = "giderGuncelle";
            this.giderGuncelle.Size = new System.Drawing.Size(128, 40);
            this.giderGuncelle.TabIndex = 77;
            this.giderGuncelle.Text = "Güncelle";
            this.giderGuncelle.UseVisualStyleBackColor = false;
            this.giderGuncelle.Click += new System.EventHandler(this.giderGuncelle_Click);
            // 
            // giderSil
            // 
            this.giderSil.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.giderSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.giderSil.ForeColor = System.Drawing.Color.White;
            this.giderSil.Location = new System.Drawing.Point(138, 252);
            this.giderSil.Name = "giderSil";
            this.giderSil.Size = new System.Drawing.Size(114, 40);
            this.giderSil.TabIndex = 76;
            this.giderSil.Text = "Sil";
            this.giderSil.UseVisualStyleBackColor = false;
            this.giderSil.Click += new System.EventHandler(this.giderSil_Click);
            // 
            // giderEkle
            // 
            this.giderEkle.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.giderEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.giderEkle.ForeColor = System.Drawing.Color.White;
            this.giderEkle.Location = new System.Drawing.Point(11, 252);
            this.giderEkle.Name = "giderEkle";
            this.giderEkle.Size = new System.Drawing.Size(114, 40);
            this.giderEkle.TabIndex = 75;
            this.giderEkle.Text = "Ekle";
            this.giderEkle.UseVisualStyleBackColor = false;
            this.giderEkle.Click += new System.EventHandler(this.giderEkle_Click);
            // 
            // birimAdTb
            // 
            this.birimAdTb.Location = new System.Drawing.Point(131, 37);
            this.birimAdTb.Name = "birimAdTb";
            this.birimAdTb.Size = new System.Drawing.Size(200, 22);
            this.birimAdTb.TabIndex = 74;
            // 
            // birimNotRTB
            // 
            this.birimNotRTB.Location = new System.Drawing.Point(131, 69);
            this.birimNotRTB.Name = "birimNotRTB";
            this.birimNotRTB.Size = new System.Drawing.Size(200, 68);
            this.birimNotRTB.TabIndex = 73;
            this.birimNotRTB.Text = "";
            // 
            // birimTarihDTP
            // 
            this.birimTarihDTP.Location = new System.Drawing.Point(131, 188);
            this.birimTarihDTP.Name = "birimTarihDTP";
            this.birimTarihDTP.Size = new System.Drawing.Size(200, 22);
            this.birimTarihDTP.TabIndex = 61;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(23, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 20);
            this.label8.TabIndex = 60;
            this.label8.Text = "Tarih";
            // 
            // birimUcretTb
            // 
            this.birimUcretTb.Location = new System.Drawing.Point(131, 143);
            this.birimUcretTb.Name = "birimUcretTb";
            this.birimUcretTb.Size = new System.Drawing.Size(200, 22);
            this.birimUcretTb.TabIndex = 58;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(23, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 20);
            this.label9.TabIndex = 57;
            this.label9.Text = "Ücret";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(23, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 20);
            this.label10.TabIndex = 55;
            this.label10.Text = "Not";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(23, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 20);
            this.label11.TabIndex = 53;
            this.label11.Text = "Birim";
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::fabrikaotomasyonu.Properties.Resources.arkaplan1;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.alinanGuncelle);
            this.groupBox1.Controls.Add(this.alinanSil);
            this.groupBox1.Controls.Add(this.utarihDTP);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.alinanEkle);
            this.groupBox1.Controls.Add(this.ubrimfiyatTb);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.uadetTb);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.uadTb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(896, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 258);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alınan";
            // 
            // alinanGuncelle
            // 
            this.alinanGuncelle.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.alinanGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.alinanGuncelle.ForeColor = System.Drawing.Color.White;
            this.alinanGuncelle.Location = new System.Drawing.Point(258, 201);
            this.alinanGuncelle.Name = "alinanGuncelle";
            this.alinanGuncelle.Size = new System.Drawing.Size(122, 40);
            this.alinanGuncelle.TabIndex = 63;
            this.alinanGuncelle.Text = "Güncelle";
            this.alinanGuncelle.UseVisualStyleBackColor = false;
            this.alinanGuncelle.Click += new System.EventHandler(this.alinanGuncelle_Click);
            // 
            // alinanSil
            // 
            this.alinanSil.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.alinanSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.alinanSil.ForeColor = System.Drawing.Color.White;
            this.alinanSil.Location = new System.Drawing.Point(131, 201);
            this.alinanSil.Name = "alinanSil";
            this.alinanSil.Size = new System.Drawing.Size(121, 40);
            this.alinanSil.TabIndex = 62;
            this.alinanSil.Text = "Sil";
            this.alinanSil.UseVisualStyleBackColor = false;
            this.alinanSil.Click += new System.EventHandler(this.alinanSil_Click);
            // 
            // utarihDTP
            // 
            this.utarihDTP.Location = new System.Drawing.Point(131, 153);
            this.utarihDTP.Name = "utarihDTP";
            this.utarihDTP.Size = new System.Drawing.Size(200, 22);
            this.utarihDTP.TabIndex = 61;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(23, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 20);
            this.label7.TabIndex = 60;
            this.label7.Text = "Tarih";
            // 
            // alinanEkle
            // 
            this.alinanEkle.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.alinanEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.alinanEkle.ForeColor = System.Drawing.Color.White;
            this.alinanEkle.Location = new System.Drawing.Point(11, 201);
            this.alinanEkle.Name = "alinanEkle";
            this.alinanEkle.Size = new System.Drawing.Size(114, 40);
            this.alinanEkle.TabIndex = 59;
            this.alinanEkle.Text = "Ekle";
            this.alinanEkle.UseVisualStyleBackColor = false;
            this.alinanEkle.Click += new System.EventHandler(this.alinanEkle_Click);
            // 
            // ubrimfiyatTb
            // 
            this.ubrimfiyatTb.Location = new System.Drawing.Point(131, 115);
            this.ubrimfiyatTb.Name = "ubrimfiyatTb";
            this.ubrimfiyatTb.Size = new System.Drawing.Size(154, 22);
            this.ubrimfiyatTb.TabIndex = 58;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(23, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 20);
            this.label6.TabIndex = 57;
            this.label6.Text = "Birim Fiyat";
            // 
            // uadetTb
            // 
            this.uadetTb.Location = new System.Drawing.Point(131, 77);
            this.uadetTb.Name = "uadetTb";
            this.uadetTb.Size = new System.Drawing.Size(154, 22);
            this.uadetTb.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(23, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 55;
            this.label3.Text = "Ürün Adet";
            // 
            // uadTb
            // 
            this.uadTb.Location = new System.Drawing.Point(131, 39);
            this.uadTb.Name = "uadTb";
            this.uadTb.Size = new System.Drawing.Size(154, 22);
            this.uadTb.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(23, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 53;
            this.label2.Text = "Ürün Adı";
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::fabrikaotomasyonu.Properties.Resources.back_1689837_1280;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(1293, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 45);
            this.button4.TabIndex = 64;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // hesapla
            // 
            this.hesapla.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.hesapla.BackgroundImage = global::fabrikaotomasyonu.Properties.Resources.calculations;
            this.hesapla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hesapla.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.hesapla.ForeColor = System.Drawing.Color.White;
            this.hesapla.Location = new System.Drawing.Point(298, 37);
            this.hesapla.Name = "hesapla";
            this.hesapla.Size = new System.Drawing.Size(153, 162);
            this.hesapla.TabIndex = 47;
            this.hesapla.UseVisualStyleBackColor = false;
            this.hesapla.Click += new System.EventHandler(this.hesapla_Click);
            // 
            // listeleBtn
            // 
            this.listeleBtn.BackgroundImage = global::fabrikaotomasyonu.Properties.Resources.pngwing_com;
            this.listeleBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.listeleBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listeleBtn.ForeColor = System.Drawing.Color.White;
            this.listeleBtn.Location = new System.Drawing.Point(52, 37);
            this.listeleBtn.Name = "listeleBtn";
            this.listeleBtn.Size = new System.Drawing.Size(151, 164);
            this.listeleBtn.TabIndex = 46;
            this.listeleBtn.UseVisualStyleBackColor = false;
            this.listeleBtn.Click += new System.EventHandler(this.listeleBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::fabrikaotomasyonu.Properties.Resources.factory_background_elements_vector;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1362, 795);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pmuhasebe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 792);
            this.Controls.Add(this.giderlistele);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.hesapla);
            this.Controls.Add(this.listeleBtn);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "pmuhasebe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "pmuhasebe";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button hesapla;
        private System.Windows.Forms.Button listeleBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ubrimfiyatTb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox uadetTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uadTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button alinanEkle;
        private System.Windows.Forms.DateTimePicker utarihDTP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker birimTarihDTP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox birimUcretTb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox birimNotRTB;
        private System.Windows.Forms.TextBox birimAdTb;
        private System.Windows.Forms.Button giderlistele;
        private System.Windows.Forms.Button alinanGuncelle;
        private System.Windows.Forms.Button alinanSil;
        private System.Windows.Forms.Button giderGuncelle;
        private System.Windows.Forms.Button giderSil;
        private System.Windows.Forms.Button giderEkle;
    }
}