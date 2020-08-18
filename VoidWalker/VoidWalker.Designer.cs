namespace VoidWalker
{
    partial class VoidWalker
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbBox_Champion = new System.Windows.Forms.ComboBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.txtbox_Chat = new System.Windows.Forms.TextBox();
            this.lbl_Chat = new System.Windows.Forms.Label();
            this.lbl_Champions = new System.Windows.Forms.Label();
            this.num_Times = new System.Windows.Forms.NumericUpDown();
            this.lbl_Times = new System.Windows.Forms.Label();
            this.lbl_SummonerSpells = new System.Windows.Forms.Label();
            this.pctBox_FirstSpell = new System.Windows.Forms.PictureBox();
            this.pctBox_Spell = new System.Windows.Forms.PictureBox();
            this.lbl_FirstSpell = new System.Windows.Forms.Label();
            this.lbl_SecondSpell = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_Times)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBox_FirstSpell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBox_Spell)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbBox_Champion
            // 
            this.cmbBox_Champion.FormattingEnabled = true;
            this.cmbBox_Champion.Location = new System.Drawing.Point(35, 36);
            this.cmbBox_Champion.Name = "cmbBox_Champion";
            this.cmbBox_Champion.Size = new System.Drawing.Size(146, 21);
            this.cmbBox_Champion.TabIndex = 0;
            // 
            // btn_Start
            // 
            this.btn_Start.BackColor = System.Drawing.SystemColors.Window;
            this.btn_Start.Font = new System.Drawing.Font("Colfax", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Start.Location = new System.Drawing.Point(35, 262);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_Start.Size = new System.Drawing.Size(146, 43);
            this.btn_Start.TabIndex = 1;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = false;
            this.btn_Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtbox_Chat
            // 
            this.txtbox_Chat.Location = new System.Drawing.Point(35, 104);
            this.txtbox_Chat.Name = "txtbox_Chat";
            this.txtbox_Chat.Size = new System.Drawing.Size(104, 20);
            this.txtbox_Chat.TabIndex = 3;
            // 
            // lbl_Chat
            // 
            this.lbl_Chat.AutoSize = true;
            this.lbl_Chat.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_Chat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_Chat.Location = new System.Drawing.Point(32, 86);
            this.lbl_Chat.Name = "lbl_Chat";
            this.lbl_Chat.Size = new System.Drawing.Size(32, 13);
            this.lbl_Chat.TabIndex = 4;
            this.lbl_Chat.Text = "Chat:";
            this.lbl_Chat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Champions
            // 
            this.lbl_Champions.AutoSize = true;
            this.lbl_Champions.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_Champions.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_Champions.Location = new System.Drawing.Point(32, 20);
            this.lbl_Champions.Name = "lbl_Champions";
            this.lbl_Champions.Size = new System.Drawing.Size(57, 13);
            this.lbl_Champions.TabIndex = 5;
            this.lbl_Champions.Text = "Champion:";
            // 
            // num_Times
            // 
            this.num_Times.Location = new System.Drawing.Point(145, 104);
            this.num_Times.Name = "num_Times";
            this.num_Times.Size = new System.Drawing.Size(36, 20);
            this.num_Times.TabIndex = 6;
            this.num_Times.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl_Times
            // 
            this.lbl_Times.AutoSize = true;
            this.lbl_Times.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_Times.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_Times.Location = new System.Drawing.Point(142, 86);
            this.lbl_Times.Name = "lbl_Times";
            this.lbl_Times.Size = new System.Drawing.Size(35, 13);
            this.lbl_Times.TabIndex = 4;
            this.lbl_Times.Text = "Times";
            this.lbl_Times.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_SummonerSpells
            // 
            this.lbl_SummonerSpells.AutoSize = true;
            this.lbl_SummonerSpells.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_SummonerSpells.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_SummonerSpells.Location = new System.Drawing.Point(32, 152);
            this.lbl_SummonerSpells.Name = "lbl_SummonerSpells";
            this.lbl_SummonerSpells.Size = new System.Drawing.Size(91, 13);
            this.lbl_SummonerSpells.TabIndex = 7;
            this.lbl_SummonerSpells.Text = "Summoner Spells:";
            // 
            // pctBox_FirstSpell
            // 
            this.pctBox_FirstSpell.Location = new System.Drawing.Point(35, 195);
            this.pctBox_FirstSpell.Name = "pctBox_FirstSpell";
            this.pctBox_FirstSpell.Size = new System.Drawing.Size(54, 48);
            this.pctBox_FirstSpell.TabIndex = 8;
            this.pctBox_FirstSpell.TabStop = false;
            // 
            // pctBox_Spell
            // 
            this.pctBox_Spell.Location = new System.Drawing.Point(123, 195);
            this.pctBox_Spell.Name = "pctBox_Spell";
            this.pctBox_Spell.Size = new System.Drawing.Size(54, 48);
            this.pctBox_Spell.TabIndex = 8;
            this.pctBox_Spell.TabStop = false;
            // 
            // lbl_FirstSpell
            // 
            this.lbl_FirstSpell.AutoSize = true;
            this.lbl_FirstSpell.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_FirstSpell.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_FirstSpell.Location = new System.Drawing.Point(55, 179);
            this.lbl_FirstSpell.Name = "lbl_FirstSpell";
            this.lbl_FirstSpell.Size = new System.Drawing.Size(15, 13);
            this.lbl_FirstSpell.TabIndex = 9;
            this.lbl_FirstSpell.Text = "D";
            // 
            // lbl_SecondSpell
            // 
            this.lbl_SecondSpell.AutoSize = true;
            this.lbl_SecondSpell.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_SecondSpell.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_SecondSpell.Location = new System.Drawing.Point(144, 179);
            this.lbl_SecondSpell.Name = "lbl_SecondSpell";
            this.lbl_SecondSpell.Size = new System.Drawing.Size(13, 13);
            this.lbl_SecondSpell.TabIndex = 9;
            this.lbl_SecondSpell.Text = "F";
            // 
            // VoidWalker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(215, 351);
            this.Controls.Add(this.lbl_SecondSpell);
            this.Controls.Add(this.lbl_FirstSpell);
            this.Controls.Add(this.pctBox_Spell);
            this.Controls.Add(this.pctBox_FirstSpell);
            this.Controls.Add(this.lbl_SummonerSpells);
            this.Controls.Add(this.num_Times);
            this.Controls.Add(this.lbl_Champions);
            this.Controls.Add(this.lbl_Times);
            this.Controls.Add(this.lbl_Chat);
            this.Controls.Add(this.txtbox_Chat);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.cmbBox_Champion);
            this.Name = "VoidWalker";
            this.Text = "VoidWalker";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_Times)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBox_FirstSpell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBox_Spell)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBox_Champion;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.TextBox txtbox_Chat;
        private System.Windows.Forms.Label lbl_Chat;
        private System.Windows.Forms.Label lbl_Champions;
        private System.Windows.Forms.NumericUpDown num_Times;
        private System.Windows.Forms.Label lbl_Times;
        private System.Windows.Forms.Label lbl_SummonerSpells;
        private System.Windows.Forms.PictureBox pctBox_FirstSpell;
        private System.Windows.Forms.PictureBox pctBox_Spell;
        private System.Windows.Forms.Label lbl_FirstSpell;
        private System.Windows.Forms.Label lbl_SecondSpell;
    }
}

