namespace DataTableCBillMigrator
{
    partial class Form1
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
            btn_OpenDataTable = new System.Windows.Forms.Button();
            textBox_FileName = new System.Windows.Forms.TextBox();
            btn_Migrate = new System.Windows.Forms.Button();
            richTextBox_Output = new System.Windows.Forms.RichTextBox();
            lbl_Entries = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // btn_OpenDataTable
            // 
            btn_OpenDataTable.Location = new System.Drawing.Point(12, 13);
            btn_OpenDataTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btn_OpenDataTable.Name = "btn_OpenDataTable";
            btn_OpenDataTable.Size = new System.Drawing.Size(166, 59);
            btn_OpenDataTable.TabIndex = 0;
            btn_OpenDataTable.Text = "Select Data Table Json";
            btn_OpenDataTable.UseVisualStyleBackColor = true;
            btn_OpenDataTable.Click += btn_OpenDataTable_Click;
            // 
            // textBox_FileName
            // 
            textBox_FileName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox_FileName.Location = new System.Drawing.Point(184, 13);
            textBox_FileName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            textBox_FileName.Name = "textBox_FileName";
            textBox_FileName.ReadOnly = true;
            textBox_FileName.Size = new System.Drawing.Size(453, 27);
            textBox_FileName.TabIndex = 1;
            // 
            // btn_Migrate
            // 
            btn_Migrate.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btn_Migrate.Location = new System.Drawing.Point(12, 297);
            btn_Migrate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btn_Migrate.Name = "btn_Migrate";
            btn_Migrate.Size = new System.Drawing.Size(166, 59);
            btn_Migrate.TabIndex = 4;
            btn_Migrate.Text = "Migrate CBill Data";
            btn_Migrate.UseVisualStyleBackColor = true;
            btn_Migrate.Click += btn_Migrate_Click;
            // 
            // richTextBox_Output
            // 
            richTextBox_Output.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            richTextBox_Output.Location = new System.Drawing.Point(184, 49);
            richTextBox_Output.Name = "richTextBox_Output";
            richTextBox_Output.ReadOnly = true;
            richTextBox_Output.Size = new System.Drawing.Size(453, 308);
            richTextBox_Output.TabIndex = 5;
            richTextBox_Output.Text = "";
            // 
            // lbl_Entries
            // 
            lbl_Entries.Location = new System.Drawing.Point(12, 78);
            lbl_Entries.Name = "lbl_Entries";
            lbl_Entries.Size = new System.Drawing.Size(145, 23);
            lbl_Entries.TabIndex = 6;
            lbl_Entries.Text = "99999 Entries";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(649, 369);
            Controls.Add(lbl_Entries);
            Controls.Add(richTextBox_Output);
            Controls.Add(btn_Migrate);
            Controls.Add(textBox_FileName);
            Controls.Add(btn_OpenDataTable);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "DataTable CBill Migrator";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lbl_Entries;

        private System.Windows.Forms.RichTextBox richTextBox_Output;

        private System.Windows.Forms.TextBox textBox_FileName;
        private System.Windows.Forms.Button btn_Migrate;

        private System.Windows.Forms.Button btn_OpenDataTable;

        #endregion
    }
}

