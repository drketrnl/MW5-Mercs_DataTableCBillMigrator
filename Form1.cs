using System;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.VisualBasic.Logging;

namespace DataTableCBillMigrator
{
    public partial class Form1 : Form
    {
        private string _dataTableFileName = "";
        private JsonNode _rootNode;
        private JsonArray _dataTableArray;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void LogToOutput(string message)
        {
            richTextBox_Output.AppendText(message + Environment.NewLine);
            richTextBox_Output.ScrollToCaret();
        }
        
        private void btn_OpenDataTable_Click(object sender, EventArgs e)
        {
            using OpenFileDialog fileDialogBox = new OpenFileDialog();
            fileDialogBox.Filter = @"JSON File (*.json)|*.json";
            fileDialogBox.RestoreDirectory = true;
            if (fileDialogBox.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            richTextBox_Output.Text = "";
            
            _dataTableFileName = fileDialogBox.FileName;
            textBox_FileName.Text = _dataTableFileName;
            
            var jsonString = File.ReadAllText(_dataTableFileName);
            
            var bSuccess = ParseDataTableJson(jsonString);
            
            _rootNode = JsonNode.Parse(jsonString);
            if (_rootNode is not JsonArray rootArray)
            {
                lbl_Entries.Text = @"No data found";
                return;
            }

            _dataTableArray = rootArray;
            lbl_Entries.Text = rootArray.Count + @" Entries";

            btn_Migrate.Enabled = true;
        }

        private bool ParseDataTableJson(string jsonString)
        {
            _rootNode = JsonNode.Parse(jsonString);
            if (_rootNode is not JsonArray rootArray)
            {
                lbl_Entries.Text = @"No data found";
                return false;
            }

            foreach (var currNode in rootArray)
            {
                var name = currNode?["Name"]?.GetValue<string>() ?? "ERROR";
                var deprecatedValue = currNode?["DEPRECATED_CBillBaseValue"]?.GetValue<int>() ?? 0;
                var bigIntElement = currNode?["CBillBaseValueBigInt"];
                var bigIntValue = bigIntElement?["Value"]?.GetValue<Int64>() ?? 0;

            }

            return true;
        }

        private void btn_Migrate_Click(object sender, EventArgs e)
        {
            LogToOutput(@"Migrating " + Path.GetFileName(_dataTableFileName) + "\n");
           
            foreach (var currNode in _dataTableArray)
            {
                var name = currNode?["Name"]?.GetValue<string>() ?? "ERROR";
                var deprecatedValue = currNode?["DEPRECATED_CBillBaseValue"]?.GetValue<int>() ?? 0;
                var bigIntElement = currNode?["CBillBaseValueBigInt"];
                if (bigIntElement != null)
                {
                    bigIntElement["Value"] = deprecatedValue;
                }

                LogToOutput(name);
                richTextBox_Output.SelectionStart = richTextBox_Output.Text.Length;
                richTextBox_Output.ScrollToCaret();
            }
                
            LogToOutput("");
            LogToOutput(@"Data migrated");
            
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var updatedJsonString = _rootNode.ToJsonString(options);
            LogToOutput("");
            LogToOutput(@"Save prompt");
            richTextBox_Output.SelectionStart = richTextBox_Output.Text.Length;
            richTextBox_Output.ScrollToCaret();

            using var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = @"Save As";
            saveFileDialog.Filter = @"JSON File (*.json)|*.json";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.FileName = _dataTableFileName;

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                LogToOutput("");
                LogToOutput(@"Save failure. Aborted?");
                richTextBox_Output.SelectionStart = richTextBox_Output.Text.Length;
                richTextBox_Output.ScrollToCaret();
                
                return;
            }

            if (saveFileDialog.FileName == null || saveFileDialog.FileName.Length == 0)
            {
                LogToOutput("");
                LogToOutput(@"Invalid save file!");

                return;
            }
            
            File.WriteAllText(saveFileDialog.FileName, updatedJsonString);
            LogToOutput("");
            LogToOutput(@"Finished!");
            richTextBox_Output.SelectionStart = richTextBox_Output.Text.Length;
            richTextBox_Output.ScrollToCaret();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbl_Entries.Text = @"";
            btn_Migrate.Enabled = false;
        }
    }
}
