
namespace MyDirSyncApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button btnBrowseDestination;
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxIncludeSubDir = new System.Windows.Forms.CheckBox();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.btnReplicate = new System.Windows.Forms.Button();
            this.btnViewLog = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            btnBrowseDestination = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowseDestination
            // 
            btnBrowseDestination.Location = new System.Drawing.Point(845, 138);
            btnBrowseDestination.Name = "btnBrowseDestination";
            btnBrowseDestination.Size = new System.Drawing.Size(125, 34);
            btnBrowseDestination.TabIndex = 11;
            btnBrowseDestination.Text = "Browse";
            btnBrowseDestination.UseVisualStyleBackColor = true;
            btnBrowseDestination.Click += new System.EventHandler(this.btnBrowseDestination_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(65, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(29, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Destination";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxIncludeSubDir);
            this.panel1.Controls.Add(btnBrowseDestination);
            this.panel1.Controls.Add(this.btnBrowseSource);
            this.panel1.Controls.Add(this.txtDestination);
            this.panel1.Controls.Add(this.txtSource);
            this.panel1.Controls.Add(this.btnReplicate);
            this.panel1.Controls.Add(this.btnViewLog);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(89, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 569);
            this.panel1.TabIndex = 2;
            // 
            // checkBoxIncludeSubDir
            // 
            this.checkBoxIncludeSubDir.AutoSize = true;
            this.checkBoxIncludeSubDir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.checkBoxIncludeSubDir.Location = new System.Drawing.Point(161, 216);
            this.checkBoxIncludeSubDir.Name = "checkBoxIncludeSubDir";
            this.checkBoxIncludeSubDir.Size = new System.Drawing.Size(235, 29);
            this.checkBoxIncludeSubDir.TabIndex = 13;
            this.checkBoxIncludeSubDir.Text = "Include Sub Directories";
            this.checkBoxIncludeSubDir.UseVisualStyleBackColor = true;
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.Location = new System.Drawing.Point(845, 66);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(125, 34);
            this.btnBrowseSource.TabIndex = 10;
            this.btnBrowseSource.Text = "Browse";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(161, 140);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(667, 31);
            this.txtDestination.TabIndex = 9;
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(161, 69);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(667, 31);
            this.txtSource.TabIndex = 8;
            // 
            // btnReplicate
            // 
            this.btnReplicate.Location = new System.Drawing.Point(161, 285);
            this.btnReplicate.Name = "btnReplicate";
            this.btnReplicate.Size = new System.Drawing.Size(112, 34);
            this.btnReplicate.TabIndex = 7;
            this.btnReplicate.Text = "Replicate";
            this.btnReplicate.UseVisualStyleBackColor = true;
            this.btnReplicate.Click += new System.EventHandler(this.btnReplicate_Click);
            // 
            // btnViewLog
            // 
            this.btnViewLog.Location = new System.Drawing.Point(161, 478);
            this.btnViewLog.Name = "btnViewLog";
            this.btnViewLog.Size = new System.Drawing.Size(112, 34);
            this.btnViewLog.TabIndex = 6;
            this.btnViewLog.Text = "View Log";
            this.btnViewLog.UseVisualStyleBackColor = true;
            this.btnViewLog.Click += new System.EventHandler(this.btnViewLog_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(161, 391);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(809, 42);
            this.progressBar1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(29, 400);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Progress Bar";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(845, 478);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(125, 34);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 771);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "ReplicateIT";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReplicate;
        private System.Windows.Forms.Button btnViewLog;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Button btnBrowseDestination;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.CheckBox checkBoxIncludeSubDir;
    }
}

