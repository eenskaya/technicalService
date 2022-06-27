
namespace teknikServis
{
    partial class Form6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ilk_tarih = new System.Windows.Forms.DateTimePicker();
            this.ikinci_tarih = new System.Windows.Forms.DateTimePicker();
            this.button6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toplam_tl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 303);
            this.dataGridView1.TabIndex = 72;
            // 
            // ilk_tarih
            // 
            this.ilk_tarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ilk_tarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ilk_tarih.Location = new System.Drawing.Point(12, 17);
            this.ilk_tarih.Name = "ilk_tarih";
            this.ilk_tarih.Size = new System.Drawing.Size(200, 26);
            this.ilk_tarih.TabIndex = 73;
            // 
            // ikinci_tarih
            // 
            this.ikinci_tarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ikinci_tarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ikinci_tarih.Location = new System.Drawing.Point(218, 17);
            this.ikinci_tarih.Name = "ikinci_tarih";
            this.ikinci_tarih.Size = new System.Drawing.Size(200, 26);
            this.ikinci_tarih.TabIndex = 74;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button6.ForeColor = System.Drawing.Color.Purple;
            this.button6.Location = new System.Drawing.Point(424, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(140, 31);
            this.button6.TabIndex = 75;
            this.button6.Text = "Sırala";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(596, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "İki  tarih arasında kazanılan kazanç:";
            // 
            // toplam_tl
            // 
            this.toplam_tl.AutoSize = true;
            this.toplam_tl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toplam_tl.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toplam_tl.Location = new System.Drawing.Point(663, 23);
            this.toplam_tl.Name = "toplam_tl";
            this.toplam_tl.Size = new System.Drawing.Size(0, 20);
            this.toplam_tl.TabIndex = 77;
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 381);
            this.Controls.Add(this.toplam_tl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.ikinci_tarih);
            this.Controls.Add(this.ilk_tarih);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teknik Servis Rapor";
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker ilk_tarih;
        private System.Windows.Forms.DateTimePicker ikinci_tarih;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label toplam_tl;
    }
}