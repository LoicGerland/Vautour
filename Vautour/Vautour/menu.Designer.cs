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
            this.label3 = new System.Windows.Forms.Label();
            this.tb_P1_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_IA1 = new System.Windows.Forms.TextBox();
            this.tb_IA2 = new System.Windows.Forms.TextBox();
            this.tb_IA3 = new System.Windows.Forms.TextBox();
            this.tb_IA4 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.règleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Miramonte", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(112, 24);
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
            this.bt_menuJouer.Location = new System.Drawing.Point(118, 306);
            this.bt_menuJouer.Name = "bt_menuJouer";
            this.bt_menuJouer.Size = new System.Drawing.Size(75, 23);
            this.bt_menuJouer.TabIndex = 11;
            this.bt_menuJouer.Text = "Jouer";
            this.bt_menuJouer.UseVisualStyleBackColor = true;
            this.bt_menuJouer.Click += new System.EventHandler(this.bt_menuJouer_Click);
            // 
            // lb_IA1
            // 
            this.lb_IA1.AutoSize = true;
            this.lb_IA1.Font = new System.Drawing.Font("Miramonte", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_IA1.Location = new System.Drawing.Point(10, 146);
            this.lb_IA1.Name = "lb_IA1";
            this.lb_IA1.Size = new System.Drawing.Size(26, 14);
            this.lb_IA1.TabIndex = 4;
            this.lb_IA1.Text = "IA1";
            // 
            // cb_diffIA1
            // 
            this.cb_diffIA1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_diffIA1.FormattingEnabled = true;
            this.cb_diffIA1.Location = new System.Drawing.Point(45, 143);
            this.cb_diffIA1.Name = "cb_diffIA1";
            this.cb_diffIA1.Size = new System.Drawing.Size(121, 21);
            this.cb_diffIA1.TabIndex = 3;
            // 
            // lb_IA2
            // 
            this.lb_IA2.AutoSize = true;
            this.lb_IA2.Font = new System.Drawing.Font("Miramonte", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_IA2.Location = new System.Drawing.Point(10, 185);
            this.lb_IA2.Name = "lb_IA2";
            this.lb_IA2.Size = new System.Drawing.Size(26, 14);
            this.lb_IA2.TabIndex = 4;
            this.lb_IA2.Text = "IA2";
            // 
            // cb_diffIA2
            // 
            this.cb_diffIA2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_diffIA2.FormattingEnabled = true;
            this.cb_diffIA2.Location = new System.Drawing.Point(45, 182);
            this.cb_diffIA2.Name = "cb_diffIA2";
            this.cb_diffIA2.Size = new System.Drawing.Size(121, 21);
            this.cb_diffIA2.TabIndex = 5;
            // 
            // lb_IA4
            // 
            this.lb_IA4.AutoSize = true;
            this.lb_IA4.Font = new System.Drawing.Font("Miramonte", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_IA4.Location = new System.Drawing.Point(10, 263);
            this.lb_IA4.Name = "lb_IA4";
            this.lb_IA4.Size = new System.Drawing.Size(26, 14);
            this.lb_IA4.TabIndex = 4;
            this.lb_IA4.Text = "IA4";
            // 
            // cb_diffIA4
            // 
            this.cb_diffIA4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_diffIA4.FormattingEnabled = true;
            this.cb_diffIA4.Location = new System.Drawing.Point(45, 260);
            this.cb_diffIA4.Name = "cb_diffIA4";
            this.cb_diffIA4.Size = new System.Drawing.Size(121, 21);
            this.cb_diffIA4.TabIndex = 9;
            // 
            // lb_IA3
            // 
            this.lb_IA3.AutoSize = true;
            this.lb_IA3.Font = new System.Drawing.Font("Miramonte", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_IA3.Location = new System.Drawing.Point(10, 226);
            this.lb_IA3.Name = "lb_IA3";
            this.lb_IA3.Size = new System.Drawing.Size(26, 14);
            this.lb_IA3.TabIndex = 4;
            this.lb_IA3.Text = "IA3";
            // 
            // cb_diffIA3
            // 
            this.cb_diffIA3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_diffIA3.FormattingEnabled = true;
            this.cb_diffIA3.Location = new System.Drawing.Point(45, 223);
            this.cb_diffIA3.Name = "cb_diffIA3";
            this.cb_diffIA3.Size = new System.Drawing.Size(121, 21);
            this.cb_diffIA3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Miramonte", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nom du joueur";
            // 
            // tb_P1_name
            // 
            this.tb_P1_name.BackColor = System.Drawing.SystemColors.Menu;
            this.tb_P1_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_P1_name.Location = new System.Drawing.Point(118, 94);
            this.tb_P1_name.Name = "tb_P1_name";
            this.tb_P1_name.Size = new System.Drawing.Size(100, 20);
            this.tb_P1_name.TabIndex = 2;
            this.tb_P1_name.Text = "Player One";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Miramonte", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Difficulté du BOT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Miramonte", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(196, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "Nom du BOT";
            // 
            // tb_IA1
            // 
            this.tb_IA1.BackColor = System.Drawing.SystemColors.Menu;
            this.tb_IA1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_IA1.Location = new System.Drawing.Point(199, 144);
            this.tb_IA1.Name = "tb_IA1";
            this.tb_IA1.Size = new System.Drawing.Size(100, 20);
            this.tb_IA1.TabIndex = 4;
            this.tb_IA1.Text = "BOT_Zizi";
            // 
            // tb_IA2
            // 
            this.tb_IA2.BackColor = System.Drawing.SystemColors.Menu;
            this.tb_IA2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_IA2.Enabled = false;
            this.tb_IA2.Location = new System.Drawing.Point(199, 182);
            this.tb_IA2.Name = "tb_IA2";
            this.tb_IA2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tb_IA2.Size = new System.Drawing.Size(100, 20);
            this.tb_IA2.TabIndex = 6;
            this.tb_IA2.Text = "BOT_Riri";
            // 
            // tb_IA3
            // 
            this.tb_IA3.BackColor = System.Drawing.SystemColors.Menu;
            this.tb_IA3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_IA3.Enabled = false;
            this.tb_IA3.Location = new System.Drawing.Point(199, 223);
            this.tb_IA3.Name = "tb_IA3";
            this.tb_IA3.Size = new System.Drawing.Size(100, 20);
            this.tb_IA3.TabIndex = 8;
            this.tb_IA3.Text = "BOT_Titi";
            // 
            // tb_IA4
            // 
            this.tb_IA4.BackColor = System.Drawing.SystemColors.Menu;
            this.tb_IA4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_IA4.Enabled = false;
            this.tb_IA4.Location = new System.Drawing.Point(199, 260);
            this.tb_IA4.Name = "tb_IA4";
            this.tb_IA4.Size = new System.Drawing.Size(100, 20);
            this.tb_IA4.TabIndex = 10;
            this.tb_IA4.Text = "BOT_pipi";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aideToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(317, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.règleToolStripMenuItem});
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.aideToolStripMenuItem.Text = "Aide";
            // 
            // règleToolStripMenuItem
            // 
            this.règleToolStripMenuItem.Name = "règleToolStripMenuItem";
            this.règleToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.règleToolStripMenuItem.Text = "Règle";
            this.règleToolStripMenuItem.Click += new System.EventHandler(this.règleToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(317, 342);
            this.Controls.Add(this.tb_IA4);
            this.Controls.Add(this.tb_IA3);
            this.Controls.Add(this.tb_IA2);
            this.Controls.Add(this.tb_IA1);
            this.Controls.Add(this.tb_P1_name);
            this.Controls.Add(this.cb_diffIA3);
            this.Controls.Add(this.cb_diffIA4);
            this.Controls.Add(this.cb_diffIA2);
            this.Controls.Add(this.cb_diffIA1);
            this.Controls.Add(this.lb_IA3);
            this.Controls.Add(this.lb_IA4);
            this.Controls.Add(this.lb_IA2);
            this.Controls.Add(this.lb_IA1);
            this.Controls.Add(this.bt_menuJouer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_nbJ);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(333, 380);
            this.MinimumSize = new System.Drawing.Size(333, 380);
            this.Name = "menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stupid vautour";
            this.TransparencyKey = System.Drawing.Color.White;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_nbJ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_menuJouer;
        private System.Windows.Forms.Label lb_IA1;
        private System.Windows.Forms.Label lb_IA2;
        private System.Windows.Forms.Label lb_IA4;
        private System.Windows.Forms.Label lb_IA3;
        internal System.Windows.Forms.ComboBox cb_diffIA1;
        internal System.Windows.Forms.ComboBox cb_diffIA2;
        internal System.Windows.Forms.ComboBox cb_diffIA4;
        internal System.Windows.Forms.ComboBox cb_diffIA3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_P1_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_IA1;
        private System.Windows.Forms.TextBox tb_IA2;
        private System.Windows.Forms.TextBox tb_IA3;
        private System.Windows.Forms.TextBox tb_IA4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem règleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
    }
}