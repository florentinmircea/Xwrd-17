namespace Xwrd_1._0
{
    partial class copilMDI
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCnc = new System.Windows.Forms.Button();
            this.txtboxraspuns = new System.Windows.Forms.RichTextBox();
            this.txtinput = new System.Windows.Forms.TextBox();
            this.btnro = new System.Windows.Forms.Button();
            this.butrasp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(197, 226);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCnc
            // 
            this.btnCnc.Location = new System.Drawing.Point(116, 226);
            this.btnCnc.Name = "btnCnc";
            this.btnCnc.Size = new System.Drawing.Size(75, 23);
            this.btnCnc.TabIndex = 1;
            this.btnCnc.Text = "Cancel";
            this.btnCnc.UseVisualStyleBackColor = true;
            this.btnCnc.Click += new System.EventHandler(this.btnCnc_Click);
            // 
            // txtboxraspuns
            // 
            this.txtboxraspuns.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtboxraspuns.Location = new System.Drawing.Point(36, 27);
            this.txtboxraspuns.Name = "txtboxraspuns";
            this.txtboxraspuns.ReadOnly = true;
            this.txtboxraspuns.ShortcutsEnabled = false;
            this.txtboxraspuns.Size = new System.Drawing.Size(211, 96);
            this.txtboxraspuns.TabIndex = 2;
            this.txtboxraspuns.Text = "";
            // 
            // txtinput
            // 
            this.txtinput.Location = new System.Drawing.Point(36, 168);
            this.txtinput.Name = "txtinput";
            this.txtinput.Size = new System.Drawing.Size(211, 20);
            this.txtinput.TabIndex = 3;
            this.txtinput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtinput_KeyDown);
            // 
            // btnro
            // 
            this.btnro.Location = new System.Drawing.Point(214, 129);
            this.btnro.Name = "btnro";
            this.btnro.Size = new System.Drawing.Size(33, 23);
            this.btnro.TabIndex = 4;
            this.btnro.Text = "RO";
            this.btnro.UseVisualStyleBackColor = true;
            this.btnro.Click += new System.EventHandler(this.btnro_Click);
            // 
            // butrasp
            // 
            this.butrasp.Location = new System.Drawing.Point(36, 128);
            this.butrasp.Name = "butrasp";
            this.butrasp.Size = new System.Drawing.Size(75, 23);
            this.butrasp.TabIndex = 5;
            this.butrasp.Text = "Réponse";
            this.butrasp.UseVisualStyleBackColor = true;
            this.butrasp.Click += new System.EventHandler(this.butrasp_Click);
            // 
            // copilMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.butrasp);
            this.Controls.Add(this.btnro);
            this.Controls.Add(this.txtinput);
            this.Controls.Add(this.txtboxraspuns);
            this.Controls.Add(this.btnCnc);
            this.Controls.Add(this.btnOK);
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "copilMDI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Réponse";
            this.Load += new System.EventHandler(this.copilMDI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCnc;
        private System.Windows.Forms.TextBox txtinput;
        public System.Windows.Forms.RichTextBox txtboxraspuns;
        private System.Windows.Forms.Button btnro;
        private System.Windows.Forms.Button butrasp;
    }
}