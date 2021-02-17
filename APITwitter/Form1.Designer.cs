namespace APITwitter
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
            this.button1 = new System.Windows.Forms.Button();
            this.tabInicio = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstFecha = new System.Windows.Forms.ListView();
            this.lstSeguidores = new System.Windows.Forms.ListView();
            this.lstIdiomas = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.cboHashtags = new System.Windows.Forms.ComboBox();
            this.lstTweets = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInicio.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Maiandra GD", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(338, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(443, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Rank";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabInicio
            // 
            this.tabInicio.Controls.Add(this.label4);
            this.tabInicio.Controls.Add(this.label3);
            this.tabInicio.Controls.Add(this.lstFecha);
            this.tabInicio.Controls.Add(this.lstSeguidores);
            this.tabInicio.Controls.Add(this.button1);
            this.tabInicio.Controls.Add(this.lstIdiomas);
            this.tabInicio.Controls.Add(this.label2);
            this.tabInicio.Controls.Add(this.cboHashtags);
            this.tabInicio.Controls.Add(this.lstTweets);
            this.tabInicio.Controls.Add(this.label1);
            this.tabInicio.Location = new System.Drawing.Point(4, 22);
            this.tabInicio.Name = "tabInicio";
            this.tabInicio.Padding = new System.Windows.Forms.Padding(3);
            this.tabInicio.Size = new System.Drawing.Size(1057, 608);
            this.tabInicio.TabIndex = 0;
            this.tabInicio.Text = "Inicio";
            this.tabInicio.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(825, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 27);
            this.label4.TabIndex = 12;
            this.label4.Text = "Día con mayor actividad";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(825, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 62);
            this.label3.TabIndex = 11;
            this.label3.Text = "TOP 5                        Usuarios con más Followers";
            // 
            // lstFecha
            // 
            this.lstFecha.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lstFecha.HideSelection = false;
            this.lstFecha.Location = new System.Drawing.Point(825, 43);
            this.lstFecha.Name = "lstFecha";
            this.lstFecha.Size = new System.Drawing.Size(204, 131);
            this.lstFecha.TabIndex = 10;
            this.lstFecha.UseCompatibleStateImageBehavior = false;
            this.lstFecha.View = System.Windows.Forms.View.Details;
            // 
            // lstSeguidores
            // 
            this.lstSeguidores.BackColor = System.Drawing.Color.Thistle;
            this.lstSeguidores.HideSelection = false;
            this.lstSeguidores.Location = new System.Drawing.Point(825, 255);
            this.lstSeguidores.Name = "lstSeguidores";
            this.lstSeguidores.Size = new System.Drawing.Size(204, 131);
            this.lstSeguidores.TabIndex = 9;
            this.lstSeguidores.UseCompatibleStateImageBehavior = false;
            this.lstSeguidores.View = System.Windows.Forms.View.Details;
            // 
            // lstIdiomas
            // 
            this.lstIdiomas.BackColor = System.Drawing.Color.Wheat;
            this.lstIdiomas.HideSelection = false;
            this.lstIdiomas.Location = new System.Drawing.Point(825, 457);
            this.lstIdiomas.Name = "lstIdiomas";
            this.lstIdiomas.Size = new System.Drawing.Size(204, 131);
            this.lstIdiomas.TabIndex = 8;
            this.lstIdiomas.UseCompatibleStateImageBehavior = false;
            this.lstIdiomas.View = System.Windows.Forms.View.Details;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "HASHTAGS :";
            // 
            // cboHashtags
            // 
            this.cboHashtags.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboHashtags.FormattingEnabled = true;
            this.cboHashtags.Location = new System.Drawing.Point(170, 31);
            this.cboHashtags.Name = "cboHashtags";
            this.cboHashtags.Size = new System.Drawing.Size(135, 28);
            this.cboHashtags.TabIndex = 5;
            // 
            // lstTweets
            // 
            this.lstTweets.HideSelection = false;
            this.lstTweets.Location = new System.Drawing.Point(30, 74);
            this.lstTweets.Name = "lstTweets";
            this.lstTweets.Size = new System.Drawing.Size(763, 504);
            this.lstTweets.TabIndex = 0;
            this.lstTweets.UseCompatibleStateImageBehavior = false;
            this.lstTweets.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(825, 413);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 48);
            this.label1.TabIndex = 4;
            this.label1.Text = "TOP 3                        Idiomas más utilizados";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabInicio);
            this.tabControl1.Location = new System.Drawing.Point(10, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1065, 634);
            this.tabControl1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1085, 649);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "API Twitter | Prueba NODEL - Dúber Medina";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabInicio.ResumeLayout(false);
            this.tabInicio.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabInicio;
        private System.Windows.Forms.ListView lstTweets;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboHashtags;
        private System.Windows.Forms.ListView lstIdiomas;
        private System.Windows.Forms.ListView lstSeguidores;
        private System.Windows.Forms.ListView lstFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

