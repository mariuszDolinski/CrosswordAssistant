﻿namespace CrosswordAssistant
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tabControl = new TabControl();
            tabPattern = new TabPage();
            splitContainerResults = new SplitContainer();
            textBoxPatternResults = new TextBox();
            contextMenuStripResults = new ContextMenuStrip(components);
            szukajWToolStripMenuItem = new ToolStripMenuItem();
            googleToolStripMenuItem = new ToolStripMenuItem();
            sJPToolStripMenuItem = new ToolStripMenuItem();
            groupBoxFilters = new GroupBox();
            textBoxContains = new TextBox();
            checkBoxContains = new CheckBox();
            textBoxEndsWith = new TextBox();
            checkBoxEndsWith = new CheckBox();
            textBoxBeginsWith = new TextBox();
            checkBoxBeginWith = new CheckBox();
            groupBoxMode = new GroupBox();
            labelLenEnd = new Label();
            textBoxMaxLen = new TextBox();
            labelMaxLen = new Label();
            textBoxMinLen = new TextBox();
            labelMinLen = new Label();
            radioMetagramMode = new RadioButton();
            radioLengthMode = new RadioButton();
            radioAnagramMode = new RadioButton();
            radioPatternMode = new RadioButton();
            labelSpace3 = new Label();
            splitContainerPattern = new SplitContainer();
            textBoxPattern = new TextBox();
            searchPatternBtn = new Button();
            labelSpace1 = new Label();
            labelPattern = new Label();
            tabPageUlozSam = new TabPage();
            splitContainerUls = new SplitContainer();
            textBoxResultsUls = new TextBox();
            groupBoxUlsGroups = new GroupBox();
            tableLayoutPanelUsl = new TableLayoutPanel();
            textBoxGr8 = new TextBox();
            textBoxGr7 = new TextBox();
            textBoxGr6 = new TextBox();
            textBoxGr5 = new TextBox();
            textBoxGr4 = new TextBox();
            textBoxGr3 = new TextBox();
            textBoxGr2 = new TextBox();
            labelGr8 = new Label();
            labelGr7 = new Label();
            labelGr6 = new Label();
            labelGr4 = new Label();
            labelGr3 = new Label();
            labelGr2 = new Label();
            labelGr1 = new Label();
            labelGr5 = new Label();
            textBoxGr1 = new TextBox();
            label18 = new Label();
            label17 = new Label();
            label14 = new Label();
            label16 = new Label();
            label15 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            buttonSearchUls = new Button();
            label9 = new Label();
            textBoxPatternUls = new TextBox();
            label8 = new Label();
            labelUluzSam = new Label();
            tabPageDictionary = new TabPage();
            tableLayoutPanel3 = new TableLayoutPanel();
            groupBoxAddToDict = new GroupBox();
            buttonAddToDictionary = new Button();
            label21 = new Label();
            textBoxAddToDictionary = new TextBox();
            buttonLoadDict = new Button();
            label20 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            labelWordsCount = new Label();
            labelDicLengthInfo = new Label();
            labelFileNameInfo = new Label();
            labelFileName = new Label();
            labelDictionary = new Label();
            tabPageAbout = new TabPage();
            labelAbout = new Label();
            label2 = new Label();
            label1 = new Label();
            textBoxAbout = new TextBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            labelShortcuts = new Label();
            labelUlozSamInfo = new Label();
            labelLengthInfo = new Label();
            labelMetagramInfo = new Label();
            labelAnagramInfo = new Label();
            labelPatternInfo = new Label();
            label3 = new Label();
            labelSpace2 = new Label();
            labelHelp = new Label();
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label19 = new Label();
            label22 = new Label();
            newDictionaryDialog = new OpenFileDialog();
            tabControl.SuspendLayout();
            tabPattern.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerResults).BeginInit();
            splitContainerResults.Panel1.SuspendLayout();
            splitContainerResults.Panel2.SuspendLayout();
            splitContainerResults.SuspendLayout();
            contextMenuStripResults.SuspendLayout();
            groupBoxFilters.SuspendLayout();
            groupBoxMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerPattern).BeginInit();
            splitContainerPattern.Panel1.SuspendLayout();
            splitContainerPattern.Panel2.SuspendLayout();
            splitContainerPattern.SuspendLayout();
            tabPageUlozSam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerUls).BeginInit();
            splitContainerUls.Panel1.SuspendLayout();
            splitContainerUls.Panel2.SuspendLayout();
            splitContainerUls.SuspendLayout();
            groupBoxUlsGroups.SuspendLayout();
            tableLayoutPanelUsl.SuspendLayout();
            tabPageDictionary.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            groupBoxAddToDict.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tabPageAbout.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPattern);
            tabControl.Controls.Add(tabPageUlozSam);
            tabControl.Controls.Add(tabPageDictionary);
            tabControl.Controls.Add(tabPageAbout);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(825, 700);
            tabControl.TabIndex = 0;
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            // 
            // tabPattern
            // 
            tabPattern.Controls.Add(splitContainerResults);
            tabPattern.Controls.Add(labelSpace3);
            tabPattern.Controls.Add(splitContainerPattern);
            tabPattern.Controls.Add(labelSpace1);
            tabPattern.Controls.Add(labelPattern);
            tabPattern.Location = new Point(4, 34);
            tabPattern.Name = "tabPattern";
            tabPattern.Padding = new Padding(3);
            tabPattern.Size = new Size(817, 662);
            tabPattern.TabIndex = 0;
            tabPattern.Text = "Wzorzec";
            tabPattern.UseVisualStyleBackColor = true;
            // 
            // splitContainerResults
            // 
            splitContainerResults.Dock = DockStyle.Fill;
            splitContainerResults.Location = new Point(3, 78);
            splitContainerResults.Name = "splitContainerResults";
            // 
            // splitContainerResults.Panel1
            // 
            splitContainerResults.Panel1.Controls.Add(textBoxPatternResults);
            // 
            // splitContainerResults.Panel2
            // 
            splitContainerResults.Panel2.Controls.Add(groupBoxFilters);
            splitContainerResults.Panel2.Controls.Add(groupBoxMode);
            splitContainerResults.Size = new Size(811, 581);
            splitContainerResults.SplitterDistance = 479;
            splitContainerResults.TabIndex = 8;
            // 
            // textBoxPatternResults
            // 
            textBoxPatternResults.BackColor = SystemColors.ControlLight;
            textBoxPatternResults.BorderStyle = BorderStyle.FixedSingle;
            textBoxPatternResults.ContextMenuStrip = contextMenuStripResults;
            textBoxPatternResults.Dock = DockStyle.Fill;
            textBoxPatternResults.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBoxPatternResults.Location = new Point(0, 0);
            textBoxPatternResults.Multiline = true;
            textBoxPatternResults.Name = "textBoxPatternResults";
            textBoxPatternResults.ReadOnly = true;
            textBoxPatternResults.ScrollBars = ScrollBars.Vertical;
            textBoxPatternResults.Size = new Size(479, 581);
            textBoxPatternResults.TabIndex = 0;
            // 
            // contextMenuStripResults
            // 
            contextMenuStripResults.ImageScalingSize = new Size(24, 24);
            contextMenuStripResults.Items.AddRange(new ToolStripItem[] { szukajWToolStripMenuItem });
            contextMenuStripResults.Name = "contextMenuStripPR";
            contextMenuStripResults.Size = new Size(164, 36);
            // 
            // szukajWToolStripMenuItem
            // 
            szukajWToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { googleToolStripMenuItem, sJPToolStripMenuItem });
            szukajWToolStripMenuItem.Name = "szukajWToolStripMenuItem";
            szukajWToolStripMenuItem.Size = new Size(163, 32);
            szukajWToolStripMenuItem.Text = "Szukaj w...";
            // 
            // googleToolStripMenuItem
            // 
            googleToolStripMenuItem.Name = "googleToolStripMenuItem";
            googleToolStripMenuItem.Size = new Size(172, 34);
            googleToolStripMenuItem.Text = "Google";
            googleToolStripMenuItem.Click += SearchGoogle_MenuClick;
            // 
            // sJPToolStripMenuItem
            // 
            sJPToolStripMenuItem.Name = "sJPToolStripMenuItem";
            sJPToolStripMenuItem.Size = new Size(172, 34);
            sJPToolStripMenuItem.Text = "SJP";
            sJPToolStripMenuItem.Click += SearchSJP_MenuClick;
            // 
            // groupBoxFilters
            // 
            groupBoxFilters.Controls.Add(textBoxContains);
            groupBoxFilters.Controls.Add(checkBoxContains);
            groupBoxFilters.Controls.Add(textBoxEndsWith);
            groupBoxFilters.Controls.Add(checkBoxEndsWith);
            groupBoxFilters.Controls.Add(textBoxBeginsWith);
            groupBoxFilters.Controls.Add(checkBoxBeginWith);
            groupBoxFilters.Dock = DockStyle.Fill;
            groupBoxFilters.Location = new Point(0, 110);
            groupBoxFilters.Name = "groupBoxFilters";
            groupBoxFilters.Size = new Size(328, 471);
            groupBoxFilters.TabIndex = 1;
            groupBoxFilters.TabStop = false;
            groupBoxFilters.Text = "Dodatkowe filtry";
            // 
            // textBoxContains
            // 
            textBoxContains.Enabled = false;
            textBoxContains.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBoxContains.Location = new Point(26, 231);
            textBoxContains.Name = "textBoxContains";
            textBoxContains.Size = new Size(273, 37);
            textBoxContains.TabIndex = 5;
            // 
            // checkBoxContains
            // 
            checkBoxContains.AutoSize = true;
            checkBoxContains.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            checkBoxContains.Location = new Point(26, 196);
            checkBoxContains.Name = "checkBoxContains";
            checkBoxContains.Size = new Size(231, 29);
            checkBoxContains.TabIndex = 4;
            checkBoxContains.Text = "Tylko wyrazy zawierające";
            checkBoxContains.UseVisualStyleBackColor = true;
            checkBoxContains.CheckedChanged += CheckBoxContains_CheckedChanged;
            // 
            // textBoxEndsWith
            // 
            textBoxEndsWith.Enabled = false;
            textBoxEndsWith.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBoxEndsWith.Location = new Point(28, 153);
            textBoxEndsWith.Name = "textBoxEndsWith";
            textBoxEndsWith.Size = new Size(273, 37);
            textBoxEndsWith.TabIndex = 3;
            // 
            // checkBoxEndsWith
            // 
            checkBoxEndsWith.AutoSize = true;
            checkBoxEndsWith.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            checkBoxEndsWith.Location = new Point(26, 118);
            checkBoxEndsWith.Name = "checkBoxEndsWith";
            checkBoxEndsWith.Size = new Size(265, 29);
            checkBoxEndsWith.TabIndex = 2;
            checkBoxEndsWith.Text = "Tylko wyrazy kończące się na";
            checkBoxEndsWith.UseVisualStyleBackColor = true;
            checkBoxEndsWith.CheckedChanged += CheckBoxEndsWith_CheckedChanged;
            // 
            // textBoxBeginsWith
            // 
            textBoxBeginsWith.Enabled = false;
            textBoxBeginsWith.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBoxBeginsWith.Location = new Point(26, 75);
            textBoxBeginsWith.Name = "textBoxBeginsWith";
            textBoxBeginsWith.Size = new Size(273, 37);
            textBoxBeginsWith.TabIndex = 1;
            // 
            // checkBoxBeginWith
            // 
            checkBoxBeginWith.AutoSize = true;
            checkBoxBeginWith.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            checkBoxBeginWith.Location = new Point(26, 40);
            checkBoxBeginWith.Name = "checkBoxBeginWith";
            checkBoxBeginWith.Size = new Size(287, 29);
            checkBoxBeginWith.TabIndex = 0;
            checkBoxBeginWith.Text = "Tylko wyrazy zaczynające się od";
            checkBoxBeginWith.UseVisualStyleBackColor = true;
            checkBoxBeginWith.CheckedChanged += CheckBoxStartWith_CheckedChanged;
            // 
            // groupBoxMode
            // 
            groupBoxMode.Controls.Add(labelLenEnd);
            groupBoxMode.Controls.Add(textBoxMaxLen);
            groupBoxMode.Controls.Add(labelMaxLen);
            groupBoxMode.Controls.Add(textBoxMinLen);
            groupBoxMode.Controls.Add(labelMinLen);
            groupBoxMode.Controls.Add(radioMetagramMode);
            groupBoxMode.Controls.Add(radioLengthMode);
            groupBoxMode.Controls.Add(radioAnagramMode);
            groupBoxMode.Controls.Add(radioPatternMode);
            groupBoxMode.Dock = DockStyle.Top;
            groupBoxMode.Location = new Point(0, 0);
            groupBoxMode.Name = "groupBoxMode";
            groupBoxMode.Size = new Size(328, 110);
            groupBoxMode.TabIndex = 0;
            groupBoxMode.TabStop = false;
            groupBoxMode.Text = "Tryb";
            // 
            // labelLenEnd
            // 
            labelLenEnd.AutoSize = true;
            labelLenEnd.Location = new Point(225, 116);
            labelLenEnd.Name = "labelLenEnd";
            labelLenEnd.Size = new Size(76, 25);
            labelLenEnd.TabIndex = 8;
            labelLenEnd.Text = "znaków.";
            // 
            // textBoxMaxLen
            // 
            textBoxMaxLen.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBoxMaxLen.Location = new Point(166, 113);
            textBoxMaxLen.MaxLength = 2;
            textBoxMaxLen.Name = "textBoxMaxLen";
            textBoxMaxLen.Size = new Size(53, 31);
            textBoxMaxLen.TabIndex = 7;
            // 
            // labelMaxLen
            // 
            labelMaxLen.AutoSize = true;
            labelMaxLen.Location = new Point(123, 116);
            labelMaxLen.Name = "labelMaxLen";
            labelMaxLen.Size = new Size(34, 25);
            labelMaxLen.TabIndex = 6;
            labelMaxLen.Text = "do";
            // 
            // textBoxMinLen
            // 
            textBoxMinLen.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBoxMinLen.Location = new Point(58, 113);
            textBoxMinLen.MaxLength = 2;
            textBoxMinLen.Name = "textBoxMinLen";
            textBoxMinLen.Size = new Size(53, 31);
            textBoxMinLen.TabIndex = 5;
            // 
            // labelMinLen
            // 
            labelMinLen.AutoSize = true;
            labelMinLen.Location = new Point(13, 116);
            labelMinLen.Name = "labelMinLen";
            labelMinLen.Size = new Size(37, 25);
            labelMinLen.TabIndex = 4;
            labelMinLen.Text = "Od";
            // 
            // radioMetagramMode
            // 
            radioMetagramMode.AutoSize = true;
            radioMetagramMode.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            radioMetagramMode.Location = new Point(171, 69);
            radioMetagramMode.Name = "radioMetagramMode";
            radioMetagramMode.Size = new Size(128, 29);
            radioMetagramMode.TabIndex = 3;
            radioMetagramMode.TabStop = true;
            radioMetagramMode.Text = "Metagramy";
            radioMetagramMode.UseVisualStyleBackColor = true;
            radioMetagramMode.CheckedChanged += RadioMetagram_CheckedChanged;
            // 
            // radioLengthMode
            // 
            radioLengthMode.AutoSize = true;
            radioLengthMode.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            radioLengthMode.Location = new Point(26, 69);
            radioLengthMode.Name = "radioLengthMode";
            radioLengthMode.Size = new Size(103, 29);
            radioLengthMode.TabIndex = 2;
            radioLengthMode.TabStop = true;
            radioLengthMode.Text = "Długość";
            radioLengthMode.UseVisualStyleBackColor = true;
            radioLengthMode.CheckedChanged += RadioLength_CheckedChanged;
            // 
            // radioAnagramMode
            // 
            radioAnagramMode.AutoSize = true;
            radioAnagramMode.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            radioAnagramMode.Location = new Point(171, 34);
            radioAnagramMode.Name = "radioAnagramMode";
            radioAnagramMode.Size = new Size(119, 29);
            radioAnagramMode.TabIndex = 1;
            radioAnagramMode.Text = "Anagramy";
            radioAnagramMode.UseVisualStyleBackColor = true;
            radioAnagramMode.CheckedChanged += RadioAnagram_CheckedChanged;
            // 
            // radioPatternMode
            // 
            radioPatternMode.AutoSize = true;
            radioPatternMode.Checked = true;
            radioPatternMode.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            radioPatternMode.Location = new Point(26, 34);
            radioPatternMode.Name = "radioPatternMode";
            radioPatternMode.Size = new Size(104, 29);
            radioPatternMode.TabIndex = 0;
            radioPatternMode.TabStop = true;
            radioPatternMode.Text = "Wzorzec";
            radioPatternMode.UseVisualStyleBackColor = true;
            radioPatternMode.CheckedChanged += RadioPattern_CheckedChanged;
            // 
            // labelSpace3
            // 
            labelSpace3.BackColor = Color.Transparent;
            labelSpace3.Dock = DockStyle.Top;
            labelSpace3.Location = new Point(3, 75);
            labelSpace3.Name = "labelSpace3";
            labelSpace3.Size = new Size(811, 3);
            labelSpace3.TabIndex = 7;
            labelSpace3.Text = " ";
            // 
            // splitContainerPattern
            // 
            splitContainerPattern.Dock = DockStyle.Top;
            splitContainerPattern.Location = new Point(3, 38);
            splitContainerPattern.Name = "splitContainerPattern";
            // 
            // splitContainerPattern.Panel1
            // 
            splitContainerPattern.Panel1.Controls.Add(textBoxPattern);
            // 
            // splitContainerPattern.Panel2
            // 
            splitContainerPattern.Panel2.Controls.Add(searchPatternBtn);
            splitContainerPattern.Size = new Size(811, 37);
            splitContainerPattern.SplitterDistance = 588;
            splitContainerPattern.TabIndex = 6;
            // 
            // textBoxPattern
            // 
            textBoxPattern.CharacterCasing = CharacterCasing.Upper;
            textBoxPattern.Dock = DockStyle.Fill;
            textBoxPattern.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238);
            textBoxPattern.Location = new Point(0, 0);
            textBoxPattern.Name = "textBoxPattern";
            textBoxPattern.Size = new Size(588, 37);
            textBoxPattern.TabIndex = 7;
            // 
            // searchPatternBtn
            // 
            searchPatternBtn.Cursor = Cursors.Hand;
            searchPatternBtn.Dock = DockStyle.Fill;
            searchPatternBtn.FlatStyle = FlatStyle.Flat;
            searchPatternBtn.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            searchPatternBtn.Location = new Point(0, 0);
            searchPatternBtn.Name = "searchPatternBtn";
            searchPatternBtn.Size = new Size(219, 37);
            searchPatternBtn.TabIndex = 7;
            searchPatternBtn.Text = "SZUKAJ";
            searchPatternBtn.UseVisualStyleBackColor = true;
            searchPatternBtn.Click += SearchPattern_Click;
            // 
            // labelSpace1
            // 
            labelSpace1.BackColor = Color.Transparent;
            labelSpace1.Dock = DockStyle.Top;
            labelSpace1.Location = new Point(3, 35);
            labelSpace1.Name = "labelSpace1";
            labelSpace1.Size = new Size(811, 3);
            labelSpace1.TabIndex = 3;
            labelSpace1.Text = " ";
            // 
            // labelPattern
            // 
            labelPattern.BackColor = Color.DarkSeaGreen;
            labelPattern.Dock = DockStyle.Top;
            labelPattern.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelPattern.Location = new Point(3, 3);
            labelPattern.Name = "labelPattern";
            labelPattern.Size = new Size(811, 32);
            labelPattern.TabIndex = 0;
            labelPattern.Text = "WZORZEC";
            labelPattern.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabPageUlozSam
            // 
            tabPageUlozSam.Controls.Add(splitContainerUls);
            tabPageUlozSam.Controls.Add(label8);
            tabPageUlozSam.Controls.Add(labelUluzSam);
            tabPageUlozSam.Location = new Point(4, 34);
            tabPageUlozSam.Name = "tabPageUlozSam";
            tabPageUlozSam.Padding = new Padding(3);
            tabPageUlozSam.Size = new Size(817, 662);
            tabPageUlozSam.TabIndex = 2;
            tabPageUlozSam.Text = "Ułóż sam";
            tabPageUlozSam.UseVisualStyleBackColor = true;
            // 
            // splitContainerUls
            // 
            splitContainerUls.Dock = DockStyle.Fill;
            splitContainerUls.Location = new Point(3, 38);
            splitContainerUls.Name = "splitContainerUls";
            // 
            // splitContainerUls.Panel1
            // 
            splitContainerUls.Panel1.Controls.Add(textBoxResultsUls);
            // 
            // splitContainerUls.Panel2
            // 
            splitContainerUls.Panel2.Controls.Add(groupBoxUlsGroups);
            splitContainerUls.Panel2.Controls.Add(label10);
            splitContainerUls.Panel2.Controls.Add(buttonSearchUls);
            splitContainerUls.Panel2.Controls.Add(label9);
            splitContainerUls.Panel2.Controls.Add(textBoxPatternUls);
            splitContainerUls.Size = new Size(811, 621);
            splitContainerUls.SplitterDistance = 451;
            splitContainerUls.TabIndex = 5;
            // 
            // textBoxResultsUls
            // 
            textBoxResultsUls.BackColor = SystemColors.ControlLight;
            textBoxResultsUls.BorderStyle = BorderStyle.FixedSingle;
            textBoxResultsUls.ContextMenuStrip = contextMenuStripResults;
            textBoxResultsUls.Dock = DockStyle.Fill;
            textBoxResultsUls.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBoxResultsUls.Location = new Point(0, 0);
            textBoxResultsUls.Multiline = true;
            textBoxResultsUls.Name = "textBoxResultsUls";
            textBoxResultsUls.ReadOnly = true;
            textBoxResultsUls.ScrollBars = ScrollBars.Vertical;
            textBoxResultsUls.Size = new Size(451, 621);
            textBoxResultsUls.TabIndex = 1;
            // 
            // groupBoxUlsGroups
            // 
            groupBoxUlsGroups.Controls.Add(tableLayoutPanelUsl);
            groupBoxUlsGroups.Controls.Add(label18);
            groupBoxUlsGroups.Controls.Add(label17);
            groupBoxUlsGroups.Controls.Add(label14);
            groupBoxUlsGroups.Controls.Add(label16);
            groupBoxUlsGroups.Controls.Add(label15);
            groupBoxUlsGroups.Controls.Add(label13);
            groupBoxUlsGroups.Controls.Add(label12);
            groupBoxUlsGroups.Controls.Add(label11);
            groupBoxUlsGroups.Dock = DockStyle.Fill;
            groupBoxUlsGroups.Location = new Point(0, 80);
            groupBoxUlsGroups.Name = "groupBoxUlsGroups";
            groupBoxUlsGroups.Size = new Size(356, 541);
            groupBoxUlsGroups.TabIndex = 12;
            groupBoxUlsGroups.TabStop = false;
            groupBoxUlsGroups.Text = "Grupy znaków";
            // 
            // tableLayoutPanelUsl
            // 
            tableLayoutPanelUsl.ColumnCount = 2;
            tableLayoutPanelUsl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanelUsl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanelUsl.Controls.Add(textBoxGr8, 1, 7);
            tableLayoutPanelUsl.Controls.Add(textBoxGr7, 1, 6);
            tableLayoutPanelUsl.Controls.Add(textBoxGr6, 1, 5);
            tableLayoutPanelUsl.Controls.Add(textBoxGr5, 1, 4);
            tableLayoutPanelUsl.Controls.Add(textBoxGr4, 1, 3);
            tableLayoutPanelUsl.Controls.Add(textBoxGr3, 1, 2);
            tableLayoutPanelUsl.Controls.Add(textBoxGr2, 1, 1);
            tableLayoutPanelUsl.Controls.Add(labelGr8, 0, 7);
            tableLayoutPanelUsl.Controls.Add(labelGr7, 0, 6);
            tableLayoutPanelUsl.Controls.Add(labelGr6, 0, 5);
            tableLayoutPanelUsl.Controls.Add(labelGr4, 0, 3);
            tableLayoutPanelUsl.Controls.Add(labelGr3, 0, 2);
            tableLayoutPanelUsl.Controls.Add(labelGr2, 0, 1);
            tableLayoutPanelUsl.Controls.Add(labelGr1, 0, 0);
            tableLayoutPanelUsl.Controls.Add(labelGr5, 0, 4);
            tableLayoutPanelUsl.Controls.Add(textBoxGr1, 1, 0);
            tableLayoutPanelUsl.Dock = DockStyle.Top;
            tableLayoutPanelUsl.Location = new Point(3, 51);
            tableLayoutPanelUsl.Name = "tableLayoutPanelUsl";
            tableLayoutPanelUsl.RowCount = 8;
            tableLayoutPanelUsl.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanelUsl.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanelUsl.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanelUsl.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanelUsl.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanelUsl.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanelUsl.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanelUsl.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanelUsl.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelUsl.Size = new Size(350, 320);
            tableLayoutPanelUsl.TabIndex = 26;
            // 
            // textBoxGr8
            // 
            textBoxGr8.Dock = DockStyle.Fill;
            textBoxGr8.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238);
            textBoxGr8.Location = new Point(108, 281);
            textBoxGr8.Margin = new Padding(3, 1, 3, 3);
            textBoxGr8.Name = "textBoxGr8";
            textBoxGr8.Size = new Size(239, 37);
            textBoxGr8.TabIndex = 32;
            textBoxGr8.Text = "YZŹŻ";
            // 
            // textBoxGr7
            // 
            textBoxGr7.Dock = DockStyle.Fill;
            textBoxGr7.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238);
            textBoxGr7.Location = new Point(108, 241);
            textBoxGr7.Margin = new Padding(3, 1, 3, 3);
            textBoxGr7.Name = "textBoxGr7";
            textBoxGr7.Size = new Size(239, 37);
            textBoxGr7.TabIndex = 32;
            textBoxGr7.Text = "ŚTUW";
            // 
            // textBoxGr6
            // 
            textBoxGr6.Dock = DockStyle.Fill;
            textBoxGr6.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238);
            textBoxGr6.Location = new Point(108, 201);
            textBoxGr6.Margin = new Padding(3, 1, 3, 3);
            textBoxGr6.Name = "textBoxGr6";
            textBoxGr6.Size = new Size(239, 37);
            textBoxGr6.TabIndex = 32;
            textBoxGr6.Text = "ÓPRS";
            // 
            // textBoxGr5
            // 
            textBoxGr5.Dock = DockStyle.Fill;
            textBoxGr5.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238);
            textBoxGr5.Location = new Point(108, 161);
            textBoxGr5.Margin = new Padding(3, 1, 3, 3);
            textBoxGr5.Name = "textBoxGr5";
            textBoxGr5.Size = new Size(239, 37);
            textBoxGr5.TabIndex = 32;
            textBoxGr5.Text = "MNŃO";
            // 
            // textBoxGr4
            // 
            textBoxGr4.Dock = DockStyle.Fill;
            textBoxGr4.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238);
            textBoxGr4.Location = new Point(108, 121);
            textBoxGr4.Margin = new Padding(3, 1, 3, 3);
            textBoxGr4.Name = "textBoxGr4";
            textBoxGr4.Size = new Size(239, 37);
            textBoxGr4.TabIndex = 32;
            textBoxGr4.Text = "JKLŁ";
            // 
            // textBoxGr3
            // 
            textBoxGr3.Dock = DockStyle.Fill;
            textBoxGr3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238);
            textBoxGr3.Location = new Point(108, 81);
            textBoxGr3.Margin = new Padding(3, 1, 3, 3);
            textBoxGr3.Name = "textBoxGr3";
            textBoxGr3.Size = new Size(239, 37);
            textBoxGr3.TabIndex = 31;
            textBoxGr3.Text = "FGHI";
            // 
            // textBoxGr2
            // 
            textBoxGr2.Dock = DockStyle.Fill;
            textBoxGr2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238);
            textBoxGr2.Location = new Point(108, 41);
            textBoxGr2.Margin = new Padding(3, 1, 3, 3);
            textBoxGr2.Name = "textBoxGr2";
            textBoxGr2.Size = new Size(239, 37);
            textBoxGr2.TabIndex = 31;
            textBoxGr2.Text = "ĆDEĘ";
            // 
            // labelGr8
            // 
            labelGr8.BackColor = Color.MediumPurple;
            labelGr8.Dock = DockStyle.Fill;
            labelGr8.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelGr8.Location = new Point(4, 282);
            labelGr8.Margin = new Padding(4, 2, 3, 2);
            labelGr8.Name = "labelGr8";
            labelGr8.Size = new Size(98, 36);
            labelGr8.TabIndex = 28;
            labelGr8.Text = "8";
            labelGr8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelGr7
            // 
            labelGr7.BackColor = Color.MediumPurple;
            labelGr7.Dock = DockStyle.Fill;
            labelGr7.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelGr7.Location = new Point(4, 242);
            labelGr7.Margin = new Padding(4, 2, 3, 2);
            labelGr7.Name = "labelGr7";
            labelGr7.Size = new Size(98, 36);
            labelGr7.TabIndex = 28;
            labelGr7.Text = "7";
            labelGr7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelGr6
            // 
            labelGr6.BackColor = Color.MediumPurple;
            labelGr6.Dock = DockStyle.Fill;
            labelGr6.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelGr6.Location = new Point(4, 202);
            labelGr6.Margin = new Padding(4, 2, 3, 2);
            labelGr6.Name = "labelGr6";
            labelGr6.Size = new Size(98, 36);
            labelGr6.TabIndex = 28;
            labelGr6.Text = "6";
            labelGr6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelGr4
            // 
            labelGr4.BackColor = Color.MediumPurple;
            labelGr4.Dock = DockStyle.Fill;
            labelGr4.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelGr4.Location = new Point(4, 122);
            labelGr4.Margin = new Padding(4, 2, 3, 2);
            labelGr4.Name = "labelGr4";
            labelGr4.Size = new Size(98, 36);
            labelGr4.TabIndex = 28;
            labelGr4.Text = "4";
            labelGr4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelGr3
            // 
            labelGr3.BackColor = Color.MediumPurple;
            labelGr3.Dock = DockStyle.Fill;
            labelGr3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelGr3.Location = new Point(4, 82);
            labelGr3.Margin = new Padding(4, 2, 3, 2);
            labelGr3.Name = "labelGr3";
            labelGr3.Size = new Size(98, 36);
            labelGr3.TabIndex = 27;
            labelGr3.Text = "3";
            labelGr3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelGr2
            // 
            labelGr2.BackColor = Color.MediumPurple;
            labelGr2.Dock = DockStyle.Fill;
            labelGr2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelGr2.Location = new Point(4, 42);
            labelGr2.Margin = new Padding(4, 2, 3, 2);
            labelGr2.Name = "labelGr2";
            labelGr2.Size = new Size(98, 36);
            labelGr2.TabIndex = 2;
            labelGr2.Text = "2";
            labelGr2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelGr1
            // 
            labelGr1.BackColor = Color.MediumPurple;
            labelGr1.Dock = DockStyle.Fill;
            labelGr1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelGr1.Location = new Point(4, 2);
            labelGr1.Margin = new Padding(4, 2, 3, 2);
            labelGr1.Name = "labelGr1";
            labelGr1.Size = new Size(98, 36);
            labelGr1.TabIndex = 0;
            labelGr1.Text = "1";
            labelGr1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelGr5
            // 
            labelGr5.BackColor = Color.MediumPurple;
            labelGr5.Dock = DockStyle.Fill;
            labelGr5.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelGr5.Location = new Point(4, 162);
            labelGr5.Margin = new Padding(4, 2, 3, 2);
            labelGr5.Name = "labelGr5";
            labelGr5.Size = new Size(98, 36);
            labelGr5.TabIndex = 29;
            labelGr5.Text = "5";
            labelGr5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxGr1
            // 
            textBoxGr1.Dock = DockStyle.Fill;
            textBoxGr1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238);
            textBoxGr1.Location = new Point(108, 1);
            textBoxGr1.Margin = new Padding(3, 1, 3, 3);
            textBoxGr1.Name = "textBoxGr1";
            textBoxGr1.Size = new Size(239, 37);
            textBoxGr1.TabIndex = 30;
            textBoxGr1.Text = "AĄBC";
            // 
            // label18
            // 
            label18.BackColor = Color.Transparent;
            label18.Dock = DockStyle.Top;
            label18.Location = new Point(3, 48);
            label18.Name = "label18";
            label18.Size = new Size(350, 3);
            label18.TabIndex = 24;
            label18.Text = " ";
            // 
            // label17
            // 
            label17.BackColor = Color.Transparent;
            label17.Dock = DockStyle.Top;
            label17.Location = new Point(3, 45);
            label17.Name = "label17";
            label17.Size = new Size(350, 3);
            label17.TabIndex = 22;
            label17.Text = " ";
            // 
            // label14
            // 
            label14.BackColor = Color.Transparent;
            label14.Dock = DockStyle.Top;
            label14.Location = new Point(3, 42);
            label14.Name = "label14";
            label14.Size = new Size(350, 3);
            label14.TabIndex = 20;
            label14.Text = " ";
            // 
            // label16
            // 
            label16.BackColor = Color.Transparent;
            label16.Dock = DockStyle.Top;
            label16.Location = new Point(3, 39);
            label16.Name = "label16";
            label16.Size = new Size(350, 3);
            label16.TabIndex = 18;
            label16.Text = " ";
            // 
            // label15
            // 
            label15.BackColor = Color.Transparent;
            label15.Dock = DockStyle.Top;
            label15.Location = new Point(3, 36);
            label15.Name = "label15";
            label15.Size = new Size(350, 3);
            label15.TabIndex = 16;
            label15.Text = " ";
            // 
            // label13
            // 
            label13.BackColor = Color.Transparent;
            label13.Dock = DockStyle.Top;
            label13.Location = new Point(3, 33);
            label13.Name = "label13";
            label13.Size = new Size(350, 3);
            label13.TabIndex = 14;
            label13.Text = " ";
            // 
            // label12
            // 
            label12.BackColor = Color.Transparent;
            label12.Dock = DockStyle.Top;
            label12.Location = new Point(3, 30);
            label12.Name = "label12";
            label12.Size = new Size(350, 3);
            label12.TabIndex = 12;
            label12.Text = " ";
            // 
            // label11
            // 
            label11.BackColor = Color.Transparent;
            label11.Dock = DockStyle.Top;
            label11.Location = new Point(3, 27);
            label11.Name = "label11";
            label11.Size = new Size(350, 3);
            label11.TabIndex = 10;
            label11.Text = " ";
            // 
            // label10
            // 
            label10.BackColor = Color.Transparent;
            label10.Dock = DockStyle.Top;
            label10.Location = new Point(0, 77);
            label10.Name = "label10";
            label10.Size = new Size(356, 3);
            label10.TabIndex = 11;
            label10.Text = " ";
            // 
            // buttonSearchUls
            // 
            buttonSearchUls.Cursor = Cursors.Hand;
            buttonSearchUls.Dock = DockStyle.Top;
            buttonSearchUls.FlatStyle = FlatStyle.Flat;
            buttonSearchUls.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            buttonSearchUls.Location = new Point(0, 40);
            buttonSearchUls.Name = "buttonSearchUls";
            buttonSearchUls.Size = new Size(356, 37);
            buttonSearchUls.TabIndex = 10;
            buttonSearchUls.Text = "SZUKAJ";
            buttonSearchUls.UseVisualStyleBackColor = true;
            buttonSearchUls.Click += UluzSamSearch_Click;
            // 
            // label9
            // 
            label9.BackColor = Color.Transparent;
            label9.Dock = DockStyle.Top;
            label9.Location = new Point(0, 37);
            label9.Name = "label9";
            label9.Size = new Size(356, 3);
            label9.TabIndex = 9;
            label9.Text = " ";
            // 
            // textBoxPatternUls
            // 
            textBoxPatternUls.Dock = DockStyle.Top;
            textBoxPatternUls.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238);
            textBoxPatternUls.Location = new Point(0, 0);
            textBoxPatternUls.Name = "textBoxPatternUls";
            textBoxPatternUls.Size = new Size(356, 37);
            textBoxPatternUls.TabIndex = 8;
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.Dock = DockStyle.Top;
            label8.Location = new Point(3, 35);
            label8.Name = "label8";
            label8.Size = new Size(811, 3);
            label8.TabIndex = 4;
            label8.Text = " ";
            // 
            // labelUluzSam
            // 
            labelUluzSam.BackColor = Color.MediumPurple;
            labelUluzSam.Dock = DockStyle.Top;
            labelUluzSam.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelUluzSam.Location = new Point(3, 3);
            labelUluzSam.Name = "labelUluzSam";
            labelUluzSam.Size = new Size(811, 32);
            labelUluzSam.TabIndex = 1;
            labelUluzSam.Text = "UŁÓŻ SAM";
            labelUluzSam.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabPageDictionary
            // 
            tabPageDictionary.Controls.Add(tableLayoutPanel3);
            tabPageDictionary.Controls.Add(buttonLoadDict);
            tabPageDictionary.Controls.Add(label20);
            tabPageDictionary.Controls.Add(tableLayoutPanel2);
            tabPageDictionary.Controls.Add(labelDictionary);
            tabPageDictionary.Location = new Point(4, 34);
            tabPageDictionary.Name = "tabPageDictionary";
            tabPageDictionary.Padding = new Padding(3);
            tabPageDictionary.Size = new Size(817, 662);
            tabPageDictionary.TabIndex = 3;
            tabPageDictionary.Text = "Słownik";
            tabPageDictionary.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(groupBoxAddToDict, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 146);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(811, 513);
            tableLayoutPanel3.TabIndex = 9;
            // 
            // groupBoxAddToDict
            // 
            groupBoxAddToDict.Controls.Add(buttonAddToDictionary);
            groupBoxAddToDict.Controls.Add(label21);
            groupBoxAddToDict.Controls.Add(textBoxAddToDictionary);
            groupBoxAddToDict.Dock = DockStyle.Fill;
            groupBoxAddToDict.Location = new Point(3, 3);
            groupBoxAddToDict.Name = "groupBoxAddToDict";
            groupBoxAddToDict.Size = new Size(399, 507);
            groupBoxAddToDict.TabIndex = 0;
            groupBoxAddToDict.TabStop = false;
            groupBoxAddToDict.Text = "Dodaj wyrazy do bieżącego słownika";
            // 
            // buttonAddToDictionary
            // 
            buttonAddToDictionary.Cursor = Cursors.Hand;
            buttonAddToDictionary.Dock = DockStyle.Fill;
            buttonAddToDictionary.FlatStyle = FlatStyle.Flat;
            buttonAddToDictionary.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            buttonAddToDictionary.Location = new Point(3, 467);
            buttonAddToDictionary.Name = "buttonAddToDictionary";
            buttonAddToDictionary.Size = new Size(393, 37);
            buttonAddToDictionary.TabIndex = 8;
            buttonAddToDictionary.Text = "DODAJ DO SŁOWNIKA";
            buttonAddToDictionary.UseVisualStyleBackColor = true;
            buttonAddToDictionary.Click += AddToDictionaryBtn_Click;
            // 
            // label21
            // 
            label21.Dock = DockStyle.Top;
            label21.Location = new Point(3, 464);
            label21.Name = "label21";
            label21.Size = new Size(393, 3);
            label21.TabIndex = 4;
            // 
            // textBoxAddToDictionary
            // 
            textBoxAddToDictionary.Dock = DockStyle.Top;
            textBoxAddToDictionary.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            textBoxAddToDictionary.Location = new Point(3, 27);
            textBoxAddToDictionary.Multiline = true;
            textBoxAddToDictionary.Name = "textBoxAddToDictionary";
            textBoxAddToDictionary.ScrollBars = ScrollBars.Vertical;
            textBoxAddToDictionary.Size = new Size(393, 437);
            textBoxAddToDictionary.TabIndex = 0;
            // 
            // buttonLoadDict
            // 
            buttonLoadDict.Cursor = Cursors.Hand;
            buttonLoadDict.Dock = DockStyle.Top;
            buttonLoadDict.FlatStyle = FlatStyle.Flat;
            buttonLoadDict.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            buttonLoadDict.Location = new Point(3, 109);
            buttonLoadDict.Name = "buttonLoadDict";
            buttonLoadDict.Size = new Size(811, 37);
            buttonLoadDict.TabIndex = 8;
            buttonLoadDict.Text = "WCZYTAJ PLIK ZE SŁOWNIKIEM";
            buttonLoadDict.UseVisualStyleBackColor = true;
            buttonLoadDict.Click += LoadDictionaryBtn_Click;
            // 
            // label20
            // 
            label20.Dock = DockStyle.Top;
            label20.Location = new Point(3, 104);
            label20.Name = "label20";
            label20.Size = new Size(811, 5);
            label20.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 61.89889F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.10111F));
            tableLayoutPanel2.Controls.Add(labelWordsCount, 1, 1);
            tableLayoutPanel2.Controls.Add(labelDicLengthInfo, 0, 1);
            tableLayoutPanel2.Controls.Add(labelFileNameInfo, 0, 0);
            tableLayoutPanel2.Controls.Add(labelFileName, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(3, 35);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(811, 69);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // labelWordsCount
            // 
            labelWordsCount.BackColor = Color.MediumAquamarine;
            labelWordsCount.Dock = DockStyle.Fill;
            labelWordsCount.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelWordsCount.Location = new Point(504, 38);
            labelWordsCount.Margin = new Padding(2, 4, 0, 0);
            labelWordsCount.Name = "labelWordsCount";
            labelWordsCount.Size = new Size(307, 31);
            labelWordsCount.TabIndex = 3;
            labelWordsCount.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelDicLengthInfo
            // 
            labelDicLengthInfo.BackColor = Color.LightGray;
            labelDicLengthInfo.Dock = DockStyle.Fill;
            labelDicLengthInfo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelDicLengthInfo.Location = new Point(0, 38);
            labelDicLengthInfo.Margin = new Padding(0, 4, 2, 0);
            labelDicLengthInfo.Name = "labelDicLengthInfo";
            labelDicLengthInfo.Size = new Size(500, 31);
            labelDicLengthInfo.TabIndex = 1;
            labelDicLengthInfo.Text = "Ilość wyrazów w słowniku:";
            labelDicLengthInfo.TextAlign = ContentAlignment.TopRight;
            // 
            // labelFileNameInfo
            // 
            labelFileNameInfo.BackColor = Color.LightGray;
            labelFileNameInfo.Dock = DockStyle.Fill;
            labelFileNameInfo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelFileNameInfo.Location = new Point(0, 4);
            labelFileNameInfo.Margin = new Padding(0, 4, 2, 0);
            labelFileNameInfo.Name = "labelFileNameInfo";
            labelFileNameInfo.Size = new Size(500, 30);
            labelFileNameInfo.TabIndex = 0;
            labelFileNameInfo.Text = "Wczytany plik ze słownikiem:";
            labelFileNameInfo.TextAlign = ContentAlignment.TopRight;
            // 
            // labelFileName
            // 
            labelFileName.BackColor = Color.MediumAquamarine;
            labelFileName.Dock = DockStyle.Fill;
            labelFileName.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelFileName.Location = new Point(504, 4);
            labelFileName.Margin = new Padding(2, 4, 0, 0);
            labelFileName.Name = "labelFileName";
            labelFileName.Size = new Size(307, 30);
            labelFileName.TabIndex = 2;
            labelFileName.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelDictionary
            // 
            labelDictionary.BackColor = Color.CornflowerBlue;
            labelDictionary.Dock = DockStyle.Top;
            labelDictionary.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelDictionary.Location = new Point(3, 3);
            labelDictionary.Name = "labelDictionary";
            labelDictionary.Size = new Size(811, 32);
            labelDictionary.TabIndex = 1;
            labelDictionary.Text = "ZARZĄDZANIE SŁOWNIKIEM";
            labelDictionary.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabPageAbout
            // 
            tabPageAbout.Controls.Add(labelAbout);
            tabPageAbout.Controls.Add(label2);
            tabPageAbout.Controls.Add(label1);
            tabPageAbout.Controls.Add(textBoxAbout);
            tabPageAbout.Controls.Add(tableLayoutPanel4);
            tabPageAbout.Controls.Add(label3);
            tabPageAbout.Controls.Add(labelSpace2);
            tabPageAbout.Controls.Add(labelHelp);
            tabPageAbout.Location = new Point(4, 34);
            tabPageAbout.Name = "tabPageAbout";
            tabPageAbout.Padding = new Padding(3);
            tabPageAbout.Size = new Size(817, 662);
            tabPageAbout.TabIndex = 1;
            tabPageAbout.Text = "O aplikacji";
            tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // labelAbout
            // 
            labelAbout.BackColor = Color.Silver;
            labelAbout.Dock = DockStyle.Fill;
            labelAbout.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelAbout.Location = new Point(234, 555);
            labelAbout.Name = "labelAbout";
            labelAbout.Size = new Size(580, 101);
            labelAbout.TabIndex = 18;
            labelAbout.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(234, 553);
            label2.Name = "label2";
            label2.Size = new Size(580, 2);
            label2.TabIndex = 17;
            label2.Text = " ";
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Dock = DockStyle.Bottom;
            label1.Location = new Point(234, 656);
            label1.Name = "label1";
            label1.Size = new Size(580, 3);
            label1.TabIndex = 15;
            label1.Text = " ";
            // 
            // textBoxAbout
            // 
            textBoxAbout.BackColor = SystemColors.ControlLightLight;
            textBoxAbout.Dock = DockStyle.Top;
            textBoxAbout.Enabled = false;
            textBoxAbout.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBoxAbout.ForeColor = SystemColors.InfoText;
            textBoxAbout.Location = new Point(234, 40);
            textBoxAbout.Margin = new Padding(3, 6, 3, 3);
            textBoxAbout.Multiline = true;
            textBoxAbout.Name = "textBoxAbout";
            textBoxAbout.Size = new Size(580, 513);
            textBoxAbout.TabIndex = 14;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(labelShortcuts, 0, 5);
            tableLayoutPanel4.Controls.Add(labelUlozSamInfo, 0, 4);
            tableLayoutPanel4.Controls.Add(labelLengthInfo, 0, 3);
            tableLayoutPanel4.Controls.Add(labelMetagramInfo, 0, 2);
            tableLayoutPanel4.Controls.Add(labelAnagramInfo, 0, 1);
            tableLayoutPanel4.Controls.Add(labelPatternInfo, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Left;
            tableLayoutPanel4.Location = new Point(3, 40);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 7;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(231, 619);
            tableLayoutPanel4.TabIndex = 13;
            // 
            // labelShortcuts
            // 
            labelShortcuts.BackColor = Color.Silver;
            labelShortcuts.Cursor = Cursors.Hand;
            labelShortcuts.Dock = DockStyle.Fill;
            labelShortcuts.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelShortcuts.Location = new Point(0, 200);
            labelShortcuts.Margin = new Padding(0, 0, 3, 5);
            labelShortcuts.Name = "labelShortcuts";
            labelShortcuts.Size = new Size(228, 35);
            labelShortcuts.TabIndex = 14;
            labelShortcuts.Text = "SKRÓTY";
            labelShortcuts.TextAlign = ContentAlignment.MiddleLeft;
            labelShortcuts.Click += Shortcuts_Click;
            // 
            // labelUlozSamInfo
            // 
            labelUlozSamInfo.BackColor = Color.Silver;
            labelUlozSamInfo.Cursor = Cursors.Hand;
            labelUlozSamInfo.Dock = DockStyle.Fill;
            labelUlozSamInfo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelUlozSamInfo.Location = new Point(0, 160);
            labelUlozSamInfo.Margin = new Padding(0, 0, 3, 5);
            labelUlozSamInfo.Name = "labelUlozSamInfo";
            labelUlozSamInfo.Size = new Size(228, 35);
            labelUlozSamInfo.TabIndex = 4;
            labelUlozSamInfo.Text = "UŁÓŻ SAM";
            labelUlozSamInfo.TextAlign = ContentAlignment.MiddleLeft;
            labelUlozSamInfo.Click += UlozSamInfo;
            // 
            // labelLengthInfo
            // 
            labelLengthInfo.BackColor = Color.Silver;
            labelLengthInfo.Cursor = Cursors.Hand;
            labelLengthInfo.Dock = DockStyle.Fill;
            labelLengthInfo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelLengthInfo.Location = new Point(0, 120);
            labelLengthInfo.Margin = new Padding(0, 0, 3, 5);
            labelLengthInfo.Name = "labelLengthInfo";
            labelLengthInfo.Size = new Size(228, 35);
            labelLengthInfo.TabIndex = 3;
            labelLengthInfo.Text = "DŁUGOŚĆ";
            labelLengthInfo.TextAlign = ContentAlignment.MiddleLeft;
            labelLengthInfo.Click += LengthInfo_Click;
            // 
            // labelMetagramInfo
            // 
            labelMetagramInfo.BackColor = Color.Silver;
            labelMetagramInfo.Cursor = Cursors.Hand;
            labelMetagramInfo.Dock = DockStyle.Fill;
            labelMetagramInfo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelMetagramInfo.Location = new Point(0, 80);
            labelMetagramInfo.Margin = new Padding(0, 0, 3, 5);
            labelMetagramInfo.Name = "labelMetagramInfo";
            labelMetagramInfo.Size = new Size(228, 35);
            labelMetagramInfo.TabIndex = 2;
            labelMetagramInfo.Text = "METAGRAM";
            labelMetagramInfo.TextAlign = ContentAlignment.MiddleLeft;
            labelMetagramInfo.Click += MetagramInfo_Click;
            // 
            // labelAnagramInfo
            // 
            labelAnagramInfo.BackColor = Color.Silver;
            labelAnagramInfo.Cursor = Cursors.Hand;
            labelAnagramInfo.Dock = DockStyle.Fill;
            labelAnagramInfo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelAnagramInfo.Location = new Point(0, 40);
            labelAnagramInfo.Margin = new Padding(0, 0, 3, 5);
            labelAnagramInfo.Name = "labelAnagramInfo";
            labelAnagramInfo.Size = new Size(228, 35);
            labelAnagramInfo.TabIndex = 1;
            labelAnagramInfo.Text = "ANAGRAM";
            labelAnagramInfo.TextAlign = ContentAlignment.MiddleLeft;
            labelAnagramInfo.Click += AnagramInfo_Click;
            // 
            // labelPatternInfo
            // 
            labelPatternInfo.BackColor = Color.Silver;
            labelPatternInfo.Cursor = Cursors.Hand;
            labelPatternInfo.Dock = DockStyle.Fill;
            labelPatternInfo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelPatternInfo.Location = new Point(0, 0);
            labelPatternInfo.Margin = new Padding(0, 0, 3, 5);
            labelPatternInfo.Name = "labelPatternInfo";
            labelPatternInfo.Size = new Size(228, 35);
            labelPatternInfo.TabIndex = 0;
            labelPatternInfo.Text = "WZORZEC";
            labelPatternInfo.TextAlign = ContentAlignment.MiddleLeft;
            labelPatternInfo.Click += PatternInfo_Click;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(3, 37);
            label3.Name = "label3";
            label3.Size = new Size(811, 3);
            label3.TabIndex = 6;
            label3.Text = " ";
            // 
            // labelSpace2
            // 
            labelSpace2.BackColor = Color.Transparent;
            labelSpace2.Dock = DockStyle.Top;
            labelSpace2.Location = new Point(3, 35);
            labelSpace2.Name = "labelSpace2";
            labelSpace2.Size = new Size(811, 2);
            labelSpace2.TabIndex = 4;
            labelSpace2.Text = " ";
            // 
            // labelHelp
            // 
            labelHelp.BackColor = Color.Silver;
            labelHelp.Dock = DockStyle.Top;
            labelHelp.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelHelp.Location = new Point(3, 3);
            labelHelp.Name = "labelHelp";
            labelHelp.Size = new Size(811, 32);
            labelHelp.TabIndex = 1;
            labelHelp.Text = "DOSTĘPNE TRYBY";
            labelHelp.TextAlign = ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 100);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.Controls.Add(label19, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.Size = new Size(200, 100);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label19
            // 
            label19.BackColor = Color.MediumPurple;
            label19.Dock = DockStyle.Fill;
            label19.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label19.Location = new Point(4, 2);
            label19.Margin = new Padding(4, 2, 4, 2);
            label19.Name = "label19";
            label19.Size = new Size(52, 36);
            label19.TabIndex = 2;
            label19.Text = "2";
            label19.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            label22.BackColor = Color.MediumPurple;
            label22.Dock = DockStyle.Fill;
            label22.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label22.Location = new Point(4, 2);
            label22.Margin = new Padding(4, 2, 4, 2);
            label22.Name = "label22";
            label22.Size = new Size(97, 36);
            label22.TabIndex = 0;
            label22.Text = "112112";
            label22.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // newDictionaryDialog
            // 
            newDictionaryDialog.FileName = "slownik.txt";
            newDictionaryDialog.Filter = "Pliki tekstowe|*.txt";
            newDictionaryDialog.Title = "Wybierz plik ze słownikiem";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(825, 700);
            Controls.Add(tabControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Pomocnik szaradzisty";
            KeyDown += MainForm_KeyDown;
            tabControl.ResumeLayout(false);
            tabPattern.ResumeLayout(false);
            splitContainerResults.Panel1.ResumeLayout(false);
            splitContainerResults.Panel1.PerformLayout();
            splitContainerResults.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerResults).EndInit();
            splitContainerResults.ResumeLayout(false);
            contextMenuStripResults.ResumeLayout(false);
            groupBoxFilters.ResumeLayout(false);
            groupBoxFilters.PerformLayout();
            groupBoxMode.ResumeLayout(false);
            groupBoxMode.PerformLayout();
            splitContainerPattern.Panel1.ResumeLayout(false);
            splitContainerPattern.Panel1.PerformLayout();
            splitContainerPattern.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerPattern).EndInit();
            splitContainerPattern.ResumeLayout(false);
            tabPageUlozSam.ResumeLayout(false);
            splitContainerUls.Panel1.ResumeLayout(false);
            splitContainerUls.Panel1.PerformLayout();
            splitContainerUls.Panel2.ResumeLayout(false);
            splitContainerUls.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerUls).EndInit();
            splitContainerUls.ResumeLayout(false);
            groupBoxUlsGroups.ResumeLayout(false);
            tableLayoutPanelUsl.ResumeLayout(false);
            tableLayoutPanelUsl.PerformLayout();
            tabPageDictionary.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            groupBoxAddToDict.ResumeLayout(false);
            groupBoxAddToDict.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tabPageAbout.ResumeLayout(false);
            tabPageAbout.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabPattern;
        private TabPage tabPageAbout;
        private Label labelPattern;
        private Label labelSpace1;
        private SplitContainer splitContainerPattern;
        private TextBox textBoxPattern;
        private Button searchPatternBtn;
        private Label labelSpace3;
        private SplitContainer splitContainerResults;
        private TextBox textBoxPatternResults;
        private GroupBox groupBoxMode;
        private RadioButton radioPatternMode;
        private RadioButton radioAnagramMode;
        private Label labelLenEnd;
        private TextBox textBoxMaxLen;
        private Label labelMaxLen;
        private TextBox textBoxMinLen;
        private Label labelMinLen;
        private RadioButton radioMetagramMode;
        private RadioButton radioLengthMode;
        private GroupBox groupBoxFilters;
        private CheckBox checkBoxBeginWith;
        private TextBox textBoxBeginsWith;
        private TextBox textBoxContains;
        private CheckBox checkBoxContains;
        private TextBox textBoxEndsWith;
        private CheckBox checkBoxEndsWith;
        private Label labelHelp;
        private Label labelSpace2;
        private Label label3;
        private TabPage tabPageUlozSam;
        private SplitContainer splitContainerUls;
        private Label label8;
        private Label labelUluzSam;
        private TextBox textBoxResultsUls;
        private TextBox textBoxPatternUls;
        private Button buttonSearchUls;
        private Label label9;
        private GroupBox groupBoxUlsGroups;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label16;
        private Label label15;
        private Label label17;
        private Label label14;
        private Label label18;
        private TabPage tabPageDictionary;
        private Label labelDictionary;
        private TableLayoutPanel tableLayoutPanelUsl;
        private Label labelGr1;
        private Label labelGr2;
        private Label labelGr8;
        private Label labelGr7;
        private Label labelGr6;
        private Label labelGr4;
        private Label labelGr3;
        private Label labelGr5;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label19;
        private Label label22;
        private TextBox textBoxGr6;
        private TextBox textBoxGr5;
        private TextBox textBoxGr4;
        private TextBox textBoxGr3;
        private TextBox textBoxGr2;
        private TextBox textBoxGr1;
        private TextBox textBoxGr8;
        private TextBox textBoxGr7;
        private ContextMenuStrip contextMenuStripResults;
        private ToolStripMenuItem szukajWToolStripMenuItem;
        private ToolStripMenuItem googleToolStripMenuItem;
        private ToolStripMenuItem sJPToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel2;
        private Label labelFileNameInfo;
        private Label labelDicLengthInfo;
        private Label labelFileName;
        private Label labelWordsCount;
        private OpenFileDialog newDictionaryDialog;
        private Label label20;
        private Button buttonLoadDict;
        private TableLayoutPanel tableLayoutPanel3;
        private GroupBox groupBoxAddToDict;
        private TextBox textBoxAddToDictionary;
        private Button buttonAddToDictionary;
        private Label label21;
        private TableLayoutPanel tableLayoutPanel4;
        private Label labelPatternInfo;
        private Label labelUlozSamInfo;
        private Label labelLengthInfo;
        private Label labelMetagramInfo;
        private Label labelAnagramInfo;
        private Label labelShortcuts;
        private TextBox textBoxAbout;
        private Label label2;
        private Label label1;
        private Label labelAbout;
    }
}
