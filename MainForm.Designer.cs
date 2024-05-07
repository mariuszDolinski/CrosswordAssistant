namespace CrosswordAssistant
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
            labelLoadInfo = new Label();
            label20 = new Label();
            labelDictionary = new Label();
            tabPageAbout = new TabPage();
            labelAbout = new Label();
            splitContainerLengthHelp = new SplitContainer();
            label7 = new Label();
            labelLM = new Label();
            label6 = new Label();
            splitContainerMetagramHelp = new SplitContainer();
            label5 = new Label();
            labelMM = new Label();
            label2 = new Label();
            splitContainerAnagramHelp = new SplitContainer();
            label4 = new Label();
            labelAM = new Label();
            label3 = new Label();
            splitContainerPatternHelp = new SplitContainer();
            label1 = new Label();
            labelPM = new Label();
            labelSpace2 = new Label();
            labelHelp = new Label();
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label19 = new Label();
            label22 = new Label();
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
            tabPageAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerLengthHelp).BeginInit();
            splitContainerLengthHelp.Panel1.SuspendLayout();
            splitContainerLengthHelp.Panel2.SuspendLayout();
            splitContainerLengthHelp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMetagramHelp).BeginInit();
            splitContainerMetagramHelp.Panel1.SuspendLayout();
            splitContainerMetagramHelp.Panel2.SuspendLayout();
            splitContainerMetagramHelp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerAnagramHelp).BeginInit();
            splitContainerAnagramHelp.Panel1.SuspendLayout();
            splitContainerAnagramHelp.Panel2.SuspendLayout();
            splitContainerAnagramHelp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerPatternHelp).BeginInit();
            splitContainerPatternHelp.Panel1.SuspendLayout();
            splitContainerPatternHelp.Panel2.SuspendLayout();
            splitContainerPatternHelp.SuspendLayout();
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
            googleToolStripMenuItem.Click += searchGoogle_MenuClick;
            // 
            // sJPToolStripMenuItem
            // 
            sJPToolStripMenuItem.Name = "sJPToolStripMenuItem";
            sJPToolStripMenuItem.Size = new Size(172, 34);
            sJPToolStripMenuItem.Text = "SJP";
            sJPToolStripMenuItem.Click += searchSJP_MenuClick;
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
            labelUluzSam.Text = "UŁUŻ SAM";
            labelUluzSam.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabPageDictionary
            // 
            tabPageDictionary.Controls.Add(labelLoadInfo);
            tabPageDictionary.Controls.Add(label20);
            tabPageDictionary.Controls.Add(labelDictionary);
            tabPageDictionary.Location = new Point(4, 34);
            tabPageDictionary.Name = "tabPageDictionary";
            tabPageDictionary.Padding = new Padding(3);
            tabPageDictionary.Size = new Size(817, 662);
            tabPageDictionary.TabIndex = 3;
            tabPageDictionary.Text = "Słownik";
            tabPageDictionary.UseVisualStyleBackColor = true;
            // 
            // labelLoadInfo
            // 
            labelLoadInfo.BackColor = Color.LightGray;
            labelLoadInfo.Dock = DockStyle.Top;
            labelLoadInfo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelLoadInfo.Location = new Point(3, 38);
            labelLoadInfo.Name = "labelLoadInfo";
            labelLoadInfo.Size = new Size(811, 64);
            labelLoadInfo.TabIndex = 5;
            // 
            // label20
            // 
            label20.BackColor = Color.Transparent;
            label20.Dock = DockStyle.Top;
            label20.Location = new Point(3, 35);
            label20.Name = "label20";
            label20.Size = new Size(811, 3);
            label20.TabIndex = 4;
            label20.Text = " ";
            // 
            // labelDictionary
            // 
            labelDictionary.BackColor = Color.DarkSalmon;
            labelDictionary.Dock = DockStyle.Top;
            labelDictionary.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelDictionary.Location = new Point(3, 3);
            labelDictionary.Name = "labelDictionary";
            labelDictionary.Size = new Size(811, 32);
            labelDictionary.TabIndex = 1;
            labelDictionary.Text = "BIEŻĄCY SŁOWNIK";
            labelDictionary.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabPageAbout
            // 
            tabPageAbout.Controls.Add(labelAbout);
            tabPageAbout.Controls.Add(splitContainerLengthHelp);
            tabPageAbout.Controls.Add(label6);
            tabPageAbout.Controls.Add(splitContainerMetagramHelp);
            tabPageAbout.Controls.Add(label2);
            tabPageAbout.Controls.Add(splitContainerAnagramHelp);
            tabPageAbout.Controls.Add(label3);
            tabPageAbout.Controls.Add(splitContainerPatternHelp);
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
            labelAbout.BorderStyle = BorderStyle.FixedSingle;
            labelAbout.Dock = DockStyle.Bottom;
            labelAbout.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelAbout.Location = new Point(3, 566);
            labelAbout.Name = "labelAbout";
            labelAbout.Size = new Size(811, 93);
            labelAbout.TabIndex = 12;
            labelAbout.TextAlign = ContentAlignment.TopCenter;
            // 
            // splitContainerLengthHelp
            // 
            splitContainerLengthHelp.Dock = DockStyle.Top;
            splitContainerLengthHelp.Location = new Point(3, 227);
            splitContainerLengthHelp.Name = "splitContainerLengthHelp";
            // 
            // splitContainerLengthHelp.Panel1
            // 
            splitContainerLengthHelp.Panel1.Controls.Add(label7);
            // 
            // splitContainerLengthHelp.Panel2
            // 
            splitContainerLengthHelp.Panel2.Controls.Add(labelLM);
            splitContainerLengthHelp.Size = new Size(811, 90);
            splitContainerLengthHelp.SplitterDistance = 165;
            splitContainerLengthHelp.TabIndex = 11;
            // 
            // label7
            // 
            label7.BackColor = Color.Silver;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Size = new Size(165, 90);
            label7.TabIndex = 3;
            label7.Text = "Długość";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelLM
            // 
            labelLM.BackColor = Color.Silver;
            labelLM.Dock = DockStyle.Fill;
            labelLM.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelLM.Location = new Point(0, 0);
            labelLM.Name = "labelLM";
            labelLM.Size = new Size(642, 90);
            labelLM.TabIndex = 4;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Dock = DockStyle.Top;
            label6.Location = new Point(3, 224);
            label6.Name = "label6";
            label6.Size = new Size(811, 3);
            label6.TabIndex = 10;
            label6.Text = " ";
            // 
            // splitContainerMetagramHelp
            // 
            splitContainerMetagramHelp.Dock = DockStyle.Top;
            splitContainerMetagramHelp.Location = new Point(3, 164);
            splitContainerMetagramHelp.Name = "splitContainerMetagramHelp";
            // 
            // splitContainerMetagramHelp.Panel1
            // 
            splitContainerMetagramHelp.Panel1.Controls.Add(label5);
            // 
            // splitContainerMetagramHelp.Panel2
            // 
            splitContainerMetagramHelp.Panel2.Controls.Add(labelMM);
            splitContainerMetagramHelp.Size = new Size(811, 60);
            splitContainerMetagramHelp.SplitterDistance = 165;
            splitContainerMetagramHelp.TabIndex = 9;
            // 
            // label5
            // 
            label5.BackColor = Color.Silver;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(165, 60);
            label5.TabIndex = 2;
            label5.Text = "Metagram";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelMM
            // 
            labelMM.BackColor = Color.Silver;
            labelMM.Dock = DockStyle.Fill;
            labelMM.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelMM.Location = new Point(0, 0);
            labelMM.Name = "labelMM";
            labelMM.Size = new Size(642, 60);
            labelMM.TabIndex = 3;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(3, 161);
            label2.Name = "label2";
            label2.Size = new Size(811, 3);
            label2.TabIndex = 8;
            label2.Text = " ";
            // 
            // splitContainerAnagramHelp
            // 
            splitContainerAnagramHelp.Dock = DockStyle.Top;
            splitContainerAnagramHelp.Location = new Point(3, 101);
            splitContainerAnagramHelp.Name = "splitContainerAnagramHelp";
            // 
            // splitContainerAnagramHelp.Panel1
            // 
            splitContainerAnagramHelp.Panel1.Controls.Add(label4);
            // 
            // splitContainerAnagramHelp.Panel2
            // 
            splitContainerAnagramHelp.Panel2.Controls.Add(labelAM);
            splitContainerAnagramHelp.Size = new Size(811, 60);
            splitContainerAnagramHelp.SplitterDistance = 165;
            splitContainerAnagramHelp.TabIndex = 7;
            // 
            // label4
            // 
            label4.BackColor = Color.Silver;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(165, 60);
            label4.TabIndex = 1;
            label4.Text = "Anagram";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelAM
            // 
            labelAM.BackColor = Color.Silver;
            labelAM.Dock = DockStyle.Fill;
            labelAM.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelAM.Location = new Point(0, 0);
            labelAM.Name = "labelAM";
            labelAM.Size = new Size(642, 60);
            labelAM.TabIndex = 2;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(3, 98);
            label3.Name = "label3";
            label3.Size = new Size(811, 3);
            label3.TabIndex = 6;
            label3.Text = " ";
            // 
            // splitContainerPatternHelp
            // 
            splitContainerPatternHelp.Dock = DockStyle.Top;
            splitContainerPatternHelp.Location = new Point(3, 38);
            splitContainerPatternHelp.Name = "splitContainerPatternHelp";
            // 
            // splitContainerPatternHelp.Panel1
            // 
            splitContainerPatternHelp.Panel1.Controls.Add(label1);
            // 
            // splitContainerPatternHelp.Panel2
            // 
            splitContainerPatternHelp.Panel2.Controls.Add(labelPM);
            splitContainerPatternHelp.Size = new Size(811, 60);
            splitContainerPatternHelp.SplitterDistance = 165;
            splitContainerPatternHelp.TabIndex = 5;
            // 
            // label1
            // 
            label1.BackColor = Color.Silver;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(165, 60);
            label1.TabIndex = 0;
            label1.Text = "Wzorzec";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelPM
            // 
            labelPM.BackColor = Color.Silver;
            labelPM.Dock = DockStyle.Fill;
            labelPM.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelPM.Location = new Point(0, 0);
            labelPM.Name = "labelPM";
            labelPM.Size = new Size(642, 60);
            labelPM.TabIndex = 1;
            // 
            // labelSpace2
            // 
            labelSpace2.BackColor = Color.Transparent;
            labelSpace2.Dock = DockStyle.Top;
            labelSpace2.Location = new Point(3, 35);
            labelSpace2.Name = "labelSpace2";
            labelSpace2.Size = new Size(811, 3);
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
            label22.Text = "1";
            label22.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(825, 700);
            Controls.Add(tabControl);
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
            tabPageAbout.ResumeLayout(false);
            splitContainerLengthHelp.Panel1.ResumeLayout(false);
            splitContainerLengthHelp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerLengthHelp).EndInit();
            splitContainerLengthHelp.ResumeLayout(false);
            splitContainerMetagramHelp.Panel1.ResumeLayout(false);
            splitContainerMetagramHelp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMetagramHelp).EndInit();
            splitContainerMetagramHelp.ResumeLayout(false);
            splitContainerAnagramHelp.Panel1.ResumeLayout(false);
            splitContainerAnagramHelp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerAnagramHelp).EndInit();
            splitContainerAnagramHelp.ResumeLayout(false);
            splitContainerPatternHelp.Panel1.ResumeLayout(false);
            splitContainerPatternHelp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerPatternHelp).EndInit();
            splitContainerPatternHelp.ResumeLayout(false);
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
        private SplitContainer splitContainerAnagramHelp;
        private Label label4;
        private Label labelAM;
        private Label label3;
        private SplitContainer splitContainerPatternHelp;
        private Label label1;
        private Label labelPM;
        private SplitContainer splitContainerMetagramHelp;
        private Label label5;
        private Label labelMM;
        private Label label2;
        private SplitContainer splitContainerLengthHelp;
        private Label label7;
        private Label labelLM;
        private Label label6;
        private Label labelAbout;
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
        private Label label20;
        private Label labelDictionary;
        private Label labelLoadInfo;
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
    }
}
