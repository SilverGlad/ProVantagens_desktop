
namespace ProVantagensApp
{
    partial class frmContractPlan
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
            this.pnPlans = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnPlans
            // 
            this.pnPlans.AutoScroll = true;
            this.pnPlans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPlans.Location = new System.Drawing.Point(0, 0);
            this.pnPlans.Name = "pnPlans";
            this.pnPlans.Size = new System.Drawing.Size(603, 619);
            this.pnPlans.TabIndex = 0;
            // 
            // frmContractPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(603, 619);
            this.Controls.Add(this.pnPlans);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmContractPlan";
            this.Text = "Contratar plano";
            this.Load += new System.EventHandler(this.frmContractPlan_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnPlans;
    }
}