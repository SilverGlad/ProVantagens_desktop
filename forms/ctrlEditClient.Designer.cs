
namespace ProVantagensApp.forms
{
    partial class ctrlEditClient
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
            this.lbFatura = new System.Windows.Forms.Label();
            this.cboFatura = new System.Windows.Forms.ComboBox();
            this.btnFatura = new System.Windows.Forms.RadioButton();
            this.btnPlan = new System.Windows.Forms.RadioButton();
            this.btnClient = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbFatura
            // 
            this.lbFatura.AutoSize = true;
            this.lbFatura.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbFatura.Location = new System.Drawing.Point(12, 76);
            this.lbFatura.Name = "lbFatura";
            this.lbFatura.Size = new System.Drawing.Size(108, 18);
            this.lbFatura.TabIndex = 15;
            this.lbFatura.Text = "Nº da fatura";
            this.lbFatura.Visible = false;
            // 
            // cboFatura
            // 
            this.cboFatura.FormattingEnabled = true;
            this.cboFatura.Location = new System.Drawing.Point(127, 77);
            this.cboFatura.Name = "cboFatura";
            this.cboFatura.Size = new System.Drawing.Size(165, 21);
            this.cboFatura.TabIndex = 12;
            this.cboFatura.Visible = false;
            this.cboFatura.SelectedIndexChanged += new System.EventHandler(this.cboFatura_SelectedIndexChanged);
            // 
            // btnFatura
            // 
            this.btnFatura.AutoSize = true;
            this.btnFatura.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFatura.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFatura.Location = new System.Drawing.Point(239, 12);
            this.btnFatura.Name = "btnFatura";
            this.btnFatura.Size = new System.Drawing.Size(63, 35);
            this.btnFatura.TabIndex = 11;
            this.btnFatura.Text = "Fatura";
            this.btnFatura.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFatura.UseVisualStyleBackColor = true;
            this.btnFatura.CheckedChanged += new System.EventHandler(this.btnFatura_CheckedChanged);
            // 
            // btnPlan
            // 
            this.btnPlan.AutoSize = true;
            this.btnPlan.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPlan.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnPlan.Location = new System.Drawing.Point(127, 12);
            this.btnPlan.Name = "btnPlan";
            this.btnPlan.Size = new System.Drawing.Size(57, 35);
            this.btnPlan.TabIndex = 10;
            this.btnPlan.Text = "Plano";
            this.btnPlan.UseVisualStyleBackColor = true;
            // 
            // btnClient
            // 
            this.btnClient.AutoSize = true;
            this.btnClient.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClient.Checked = true;
            this.btnClient.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnClient.Location = new System.Drawing.Point(12, 12);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(71, 35);
            this.btnClient.TabIndex = 9;
            this.btnClient.TabStop = true;
            this.btnClient.Text = "Cliente";
            this.btnClient.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnOk.Location = new System.Drawing.Point(99, 124);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(108, 37);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "Avançar";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ctrlEditClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(320, 173);
            this.Controls.Add(this.lbFatura);
            this.Controls.Add(this.cboFatura);
            this.Controls.Add(this.btnFatura);
            this.Controls.Add(this.btnPlan);
            this.Controls.Add(this.btnClient);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ctrlEditClient";
            this.Text = "Editar cliente";
            this.Load += new System.EventHandler(this.ctrlEditClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFatura;
        private System.Windows.Forms.ComboBox cboFatura;
        private System.Windows.Forms.RadioButton btnFatura;
        private System.Windows.Forms.RadioButton btnPlan;
        private System.Windows.Forms.RadioButton btnClient;
        private System.Windows.Forms.Button btnOk;
    }
}