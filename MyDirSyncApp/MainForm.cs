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
            progressBar1.Value = 5;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    txtSource.Text = folderDialog.SelectedPath;
                }
            }

        }

        private void btnViewLog_Click(object sender, EventArgs e)
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

        private void btnBrowseDestination_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    txtDestination.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Log(string message)
        {
            string logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ReplicationLog.txt");
            using (StreamWriter writer = new StreamWriter(logFile, true))
            {
                writer.WriteLine($"{DateTime.Now} - {message}");
            }
        }

        private void btnReplicate_Click(object sender, EventArgs e)
        {
            sourceDirectory = txtSource.Text;
            destinationDirectory = txtDestination.Text;
            includeSubdirectories = checkBoxIncludeSubDir.Checked;


            Properties.Settings.Default.SourceDirectory = sourceDirectory;
            Properties.Settings.Default.DestinationDirectory = destinationDirectory;
            Properties.Settings.Default.IncludeSubdirectories = includeSubdirectories;
            Properties.Settings.Default.Save();

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
            string[] files = Directory.GetFiles(sourceDir);

            foreach (string file in files)
            {
                string destFile = Path.Combine(destinationDir, Path.GetFileName(file));
                FileInfo sourceFileInfo = new FileInfo(file);
                FileInfo destFileInfo = new FileInfo(destFile);

                if (!destFileInfo.Exists || sourceFileInfo.Length != destFileInfo.Length || sourceFileInfo.LastWriteTimeUtc != destFileInfo.LastWriteTimeUtc)
                {
                    File.Copy(file, destFile, true);
                    Log($"Copied: {file} to {destFile}");
                }

                progressBar1.Value = (int)(((double)progressBar1.Value / files.Length) * 100);
            }

            if (includeSubdirectories)
            {
                string[] subDirectories = Directory.GetDirectories(sourceDir);

                foreach (string subDir in subDirectories)
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
                string[] destFiles = Directory.GetFiles(destinationDir);

                foreach (string destFile in destFiles)
                {
                    string srcFile = Path.Combine(sourceDir, Path.GetFileName(destFile));

                    if (!File.Exists(srcFile))
                    {
                        File.Delete(destFile);
                        Log($"Deleted: {destFile}");
                    }

                    progressBar1.Value = (int)(((double)progressBar1.Value / destFiles.Length) * 100);
                }

                if (includeSubdirectories)
                {
                    string[] destSubDirectories = Directory.GetDirectories(destinationDir);

                    foreach (string destSubDir in destSubDirectories)
                    {
                        string srcSubDir = Path.Combine(sourceDir, Path.GetFileName(destSubDir));

                        if (!Directory.Exists(srcSubDir))
                        {
                            Directory.Delete(destSubDir, true);
                            Log($"Deleted Directory: {destSubDir}");
                        }

                        progressBar1.Value = (int)(((double)progressBar1.Value / destSubDirectories.Length) * 100);
                    }
                }
            }
        }
    }
}
