namespace Vautour
{
    partial class menu
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
            this.label1 = new System.Windows.Forms.Label();
            this.cb_nbJ = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_menuJouer = new System.Windows.Forms.Button();
            this.lb_IA1 = new System.Windows.Forms.Label();
            this.cb_diffIA1 = new System.Windows.Forms.ComboBox();
            this.lb_IA2 = new System.Windows.Forms.Label();
            this.cb_diffIA2 = new System.Windows.Forms.ComboBox();
            this.lb_IA4 = new System.Windows.Forms.Label();
            this.cb_diffIA4 = new System.Windows.Forms.ComboBox();
            this.lb_IA3 = new System.Windows.Forms.Label();
            this.cb_diffIA3 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Miramonte", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Menu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cb_nbJ
            // 
            this.cb_nbJ.BackColor = System.Drawing.SystemColors.Menu;
            this.cb_nbJ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_nbJ.FormattingEnabled = true;
            this.cb_nbJ.Location = new System.Drawing.Point(118, 67);
            this.cb_nbJ.Name = "cb_nbJ";
            this.cb_nbJ.Size = new System.Drawing.Size(121, 21);
            this.cb_nbJ.TabIndex = 1;
            this.cb_nbJ.SelectedIndexChanged += new System.EventHandler(this.cb_nbJ_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Miramonte", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre de joueurs";
            // 
            // bt_menuJouer
            // 
            this.bt_menuJouer.Location = new System.Drawing.Point(105, 247);
            this.bt_menuJouer.Name = "bt_menuJouer";
            this.bt_menuJouer.Size = new System.Drawing.Size(75, 23);
            this.bt_menuJouer.TabIndex = 3;
            this.bt_menuJouer.Text = "Jouer";
            this.bt_menuJouer.UseVisualStyleBackColor = true;
            this.bt_menuJouer.Click += new System.EventHandler(this.bt_menuJouer_Click);
            // 
            // lb_IA1
            // 
            this.lb_IA1.AutoSize = true;
            this.lb_IA1.Font = new System.Drawing.Font("Miramonte", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_IA1.Location = new System.Drawing.Point(45, 106);
            this.lb_IA1.Name = "lb_IA1";
            this.lb_IA1.Size = new System.Drawing.Size(26, 14);
            this.lb_IA1.TabIndex = 4;
            this.lb_IA1.Text = "IA1";
            // 
            // cb_diffIA1
            // 
            this.cb_diffIA1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_diffIA1.FormattingEnabled = true;
            this.cb_diffIA1.Location = new System.Drawing.Point(80, 103);
            this.cb_diffIA1.Name = "cb_diffIA1";
            this.cb_diffIA1.Size = new System.Drawing.Size(121, 21);
            this.cb_diffIA1.TabIndex = 5;
            // 
            // lb_IA2
            // 
            this.lb_IA2.AutoSize = true;
            this.lb_IA2.Font = new System.Drawing.Font("Miramonte", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_IA2.Location = new System.Drawing.Point(45, 142);
            this.lb_IA2.Name = "lb_IA2";
            this.lb_IA2.Size = new System.Drawing.Size(26, 14);
            this.lb_IA2.TabIndex = 4;
            this.lb_IA2.Text = "IA2";
            // 
            // cb_diffIA2
            // 
            this.cb_diffIA2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_diffIA2.FormattingEnabled = true;
            this.cb_diffIA2.Location = new System.Drawing.Point(80, 139);
            this.cb_diffIA2.Name = "cb_diffIA2";
            this.cb_diffIA2.Size = new System.Drawing.Size(121, 21);
            this.cb_diffIA2.TabIndex = 5;
            // 
            // lb_IA4
            // 
            this.lb_IA4.AutoSize = true;
            this.lb_IA4.Font = new System.Drawing.Font("Miramonte", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_IA4.Location = new System.Drawing.Point(45, 223);
            this.lb_IA4.Name = "lb_IA4";
            this.lb_IA4.Size = new System.Drawing.Size(26, 14);
            this.lb_IA4.TabIndex = 4;
            this.lb_IA4.Text = "IA4";
            // 
            // cb_diffIA4
            // 
            this.cb_diffIA4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_diffIA4.FormattingEnabled = true;
            this.cb_diffIA4.Location = new System.Drawing.Point(80, 220);
            this.cb_diffIA4.Name = "cb_diffIA4";
            this.cb_diffIA4.Size = new System.Drawing.Size(121, 21);
            this.cb_diffIA4.TabIndex = 5;
            // 
            // lb_IA3
            // 
            this.lb_IA3.AutoSize = true;
            this.lb_IA3.Font = new System.Drawing.Font("Miramonte", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_IA3.Location = new System.Drawing.Point(45, 186);
            this.lb_IA3.Name = "lb_IA3";
            this.lb_IA3.Size = new System.Drawing.Size(26, 14);
            this.lb_IA3.TabIndex = 4;
            this.lb_IA3.Text = "IA3";
            // 
            // cb_diffIA3
            // 
            this.cb_diffIA3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_diffIA3.FormattingEnabled = true;
            this.cb_diffIA3.Location = new System.Drawing.Point(80, 183);
            this.cb_diffIA3.Name = "cb_diffIA3";
            this.cb_diffIA3.Size = new System.Drawing.Size(121, 21);
            this.cb_diffIA3.TabIndex = 5;
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(262, 298);
            this.Controls.Add(this.cb_diffIA3);
            this.Controls.Add(this.cb_diffIA4);
            this.Controls.Add(this.cb_diffIA2);
            this.Controls.Add(this.cb_diffIA1);
            this.Controls.Add(this.lb_IA3);
            this.Controls.Add(this.lb_IA4);
            this.Controls.Add(this.lb_IA2);
            this.Controls.Add(this.lb_IA1);
            this.Controls.Add(this.bt_menuJouer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_nbJ);
            this.Controls.Add(this.label1);
            this.Name = "menu";
            this.Text = "Stupid vautour";
            this.TransparencyKey = System.Drawing.Color.White;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_nbJ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_menuJouer;
        private System.Windows.Forms.Label lb_IA1;
        private System.Windows.Forms.ComboBox cb_diffIA1;
        private System.Windows.Forms.Label lb_IA2;
        private System.Windows.Forms.ComboBox cb_diffIA2;
        private System.Windows.Forms.Label lb_IA4;
        private System.Windows.Forms.ComboBox cb_diffIA4;
        private System.Windows.Forms.Label lb_IA3;
        private System.Windows.Forms.ComboBox cb_diffIA3;
    }
}