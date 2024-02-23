using System;
using System.IO;
using System.Windows.Forms;

namespace MyDirSyncApp
{
    public partial class MainForm : Form
    {
        private string sourceDirectory;
        private string destinationDirectory;
        private bool includeSubdirectories;
        private bool doNotDelete;

        public MainForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            txtSource.Text = Properties.Settings.Default.SourceDirectory;
            txtDestination.Text = Properties.Settings.Default.DestinationDirectory;
            checkBoxIncludeSubDir.Checked = Properties.Settings.Default.IncludeSubdirectories;
            checkBoxDoNotDelete.Checked = Properties.Settings.Default.DoNotDelete;
        }
        private void button1_Click(object sender, EventArgs e) => Application.Exit();
        private void btnBrowseSource_Click(object sender, EventArgs e) => SelectFolder(txtSource);
        private void btnViewLog_Click(object sender, EventArgs e) => OpenLogFile();
        private void btnBrowseDestination_Click(object sender, EventArgs e) => SelectFolder(txtDestination);
        private void btnExit_Click(object sender, EventArgs e) => Application.Exit();
        private void Log(string message) => File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ReplicationLog.txt"), $"{DateTime.Now} - {message}\n");
        private void btnReplicate_Click(object sender, EventArgs e)
        {
            sourceDirectory = txtSource.Text;
            destinationDirectory = txtDestination.Text;
            includeSubdirectories = checkBoxIncludeSubDir.Checked;
            doNotDelete = checkBoxDoNotDelete.Checked;

            SaveSettings();

            if (string.IsNullOrWhiteSpace(sourceDirectory) || string.IsNullOrWhiteSpace(destinationDirectory))
            {
                MessageBox.Show("Please select source and destination directories.");
                return;
            }

            if (!Directory.Exists(sourceDirectory))
            {
                MessageBox.Show("Source directory does not exist.");
                return;
            }

            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            Log("Starting replication process..");
            progressBar1.Value = 0;
            ReplicateDirectories(sourceDirectory, destinationDirectory);
            Log("Replication process completed.");
            MessageBox.Show("Replication completed.");
        }

        private void ReplicateDirectories(string sourceDir, string destinationDir)
        {
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(destinationDir, Path.GetFileName(file));
                FileInfo sourceFileInfo = new FileInfo(file);
                FileInfo destFileInfo = new FileInfo(destFile);

                if (!destFileInfo.Exists || sourceFileInfo.Length != destFileInfo.Length || sourceFileInfo.LastWriteTimeUtc != destFileInfo.LastWriteTimeUtc)
                {
                    File.Copy(file, destFile, true);
                    Log($"Copied: {file} to {destFile}");
                }

                progressBar1.Value++;
            }

            if (includeSubdirectories)
            {
                foreach (string subDir in Directory.GetDirectories(sourceDir))
                {
                    string destSubDir = Path.Combine(destinationDir, Path.GetFileName(subDir));
                    if (!Directory.Exists(destSubDir))
                    {
                        Directory.CreateDirectory(destSubDir);
                        Log($"Created Directory: {destSubDir}");
                    }
                    ReplicateDirectories(subDir, destSubDir);
                }
            }

            if (!doNotDelete)
            {
                foreach (string destFile in Directory.GetFiles(destinationDir))
                {
                    string srcFile = Path.Combine(sourceDir, Path.GetFileName(destFile));

                    if (!File.Exists(srcFile))
                    {
                        File.Delete(destFile);
                        Log($"Deleted: {destFile}");
                    }

                    progressBar1.Value++;
                }

                if (includeSubdirectories)
                {
                    foreach (string destSubDir in Directory.GetDirectories(destinationDir))
                    {
                        string srcSubDir = Path.Combine(sourceDir, Path.GetFileName(destSubDir));

                        if (!Directory.Exists(srcSubDir))
                        {
                            Directory.Delete(destSubDir, true);
                            Log($"Deleted Directory: {destSubDir}");
                        }

                        progressBar1.Value++;
                    }
                }
            }
        }

        private void SelectFolder(TextBox textBox)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    textBox.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void OpenLogFile()
        {
            string logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ReplicationLog.txt");
            if (File.Exists(logFile))
            {
                System.Diagnostics.Process.Start("notepad.exe", logFile);
            }
            else
            {
                MessageBox.Show("Log file not found.");
            }
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.SourceDirectory = sourceDirectory;
            Properties.Settings.Default.DestinationDirectory = destinationDirectory;
            Properties.Settings.Default.IncludeSubdirectories = includeSubdirectories;
            Properties.Settings.Default.DoNotDelete = doNotDelete;
            Properties.Settings.Default.Save();
        }
    }
}
