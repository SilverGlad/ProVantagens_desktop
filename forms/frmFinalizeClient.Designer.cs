
namespace ProVantagensApp.forms
{
    partial class frmFinalizeClient
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.cboPaymentMethod = new System.Windows.Forms.ComboBox();
            this.txtPlanName = new System.Windows.Forms.TextBox();
            this.txtHolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAditional = new System.Windows.Forms.TextBox();
            this.txtTxAd = new System.Windows.Forms.TextBox();
            this.txtPlanValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnDependents = new System.Windows.Forms.GroupBox();
            this.btnAddDependent = new System.Windows.Forms.Button();
            this.txtDueDate = new System.Windows.Forms.MaskedTextBox();
            this.txtTotalValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnDependents.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDueDate);
            this.groupBox1.Controls.Add(this.cboPaymentMethod);
            this.groupBox1.Controls.Add(this.txtPlanName);
            this.groupBox1.Controls.Add(this.txtHolder);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 190);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnCancelar);
            this.groupBox4.Controls.Add(this.btnSalvar);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(0, 403);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(545, 100);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Controles";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(415, 40);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 34);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(6, 40);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 34);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentMethod.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.cboPaymentMethod.FormattingEnabled = true;
            this.cboPaymentMethod.Items.AddRange(new object[] {
            "Cartão de crédito",
            "Boleto",
            "CPFL"});
            this.cboPaymentMethod.Location = new System.Drawing.Point(220, 102);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(251, 24);
            this.cboPaymentMethod.TabIndex = 2;
            // 
            // txtPlanName
            // 
            this.txtPlanName.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.txtPlanName.Location = new System.Drawing.Point(156, 59);
            this.txtPlanName.Name = "txtPlanName";
            this.txtPlanName.ReadOnly = true;
            this.txtPlanName.Size = new System.Drawing.Size(315, 28);
            this.txtPlanName.TabIndex = 1;
            // 
            // txtHolder
            // 
            this.txtHolder.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.txtHolder.Location = new System.Drawing.Point(81, 19);
            this.txtHolder.Name = "txtHolder";
            this.txtHolder.ReadOnly = true;
            this.txtHolder.Size = new System.Drawing.Size(390, 28);
            this.txtHolder.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(6, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nome do plano:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(6, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Vencimento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(6, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Método de pagamento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Titular:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAditional);
            this.groupBox2.Controls.Add(this.txtTotalValue);
            this.groupBox2.Controls.Add(this.txtTxAd);
            this.groupBox2.Controls.Add(this.txtPlanValue);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 247);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(545, 156);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // txtAditional
            // 
            this.txtAditional.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.txtAditional.Location = new System.Drawing.Point(165, 50);
            this.txtAditional.Name = "txtAditional";
            this.txtAditional.ReadOnly = true;
            this.txtAditional.Size = new System.Drawing.Size(107, 28);
            this.txtAditional.TabIndex = 9;
            this.txtAditional.TextChanged += new System.EventHandler(this.txtAditional_TextChanged);
            // 
            // txtTxAd
            // 
            this.txtTxAd.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.txtTxAd.Location = new System.Drawing.Point(165, 84);
            this.txtTxAd.Name = "txtTxAd";
            this.txtTxAd.ReadOnly = true;
            this.txtTxAd.Size = new System.Drawing.Size(107, 28);
            this.txtTxAd.TabIndex = 7;
            // 
            // txtPlanValue
            // 
            this.txtPlanValue.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.txtPlanValue.Location = new System.Drawing.Point(165, 16);
            this.txtPlanValue.Name = "txtPlanValue";
            this.txtPlanValue.ReadOnly = true;
            this.txtPlanValue.Size = new System.Drawing.Size(107, 28);
            this.txtPlanValue.TabIndex = 8;
            this.txtPlanValue.TextChanged += new System.EventHandler(this.txtPlanValue_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(11, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Valor do plano:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(6, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "Taxa de adesão:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(58, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Adicional:";
            // 
            // pnDependents
            // 
            this.pnDependents.AutoSize = true;
            this.pnDependents.Controls.Add(this.btnAddDependent);
            this.pnDependents.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnDependents.Location = new System.Drawing.Point(0, 190);
            this.pnDependents.Name = "pnDependents";
            this.pnDependents.Size = new System.Drawing.Size(545, 57);
            this.pnDependents.TabIndex = 6;
            this.pnDependents.TabStop = false;
            this.pnDependents.Text = "Dependentes";
            // 
            // btnAddDependent
            // 
            this.btnAddDependent.BackColor = System.Drawing.Color.Transparent;
            this.btnAddDependent.BackgroundImage = global::ProVantagensApp.Properties.Resources.iconAdd;
            this.btnAddDependent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddDependent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDependent.Location = new System.Drawing.Point(478, 6);
            this.btnAddDependent.Name = "btnAddDependent";
            this.btnAddDependent.Size = new System.Drawing.Size(37, 32);
            this.btnAddDependent.TabIndex = 0;
            this.btnAddDependent.UseVisualStyleBackColor = false;
            this.btnAddDependent.Click += new System.EventHandler(this.btnAddDependent_Click);
            // 
            // txtDueDate
            // 
            this.txtDueDate.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.txtDueDate.Location = new System.Drawing.Point(131, 135);
            this.txtDueDate.Mask = "00/00/0000";
            this.txtDueDate.Name = "txtDueDate";
            this.txtDueDate.Size = new System.Drawing.Size(100, 28);
            this.txtDueDate.TabIndex = 3;
            // 
            // txtTotalValue
            // 
            this.txtTotalValue.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.txtTotalValue.Location = new System.Drawing.Point(165, 118);
            this.txtTotalValue.Name = "txtTotalValue";
            this.txtTotalValue.ReadOnly = true;
            this.txtTotalValue.Size = new System.Drawing.Size(107, 28);
            this.txtTotalValue.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(47, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Valor total:";
            // 
            // frmFinalizeClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(545, 639);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pnDependents);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmFinalizeClient";
            this.Text = "frmFinalizeClient";
            this.Load += new System.EventHandler(this.frmFinalizeClient_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnDependents.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.ComboBox cboPaymentMethod;
        private System.Windows.Forms.TextBox txtPlanName;
        private System.Windows.Forms.TextBox txtHolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtAditional;
        private System.Windows.Forms.TextBox txtTxAd;
        private System.Windows.Forms.TextBox txtPlanValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox pnDependents;
        private System.Windows.Forms.Button btnAddDependent;
        private System.Windows.Forms.MaskedTextBox txtDueDate;
        private System.Windows.Forms.TextBox txtTotalValue;
        private System.Windows.Forms.Label label2;
    }
}