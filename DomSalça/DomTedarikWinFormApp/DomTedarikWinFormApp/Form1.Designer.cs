namespace DomTedarikWinFormApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_xmlAktar = new System.Windows.Forms.Button();
            this.btn_urunEkle = new System.Windows.Forms.Button();
            this.btn_seciliUrunuSil = new System.Windows.Forms.Button();
            this.btn_seciliUrunuGuncelle = new System.Windows.Forms.Button();
            this.btn_listeyiYenile = new System.Windows.Forms.Button();
            this.tb_urunAdi = new System.Windows.Forms.TextBox();
            this.nud_fiyat = new System.Windows.Forms.NumericUpDown();
            this.nud_miktar = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_fiyat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_miktar)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 360);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1067, 188);
            this.dataGridView1.TabIndex = 0;
            // 
            // btn_xmlAktar
            // 
            this.btn_xmlAktar.Location = new System.Drawing.Point(825, 155);
            this.btn_xmlAktar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_xmlAktar.Name = "btn_xmlAktar";
            this.btn_xmlAktar.Size = new System.Drawing.Size(146, 29);
            this.btn_xmlAktar.TabIndex = 1;
            this.btn_xmlAktar.Text = "XML\'e Aktar";
            this.btn_xmlAktar.UseVisualStyleBackColor = true;
            this.btn_xmlAktar.Click += new System.EventHandler(this.btn_xmlAktar_Click);
            // 
            // btn_urunEkle
            // 
            this.btn_urunEkle.Location = new System.Drawing.Point(223, 248);
            this.btn_urunEkle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_urunEkle.Name = "btn_urunEkle";
            this.btn_urunEkle.Size = new System.Drawing.Size(103, 29);
            this.btn_urunEkle.TabIndex = 2;
            this.btn_urunEkle.Text = "Ürün Ekle";
            this.btn_urunEkle.UseVisualStyleBackColor = true;
            this.btn_urunEkle.Click += new System.EventHandler(this.btn_urunEkle_Click);
            // 
            // btn_seciliUrunuSil
            // 
            this.btn_seciliUrunuSil.Location = new System.Drawing.Point(534, 155);
            this.btn_seciliUrunuSil.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_seciliUrunuSil.Name = "btn_seciliUrunuSil";
            this.btn_seciliUrunuSil.Size = new System.Drawing.Size(195, 29);
            this.btn_seciliUrunuSil.TabIndex = 3;
            this.btn_seciliUrunuSil.Text = "Seçili Ürünü Sil";
            this.btn_seciliUrunuSil.UseVisualStyleBackColor = true;
            this.btn_seciliUrunuSil.Click += new System.EventHandler(this.btn_seciliUrunuSil_Click);
            // 
            // btn_seciliUrunuGuncelle
            // 
            this.btn_seciliUrunuGuncelle.Location = new System.Drawing.Point(786, 95);
            this.btn_seciliUrunuGuncelle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_seciliUrunuGuncelle.Name = "btn_seciliUrunuGuncelle";
            this.btn_seciliUrunuGuncelle.Size = new System.Drawing.Size(224, 29);
            this.btn_seciliUrunuGuncelle.TabIndex = 4;
            this.btn_seciliUrunuGuncelle.Text = "Seçili Ürünü Güncelle";
            this.btn_seciliUrunuGuncelle.UseVisualStyleBackColor = true;
            this.btn_seciliUrunuGuncelle.Click += new System.EventHandler(this.btn_seciliUrunuGuncelle_Click);
            // 
            // btn_listeyiYenile
            // 
            this.btn_listeyiYenile.Location = new System.Drawing.Point(550, 95);
            this.btn_listeyiYenile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_listeyiYenile.Name = "btn_listeyiYenile";
            this.btn_listeyiYenile.Size = new System.Drawing.Size(162, 29);
            this.btn_listeyiYenile.TabIndex = 5;
            this.btn_listeyiYenile.Text = "Listeyi Yenile";
            this.btn_listeyiYenile.UseVisualStyleBackColor = true;
            this.btn_listeyiYenile.Click += new System.EventHandler(this.btn_listeyiYenile_Click);
            // 
            // tb_urunAdi
            // 
            this.tb_urunAdi.Location = new System.Drawing.Point(258, 64);
            this.tb_urunAdi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_urunAdi.Name = "tb_urunAdi";
            this.tb_urunAdi.Size = new System.Drawing.Size(136, 27);
            this.tb_urunAdi.TabIndex = 6;
            // 
            // nud_fiyat
            // 
            this.nud_fiyat.Location = new System.Drawing.Point(258, 132);
            this.nud_fiyat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nud_fiyat.Name = "nud_fiyat";
            this.nud_fiyat.Size = new System.Drawing.Size(165, 27);
            this.nud_fiyat.TabIndex = 7;
            // 
            // nud_miktar
            // 
            this.nud_miktar.Location = new System.Drawing.Point(258, 195);
            this.nud_miktar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nud_miktar.Name = "nud_miktar";
            this.nud_miktar.Size = new System.Drawing.Size(165, 27);
            this.nud_miktar.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ürün Adı :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ürün Fiyatı :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 197);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ürün Miktarı :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1100, 562);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nud_miktar);
            this.Controls.Add(this.nud_fiyat);
            this.Controls.Add(this.tb_urunAdi);
            this.Controls.Add(this.btn_listeyiYenile);
            this.Controls.Add(this.btn_seciliUrunuGuncelle);
            this.Controls.Add(this.btn_seciliUrunuSil);
            this.Controls.Add(this.btn_urunEkle);
            this.Controls.Add(this.btn_xmlAktar);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DomTedarik";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_fiyat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_miktar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_xmlAktar;
        private System.Windows.Forms.Button btn_urunEkle;
        private System.Windows.Forms.Button btn_seciliUrunuSil;
        private System.Windows.Forms.Button btn_seciliUrunuGuncelle;
        private System.Windows.Forms.Button btn_listeyiYenile;
        private System.Windows.Forms.TextBox tb_urunAdi;
        private System.Windows.Forms.NumericUpDown nud_fiyat;
        private System.Windows.Forms.NumericUpDown nud_miktar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

