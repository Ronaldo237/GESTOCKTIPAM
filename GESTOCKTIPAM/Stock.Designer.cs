namespace GESTOCKTIPAM.GUI
{
    partial class Stock
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
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.txtnom = new System.Windows.Forms.TextBox();
            this.txtqte = new System.Windows.Forms.TextBox();
            this.lbldate = new System.Windows.Forms.Label();
            this.lblcodeprod = new System.Windows.Forms.Label();
            this.lblnomprod = new System.Windows.Forms.Label();
            this.lblqte = new System.Windows.Forms.Label();
            this.lblstatus = new System.Windows.Forms.Label();
            this.btnajout = new System.Windows.Forms.Button();
            this.btnsuppr = new System.Windows.Forms.Button();
            this.dgvs = new System.Windows.Forms.DataGridView();
            this.dgvno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvnom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvqte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbltotalprod = new System.Windows.Forms.Label();
            this.lbltotalqte = new System.Windows.Forms.Label();
            this.lblt1 = new System.Windows.Forms.Label();
            this.lblt2 = new System.Windows.Forms.Label();
            this.btnmodif = new System.Windows.Forms.Button();
            this.combostatus = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvs)).BeginInit();
            this.SuspendLayout();
            // 
            // dtp
            // 
            this.dtp.CustomFormat = "dd/MM/yyyy";
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp.Location = new System.Drawing.Point(148, 66);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(111, 20);
            this.dtp.TabIndex = 2;
            this.dtp.Value = new System.DateTime(2023, 10, 19, 0, 0, 0, 0);
            this.dtp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtp_KeyDown);
            // 
            // txtcode
            // 
            this.txtcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtcode.Location = new System.Drawing.Point(273, 66);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(109, 20);
            this.txtcode.TabIndex = 3;
            this.txtcode.TextChanged += new System.EventHandler(this.txtcode_TextChanged);
            this.txtcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcode_KeyDown);
            // 
            // txtnom
            // 
            this.txtnom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtnom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtnom.Location = new System.Drawing.Point(388, 66);
            this.txtnom.Name = "txtnom";
            this.txtnom.Size = new System.Drawing.Size(213, 20);
            this.txtnom.TabIndex = 4;
            this.txtnom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnom_KeyDown);
            // 
            // txtqte
            // 
            this.txtqte.Location = new System.Drawing.Point(721, 65);
            this.txtqte.Name = "txtqte";
            this.txtqte.Size = new System.Drawing.Size(44, 20);
            this.txtqte.TabIndex = 5;
            this.txtqte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtqte_KeyDown);
            this.txtqte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtqte_KeyPress);
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Location = new System.Drawing.Point(145, 46);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(114, 13);
            this.lbldate.TabIndex = 5;
            this.lbldate.Text = "Date d\'ajout du produit";
            // 
            // lblcodeprod
            // 
            this.lblcodeprod.AutoSize = true;
            this.lblcodeprod.Location = new System.Drawing.Point(270, 47);
            this.lblcodeprod.Name = "lblcodeprod";
            this.lblcodeprod.Size = new System.Drawing.Size(67, 13);
            this.lblcodeprod.TabIndex = 6;
            this.lblcodeprod.Text = "Code produit";
            // 
            // lblnomprod
            // 
            this.lblnomprod.AutoSize = true;
            this.lblnomprod.Location = new System.Drawing.Point(385, 47);
            this.lblnomprod.Name = "lblnomprod";
            this.lblnomprod.Size = new System.Drawing.Size(64, 13);
            this.lblnomprod.TabIndex = 7;
            this.lblnomprod.Text = "Nom produit";
            // 
            // lblqte
            // 
            this.lblqte.AutoSize = true;
            this.lblqte.Location = new System.Drawing.Point(718, 47);
            this.lblqte.Name = "lblqte";
            this.lblqte.Size = new System.Drawing.Size(47, 13);
            this.lblqte.TabIndex = 8;
            this.lblqte.Text = "Quantité";
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Location = new System.Drawing.Point(604, 46);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(37, 13);
            this.lblstatus.TabIndex = 9;
            this.lblstatus.Text = "Status";
            // 
            // btnajout
            // 
            this.btnajout.Location = new System.Drawing.Point(654, 413);
            this.btnajout.Name = "btnajout";
            this.btnajout.Size = new System.Drawing.Size(75, 23);
            this.btnajout.TabIndex = 10;
            this.btnajout.Text = "Ajouter";
            this.btnajout.UseVisualStyleBackColor = true;
            this.btnajout.Click += new System.EventHandler(this.btnajout_Click);
            // 
            // btnsuppr
            // 
            this.btnsuppr.Location = new System.Drawing.Point(848, 413);
            this.btnsuppr.Name = "btnsuppr";
            this.btnsuppr.Size = new System.Drawing.Size(75, 23);
            this.btnsuppr.TabIndex = 11;
            this.btnsuppr.Text = "Supprimer";
            this.btnsuppr.UseVisualStyleBackColor = true;
            this.btnsuppr.Click += new System.EventHandler(this.btnsuppr_Click);
            // 
            // dgvs
            // 
            this.dgvs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvno,
            this.dgvcode,
            this.dgvnom,
            this.dgvqte,
            this.dgvdate,
            this.dgvstatus});
            this.dgvs.Location = new System.Drawing.Point(15, 113);
            this.dgvs.Name = "dgvs";
            this.dgvs.Size = new System.Drawing.Size(902, 272);
            this.dgvs.TabIndex = 12;
            this.dgvs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvs_MouseDoubleClick);
            // 
            // dgvno
            // 
            this.dgvno.HeaderText = "N°";
            this.dgvno.Name = "dgvno";
            // 
            // dgvcode
            // 
            this.dgvcode.HeaderText = "Code";
            this.dgvcode.Name = "dgvcode";
            // 
            // dgvnom
            // 
            this.dgvnom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvnom.HeaderText = "Nom";
            this.dgvnom.Name = "dgvnom";
            // 
            // dgvqte
            // 
            this.dgvqte.HeaderText = "Quantité";
            this.dgvqte.Name = "dgvqte";
            // 
            // dgvdate
            // 
            this.dgvdate.HeaderText = "Date";
            this.dgvdate.Name = "dgvdate";
            // 
            // dgvstatus
            // 
            this.dgvstatus.HeaderText = "Status";
            this.dgvstatus.Name = "dgvstatus";
            // 
            // lbltotalprod
            // 
            this.lbltotalprod.AutoSize = true;
            this.lbltotalprod.Location = new System.Drawing.Point(246, 477);
            this.lbltotalprod.Name = "lbltotalprod";
            this.lbltotalprod.Size = new System.Drawing.Size(72, 13);
            this.lbltotalprod.TabIndex = 13;
            this.lbltotalprod.Text = "Total produit :";
            // 
            // lbltotalqte
            // 
            this.lbltotalqte.AutoSize = true;
            this.lbltotalqte.Location = new System.Drawing.Point(414, 477);
            this.lbltotalqte.Name = "lbltotalqte";
            this.lbltotalqte.Size = new System.Drawing.Size(78, 13);
            this.lbltotalqte.TabIndex = 14;
            this.lbltotalqte.Text = "Total quantité :";
            // 
            // lblt1
            // 
            this.lblt1.AutoSize = true;
            this.lblt1.Location = new System.Drawing.Point(324, 477);
            this.lblt1.Name = "lblt1";
            this.lblt1.Size = new System.Drawing.Size(13, 13);
            this.lblt1.TabIndex = 15;
            this.lblt1.Text = "0";
            // 
            // lblt2
            // 
            this.lblt2.AutoSize = true;
            this.lblt2.Location = new System.Drawing.Point(489, 477);
            this.lblt2.Name = "lblt2";
            this.lblt2.Size = new System.Drawing.Size(13, 13);
            this.lblt2.TabIndex = 16;
            this.lblt2.Text = "0";
            // 
            // btnmodif
            // 
            this.btnmodif.Location = new System.Drawing.Point(751, 413);
            this.btnmodif.Name = "btnmodif";
            this.btnmodif.Size = new System.Drawing.Size(75, 23);
            this.btnmodif.TabIndex = 20;
            this.btnmodif.Text = "Modifier";
            this.btnmodif.UseVisualStyleBackColor = true;
            this.btnmodif.Click += new System.EventHandler(this.btnmodif_Click);
            // 
            // combostatus
            // 
            this.combostatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combostatus.FormattingEnabled = true;
            this.combostatus.Location = new System.Drawing.Point(607, 65);
            this.combostatus.Name = "combostatus";
            this.combostatus.Size = new System.Drawing.Size(108, 21);
            this.combostatus.TabIndex = 21;
            // 
            // Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 524);
            this.Controls.Add(this.combostatus);
            this.Controls.Add(this.btnmodif);
            this.Controls.Add(this.lblt2);
            this.Controls.Add(this.lblt1);
            this.Controls.Add(this.lbltotalqte);
            this.Controls.Add(this.lbltotalprod);
            this.Controls.Add(this.dgvs);
            this.Controls.Add(this.btnsuppr);
            this.Controls.Add(this.btnajout);
            this.Controls.Add(this.lblstatus);
            this.Controls.Add(this.lblqte);
            this.Controls.Add(this.lblnomprod);
            this.Controls.Add(this.lblcodeprod);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.txtqte);
            this.Controls.Add(this.txtnom);
            this.Controls.Add(this.txtcode);
            this.Controls.Add(this.dtp);
            this.Name = "Stock";
            this.Text = "Stock de produits";
            this.Load += new System.EventHandler(this.Stock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.TextBox txtnom;
        private System.Windows.Forms.TextBox txtqte;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.Label lblcodeprod;
        private System.Windows.Forms.Label lblnomprod;
        private System.Windows.Forms.Label lblqte;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.Button btnajout;
        private System.Windows.Forms.Button btnsuppr;
        private System.Windows.Forms.DataGridView dgvs;
        private System.Windows.Forms.Label lbltotalprod;
        private System.Windows.Forms.Label lbltotalqte;
        private System.Windows.Forms.Label lblt1;
        private System.Windows.Forms.Label lblt2;
        private System.Windows.Forms.Button btnmodif;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvno;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvnom;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvqte;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvstatus;
        private System.Windows.Forms.ComboBox combostatus;
    }
}