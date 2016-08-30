namespace EditeurXML
{
    partial class main
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.buttonCharger = new System.Windows.Forms.Button();
            this.treeViewXML = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemCreer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRenommer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSupprimer = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonParcourir = new System.Windows.Forms.Button();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorkerLoad = new System.ComponentModel.BackgroundWorker();
            this.labelnbnoeud = new System.Windows.Forms.Label();
            this.labelnbnoeudxml = new System.Windows.Forms.Label();
            this.labelsur = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCharger
            // 
            this.buttonCharger.Location = new System.Drawing.Point(112, 19);
            this.buttonCharger.Name = "buttonCharger";
            this.buttonCharger.Size = new System.Drawing.Size(84, 23);
            this.buttonCharger.TabIndex = 0;
            this.buttonCharger.Text = "Charger";
            this.buttonCharger.UseVisualStyleBackColor = true;
            this.buttonCharger.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeViewXML
            // 
            this.treeViewXML.ContextMenuStrip = this.contextMenuStrip1;
            this.treeViewXML.LabelEdit = true;
            this.treeViewXML.Location = new System.Drawing.Point(6, 51);
            this.treeViewXML.Name = "treeViewXML";
            this.treeViewXML.Size = new System.Drawing.Size(312, 163);
            this.treeViewXML.TabIndex = 1;
            this.treeViewXML.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeViewXML_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCreer,
            this.toolStripMenuItemRenommer,
            this.toolStripMenuItemSupprimer});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(134, 70);
            // 
            // toolStripMenuItemCreer
            // 
            this.toolStripMenuItemCreer.Name = "toolStripMenuItemCreer";
            this.toolStripMenuItemCreer.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItemCreer.Text = "Créer";
            this.toolStripMenuItemCreer.Click += new System.EventHandler(this.toolStripMenuItemCreer_Click);
            // 
            // toolStripMenuItemRenommer
            // 
            this.toolStripMenuItemRenommer.Name = "toolStripMenuItemRenommer";
            this.toolStripMenuItemRenommer.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItemRenommer.Text = "Renommer";
            this.toolStripMenuItemRenommer.Click += new System.EventHandler(this.toolStripMenuItemRenommer_Click);
            // 
            // toolStripMenuItemSupprimer
            // 
            this.toolStripMenuItemSupprimer.Name = "toolStripMenuItemSupprimer";
            this.toolStripMenuItemSupprimer.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItemSupprimer.Text = "Supprimer";
            this.toolStripMenuItemSupprimer.Click += new System.EventHandler(this.toolStripMenuItemSupprimer_Click);
            // 
            // buttonParcourir
            // 
            this.buttonParcourir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonParcourir.Location = new System.Drawing.Point(615, 23);
            this.buttonParcourir.Name = "buttonParcourir";
            this.buttonParcourir.Size = new System.Drawing.Size(75, 23);
            this.buttonParcourir.TabIndex = 2;
            this.buttonParcourir.Text = "Parcourir";
            this.buttonParcourir.UseVisualStyleBackColor = true;
            this.buttonParcourir.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUrl.Location = new System.Drawing.Point(12, 25);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(597, 20);
            this.textBoxUrl.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 235);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(312, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // backgroundWorkerLoad
            // 
            this.backgroundWorkerLoad.WorkerReportsProgress = true;
            this.backgroundWorkerLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLoad_DoWork);
            this.backgroundWorkerLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLoad_RunWorkerCompleted);
            this.backgroundWorkerLoad.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerLoad_ProgressChanged);
            // 
            // labelnbnoeud
            // 
            this.labelnbnoeud.AutoSize = true;
            this.labelnbnoeud.Location = new System.Drawing.Point(120, 261);
            this.labelnbnoeud.Name = "labelnbnoeud";
            this.labelnbnoeud.Size = new System.Drawing.Size(0, 13);
            this.labelnbnoeud.TabIndex = 7;
            // 
            // labelnbnoeudxml
            // 
            this.labelnbnoeudxml.AutoSize = true;
            this.labelnbnoeudxml.Location = new System.Drawing.Point(178, 261);
            this.labelnbnoeudxml.Name = "labelnbnoeudxml";
            this.labelnbnoeudxml.Size = new System.Drawing.Size(0, 13);
            this.labelnbnoeudxml.TabIndex = 8;
            // 
            // labelsur
            // 
            this.labelsur.AutoSize = true;
            this.labelsur.Location = new System.Drawing.Point(151, 261);
            this.labelsur.Name = "labelsur";
            this.labelsur.Size = new System.Drawing.Size(21, 13);
            this.labelsur.TabIndex = 9;
            this.labelsur.Text = "sur";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Précisez le chemin d\'accès du fichier XML à éditer puis chargez le :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelnbnoeudxml);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.labelsur);
            this.groupBox1.Controls.Add(this.treeViewXML);
            this.groupBox1.Controls.Add(this.labelnbnoeud);
            this.groupBox1.Controls.Add(this.buttonCharger);
            this.groupBox1.Location = new System.Drawing.Point(12, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 277);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edition";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(366, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 277);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Autre";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 358);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.buttonParcourir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.Text = "EditeurXML";
            this.Load += new System.EventHandler(this.main_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCharger;
        private System.Windows.Forms.TreeView treeViewXML;
        private System.Windows.Forms.Button buttonParcourir;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCreer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRenommer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSupprimer;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoad;
        private System.Windows.Forms.Label labelnbnoeud;
        private System.Windows.Forms.Label labelnbnoeudxml;
        private System.Windows.Forms.Label labelsur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;

    }
}

