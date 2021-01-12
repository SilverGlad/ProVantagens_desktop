
namespace ProVantagensApp
{
    partial class ctrlHome
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

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbImg = new System.Windows.Forms.Panel();
            this.lbRight = new System.Windows.Forms.Label();
            this.imgHome = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adicionarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbLeft = new System.Windows.Forms.Label();
            this.gbImg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgHome)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbImg
            // 
            this.gbImg.BackColor = System.Drawing.Color.White;
            this.gbImg.Controls.Add(this.lbLeft);
            this.gbImg.Controls.Add(this.lbRight);
            this.gbImg.Controls.Add(this.imgHome);
            this.gbImg.Controls.Add(this.menuStrip1);
            this.gbImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbImg.Location = new System.Drawing.Point(8, 0);
            this.gbImg.Name = "gbImg";
            this.gbImg.Size = new System.Drawing.Size(666, 637);
            this.gbImg.TabIndex = 2;
            // 
            // lbRight
            // 
            this.lbRight.BackColor = System.Drawing.Color.Transparent;
            this.lbRight.Location = new System.Drawing.Point(562, 24);
            this.lbRight.Name = "lbRight";
            this.lbRight.Size = new System.Drawing.Size(100, 613);
            this.lbRight.TabIndex = 3;
            this.lbRight.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // imgHome
            // 
            this.imgHome.BackColor = System.Drawing.Color.Transparent;
            this.imgHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgHome.Location = new System.Drawing.Point(0, 24);
            this.imgHome.Name = "imgHome";
            this.imgHome.Size = new System.Drawing.Size(666, 613);
            this.imgHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgHome.TabIndex = 0;
            this.imgHome.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarToolStripMenuItem,
            this.removerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(666, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adicionarToolStripMenuItem
            // 
            this.adicionarToolStripMenuItem.Name = "adicionarToolStripMenuItem";
            this.adicionarToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.adicionarToolStripMenuItem.Text = "Adicionar";
            this.adicionarToolStripMenuItem.Click += new System.EventHandler(this.adicionarToolStripMenuItem_Click);
            // 
            // removerToolStripMenuItem
            // 
            this.removerToolStripMenuItem.Name = "removerToolStripMenuItem";
            this.removerToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.removerToolStripMenuItem.Text = "Remover";
            this.removerToolStripMenuItem.Click += new System.EventHandler(this.removerToolStripMenuItem_Click);
            // 
            // lbLeft
            // 
            this.lbLeft.BackColor = System.Drawing.Color.Transparent;
            this.lbLeft.Location = new System.Drawing.Point(1, 24);
            this.lbLeft.Name = "lbLeft";
            this.lbLeft.Size = new System.Drawing.Size(100, 613);
            this.lbLeft.TabIndex = 3;
            this.lbLeft.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ctrlHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbImg);
            this.Name = "ctrlHome";
            this.Padding = new System.Windows.Forms.Padding(8, 0, 8, 8);
            this.Size = new System.Drawing.Size(682, 645);
            this.Load += new System.EventHandler(this.ctrlHome_Load);
            this.gbImg.ResumeLayout(false);
            this.gbImg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgHome)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel gbImg;
        private System.Windows.Forms.PictureBox imgHome;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adicionarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removerToolStripMenuItem;
        private System.Windows.Forms.Label lbRight;
        private System.Windows.Forms.Label lbLeft;
    }
}
