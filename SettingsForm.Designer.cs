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
            buttonResetToDefault = new Button();
            buttonSettingsApply = new Button();
            buttonSettingsCancel = new Button();
            buttonSettingsOK = new Button();
            tabControl1 = new TabControl();
            tabPageGeneral = new TabPage();
            groupBoxSzaradzistaSettings = new GroupBox();
            radioBtnCaseSensitiveNo = new RadioButton();
            labelMaxResultsCount = new Label();
            radioBtnCaseSensitiveYes = new RadioButton();
            textBoxMaxResultsCount = new TextBox();
            labelCaseSensitive = new Label();
            groupBoxMainFormPosition = new GroupBox();
            label3 = new Label();
            radioBtnPosC = new RadioButton();
            radioBtnPosTL = new RadioButton();
            radioBtnPosTR = new RadioButton();
            groupBoxDictSettings = new GroupBox();
            saveDictLocBtn = new Button();
            textBoxDefaultDictPath = new TextBox();
            labelDefaultDictLoc = new Label();
            tabPageApparence = new TabPage();
            groupBoxColorsSettings = new GroupBox();
            buttonScrabbleColor = new Button();
            labelColorScrabble = new Label();
            label2 = new Label();
            buttonCryptharitmColor = new Button();
            labelColorCryptharitm = new Label();
            label1 = new Label();
            buttonPatternColor = new Button();
            labelColorPattern = new Label();
            labelPatternColor = new Label();
            labelColorSettings = new Label();
            setColorDialog = new ColorDialog();
            tabPageOthers = new TabPage();
            groupBoxClearAppConfig = new GroupBox();
            labelClearAppConfig = new Label();
            buttonClearAppConfig = new Button();
            panelSettingsControls.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageGeneral.SuspendLayout();
            groupBoxSzaradzistaSettings.SuspendLayout();
            groupBoxMainFormPosition.SuspendLayout();
            groupBoxDictSettings.SuspendLayout();
            tabPageApparence.SuspendLayout();
            groupBoxColorsSettings.SuspendLayout();
            tabPageOthers.SuspendLayout();
            groupBoxClearAppConfig.SuspendLayout();
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
            panelSettingsControls.Location = new Point(0, 400);
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
            tabControl1.Controls.Add(tabPageOthers);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(896, 400);
            tabControl1.TabIndex = 2;
            // 
            // tabPageGeneral
            // 
            tabPageGeneral.Controls.Add(groupBoxSzaradzistaSettings);
            tabPageGeneral.Controls.Add(groupBoxMainFormPosition);
            tabPageGeneral.Controls.Add(groupBoxDictSettings);
            tabPageGeneral.Location = new Point(4, 37);
            tabPageGeneral.Name = "tabPageGeneral";
            tabPageGeneral.Padding = new Padding(3);
            tabPageGeneral.Size = new Size(888, 359);
            tabPageGeneral.TabIndex = 0;
            tabPageGeneral.Text = "Ogólne";
            tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBoxSzaradzistaSettings
            // 
            groupBoxSzaradzistaSettings.Controls.Add(radioBtnCaseSensitiveNo);
            groupBoxSzaradzistaSettings.Controls.Add(labelMaxResultsCount);
            groupBoxSzaradzistaSettings.Controls.Add(radioBtnCaseSensitiveYes);
            groupBoxSzaradzistaSettings.Controls.Add(textBoxMaxResultsCount);
            groupBoxSzaradzistaSettings.Controls.Add(labelCaseSensitive);
            groupBoxSzaradzistaSettings.Dock = DockStyle.Top;
            groupBoxSzaradzistaSettings.Location = new Point(3, 3);
            groupBoxSzaradzistaSettings.Name = "groupBoxSzaradzistaSettings";
            groupBoxSzaradzistaSettings.Size = new Size(882, 120);
            groupBoxSzaradzistaSettings.TabIndex = 11;
            groupBoxSzaradzistaSettings.TabStop = false;
            groupBoxSzaradzistaSettings.Text = "Szaradzista";
            // 
            // radioBtnCaseSensitiveNo
            // 
            radioBtnCaseSensitiveNo.AutoSize = true;
            radioBtnCaseSensitiveNo.Checked = true;
            radioBtnCaseSensitiveNo.Location = new Point(330, 75);
            radioBtnCaseSensitiveNo.Name = "radioBtnCaseSensitiveNo";
            radioBtnCaseSensitiveNo.Size = new Size(63, 29);
            radioBtnCaseSensitiveNo.TabIndex = 9;
            radioBtnCaseSensitiveNo.TabStop = true;
            radioBtnCaseSensitiveNo.Text = "Nie";
            radioBtnCaseSensitiveNo.UseVisualStyleBackColor = true;
            radioBtnCaseSensitiveNo.CheckedChanged += RadioBtnCaseSensitive_CheckedChaged;
            // 
            // labelMaxResultsCount
            // 
            labelMaxResultsCount.AutoSize = true;
            labelMaxResultsCount.Location = new Point(6, 36);
            labelMaxResultsCount.Name = "labelMaxResultsCount";
            labelMaxResultsCount.Size = new Size(375, 25);
            labelMaxResultsCount.TabIndex = 0;
            labelMaxResultsCount.Text = "Maksymalna ilość wyświetlanych dopasowań: ";
            // 
            // radioBtnCaseSensitiveYes
            // 
            radioBtnCaseSensitiveYes.AutoSize = true;
            radioBtnCaseSensitiveYes.Location = new Point(437, 75);
            radioBtnCaseSensitiveYes.Name = "radioBtnCaseSensitiveYes";
            radioBtnCaseSensitiveYes.Size = new Size(62, 29);
            radioBtnCaseSensitiveYes.TabIndex = 10;
            radioBtnCaseSensitiveYes.Text = "Tak";
            radioBtnCaseSensitiveYes.UseVisualStyleBackColor = true;
            radioBtnCaseSensitiveYes.CheckedChanged += RadioBtnCaseSensitive_CheckedChaged;
            // 
            // textBoxMaxResultsCount
            // 
            textBoxMaxResultsCount.Location = new Point(397, 33);
            textBoxMaxResultsCount.Name = "textBoxMaxResultsCount";
            textBoxMaxResultsCount.Size = new Size(102, 31);
            textBoxMaxResultsCount.TabIndex = 1;
            textBoxMaxResultsCount.TextChanged += MaxResults_TextChanged;
            // 
            // labelCaseSensitive
            // 
            labelCaseSensitive.AutoSize = true;
            labelCaseSensitive.Location = new Point(6, 77);
            labelCaseSensitive.Name = "labelCaseSensitive";
            labelCaseSensitive.Size = new Size(225, 25);
            labelCaseSensitive.TabIndex = 8;
            labelCaseSensitive.Text = "Rozróżnianie wielkości liter:";
            // 
            // groupBoxMainFormPosition
            // 
            groupBoxMainFormPosition.Controls.Add(label3);
            groupBoxMainFormPosition.Controls.Add(radioBtnPosC);
            groupBoxMainFormPosition.Controls.Add(radioBtnPosTL);
            groupBoxMainFormPosition.Controls.Add(radioBtnPosTR);
            groupBoxMainFormPosition.Dock = DockStyle.Bottom;
            groupBoxMainFormPosition.Location = new Point(3, 123);
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
            label3.Size = new Size(291, 25);
            label3.TabIndex = 3;
            label3.Text = "Domyślna pozycja okna głównego:";
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
            groupBoxDictSettings.Location = new Point(3, 230);
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
            // tabPageApparence
            // 
            tabPageApparence.Controls.Add(groupBoxColorsSettings);
            tabPageApparence.Location = new Point(4, 37);
            tabPageApparence.Name = "tabPageApparence";
            tabPageApparence.Padding = new Padding(3);
            tabPageApparence.Size = new Size(888, 359);
            tabPageApparence.TabIndex = 1;
            tabPageApparence.Text = "Wygląd";
            tabPageApparence.UseVisualStyleBackColor = true;
            // 
            // groupBoxColorsSettings
            // 
            groupBoxColorsSettings.Controls.Add(buttonScrabbleColor);
            groupBoxColorsSettings.Controls.Add(labelColorScrabble);
            groupBoxColorsSettings.Controls.Add(label2);
            groupBoxColorsSettings.Controls.Add(buttonCryptharitmColor);
            groupBoxColorsSettings.Controls.Add(labelColorCryptharitm);
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
            buttonScrabbleColor.Location = new Point(335, 100);
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
            labelColorScrabble.Location = new Point(284, 100);
            labelColorScrabble.Name = "labelColorScrabble";
            labelColorScrabble.Size = new Size(45, 34);
            labelColorScrabble.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(284, 72);
            label2.Name = "label2";
            label2.Size = new Size(80, 25);
            label2.TabIndex = 7;
            label2.Text = "Scrabble";
            // 
            // buttonCryptharitmColor
            // 
            buttonCryptharitmColor.FlatStyle = FlatStyle.Flat;
            buttonCryptharitmColor.Location = new Point(608, 100);
            buttonCryptharitmColor.Name = "buttonCryptharitmColor";
            buttonCryptharitmColor.Size = new Size(112, 34);
            buttonCryptharitmColor.TabIndex = 6;
            buttonCryptharitmColor.Text = "Zmień";
            buttonCryptharitmColor.UseVisualStyleBackColor = true;
            buttonCryptharitmColor.Click += UlozSamColor_Click;
            // 
            // labelColorCryptharitm
            // 
            labelColorCryptharitm.BackColor = Color.DarkSeaGreen;
            labelColorCryptharitm.Location = new Point(557, 100);
            labelColorCryptharitm.Name = "labelColorCryptharitm";
            labelColorCryptharitm.Size = new Size(45, 34);
            labelColorCryptharitm.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(557, 72);
            label1.Name = "label1";
            label1.Size = new Size(109, 25);
            label1.TabIndex = 4;
            label1.Text = "Kryptarytmy";
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
            labelColorSettings.Size = new Size(325, 25);
            labelColorSettings.TabIndex = 0;
            labelColorSettings.Text = "Zmień kolorystykę wybranych zakładek:";
            // 
            // tabPageOthers
            // 
            tabPageOthers.Controls.Add(groupBoxClearAppConfig);
            tabPageOthers.Location = new Point(4, 37);
            tabPageOthers.Name = "tabPageOthers";
            tabPageOthers.Padding = new Padding(3);
            tabPageOthers.Size = new Size(888, 359);
            tabPageOthers.TabIndex = 2;
            tabPageOthers.Text = "Inne";
            tabPageOthers.UseVisualStyleBackColor = true;
            // 
            // groupBoxClearAppConfig
            // 
            groupBoxClearAppConfig.Controls.Add(buttonClearAppConfig);
            groupBoxClearAppConfig.Controls.Add(labelClearAppConfig);
            groupBoxClearAppConfig.Dock = DockStyle.Top;
            groupBoxClearAppConfig.Location = new Point(3, 3);
            groupBoxClearAppConfig.Name = "groupBoxClearAppConfig";
            groupBoxClearAppConfig.Size = new Size(882, 83);
            groupBoxClearAppConfig.TabIndex = 0;
            groupBoxClearAppConfig.TabStop = false;
            groupBoxClearAppConfig.Text = "Czyszczenie pliku z ustawieniami";
            // 
            // labelClearAppConfig
            // 
            labelClearAppConfig.Dock = DockStyle.Left;
            labelClearAppConfig.Location = new Point(3, 27);
            labelClearAppConfig.Name = "labelClearAppConfig";
            labelClearAppConfig.Size = new Size(646, 53);
            labelClearAppConfig.TabIndex = 0;
            labelClearAppConfig.Text = "Wyczyść plik z ustawieniami z niepotrzebnych wpisów.\r\nMoże to spoodować restart niektórych ustawień do wartości domyślnych.\r\n";
            labelClearAppConfig.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonClearAppConfig
            // 
            buttonClearAppConfig.Location = new Point(687, 30);
            buttonClearAppConfig.Name = "buttonClearAppConfig";
            buttonClearAppConfig.Size = new Size(112, 34);
            buttonClearAppConfig.TabIndex = 1;
            buttonClearAppConfig.Text = "Wyczyść";
            buttonClearAppConfig.UseVisualStyleBackColor = true;
            buttonClearAppConfig.Click += ClearAppConfigBtn_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 456);
            Controls.Add(tabControl1);
            Controls.Add(panelSettingsControls);
            MaximumSize = new Size(918, 514);
            MinimumSize = new Size(918, 514);
            Name = "SettingsForm";
            Text = "Ustawienia";
            FormClosing += Settings_OnClosed;
            panelSettingsControls.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPageGeneral.ResumeLayout(false);
            groupBoxSzaradzistaSettings.ResumeLayout(false);
            groupBoxSzaradzistaSettings.PerformLayout();
            groupBoxMainFormPosition.ResumeLayout(false);
            groupBoxMainFormPosition.PerformLayout();
            groupBoxDictSettings.ResumeLayout(false);
            groupBoxDictSettings.PerformLayout();
            tabPageApparence.ResumeLayout(false);
            groupBoxColorsSettings.ResumeLayout(false);
            groupBoxColorsSettings.PerformLayout();
            tabPageOthers.ResumeLayout(false);
            groupBoxClearAppConfig.ResumeLayout(false);
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
        private Button buttonCryptharitmColor;
        private Label labelColorCryptharitm;
        private Label label1;
        private Button buttonScrabbleColor;
        private Label labelColorScrabble;
        private Label label2;
        private Label label3;
        private RadioButton radioBtnPosTR;
        private RadioButton radioBtnPosTL;
        private RadioButton radioBtnPosC;
        private GroupBox groupBoxMainFormPosition;
        private Label labelCaseSensitive;
        private RadioButton radioBtnCaseSensitiveNo;
        private RadioButton radioBtnCaseSensitiveYes;
        private GroupBox groupBoxSzaradzistaSettings;
        private TabPage tabPageOthers;
        private GroupBox groupBoxClearAppConfig;
        private Label labelClearAppConfig;
        private Button buttonClearAppConfig;
    }
}