namespace GESTOCKTIPAM.GUI.ReportsForm
{
    partial class StocksReport
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
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.lbldtp1 = new System.Windows.Forms.Label();
            this.lbldtp2 = new System.Windows.Forms.Label();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.btnRapp = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtp1
            // 
            this.dtp1.CustomFormat = "dd/MM/yyyy";
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp1.Location = new System.Drawing.Point(317, 15);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(94, 20);
            this.dtp1.TabIndex = 0;
            // 
            // lbldtp1
            // 
            this.lbldtp1.AutoSize = true;
            this.lbldtp1.Location = new System.Drawing.Point(290, 15);
            this.lbldtp1.Name = "lbldtp1";
            this.lbldtp1.Size = new System.Drawing.Size(21, 13);
            this.lbldtp1.TabIndex = 1;
            this.lbldtp1.Text = "Du";
            // 
            // lbldtp2
            // 
            this.lbldtp2.AutoSize = true;
            this.lbldtp2.Location = new System.Drawing.Point(424, 15);
            this.lbldtp2.Name = "lbldtp2";
            this.lbldtp2.Size = new System.Drawing.Size(20, 13);
            this.lbldtp2.TabIndex = 2;
            this.lbldtp2.Text = "Au";
            // 
            // dtp2
            // 
            this.dtp2.CustomFormat = "dd/MM/yyyy";
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp2.Location = new System.Drawing.Point(450, 15);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(93, 20);
            this.dtp2.TabIndex = 3;
            // 
            // btnRapp
            // 
            this.btnRapp.Location = new System.Drawing.Point(584, 12);
            this.btnRapp.Name = "btnRapp";
            this.btnRapp.Size = new System.Drawing.Size(94, 23);
            this.btnRapp.TabIndex = 4;
            this.btnRapp.Text = "Afficher rapport";
            this.btnRapp.UseVisualStyleBackColor = true;
            this.btnRapp.Click += new System.EventHandler(this.btnRapp_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(13, 49);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(821, 402);
            this.crystalReportViewer1.TabIndex = 5;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(750, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(84, 23);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Exporter";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // StocksReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 463);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.btnRapp);
            this.Controls.Add(this.dtp2);
            this.Controls.Add(this.lbldtp2);
            this.Controls.Add(this.lbldtp1);
            this.Controls.Add(this.dtp1);
            this.Name = "StocksReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rapport du stock de produits";
            this.Load += new System.EventHandler(this.StocksReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Label lbldtp1;
        private System.Windows.Forms.Label lbldtp2;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.Button btnRapp;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button btnExport;
    }
}