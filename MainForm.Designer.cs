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
            groupBoxMode = new GroupBox();
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
            tabControl.Size = new Size(791, 559);
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
            tabPattern.Size = new Size(783, 521);
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
            splitContainerResults.Panel2.Controls.Add(groupBoxMode);
            splitContainerResults.Size = new Size(777, 387);
            splitContainerResults.SplitterDistance = 460;
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
            textBoxPatternResults.Size = new Size(460, 387);
            textBoxPatternResults.TabIndex = 0;
            // 
            // groupBoxMode
            // 
            groupBoxMode.Controls.Add(radioAnagramMode);
            groupBoxMode.Controls.Add(radioPatternMode);
            groupBoxMode.Dock = DockStyle.Top;
            groupBoxMode.Location = new Point(0, 0);
            groupBoxMode.Name = "groupBoxMode";
            groupBoxMode.Size = new Size(313, 118);
            groupBoxMode.TabIndex = 0;
            groupBoxMode.TabStop = false;
            groupBoxMode.Text = "Tryb";
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
            labelSpace3.Size = new Size(777, 3);
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
            splitContainerPattern.Size = new Size(777, 37);
            splitContainerPattern.SplitterDistance = 564;
            splitContainerPattern.TabIndex = 6;
            // 
            // textBoxPattern
            // 
            textBoxPattern.CharacterCasing = CharacterCasing.Upper;
            textBoxPattern.Dock = DockStyle.Fill;
            textBoxPattern.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 238);
            textBoxPattern.Location = new Point(0, 0);
            textBoxPattern.Name = "textBoxPattern";
            textBoxPattern.Size = new Size(564, 37);
            textBoxPattern.TabIndex = 7;
            // 
            // searchPatternBtn
            // 
            searchPatternBtn.Cursor = Cursors.Hand;
            searchPatternBtn.Dock = DockStyle.Fill;
            searchPatternBtn.FlatStyle = FlatStyle.Flat;
            searchPatternBtn.Location = new Point(0, 0);
            searchPatternBtn.Name = "searchPatternBtn";
            searchPatternBtn.Size = new Size(209, 37);
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
            labelSpace2.Size = new Size(777, 3);
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
            labelPatternInfo.Size = new Size(777, 50);
            labelPatternInfo.TabIndex = 4;
            labelPatternInfo.Visible = false;
            // 
            // labelSpace1
            // 
            labelSpace1.BackColor = Color.Transparent;
            labelSpace1.Dock = DockStyle.Top;
            labelSpace1.Location = new Point(3, 35);
            labelSpace1.Name = "labelSpace1";
            labelSpace1.Size = new Size(777, 3);
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
            labelPattern.Size = new Size(777, 32);
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
            tabPage2.Size = new Size(783, 521);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "TO DO";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(791, 559);
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
    }
}
