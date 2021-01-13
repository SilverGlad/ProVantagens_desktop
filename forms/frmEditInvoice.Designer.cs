
namespace ProVantagensApp.forms
{
    partial class frmEditInvoice
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtAditional = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.cboPaymentMethod = new System.Windows.Forms.ComboBox();
            this.txtTotalValue = new System.Windows.Forms.TextBox();
            this.txtPlanValue = new System.Windows.Forms.TextBox();
            this.txtPlanName = new System.Windows.Forms.TextBox();
            this.txtHolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDueDate = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Titular:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.txtDueDate);
            this.groupBox1.Controls.Add(this.txtAditional);
            this.groupBox1.Controls.Add(this.cboStatus);
            this.groupBox1.Controls.Add(this.cboPaymentMethod);
            this.groupBox1.Controls.Add(this.txtTotalValue);
            this.groupBox1.Controls.Add(this.txtPlanValue);
            this.groupBox1.Controls.Add(this.txtPlanName);
            this.groupBox1.Controls.Add(this.txtHolder);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 418);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnCancelar);
            this.groupBox4.Controls.Add(this.btnSalvar);
            this.groupBox4.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(0, 312);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(482, 100);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Controles";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(376, 40);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 34);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            // txtAditional
            // 
            this.txtAditional.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.txtAditional.Location = new System.Drawing.Point(109, 238);
            this.txtAditional.Name = "txtAditional";
            this.txtAditional.Size = new System.Drawing.Size(127, 28);
            this.txtAditional.TabIndex = 3;
            this.txtAditional.TextChanged += new System.EventHandler(this.txtAditional_TextChanged);
            this.txtAditional.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_valor_adicional_KeyPress);
            this.txtAditional.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_valor_adicional_KeyUp);
            this.txtAditional.Leave += new System.EventHandler(this.txt_valor_adicional_Leave);
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Ok",
            "Pendente",
            "Vencido"});
            this.cboStatus.Location = new System.Drawing.Point(81, 164);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(166, 24);
            this.cboStatus.TabIndex = 2;
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
            this.cboPaymentMethod.Location = new System.Drawing.Point(220, 96);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(251, 24);
            this.cboPaymentMethod.TabIndex = 2;
            // 
            // txtTotalValue
            // 
            this.txtTotalValue.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.txtTotalValue.Location = new System.Drawing.Point(120, 281);
            this.txtTotalValue.Name = "txtTotalValue";
            this.txtTotalValue.ReadOnly = true;
            this.txtTotalValue.Size = new System.Drawing.Size(138, 28);
            this.txtTotalValue.TabIndex = 1;
            this.txtTotalValue.TextChanged += new System.EventHandler(this.txt_stringValorTotal_Leave);
            this.txtTotalValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_stringValorTotal_KeyPress);
            this.txtTotalValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_stringValorTotal_KeyUp);
            this.txtTotalValue.Leave += new System.EventHandler(this.txt_stringValorTotal_Leave);
            // 
            // txtPlanValue
            // 
            this.txtPlanValue.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.txtPlanValue.Location = new System.Drawing.Point(151, 204);
            this.txtPlanValue.Name = "txtPlanValue";
            this.txtPlanValue.ReadOnly = true;
            this.txtPlanValue.Size = new System.Drawing.Size(320, 28);
            this.txtPlanValue.TabIndex = 1;
            this.txtPlanValue.TextChanged += new System.EventHandler(this.txt_stringValorPlano_Leave);
            this.txtPlanValue.Leave += new System.EventHandler(this.txt_stringValorPlano_Leave);
            // 
            // txtPlanName
            // 
            this.txtPlanName.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.txtPlanName.Location = new System.Drawing.Point(156, 53);
            this.txtPlanName.Name = "txtPlanName";
            this.txtPlanName.ReadOnly = true;
            this.txtPlanName.Size = new System.Drawing.Size(315, 28);
            this.txtPlanName.TabIndex = 1;
            // 
            // txtHolder
            // 
            this.txtHolder.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.txtHolder.Location = new System.Drawing.Point(81, 13);
            this.txtHolder.Name = "txtHolder";
            this.txtHolder.ReadOnly = true;
            this.txtHolder.Size = new System.Drawing.Size(390, 28);
            this.txtHolder.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nome do plano:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(6, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Valor do plano:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(6, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(6, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Método de pagamento:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(6, 284);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Valor total:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(6, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Adicional:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(6, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Vencimento:";
            // 
            // txtDueDate
            // 
            this.txtDueDate.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.txtDueDate.Location = new System.Drawing.Point(131, 126);
            this.txtDueDate.Name = "txtDueDate";
            this.txtDueDate.Size = new System.Drawing.Size(88, 28);
            this.txtDueDate.TabIndex = 3;
            this.txtDueDate.TextChanged += new System.EventHandler(this.txtAditional_TextChanged);
            this.txtDueDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_valor_adicional_KeyPress);
            this.txtDueDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_valor_adicional_KeyUp);
            this.txtDueDate.Leave += new System.EventHandler(this.txt_valor_adicional_Leave);
            // 
            // frmEditInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(506, 442);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmEditInvoice";
            this.Text = "frmEditInvoice";
            this.Load += new System.EventHandler(this.frmEditInvoice_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPlanName;
        private System.Windows.Forms.TextBox txtHolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAditional;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.ComboBox cboPaymentMethod;
        private System.Windows.Forms.TextBox txtTotalValue;
        private System.Windows.Forms.TextBox txtPlanValue;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtDueDate;
        private System.Windows.Forms.Label label9;
    }
}