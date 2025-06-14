﻿namespace CrosswordAssistant
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
            buttonResetToDefault = new Button();
            buttonSettingsApply = new Button();
            buttonSettingsCancel = new Button();
            buttonSettingsOK = new Button();
            tabControl1 = new TabControl();
            tabPageGeneral = new TabPage();
            groupBoxMainFormPosition = new GroupBox();
            label3 = new Label();
            radioBtnPosC = new RadioButton();
            radioBtnPosTL = new RadioButton();
            radioBtnPosTR = new RadioButton();
            groupBoxDictSettings = new GroupBox();
            saveDictLocBtn = new Button();
            textBoxDefaultDictPath = new TextBox();
            labelDefaultDictLoc = new Label();
            textBoxMaxResultsCount = new TextBox();
            labelMaxResultsCount = new Label();
            tabPageApparence = new TabPage();
            groupBoxColorsSettings = new GroupBox();
            buttonScrabbleColor = new Button();
            labelColorScrabble = new Label();
            label2 = new Label();
            buttonUlozSamColor = new Button();
            labelColorUlozSam = new Label();
            label1 = new Label();
            buttonPatternColor = new Button();
            labelColorPattern = new Label();
            labelPatternColor = new Label();
            labelColorSettings = new Label();
            setColorDialog = new ColorDialog();
            panelSettingsControls.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageGeneral.SuspendLayout();
            groupBoxMainFormPosition.SuspendLayout();
            groupBoxDictSettings.SuspendLayout();
            tabPageApparence.SuspendLayout();
            groupBoxColorsSettings.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialogNewDefaultDictPath
            // 
            openFileDialogNewDefaultDictPath.FileName = "openFileDialog1";
            // 
            // panelSettingsControls
            // 
            panelSettingsControls.Controls.Add(buttonResetToDefault);
            panelSettingsControls.Controls.Add(buttonSettingsApply);
            panelSettingsControls.Controls.Add(buttonSettingsCancel);
            panelSettingsControls.Controls.Add(buttonSettingsOK);
            panelSettingsControls.Dock = DockStyle.Bottom;
            panelSettingsControls.Location = new Point(0, 394);
            panelSettingsControls.Name = "panelSettingsControls";
            panelSettingsControls.Size = new Size(896, 56);
            panelSettingsControls.TabIndex = 1;
            // 
            // buttonResetToDefault
            // 
            buttonResetToDefault.FlatStyle = FlatStyle.Flat;
            buttonResetToDefault.Location = new Point(7, 11);
            buttonResetToDefault.Name = "buttonResetToDefault";
            buttonResetToDefault.Size = new Size(269, 34);
            buttonResetToDefault.TabIndex = 3;
            buttonResetToDefault.Text = "Przywróć ustawienia domyślne";
            buttonResetToDefault.UseVisualStyleBackColor = true;
            buttonResetToDefault.Click += BackToDefaultSettings_Click;
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
            tabPageGeneral.Controls.Add(groupBoxMainFormPosition);
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
            // groupBoxMainFormPosition
            // 
            groupBoxMainFormPosition.Controls.Add(label3);
            groupBoxMainFormPosition.Controls.Add(radioBtnPosC);
            groupBoxMainFormPosition.Controls.Add(radioBtnPosTL);
            groupBoxMainFormPosition.Controls.Add(radioBtnPosTR);
            groupBoxMainFormPosition.Dock = DockStyle.Bottom;
            groupBoxMainFormPosition.Location = new Point(3, 117);
            groupBoxMainFormPosition.Name = "groupBoxMainFormPosition";
            groupBoxMainFormPosition.Size = new Size(882, 107);
            groupBoxMainFormPosition.TabIndex = 7;
            groupBoxMainFormPosition.TabStop = false;
            groupBoxMainFormPosition.Text = "Okno główne";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 36);
            label3.Name = "label3";
            label3.Size = new Size(605, 25);
            label3.TabIndex = 3;
            label3.Text = "Domyślna pozycja okna głównego (zmiany widoczne po restarcie aplikacji):";
            // 
            // radioBtnPosC
            // 
            radioBtnPosC.AutoSize = true;
            radioBtnPosC.Checked = true;
            radioBtnPosC.Location = new Point(461, 72);
            radioBtnPosC.Name = "radioBtnPosC";
            radioBtnPosC.Size = new Size(156, 29);
            radioBtnPosC.TabIndex = 6;
            radioBtnPosC.TabStop = true;
            radioBtnPosC.Text = "wyśrodkowane";
            radioBtnPosC.UseVisualStyleBackColor = true;
            radioBtnPosC.CheckedChanged += RadioBtnPos_CheckedChange;
            // 
            // radioBtnPosTL
            // 
            radioBtnPosTL.AutoSize = true;
            radioBtnPosTL.Location = new Point(76, 72);
            radioBtnPosTL.Name = "radioBtnPosTL";
            radioBtnPosTL.Size = new Size(157, 29);
            radioBtnPosTL.TabIndex = 4;
            radioBtnPosTL.Text = "lewy górny róg";
            radioBtnPosTL.UseVisualStyleBackColor = true;
            radioBtnPosTL.CheckedChanged += RadioBtnPos_CheckedChange;
            // 
            // radioBtnPosTR
            // 
            radioBtnPosTR.AutoSize = true;
            radioBtnPosTR.Location = new Point(259, 72);
            radioBtnPosTR.Name = "radioBtnPosTR";
            radioBtnPosTR.Size = new Size(170, 29);
            radioBtnPosTR.TabIndex = 5;
            radioBtnPosTR.Text = "prawy górny róg";
            radioBtnPosTR.UseVisualStyleBackColor = true;
            radioBtnPosTR.CheckedChanged += RadioBtnPos_CheckedChange;
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
            textBoxMaxResultsCount.TextChanged += MaxResults_TextChanged;
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
            tabPageApparence.Controls.Add(groupBoxColorsSettings);
            tabPageApparence.Location = new Point(4, 37);
            tabPageApparence.Name = "tabPageApparence";
            tabPageApparence.Padding = new Padding(3);
            tabPageApparence.Size = new Size(888, 353);
            tabPageApparence.TabIndex = 1;
            tabPageApparence.Text = "Wygląd";
            tabPageApparence.UseVisualStyleBackColor = true;
            // 
            // groupBoxColorsSettings
            // 
            groupBoxColorsSettings.Controls.Add(buttonScrabbleColor);
            groupBoxColorsSettings.Controls.Add(labelColorScrabble);
            groupBoxColorsSettings.Controls.Add(label2);
            groupBoxColorsSettings.Controls.Add(buttonUlozSamColor);
            groupBoxColorsSettings.Controls.Add(labelColorUlozSam);
            groupBoxColorsSettings.Controls.Add(label1);
            groupBoxColorsSettings.Controls.Add(buttonPatternColor);
            groupBoxColorsSettings.Controls.Add(labelColorPattern);
            groupBoxColorsSettings.Controls.Add(labelPatternColor);
            groupBoxColorsSettings.Controls.Add(labelColorSettings);
            groupBoxColorsSettings.Dock = DockStyle.Top;
            groupBoxColorsSettings.Location = new Point(3, 3);
            groupBoxColorsSettings.Name = "groupBoxColorsSettings";
            groupBoxColorsSettings.Size = new Size(882, 150);
            groupBoxColorsSettings.TabIndex = 0;
            groupBoxColorsSettings.TabStop = false;
            groupBoxColorsSettings.Text = "Kolory";
            // 
            // buttonScrabbleColor
            // 
            buttonScrabbleColor.FlatStyle = FlatStyle.Flat;
            buttonScrabbleColor.Location = new Point(531, 100);
            buttonScrabbleColor.Name = "buttonScrabbleColor";
            buttonScrabbleColor.Size = new Size(112, 34);
            buttonScrabbleColor.TabIndex = 9;
            buttonScrabbleColor.Text = "Zmień";
            buttonScrabbleColor.UseVisualStyleBackColor = true;
            buttonScrabbleColor.Click += ScrabbleColor_Click;
            // 
            // labelColorScrabble
            // 
            labelColorScrabble.BackColor = Color.DarkSeaGreen;
            labelColorScrabble.Location = new Point(480, 100);
            labelColorScrabble.Name = "labelColorScrabble";
            labelColorScrabble.Size = new Size(45, 34);
            labelColorScrabble.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(480, 72);
            label2.Name = "label2";
            label2.Size = new Size(80, 25);
            label2.TabIndex = 7;
            label2.Text = "Scrabble";
            // 
            // buttonUlozSamColor
            // 
            buttonUlozSamColor.FlatStyle = FlatStyle.Flat;
            buttonUlozSamColor.Location = new Point(295, 100);
            buttonUlozSamColor.Name = "buttonUlozSamColor";
            buttonUlozSamColor.Size = new Size(112, 34);
            buttonUlozSamColor.TabIndex = 6;
            buttonUlozSamColor.Text = "Zmień";
            buttonUlozSamColor.UseVisualStyleBackColor = true;
            buttonUlozSamColor.Click += UlozSamColor_Click;
            // 
            // labelColorUlozSam
            // 
            labelColorUlozSam.BackColor = Color.DarkSeaGreen;
            labelColorUlozSam.Location = new Point(244, 100);
            labelColorUlozSam.Name = "labelColorUlozSam";
            labelColorUlozSam.Size = new Size(45, 34);
            labelColorUlozSam.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(244, 72);
            label1.Name = "label1";
            label1.Size = new Size(86, 25);
            label1.TabIndex = 4;
            label1.Text = "Ułóż sam";
            // 
            // buttonPatternColor
            // 
            buttonPatternColor.FlatStyle = FlatStyle.Flat;
            buttonPatternColor.Location = new Point(62, 100);
            buttonPatternColor.Name = "buttonPatternColor";
            buttonPatternColor.Size = new Size(112, 34);
            buttonPatternColor.TabIndex = 3;
            buttonPatternColor.Text = "Zmień";
            buttonPatternColor.UseVisualStyleBackColor = true;
            buttonPatternColor.Click += PatternColor_Click;
            // 
            // labelColorPattern
            // 
            labelColorPattern.BackColor = Color.DarkSeaGreen;
            labelColorPattern.Location = new Point(11, 100);
            labelColorPattern.Name = "labelColorPattern";
            labelColorPattern.Size = new Size(45, 34);
            labelColorPattern.TabIndex = 2;
            // 
            // labelPatternColor
            // 
            labelPatternColor.AutoSize = true;
            labelPatternColor.Location = new Point(11, 72);
            labelPatternColor.Name = "labelPatternColor";
            labelPatternColor.Size = new Size(103, 25);
            labelPatternColor.TabIndex = 1;
            labelPatternColor.Text = "Szaradzista:";
            // 
            // labelColorSettings
            // 
            labelColorSettings.AutoSize = true;
            labelColorSettings.Location = new Point(6, 37);
            labelColorSettings.Name = "labelColorSettings";
            labelColorSettings.Size = new Size(635, 25);
            labelColorSettings.TabIndex = 0;
            labelColorSettings.Text = "Zmień kolorystykę wybranych zakładek (zmiany widoczne po restarcie aplikacji)";
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
            groupBoxMainFormPosition.ResumeLayout(false);
            groupBoxMainFormPosition.PerformLayout();
            groupBoxDictSettings.ResumeLayout(false);
            groupBoxDictSettings.PerformLayout();
            tabPageApparence.ResumeLayout(false);
            groupBoxColorsSettings.ResumeLayout(false);
            groupBoxColorsSettings.PerformLayout();
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
        private GroupBox groupBoxColorsSettings;
        private Label labelColorSettings;
        private ColorDialog setColorDialog;
        private Label labelPatternColor;
        private Label labelColorPattern;
        private Button buttonPatternColor;
        private Button buttonResetToDefault;
        private Button buttonUlozSamColor;
        private Label labelColorUlozSam;
        private Label label1;
        private Button buttonScrabbleColor;
        private Label labelColorScrabble;
        private Label label2;
        private Label label3;
        private RadioButton radioBtnPosTR;
        private RadioButton radioBtnPosTL;
        private RadioButton radioBtnPosC;
        private GroupBox groupBoxMainFormPosition;
    }
}