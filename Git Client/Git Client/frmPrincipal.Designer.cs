namespace Git_Client
{
    partial class frmPrincipal
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ficheiroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AbrirFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.EstadoGit = new System.Windows.Forms.ToolStripMenuItem();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.listView1 = new System.Windows.Forms.ListView();
            this.AddAll = new System.Windows.Forms.ToolStripMenuItem();
            this.txtCommit = new System.Windows.Forms.TextBox();
            this.btnCommit = new System.Windows.Forms.Button();
            this.pushToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ficheiroToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ficheiroToolStripMenuItem
            // 
            this.ficheiroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AbrirFolder,
            this.EstadoGit,
            this.AddAll,
            this.pushToolStripMenuItem});
            this.ficheiroToolStripMenuItem.Name = "ficheiroToolStripMenuItem";
            this.ficheiroToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.ficheiroToolStripMenuItem.Text = "Ficheiro";
            // 
            // AbrirFolder
            // 
            this.AbrirFolder.Name = "AbrirFolder";
            this.AbrirFolder.Size = new System.Drawing.Size(180, 22);
            this.AbrirFolder.Text = "Abrir";
            this.AbrirFolder.Click += new System.EventHandler(this.AbrirFolder_Click);
            // 
            // EstadoGit
            // 
            this.EstadoGit.Name = "EstadoGit";
            this.EstadoGit.Size = new System.Drawing.Size(180, 22);
            this.EstadoGit.Text = "Estado";
            this.EstadoGit.Click += new System.EventHandler(this.EstadoGit_Click);
            // 
            // FolderBrowser
            // 
            this.FolderBrowser.Description = "Description";
            this.FolderBrowser.ShowNewFolderButton = false;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(0, 27);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(430, 398);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // AddAll
            // 
            this.AddAll.Name = "AddAll";
            this.AddAll.Size = new System.Drawing.Size(180, 22);
            this.AddAll.Text = "Add All";
            this.AddAll.Click += new System.EventHandler(this.AddAll_Click);
            // 
            // txtCommit
            // 
            this.txtCommit.Location = new System.Drawing.Point(451, 27);
            this.txtCommit.Multiline = true;
            this.txtCommit.Name = "txtCommit";
            this.txtCommit.Size = new System.Drawing.Size(337, 103);
            this.txtCommit.TabIndex = 4;
            // 
            // btnCommit
            // 
            this.btnCommit.Enabled = false;
            this.btnCommit.Location = new System.Drawing.Point(451, 137);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(75, 23);
            this.btnCommit.TabIndex = 5;
            this.btnCommit.Text = "Commit";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // pushToolStripMenuItem
            // 
            this.pushToolStripMenuItem.Name = "pushToolStripMenuItem";
            this.pushToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pushToolStripMenuItem.Text = "Push";
            this.pushToolStripMenuItem.Click += new System.EventHandler(this.pushToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.txtCommit);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ficheiroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AbrirFolder;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private LibGit2Sharp.Repository Repo;
        private System.Windows.Forms.ToolStripMenuItem EstadoGit;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripMenuItem AddAll;
        private System.Windows.Forms.TextBox txtCommit;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.ToolStripMenuItem pushToolStripMenuItem;
    }
}

