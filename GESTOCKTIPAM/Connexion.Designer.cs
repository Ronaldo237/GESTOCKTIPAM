namespace GESTOCKTIPAM
{
    partial class Connexion
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
            this.linkLabeloubli = new System.Windows.Forms.LinkLabel();
            this.btnlogin = new System.Windows.Forms.Button();
            this.btneffacer = new System.Windows.Forms.Button();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.txtusr = new System.Windows.Forms.TextBox();
            this.lblpass = new System.Windows.Forms.Label();
            this.lblusr = new System.Windows.Forms.Label();
            this.btncreercompte = new System.Windows.Forms.Button();
            this.lblrecup = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // linkLabeloubli
            // 
            this.linkLabeloubli.AutoSize = true;
            this.linkLabeloubli.Location = new System.Drawing.Point(213, 136);
            this.linkLabeloubli.Name = "linkLabeloubli";
            this.linkLabeloubli.Size = new System.Drawing.Size(102, 13);
            this.linkLabeloubli.TabIndex = 12;
            this.linkLabeloubli.TabStop = true;
            this.linkLabeloubli.Text = "Mot de passe oublié";
            this.linkLabeloubli.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabeloubli_LinkClicked);
            // 
            // btnlogin
            // 
            this.btnlogin.Location = new System.Drawing.Point(22, 96);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(81, 23);
            this.btnlogin.TabIndex = 13;
            this.btnlogin.Text = "Se connecter";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // btneffacer
            // 
            this.btneffacer.Location = new System.Drawing.Point(124, 96);
            this.btneffacer.Name = "btneffacer";
            this.btneffacer.Size = new System.Drawing.Size(83, 23);
            this.btneffacer.TabIndex = 14;
            this.btneffacer.Text = "Effacer";
            this.btneffacer.UseVisualStyleBackColor = true;
            this.btneffacer.Click += new System.EventHandler(this.btneffacer_Click);
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(95, 56);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(220, 20);
            this.txtpass.TabIndex = 11;
            // 
            // txtusr
            // 
            this.txtusr.Location = new System.Drawing.Point(95, 24);
            this.txtusr.Name = "txtusr";
            this.txtusr.Size = new System.Drawing.Size(220, 20);
            this.txtusr.TabIndex = 10;
            // 
            // lblpass
            // 
            this.lblpass.AutoSize = true;
            this.lblpass.Location = new System.Drawing.Point(5, 59);
            this.lblpass.Name = "lblpass";
            this.lblpass.Size = new System.Drawing.Size(71, 13);
            this.lblpass.TabIndex = 9;
            this.lblpass.Text = "Mot de passe";
            // 
            // lblusr
            // 
            this.lblusr.AutoSize = true;
            this.lblusr.Location = new System.Drawing.Point(5, 27);
            this.lblusr.Name = "lblusr";
            this.lblusr.Size = new System.Drawing.Size(84, 13);
            this.lblusr.TabIndex = 8;
            this.lblusr.Text = "Nom d\'utilisateur";
            // 
            // btncreercompte
            // 
            this.btncreercompte.Location = new System.Drawing.Point(229, 96);
            this.btncreercompte.Name = "btncreercompte";
            this.btncreercompte.Size = new System.Drawing.Size(86, 23);
            this.btncreercompte.TabIndex = 15;
            this.btncreercompte.Text = "Créer compte";
            this.btncreercompte.UseVisualStyleBackColor = true;
            this.btncreercompte.Click += new System.EventHandler(this.btncreercompte_Click);
            // 
            // lblrecup
            // 
            this.lblrecup.AutoSize = true;
            this.lblrecup.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecup.ForeColor = System.Drawing.Color.Green;
            this.lblrecup.Location = new System.Drawing.Point(162, 163);
            this.lblrecup.Name = "lblrecup";
            this.lblrecup.Size = new System.Drawing.Size(12, 12);
            this.lblrecup.TabIndex = 16;
            this.lblrecup.Text = "0";
            // 
            // Connexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 185);
            this.Controls.Add(this.lblrecup);
            this.Controls.Add(this.btncreercompte);
            this.Controls.Add(this.linkLabeloubli);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.btneffacer);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtusr);
            this.Controls.Add(this.lblpass);
            this.Controls.Add(this.lblusr);
            this.Name = "Connexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authentification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabeloubli;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Button btneffacer;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.TextBox txtusr;
        private System.Windows.Forms.Label lblpass;
        private System.Windows.Forms.Label lblusr;
        private System.Windows.Forms.Button btncreercompte;
        private System.Windows.Forms.Label lblrecup;
    }
}

