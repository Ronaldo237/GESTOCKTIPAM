namespace GESTOCKTIPAM.GUI
{
    partial class Products
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
            this.lblcodeprod = new System.Windows.Forms.Label();
            this.lblnomprod = new System.Windows.Forms.Label();
            this.lblstatusprod = new System.Windows.Forms.Label();
            this.btnsuppr = new System.Windows.Forms.Button();
            this.btnajout = new System.Windows.Forms.Button();
            this.txtcodeprod = new System.Windows.Forms.TextBox();
            this.txtnomprod = new System.Windows.Forms.TextBox();
            this.cmboprod = new System.Windows.Forms.ComboBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnmodif = new System.Windows.Forms.Button();
            this.txtrecherche = new System.Windows.Forms.TextBox();
            this.btnrecherche = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // lblcodeprod
            // 
            this.lblcodeprod.AutoSize = true;
            this.lblcodeprod.Location = new System.Drawing.Point(13, 66);
            this.lblcodeprod.Name = "lblcodeprod";
            this.lblcodeprod.Size = new System.Drawing.Size(67, 13);
            this.lblcodeprod.TabIndex = 0;
            this.lblcodeprod.Text = "Code produit";
            // 
            // lblnomprod
            // 
            this.lblnomprod.AutoSize = true;
            this.lblnomprod.Location = new System.Drawing.Point(179, 67);
            this.lblnomprod.Name = "lblnomprod";
            this.lblnomprod.Size = new System.Drawing.Size(64, 13);
            this.lblnomprod.TabIndex = 1;
            this.lblnomprod.Text = "Nom produit";
            // 
            // lblstatusprod
            // 
            this.lblstatusprod.AutoSize = true;
            this.lblstatusprod.Location = new System.Drawing.Point(347, 66);
            this.lblstatusprod.Name = "lblstatusprod";
            this.lblstatusprod.Size = new System.Drawing.Size(37, 13);
            this.lblstatusprod.TabIndex = 2;
            this.lblstatusprod.Text = "Status";
            // 
            // btnsuppr
            // 
            this.btnsuppr.Location = new System.Drawing.Point(767, 363);
            this.btnsuppr.Name = "btnsuppr";
            this.btnsuppr.Size = new System.Drawing.Size(75, 23);
            this.btnsuppr.TabIndex = 3;
            this.btnsuppr.Text = "Supprimer";
            this.btnsuppr.UseVisualStyleBackColor = true;
            this.btnsuppr.Click += new System.EventHandler(this.btnsuppr_Click);
            // 
            // btnajout
            // 
            this.btnajout.Location = new System.Drawing.Point(550, 364);
            this.btnajout.Name = "btnajout";
            this.btnajout.Size = new System.Drawing.Size(75, 23);
            this.btnajout.TabIndex = 4;
            this.btnajout.Text = "Ajouter";
            this.btnajout.UseVisualStyleBackColor = true;
            this.btnajout.Click += new System.EventHandler(this.btnajout_Click);
            // 
            // txtcodeprod
            // 
            this.txtcodeprod.Location = new System.Drawing.Point(16, 83);
            this.txtcodeprod.Name = "txtcodeprod";
            this.txtcodeprod.Size = new System.Drawing.Size(129, 20);
            this.txtcodeprod.TabIndex = 3;
            // 
            // txtnomprod
            // 
            this.txtnomprod.Location = new System.Drawing.Point(182, 83);
            this.txtnomprod.Name = "txtnomprod";
            this.txtnomprod.Size = new System.Drawing.Size(124, 20);
            this.txtnomprod.TabIndex = 4;
            // 
            // cmboprod
            // 
            this.cmboprod.FormattingEnabled = true;
            this.cmboprod.Items.AddRange(new object[] {
            "Disponible",
            "Indisponible"});
            this.cmboprod.Location = new System.Drawing.Point(350, 82);
            this.cmboprod.Name = "cmboprod";
            this.cmboprod.Size = new System.Drawing.Size(121, 21);
            this.cmboprod.TabIndex = 7;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgv.Location = new System.Drawing.Point(16, 123);
            this.dgv.Name = "dgv";
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(833, 234);
            this.dgv.TabIndex = 8;
            this.dgv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Code ";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Nom";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Status";
            this.Column3.Name = "Column3";
            // 
            // btnmodif
            // 
            this.btnmodif.Location = new System.Drawing.Point(659, 364);
            this.btnmodif.Name = "btnmodif";
            this.btnmodif.Size = new System.Drawing.Size(75, 23);
            this.btnmodif.TabIndex = 9;
            this.btnmodif.Text = "Modifier";
            this.btnmodif.UseVisualStyleBackColor = true;
            this.btnmodif.Click += new System.EventHandler(this.btnmodif_Click);
            // 
            // txtrecherche
            // 
            this.txtrecherche.Location = new System.Drawing.Point(597, 82);
            this.txtrecherche.Name = "txtrecherche";
            this.txtrecherche.Size = new System.Drawing.Size(146, 20);
            this.txtrecherche.TabIndex = 10;
            this.txtrecherche.Visible = false;
            // 
            // btnrecherche
            // 
            this.btnrecherche.Location = new System.Drawing.Point(767, 79);
            this.btnrecherche.Name = "btnrecherche";
            this.btnrecherche.Size = new System.Drawing.Size(75, 23);
            this.btnrecherche.TabIndex = 11;
            this.btnrecherche.Text = "Rechercher";
            this.btnrecherche.UseVisualStyleBackColor = true;
            this.btnrecherche.Visible = false;
            this.btnrecherche.Click += new System.EventHandler(this.btnrecherche_Click);
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 422);
            this.Controls.Add(this.btnrecherche);
            this.Controls.Add(this.txtrecherche);
            this.Controls.Add(this.btnmodif);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.cmboprod);
            this.Controls.Add(this.txtnomprod);
            this.Controls.Add(this.txtcodeprod);
            this.Controls.Add(this.btnajout);
            this.Controls.Add(this.btnsuppr);
            this.Controls.Add(this.lblstatusprod);
            this.Controls.Add(this.lblnomprod);
            this.Controls.Add(this.lblcodeprod);
            this.Name = "Products";
            this.Text = "Produits";
            this.Load += new System.EventHandler(this.Products_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblcodeprod;
        private System.Windows.Forms.Label lblnomprod;
        private System.Windows.Forms.Label lblstatusprod;
        private System.Windows.Forms.Button btnsuppr;
        private System.Windows.Forms.Button btnajout;
        private System.Windows.Forms.TextBox txtcodeprod;
        private System.Windows.Forms.TextBox txtnomprod;
        private System.Windows.Forms.ComboBox cmboprod;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnmodif;
        private System.Windows.Forms.TextBox txtrecherche;
        private System.Windows.Forms.Button btnrecherche;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}