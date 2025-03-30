namespace GESTOCKTIPAM.GUI
{
    partial class CreerCompte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreerCompte));
            this.btnconnexion = new System.Windows.Forms.Button();
            this.btnenreg = new System.Windows.Forms.Button();
            this.txtconfirmpass = new System.Windows.Forms.TextBox();
            this.lblconfirm = new System.Windows.Forms.Label();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtusr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbx = new System.Windows.Forms.PictureBox();
            this.btnpar = new System.Windows.Forms.Button();
            this.dgvu = new System.Windows.Forms.DataGridView();
            this.dgvno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvpass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvimg = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvu)).BeginInit();
            this.SuspendLayout();
            // 
            // btnconnexion
            // 
            this.btnconnexion.Location = new System.Drawing.Point(355, 241);
            this.btnconnexion.Name = "btnconnexion";
            this.btnconnexion.Size = new System.Drawing.Size(85, 23);
            this.btnconnexion.TabIndex = 16;
            this.btnconnexion.Text = "Connexion";
            this.btnconnexion.UseVisualStyleBackColor = true;
            this.btnconnexion.Click += new System.EventHandler(this.btnconnexion_Click);
            // 
            // btnenreg
            // 
            this.btnenreg.Location = new System.Drawing.Point(355, 207);
            this.btnenreg.Name = "btnenreg";
            this.btnenreg.Size = new System.Drawing.Size(85, 23);
            this.btnenreg.TabIndex = 15;
            this.btnenreg.Text = "Créer compte";
            this.btnenreg.UseVisualStyleBackColor = true;
            this.btnenreg.Click += new System.EventHandler(this.btnenreg_Click);
            // 
            // txtconfirmpass
            // 
            this.txtconfirmpass.Location = new System.Drawing.Point(235, 149);
            this.txtconfirmpass.Name = "txtconfirmpass";
            this.txtconfirmpass.Size = new System.Drawing.Size(205, 20);
            this.txtconfirmpass.TabIndex = 14;
            // 
            // lblconfirm
            // 
            this.lblconfirm.AutoSize = true;
            this.lblconfirm.Location = new System.Drawing.Point(235, 123);
            this.lblconfirm.Name = "lblconfirm";
            this.lblconfirm.Size = new System.Drawing.Size(131, 13);
            this.lblconfirm.TabIndex = 13;
            this.lblconfirm.Text = "Confirmation mot de passe";
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(235, 86);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(205, 20);
            this.txtpass.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Mot de passe";
            // 
            // txtusr
            // 
            this.txtusr.Location = new System.Drawing.Point(235, 33);
            this.txtusr.Name = "txtusr";
            this.txtusr.Size = new System.Drawing.Size(205, 20);
            this.txtusr.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nom d\'utilisateur";
            // 
            // pbx
            // 
            this.pbx.Image = ((System.Drawing.Image)(resources.GetObject("pbx.Image")));
            this.pbx.Location = new System.Drawing.Point(43, 16);
            this.pbx.Name = "pbx";
            this.pbx.Size = new System.Drawing.Size(123, 121);
            this.pbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx.TabIndex = 17;
            this.pbx.TabStop = false;
            // 
            // btnpar
            // 
            this.btnpar.Location = new System.Drawing.Point(66, 149);
            this.btnpar.Name = "btnpar";
            this.btnpar.Size = new System.Drawing.Size(75, 23);
            this.btnpar.TabIndex = 18;
            this.btnpar.Text = "Parcourir";
            this.btnpar.UseVisualStyleBackColor = true;
            this.btnpar.Click += new System.EventHandler(this.btnpar_Click_1);
            // 
            // dgvu
            // 
            this.dgvu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvno,
            this.dgvname,
            this.dgvpass,
            this.dgvimg});
            this.dgvu.Location = new System.Drawing.Point(467, 33);
            this.dgvu.Name = "dgvu";
            this.dgvu.RowTemplate.Height = 80;
            this.dgvu.Size = new System.Drawing.Size(632, 273);
            this.dgvu.TabIndex = 19;
            // 
            // dgvno
            // 
            this.dgvno.HeaderText = "ID";
            this.dgvno.Name = "dgvno";
            // 
            // dgvname
            // 
            this.dgvname.HeaderText = "Username";
            this.dgvname.Name = "dgvname";
            // 
            // dgvpass
            // 
            this.dgvpass.HeaderText = "Password";
            this.dgvpass.Name = "dgvpass";
            // 
            // dgvimg
            // 
            this.dgvimg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvimg.FillWeight = 200F;
            this.dgvimg.HeaderText = "Photo";
            this.dgvimg.Name = "dgvimg";
            // 
            // CreerCompte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 331);
            this.Controls.Add(this.dgvu);
            this.Controls.Add(this.btnpar);
            this.Controls.Add(this.pbx);
            this.Controls.Add(this.btnconnexion);
            this.Controls.Add(this.btnenreg);
            this.Controls.Add(this.txtconfirmpass);
            this.Controls.Add(this.lblconfirm);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtusr);
            this.Controls.Add(this.label1);
            this.Name = "CreerCompte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Créer compte utilisateur";
            this.Load += new System.EventHandler(this.CreerCompte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnconnexion;
        private System.Windows.Forms.Button btnenreg;
        private System.Windows.Forms.TextBox txtconfirmpass;
        private System.Windows.Forms.Label lblconfirm;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtusr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbx;
        private System.Windows.Forms.Button btnpar;
        private System.Windows.Forms.DataGridView dgvu;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvno;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvpass;
        private System.Windows.Forms.DataGridViewImageColumn dgvimg;
    }
}