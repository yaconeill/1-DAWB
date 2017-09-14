namespace Win3enraya
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.B22 = new System.Windows.Forms.Button();
            this.B21 = new System.Windows.Forms.Button();
            this.B20 = new System.Windows.Forms.Button();
            this.B12 = new System.Windows.Forms.Button();
            this.B11 = new System.Windows.Forms.Button();
            this.B10 = new System.Windows.Forms.Button();
            this.B02 = new System.Windows.Forms.Button();
            this.B01 = new System.Windows.Forms.Button();
            this.B00 = new System.Windows.Forms.Button();
            this.BInicia = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Won = new System.Windows.Forms.TextBox();
            this.Lwon = new System.Windows.Forms.Label();
            this.Llost = new System.Windows.Forms.Label();
            this.Lost = new System.Windows.Forms.TextBox();
            this.Ldraw = new System.Windows.Forms.Label();
            this.Draw = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.B22);
            this.panel1.Controls.Add(this.B21);
            this.panel1.Controls.Add(this.B20);
            this.panel1.Controls.Add(this.B12);
            this.panel1.Controls.Add(this.B11);
            this.panel1.Controls.Add(this.B10);
            this.panel1.Controls.Add(this.B02);
            this.panel1.Controls.Add(this.B01);
            this.panel1.Controls.Add(this.B00);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // B22
            // 
            resources.ApplyResources(this.B22, "B22");
            this.B22.ForeColor = System.Drawing.Color.Lime;
            this.B22.Name = "B22";
            this.B22.UseVisualStyleBackColor = true;
            this.B22.Click += new System.EventHandler(this.Movimiento);
            // 
            // B21
            // 
            resources.ApplyResources(this.B21, "B21");
            this.B21.ForeColor = System.Drawing.Color.Lime;
            this.B21.Name = "B21";
            this.B21.UseVisualStyleBackColor = true;
            this.B21.Click += new System.EventHandler(this.Movimiento);
            // 
            // B20
            // 
            resources.ApplyResources(this.B20, "B20");
            this.B20.ForeColor = System.Drawing.Color.Lime;
            this.B20.Name = "B20";
            this.B20.UseVisualStyleBackColor = true;
            this.B20.Click += new System.EventHandler(this.Movimiento);
            // 
            // B12
            // 
            resources.ApplyResources(this.B12, "B12");
            this.B12.ForeColor = System.Drawing.Color.Lime;
            this.B12.Name = "B12";
            this.B12.UseVisualStyleBackColor = true;
            this.B12.Click += new System.EventHandler(this.Movimiento);
            // 
            // B11
            // 
            resources.ApplyResources(this.B11, "B11");
            this.B11.ForeColor = System.Drawing.Color.Lime;
            this.B11.Name = "B11";
            this.B11.UseVisualStyleBackColor = true;
            this.B11.Click += new System.EventHandler(this.Movimiento);
            // 
            // B10
            // 
            resources.ApplyResources(this.B10, "B10");
            this.B10.ForeColor = System.Drawing.Color.Lime;
            this.B10.Name = "B10";
            this.B10.UseVisualStyleBackColor = true;
            this.B10.Click += new System.EventHandler(this.Movimiento);
            // 
            // B02
            // 
            resources.ApplyResources(this.B02, "B02");
            this.B02.ForeColor = System.Drawing.Color.Lime;
            this.B02.Name = "B02";
            this.B02.UseVisualStyleBackColor = true;
            this.B02.Click += new System.EventHandler(this.Movimiento);
            // 
            // B01
            // 
            resources.ApplyResources(this.B01, "B01");
            this.B01.ForeColor = System.Drawing.Color.Lime;
            this.B01.Name = "B01";
            this.B01.UseVisualStyleBackColor = true;
            this.B01.Click += new System.EventHandler(this.Movimiento);
            // 
            // B00
            // 
            resources.ApplyResources(this.B00, "B00");
            this.B00.ForeColor = System.Drawing.Color.Lime;
            this.B00.Name = "B00";
            this.B00.UseVisualStyleBackColor = true;
            this.B00.Click += new System.EventHandler(this.Movimiento);
            // 
            // BInicia
            // 
            this.BInicia.BackColor = System.Drawing.Color.ForestGreen;
            resources.ApplyResources(this.BInicia, "BInicia");
            this.BInicia.ForeColor = System.Drawing.Color.Lime;
            this.BInicia.Name = "BInicia";
            this.BInicia.UseVisualStyleBackColor = false;
            this.BInicia.Click += new System.EventHandler(this.BInicia_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Name = "label1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Tomato;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // Won
            // 
            resources.ApplyResources(this.Won, "Won");
            this.Won.Name = "Won";
            this.Won.ReadOnly = true;
            // 
            // Lwon
            // 
            resources.ApplyResources(this.Lwon, "Lwon");
            this.Lwon.BackColor = System.Drawing.Color.Transparent;
            this.Lwon.Name = "Lwon";
            // 
            // Llost
            // 
            resources.ApplyResources(this.Llost, "Llost");
            this.Llost.BackColor = System.Drawing.Color.Transparent;
            this.Llost.Name = "Llost";
            // 
            // Lost
            // 
            resources.ApplyResources(this.Lost, "Lost");
            this.Lost.Name = "Lost";
            this.Lost.ReadOnly = true;
            // 
            // Ldraw
            // 
            resources.ApplyResources(this.Ldraw, "Ldraw");
            this.Ldraw.BackColor = System.Drawing.Color.Transparent;
            this.Ldraw.Name = "Ldraw";
            // 
            // Draw
            // 
            resources.ApplyResources(this.Draw, "Draw");
            this.Draw.Name = "Draw";
            this.Draw.ReadOnly = true;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Win3enraya.Properties.Resources.tic_tac_toe_game_wallpaper_800x480;
            this.Controls.Add(this.Ldraw);
            this.Controls.Add(this.Draw);
            this.Controls.Add(this.Llost);
            this.Controls.Add(this.Lost);
            this.Controls.Add(this.Lwon);
            this.Controls.Add(this.Won);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BInicia);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button B22;
        private System.Windows.Forms.Button B21;
        private System.Windows.Forms.Button B20;
        private System.Windows.Forms.Button B12;
        private System.Windows.Forms.Button B11;
        private System.Windows.Forms.Button B10;
        private System.Windows.Forms.Button B02;
        private System.Windows.Forms.Button B01;
        private System.Windows.Forms.Button B00;
        private System.Windows.Forms.Button BInicia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Won;
        private System.Windows.Forms.Label Lwon;
        private System.Windows.Forms.Label Llost;
        private System.Windows.Forms.TextBox Lost;
        private System.Windows.Forms.Label Ldraw;
        private System.Windows.Forms.TextBox Draw;
    }
}

