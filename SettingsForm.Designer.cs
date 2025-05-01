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
            openFileDialogNewDefaultDictPath = new OpenFileDialog();
            panelSettingsControls = new Panel();
            buttonSettingsApply = new Button();
            buttonSettingsCancel = new Button();
            buttonSettingsOK = new Button();
            tabControl1 = new TabControl();
            tabPageGeneral = new TabPage();
            groupBoxDictSettings = new GroupBox();
            saveDictLocBtn = new Button();
            textBoxDefaultDictPath = new TextBox();
            labelDefaultDictLoc = new Label();
            textBoxMaxResultsCount = new TextBox();
            labelMaxResultsCount = new Label();
            tabPageApparence = new TabPage();
            panelSettingsControls.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageGeneral.SuspendLayout();
            groupBoxDictSettings.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialogNewDefaultDictPath
            // 
            openFileDialogNewDefaultDictPath.FileName = "openFileDialog1";
            // 
            // panelSettingsControls
            // 
            panelSettingsControls.Controls.Add(buttonSettingsApply);
            panelSettingsControls.Controls.Add(buttonSettingsCancel);
            panelSettingsControls.Controls.Add(buttonSettingsOK);
            panelSettingsControls.Dock = DockStyle.Bottom;
            panelSettingsControls.Location = new Point(0, 394);
            panelSettingsControls.Name = "panelSettingsControls";
            panelSettingsControls.Size = new Size(896, 56);
            panelSettingsControls.TabIndex = 1;
            // 
            // buttonSettingsApply
            // 
            buttonSettingsApply.Enabled = false;
            buttonSettingsApply.FlatStyle = FlatStyle.Flat;
            buttonSettingsApply.Location = new Point(653, 11);
            buttonSettingsApply.Name = "buttonSettingsApply";
            buttonSettingsApply.Size = new Size(112, 34);
            buttonSettingsApply.TabIndex = 2;
            buttonSettingsApply.Text = "Zastosuj";
            buttonSettingsApply.UseVisualStyleBackColor = true;
            buttonSettingsApply.Click += SettingsApply_Click;
            // 
            // buttonSettingsCancel
            // 
            buttonSettingsCancel.FlatStyle = FlatStyle.Flat;
            buttonSettingsCancel.Location = new Point(771, 11);
            buttonSettingsCancel.Name = "buttonSettingsCancel";
            buttonSettingsCancel.Size = new Size(112, 34);
            buttonSettingsCancel.TabIndex = 1;
            buttonSettingsCancel.Text = "Anuluj";
            buttonSettingsCancel.UseVisualStyleBackColor = true;
            buttonSettingsCancel.Click += SettingsCancel_Click;
            // 
            // buttonSettingsOK
            // 
            buttonSettingsOK.Enabled = false;
            buttonSettingsOK.FlatStyle = FlatStyle.Flat;
            buttonSettingsOK.Location = new Point(536, 11);
            buttonSettingsOK.Name = "buttonSettingsOK";
            buttonSettingsOK.Size = new Size(112, 34);
            buttonSettingsOK.TabIndex = 0;
            buttonSettingsOK.Text = "Zapisz";
            buttonSettingsOK.UseVisualStyleBackColor = true;
            buttonSettingsOK.Click += SettingsSave_Click;
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Controls.Add(tabPageGeneral);
            tabControl1.Controls.Add(tabPageApparence);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(896, 394);
            tabControl1.TabIndex = 2;
            // 
            // tabPageGeneral
            // 
            tabPageGeneral.Controls.Add(groupBoxDictSettings);
            tabPageGeneral.Controls.Add(textBoxMaxResultsCount);
            tabPageGeneral.Controls.Add(labelMaxResultsCount);
            tabPageGeneral.Location = new Point(4, 37);
            tabPageGeneral.Name = "tabPageGeneral";
            tabPageGeneral.Padding = new Padding(3);
            tabPageGeneral.Size = new Size(888, 353);
            tabPageGeneral.TabIndex = 0;
            tabPageGeneral.Text = "Ogólne";
            tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBoxDictSettings
            // 
            groupBoxDictSettings.Controls.Add(saveDictLocBtn);
            groupBoxDictSettings.Controls.Add(textBoxDefaultDictPath);
            groupBoxDictSettings.Controls.Add(labelDefaultDictLoc);
            groupBoxDictSettings.Dock = DockStyle.Bottom;
            groupBoxDictSettings.Location = new Point(3, 224);
            groupBoxDictSettings.Name = "groupBoxDictSettings";
            groupBoxDictSettings.Size = new Size(882, 126);
            groupBoxDictSettings.TabIndex = 2;
            groupBoxDictSettings.TabStop = false;
            groupBoxDictSettings.Text = "Słownik";
            // 
            // saveDictLocBtn
            // 
            saveDictLocBtn.FlatStyle = FlatStyle.Flat;
            saveDictLocBtn.Location = new Point(735, 78);
            saveDictLocBtn.Name = "saveDictLocBtn";
            saveDictLocBtn.Size = new Size(141, 34);
            saveDictLocBtn.TabIndex = 2;
            saveDictLocBtn.Text = "Zmień";
            saveDictLocBtn.UseVisualStyleBackColor = true;
            saveDictLocBtn.Click += SaveNewDictionaryPathBtn_Click;
            // 
            // textBoxDefaultDictPath
            // 
            textBoxDefaultDictPath.BackColor = Color.White;
            textBoxDefaultDictPath.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBoxDefaultDictPath.Location = new Point(6, 78);
            textBoxDefaultDictPath.Name = "textBoxDefaultDictPath";
            textBoxDefaultDictPath.ReadOnly = true;
            textBoxDefaultDictPath.Size = new Size(723, 34);
            textBoxDefaultDictPath.TabIndex = 1;
            // 
            // labelDefaultDictLoc
            // 
            labelDefaultDictLoc.AutoSize = true;
            labelDefaultDictLoc.Location = new Point(5, 37);
            labelDefaultDictLoc.Name = "labelDefaultDictLoc";
            labelDefaultDictLoc.Size = new Size(764, 25);
            labelDefaultDictLoc.TabIndex = 0;
            labelDefaultDictLoc.Text = "Domyślna lokalizacja pliku ze słownikiem, który będzie wczytywany przy uruchomieniu aplikacji:";
            // 
            // textBoxMaxResultsCount
            // 
            textBoxMaxResultsCount.Location = new Point(507, 10);
            textBoxMaxResultsCount.Name = "textBoxMaxResultsCount";
            textBoxMaxResultsCount.Size = new Size(102, 31);
            textBoxMaxResultsCount.TabIndex = 1;
            // 
            // labelMaxResultsCount
            // 
            labelMaxResultsCount.AutoSize = true;
            labelMaxResultsCount.Location = new Point(8, 13);
            labelMaxResultsCount.Name = "labelMaxResultsCount";
            labelMaxResultsCount.Size = new Size(375, 25);
            labelMaxResultsCount.TabIndex = 0;
            labelMaxResultsCount.Text = "Maksymalna ilość wyświetlanych dopasowań: ";
            // 
            // tabPageApparence
            // 
            tabPageApparence.Location = new Point(4, 37);
            tabPageApparence.Name = "tabPageApparence";
            tabPageApparence.Padding = new Padding(3);
            tabPageApparence.Size = new Size(888, 353);
            tabPageApparence.TabIndex = 1;
            tabPageApparence.Text = "Wygląd";
            tabPageApparence.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 450);
            Controls.Add(tabControl1);
            Controls.Add(panelSettingsControls);
            Name = "SettingsForm";
            Text = "Ustawienia";
            FormClosing += Settings_OnClosed;
            panelSettingsControls.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPageGeneral.ResumeLayout(false);
            tabPageGeneral.PerformLayout();
            groupBoxDictSettings.ResumeLayout(false);
            groupBoxDictSettings.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private OpenFileDialog openFileDialogNewDefaultDictPath;
        private Panel panelSettingsControls;
        private TabControl tabControl1;
        private TabPage tabPageGeneral;
        private GroupBox groupBoxDictSettings;
        private TextBox textBoxDefaultDictPath;
        private Label labelDefaultDictLoc;
        private TextBox textBoxMaxResultsCount;
        private Label labelMaxResultsCount;
        private TabPage tabPageApparence;
        private Button saveDictLocBtn;
        private Button buttonSettingsApply;
        private Button buttonSettingsCancel;
        private Button buttonSettingsOK;
    }
}