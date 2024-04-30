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
            tabControl = new TabControl();
            tabPattern = new TabPage();
            splitContainerResults = new SplitContainer();
            textBoxPatternResults = new TextBox();
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
            labelSpace2 = new Label();
            labelPatternInfo = new Label();
            labelSpace1 = new Label();
            labelPattern = new Label();
            tabPage2 = new TabPage();
            tabControl.SuspendLayout();
            tabPattern.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerResults).BeginInit();
            splitContainerResults.Panel1.SuspendLayout();
            splitContainerResults.Panel2.SuspendLayout();
            splitContainerResults.SuspendLayout();
            groupBoxFilters.SuspendLayout();
            groupBoxMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerPattern).BeginInit();
            splitContainerPattern.Panel1.SuspendLayout();
            splitContainerPattern.Panel2.SuspendLayout();
            splitContainerPattern.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPattern);
            tabControl.Controls.Add(tabPage2);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(825, 573);
            tabControl.TabIndex = 0;
            // 
            // tabPattern
            // 
            tabPattern.Controls.Add(splitContainerResults);
            tabPattern.Controls.Add(labelSpace3);
            tabPattern.Controls.Add(splitContainerPattern);
            tabPattern.Controls.Add(labelSpace2);
            tabPattern.Controls.Add(labelPatternInfo);
            tabPattern.Controls.Add(labelSpace1);
            tabPattern.Controls.Add(labelPattern);
            tabPattern.Location = new Point(4, 34);
            tabPattern.Name = "tabPattern";
            tabPattern.Padding = new Padding(3);
            tabPattern.Size = new Size(817, 535);
            tabPattern.TabIndex = 0;
            tabPattern.Text = "Wzorzec";
            tabPattern.UseVisualStyleBackColor = true;
            // 
            // splitContainerResults
            // 
            splitContainerResults.Dock = DockStyle.Fill;
            splitContainerResults.Location = new Point(3, 131);
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
            splitContainerResults.Size = new Size(811, 401);
            splitContainerResults.SplitterDistance = 479;
            splitContainerResults.TabIndex = 8;
            // 
            // textBoxPatternResults
            // 
            textBoxPatternResults.BackColor = SystemColors.ControlLight;
            textBoxPatternResults.BorderStyle = BorderStyle.FixedSingle;
            textBoxPatternResults.Dock = DockStyle.Fill;
            textBoxPatternResults.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBoxPatternResults.Location = new Point(0, 0);
            textBoxPatternResults.Multiline = true;
            textBoxPatternResults.Name = "textBoxPatternResults";
            textBoxPatternResults.ReadOnly = true;
            textBoxPatternResults.ScrollBars = ScrollBars.Vertical;
            textBoxPatternResults.Size = new Size(479, 401);
            textBoxPatternResults.TabIndex = 0;
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
            groupBoxFilters.Size = new Size(328, 291);
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
            labelSpace3.Location = new Point(3, 128);
            labelSpace3.Name = "labelSpace3";
            labelSpace3.Size = new Size(811, 3);
            labelSpace3.TabIndex = 7;
            labelSpace3.Text = " ";
            // 
            // splitContainerPattern
            // 
            splitContainerPattern.Dock = DockStyle.Top;
            splitContainerPattern.Location = new Point(3, 91);
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
            searchPatternBtn.Location = new Point(0, 0);
            searchPatternBtn.Name = "searchPatternBtn";
            searchPatternBtn.Size = new Size(219, 37);
            searchPatternBtn.TabIndex = 7;
            searchPatternBtn.Text = "SZUKAJ";
            searchPatternBtn.UseVisualStyleBackColor = true;
            searchPatternBtn.Click += SearchPattern_Click;
            // 
            // labelSpace2
            // 
            labelSpace2.BackColor = Color.Transparent;
            labelSpace2.Dock = DockStyle.Top;
            labelSpace2.Location = new Point(3, 88);
            labelSpace2.Name = "labelSpace2";
            labelSpace2.Size = new Size(811, 3);
            labelSpace2.TabIndex = 5;
            labelSpace2.Text = " ";
            labelSpace2.Visible = false;
            // 
            // labelPatternInfo
            // 
            labelPatternInfo.BackColor = Color.DarkSeaGreen;
            labelPatternInfo.Dock = DockStyle.Top;
            labelPatternInfo.Location = new Point(3, 38);
            labelPatternInfo.Name = "labelPatternInfo";
            labelPatternInfo.Size = new Size(811, 50);
            labelPatternInfo.TabIndex = 4;
            labelPatternInfo.Visible = false;
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
            labelPattern.Cursor = Cursors.Hand;
            labelPattern.Dock = DockStyle.Top;
            labelPattern.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelPattern.Location = new Point(3, 3);
            labelPattern.Name = "labelPattern";
            labelPattern.Size = new Size(811, 32);
            labelPattern.TabIndex = 0;
            labelPattern.Text = "WZORZEC/ANAGRAMY/METAGRAMY";
            labelPattern.TextAlign = ContentAlignment.TopCenter;
            labelPattern.Click += PatternLabel_Click;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(817, 535);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "TO DO";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(825, 573);
            Controls.Add(tabControl);
            Name = "MainForm";
            Text = "Pomocnik szaradzisty";
            tabControl.ResumeLayout(false);
            tabPattern.ResumeLayout(false);
            splitContainerResults.Panel1.ResumeLayout(false);
            splitContainerResults.Panel1.PerformLayout();
            splitContainerResults.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerResults).EndInit();
            splitContainerResults.ResumeLayout(false);
            groupBoxFilters.ResumeLayout(false);
            groupBoxFilters.PerformLayout();
            groupBoxMode.ResumeLayout(false);
            groupBoxMode.PerformLayout();
            splitContainerPattern.Panel1.ResumeLayout(false);
            splitContainerPattern.Panel1.PerformLayout();
            splitContainerPattern.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerPattern).EndInit();
            splitContainerPattern.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabPattern;
        private TabPage tabPage2;
        private Label labelPattern;
        private Label labelSpace1;
        private Label labelPatternInfo;
        private Label labelSpace2;
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
    }
}
