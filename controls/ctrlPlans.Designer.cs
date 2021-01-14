
namespace ProVantagensApp
{
    partial class ctrlPlans
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
            this.menuTab = new System.Windows.Forms.MenuStrip();
            this.removerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adicionarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.idPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namePlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typePlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valuePlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnTop = new System.Windows.Forms.Panel();
            this.cboSearch = new System.Windows.Forms.ComboBox();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.menuTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuTab
            // 
            this.menuTab.BackColor = System.Drawing.Color.Transparent;
            this.menuTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removerToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.adicionarToolStripMenuItem});
            this.menuTab.Location = new System.Drawing.Point(8, 0);
            this.menuTab.Name = "menuTab";
            this.menuTab.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuTab.Size = new System.Drawing.Size(666, 24);
            this.menuTab.TabIndex = 0;
            this.menuTab.Text = "menuStrip1";
            // 
            // removerToolStripMenuItem
            // 
            this.removerToolStripMenuItem.Name = "removerToolStripMenuItem";
            this.removerToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.removerToolStripMenuItem.Text = "Remover";
            this.removerToolStripMenuItem.Click += new System.EventHandler(this.removerToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // adicionarToolStripMenuItem
            // 
            this.adicionarToolStripMenuItem.Name = "adicionarToolStripMenuItem";
            this.adicionarToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.adicionarToolStripMenuItem.Text = "Adicionar";
            this.adicionarToolStripMenuItem.Click += new System.EventHandler(this.adicionarToolStripMenuItem_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.BackgroundColor = System.Drawing.Color.White;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPlan,
            this.namePlan,
            this.descriptionPlan,
            this.typePlan,
            this.valuePlan});
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(8, 52);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(16);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(666, 585);
            this.dataGrid.TabIndex = 1;
            this.dataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellClick);
            // 
            // idPlan
            // 
            this.idPlan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.idPlan.HeaderText = "ID";
            this.idPlan.Name = "idPlan";
            this.idPlan.ReadOnly = true;
            this.idPlan.Width = 43;
            // 
            // namePlan
            // 
            this.namePlan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.namePlan.HeaderText = "Nome do plano";
            this.namePlan.Name = "namePlan";
            this.namePlan.ReadOnly = true;
            // 
            // descriptionPlan
            // 
            this.descriptionPlan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionPlan.HeaderText = "Descrição do plano";
            this.descriptionPlan.Name = "descriptionPlan";
            this.descriptionPlan.ReadOnly = true;
            // 
            // typePlan
            // 
            this.typePlan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.typePlan.HeaderText = "Tipo de plano";
            this.typePlan.Name = "typePlan";
            this.typePlan.ReadOnly = true;
            // 
            // valuePlan
            // 
            this.valuePlan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valuePlan.HeaderText = "Valor do plano";
            this.valuePlan.Name = "valuePlan";
            this.valuePlan.ReadOnly = true;
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.cboSearch);
            this.pnTop.Controls.Add(this.btnShowAll);
            this.pnTop.Controls.Add(this.btnSearch);
            this.pnTop.Controls.Add(this.lbSearch);
            this.pnTop.Controls.Add(this.txtSearch);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(8, 24);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(666, 28);
            this.pnTop.TabIndex = 5;
            // 
            // cboSearch
            // 
            this.cboSearch.FormattingEnabled = true;
            this.cboSearch.Location = new System.Drawing.Point(63, 4);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.Size = new System.Drawing.Size(121, 21);
            this.cboSearch.TabIndex = 3;
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(565, 3);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(98, 23);
            this.btnShowAll.TabIndex = 2;
            this.btnShowAll.Text = "Mostrar todos";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(484, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(3, 8);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(64, 13);
            this.lbSearch.TabIndex = 1;
            this.lbSearch.Text = "Buscar por :";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(190, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(288, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // ctrlPlans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.pnTop);
            this.Controls.Add(this.menuTab);
            this.Name = "ctrlPlans";
            this.Padding = new System.Windows.Forms.Padding(8, 0, 8, 8);
            this.Size = new System.Drawing.Size(682, 645);
            this.Load += new System.EventHandler(this.ctrlPlans_LoadAsync);
            this.menuTab.ResumeLayout(false);
            this.menuTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuTab;
        private System.Windows.Forms.ToolStripMenuItem removerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adicionarToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn namePlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionPlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn typePlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn valuePlan;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.ComboBox cboSearch;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.TextBox txtSearch;
    }
}
