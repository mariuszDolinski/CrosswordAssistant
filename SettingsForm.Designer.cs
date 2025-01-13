namespace CrosswordAssistant
{
    partial class SettingsForm
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
            tabControl1 = new TabControl();
            tabPageSettingsDictionary = new TabPage();
            saveDictLocBtn = new Button();
            textBoxDefaultDictPath = new TextBox();
            labelDefaultDictLoc = new Label();
            tabPage2 = new TabPage();
            openFileDialogNewDefaultDictPath = new OpenFileDialog();
            tabControl1.SuspendLayout();
            tabPageSettingsDictionary.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Controls.Add(tabPageSettingsDictionary);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(896, 450);
            tabControl1.TabIndex = 0;
            // 
            // tabPageSettingsDictionary
            // 
            tabPageSettingsDictionary.Controls.Add(saveDictLocBtn);
            tabPageSettingsDictionary.Controls.Add(textBoxDefaultDictPath);
            tabPageSettingsDictionary.Controls.Add(labelDefaultDictLoc);
            tabPageSettingsDictionary.Location = new Point(4, 37);
            tabPageSettingsDictionary.Name = "tabPageSettingsDictionary";
            tabPageSettingsDictionary.Padding = new Padding(3);
            tabPageSettingsDictionary.Size = new Size(888, 409);
            tabPageSettingsDictionary.TabIndex = 0;
            tabPageSettingsDictionary.Text = "Słownik";
            tabPageSettingsDictionary.UseVisualStyleBackColor = true;
            // 
            // saveDictLocBtn
            // 
            saveDictLocBtn.FlatStyle = FlatStyle.Flat;
            saveDictLocBtn.Location = new Point(793, 42);
            saveDictLocBtn.Name = "saveDictLocBtn";
            saveDictLocBtn.Size = new Size(92, 34);
            saveDictLocBtn.TabIndex = 2;
            saveDictLocBtn.Text = "Zmień";
            saveDictLocBtn.UseVisualStyleBackColor = true;
            saveDictLocBtn.Click += SaveNewDictionaryPathBtn_Click;
            // 
            // textBoxDefaultDictPath
            // 
            textBoxDefaultDictPath.BackColor = SystemColors.HighlightText;
            textBoxDefaultDictPath.Enabled = false;
            textBoxDefaultDictPath.Location = new Point(15, 44);
            textBoxDefaultDictPath.Name = "textBoxDefaultDictPath";
            textBoxDefaultDictPath.Size = new Size(772, 31);
            textBoxDefaultDictPath.TabIndex = 1;
            // 
            // labelDefaultDictLoc
            // 
            labelDefaultDictLoc.AutoSize = true;
            labelDefaultDictLoc.Location = new Point(15, 16);
            labelDefaultDictLoc.Name = "labelDefaultDictLoc";
            labelDefaultDictLoc.Size = new Size(764, 25);
            labelDefaultDictLoc.TabIndex = 0;
            labelDefaultDictLoc.Text = "Domyślna lokalizacja pliku ze słownikiem, który będzie wczytywany przy uruchomieniu aplikacji:";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 37);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(888, 409);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Inne";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // openFileDialogNewDefaultDictPath
            // 
            openFileDialogNewDefaultDictPath.FileName = "openFileDialog1";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 450);
            Controls.Add(tabControl1);
            Name = "SettingsForm";
            Text = "Ustawienia";
            FormClosing += Settings_OnClosed;
            tabControl1.ResumeLayout(false);
            tabPageSettingsDictionary.ResumeLayout(false);
            tabPageSettingsDictionary.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageSettingsDictionary;
        private TabPage tabPage2;
        private Label labelDefaultDictLoc;
        private TextBox textBoxDefaultDictPath;
        private Button saveDictLocBtn;
        private OpenFileDialog openFileDialogNewDefaultDictPath;
    }
}