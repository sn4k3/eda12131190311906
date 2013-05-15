namespace eda12131190311906
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.cblAlgorithms = new System.Windows.Forms.CheckedListBox();
            this.tsAlgortimsBar = new System.Windows.Forms.ToolStrip();
            this.lbAlgorithmsSelected = new System.Windows.Forms.ToolStripLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbGnuplotExecutable = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSaveReportsTo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.cbCutLowerHigherAvgValue = new System.Windows.Forms.CheckBox();
            this.nmComputeAverageValueWith = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.cbArrayNumberGrowFactorType = new System.Windows.Forms.ComboBox();
            this.cbArrayGrowFactorType = new System.Windows.Forms.ComboBox();
            this.cbArrayRandomBetweenValues = new System.Windows.Forms.CheckBox();
            this.nmArrayMaxRandomNumber = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.nmArrayNumberGrowFactor = new System.Windows.Forms.NumericUpDown();
            this.nmArrayMinRandomNumber = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nmArrayGrowFactor = new System.Windows.Forms.NumericUpDown();
            this.nmArrayInitialSize = new System.Windows.Forms.NumericUpDown();
            this.nmNumberOfTests = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbAutoOpenPlots = new System.Windows.Forms.CheckBox();
            this.pbLoad = new System.Windows.Forms.ProgressBar();
            this.lbProjectUrl = new System.Windows.Forms.LinkLabel();
            this.lbCredits = new System.Windows.Forms.Label();
            this.lbTimeElapsed = new System.Windows.Forms.Label();
            this.tmClock = new System.Windows.Forms.Timer(this.components);
            this.lbStatus = new System.Windows.Forms.Label();
            this.gbControls = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTop = new System.Windows.Forms.Panel();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSaveReportsTo = new System.Windows.Forms.Button();
            this.btnSearchGnuplotExe = new System.Windows.Forms.Button();
            this.btnAlgorithmsSelectAll = new System.Windows.Forms.ToolStripButton();
            this.btnAlgorithmsDeselectAll = new System.Windows.Forms.ToolStripButton();
            this.btnAlgorithmsInvert = new System.Windows.Forms.ToolStripButton();
            this.btnViewLog = new System.Windows.Forms.ToolStripButton();
            this.bgWorker = new eda12131190311906.AbortableBackgroundWorker();
            this.tsAlgortimsBar.SuspendLayout();
            this.gbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmComputeAverageValueWith)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmArrayMaxRandomNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmArrayNumberGrowFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmArrayMinRandomNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmArrayGrowFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmArrayInitialSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmNumberOfTests)).BeginInit();
            this.gbControls.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // cblAlgorithms
            // 
            this.cblAlgorithms.CheckOnClick = true;
            this.cblAlgorithms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cblAlgorithms.FormattingEnabled = true;
            this.cblAlgorithms.Location = new System.Drawing.Point(0, 0);
            this.cblAlgorithms.MultiColumn = true;
            this.cblAlgorithms.Name = "cblAlgorithms";
            this.cblAlgorithms.Size = new System.Drawing.Size(438, 94);
            this.cblAlgorithms.TabIndex = 0;
            // 
            // tsAlgortimsBar
            // 
            this.tsAlgortimsBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsAlgortimsBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAlgorithmsSelectAll,
            this.btnAlgorithmsDeselectAll,
            this.btnAlgorithmsInvert,
            this.lbAlgorithmsSelected,
            this.btnViewLog});
            this.tsAlgortimsBar.Location = new System.Drawing.Point(0, 0);
            this.tsAlgortimsBar.Name = "tsAlgortimsBar";
            this.tsAlgortimsBar.Size = new System.Drawing.Size(438, 25);
            this.tsAlgortimsBar.TabIndex = 1;
            this.tsAlgortimsBar.Text = "toolStrip1";
            // 
            // lbAlgorithmsSelected
            // 
            this.lbAlgorithmsSelected.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lbAlgorithmsSelected.Name = "lbAlgorithmsSelected";
            this.lbAlgorithmsSelected.Size = new System.Drawing.Size(63, 22);
            this.lbAlgorithmsSelected.Text = "Selected: 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of tests:";
            // 
            // tbGnuplotExecutable
            // 
            this.tbGnuplotExecutable.Location = new System.Drawing.Point(102, 19);
            this.tbGnuplotExecutable.Name = "tbGnuplotExecutable";
            this.tbGnuplotExecutable.ReadOnly = true;
            this.tbGnuplotExecutable.Size = new System.Drawing.Size(300, 20);
            this.tbGnuplotExecutable.TabIndex = 5;
            this.tbGnuplotExecutable.Text = "gnuplot";
            this.tbGnuplotExecutable.TextChanged += new System.EventHandler(this.ObjValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Gnuplot exe:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "(Between 5 and 255)";
            // 
            // tbSaveReportsTo
            // 
            this.tbSaveReportsTo.Location = new System.Drawing.Point(102, 45);
            this.tbSaveReportsTo.Name = "tbSaveReportsTo";
            this.tbSaveReportsTo.ReadOnly = true;
            this.tbSaveReportsTo.Size = new System.Drawing.Size(300, 20);
            this.tbSaveReportsTo.TabIndex = 9;
            this.tbSaveReportsTo.Text = "reports/plot";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Save reports to:";
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.cbCutLowerHigherAvgValue);
            this.gbOptions.Controls.Add(this.nmComputeAverageValueWith);
            this.gbOptions.Controls.Add(this.label10);
            this.gbOptions.Controls.Add(this.cbArrayNumberGrowFactorType);
            this.gbOptions.Controls.Add(this.cbArrayGrowFactorType);
            this.gbOptions.Controls.Add(this.cbArrayRandomBetweenValues);
            this.gbOptions.Controls.Add(this.nmArrayMaxRandomNumber);
            this.gbOptions.Controls.Add(this.label9);
            this.gbOptions.Controls.Add(this.nmArrayNumberGrowFactor);
            this.gbOptions.Controls.Add(this.nmArrayMinRandomNumber);
            this.gbOptions.Controls.Add(this.label7);
            this.gbOptions.Controls.Add(this.label8);
            this.gbOptions.Controls.Add(this.nmArrayGrowFactor);
            this.gbOptions.Controls.Add(this.nmArrayInitialSize);
            this.gbOptions.Controls.Add(this.nmNumberOfTests);
            this.gbOptions.Controls.Add(this.label6);
            this.gbOptions.Controls.Add(this.label5);
            this.gbOptions.Controls.Add(this.cbAutoOpenPlots);
            this.gbOptions.Controls.Add(this.tbSaveReportsTo);
            this.gbOptions.Controls.Add(this.btnSaveReportsTo);
            this.gbOptions.Controls.Add(this.label1);
            this.gbOptions.Controls.Add(this.label4);
            this.gbOptions.Controls.Add(this.label2);
            this.gbOptions.Controls.Add(this.label3);
            this.gbOptions.Controls.Add(this.tbGnuplotExecutable);
            this.gbOptions.Controls.Add(this.btnSearchGnuplotExe);
            this.gbOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbOptions.Location = new System.Drawing.Point(0, 119);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(438, 233);
            this.gbOptions.TabIndex = 11;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Options";
            // 
            // cbCutLowerHigherAvgValue
            // 
            this.cbCutLowerHigherAvgValue.AutoSize = true;
            this.cbCutLowerHigherAvgValue.Checked = true;
            this.cbCutLowerHigherAvgValue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCutLowerHigherAvgValue.Location = new System.Drawing.Point(201, 121);
            this.cbCutLowerHigherAvgValue.Name = "cbCutLowerHigherAvgValue";
            this.cbCutLowerHigherAvgValue.Size = new System.Drawing.Size(157, 17);
            this.cbCutLowerHigherAvgValue.TabIndex = 32;
            this.cbCutLowerHigherAvgValue.Text = "Cut lower and higher values";
            this.cbCutLowerHigherAvgValue.UseVisualStyleBackColor = true;
            this.cbCutLowerHigherAvgValue.CheckedChanged += new System.EventHandler(this.ObjValueChanged);
            // 
            // nmComputeAverageValueWith
            // 
            this.nmComputeAverageValueWith.Location = new System.Drawing.Point(102, 120);
            this.nmComputeAverageValueWith.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nmComputeAverageValueWith.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmComputeAverageValueWith.Name = "nmComputeAverageValueWith";
            this.nmComputeAverageValueWith.Size = new System.Drawing.Size(90, 20);
            this.nmComputeAverageValueWith.TabIndex = 31;
            this.nmComputeAverageValueWith.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nmComputeAverageValueWith.ValueChanged += new System.EventHandler(this.ObjValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Compute average:";
            // 
            // cbArrayNumberGrowFactorType
            // 
            this.cbArrayNumberGrowFactorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArrayNumberGrowFactorType.FormattingEnabled = true;
            this.cbArrayNumberGrowFactorType.Items.AddRange(new object[] {
            "*=",
            "+="});
            this.cbArrayNumberGrowFactorType.Location = new System.Drawing.Point(307, 172);
            this.cbArrayNumberGrowFactorType.Name = "cbArrayNumberGrowFactorType";
            this.cbArrayNumberGrowFactorType.Size = new System.Drawing.Size(40, 21);
            this.cbArrayNumberGrowFactorType.TabIndex = 29;
            this.cbArrayNumberGrowFactorType.SelectedIndexChanged += new System.EventHandler(this.ObjValueChanged);
            // 
            // cbArrayGrowFactorType
            // 
            this.cbArrayGrowFactorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArrayGrowFactorType.FormattingEnabled = true;
            this.cbArrayGrowFactorType.Items.AddRange(new object[] {
            "*=",
            "+="});
            this.cbArrayGrowFactorType.Location = new System.Drawing.Point(307, 145);
            this.cbArrayGrowFactorType.Name = "cbArrayGrowFactorType";
            this.cbArrayGrowFactorType.Size = new System.Drawing.Size(40, 21);
            this.cbArrayGrowFactorType.TabIndex = 28;
            this.cbArrayGrowFactorType.SelectedIndexChanged += new System.EventHandler(this.ObjValueChanged);
            // 
            // cbArrayRandomBetweenValues
            // 
            this.cbArrayRandomBetweenValues.AutoSize = true;
            this.cbArrayRandomBetweenValues.Checked = true;
            this.cbArrayRandomBetweenValues.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbArrayRandomBetweenValues.Location = new System.Drawing.Point(201, 199);
            this.cbArrayRandomBetweenValues.Name = "cbArrayRandomBetweenValues";
            this.cbArrayRandomBetweenValues.Size = new System.Drawing.Size(187, 17);
            this.cbArrayRandomBetweenValues.TabIndex = 27;
            this.cbArrayRandomBetweenValues.Text = "Random numbers between values";
            this.cbArrayRandomBetweenValues.UseVisualStyleBackColor = true;
            this.cbArrayRandomBetweenValues.CheckedChanged += new System.EventHandler(this.ButtonClick);
            // 
            // nmArrayMaxRandomNumber
            // 
            this.nmArrayMaxRandomNumber.Location = new System.Drawing.Point(102, 198);
            this.nmArrayMaxRandomNumber.Maximum = new decimal(new int[] {
            147483647,
            0,
            0,
            0});
            this.nmArrayMaxRandomNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmArrayMaxRandomNumber.Name = "nmArrayMaxRandomNumber";
            this.nmArrayMaxRandomNumber.Size = new System.Drawing.Size(90, 20);
            this.nmArrayMaxRandomNumber.TabIndex = 26;
            this.nmArrayMaxRandomNumber.Value = new decimal(new int[] {
            147483647,
            0,
            0,
            0});
            this.nmArrayMaxRandomNumber.ValueChanged += new System.EventHandler(this.ObjValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 202);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Max rand number:";
            // 
            // nmArrayNumberGrowFactor
            // 
            this.nmArrayNumberGrowFactor.DecimalPlaces = 2;
            this.nmArrayNumberGrowFactor.Enabled = false;
            this.nmArrayNumberGrowFactor.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nmArrayNumberGrowFactor.Location = new System.Drawing.Point(353, 172);
            this.nmArrayNumberGrowFactor.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nmArrayNumberGrowFactor.Minimum = new decimal(new int[] {
            11,
            0,
            0,
            65536});
            this.nmArrayNumberGrowFactor.Name = "nmArrayNumberGrowFactor";
            this.nmArrayNumberGrowFactor.Size = new System.Drawing.Size(79, 20);
            this.nmArrayNumberGrowFactor.TabIndex = 24;
            this.nmArrayNumberGrowFactor.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nmArrayNumberGrowFactor.ValueChanged += new System.EventHandler(this.ObjValueChanged);
            // 
            // nmArrayMinRandomNumber
            // 
            this.nmArrayMinRandomNumber.Location = new System.Drawing.Point(102, 172);
            this.nmArrayMinRandomNumber.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nmArrayMinRandomNumber.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nmArrayMinRandomNumber.Name = "nmArrayMinRandomNumber";
            this.nmArrayMinRandomNumber.Size = new System.Drawing.Size(90, 20);
            this.nmArrayMinRandomNumber.TabIndex = 23;
            this.nmArrayMinRandomNumber.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nmArrayMinRandomNumber.ValueChanged += new System.EventHandler(this.ObjValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(198, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Number grow factor:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Min rand number:";
            // 
            // nmArrayGrowFactor
            // 
            this.nmArrayGrowFactor.DecimalPlaces = 2;
            this.nmArrayGrowFactor.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nmArrayGrowFactor.Location = new System.Drawing.Point(353, 146);
            this.nmArrayGrowFactor.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmArrayGrowFactor.Minimum = new decimal(new int[] {
            11,
            0,
            0,
            65536});
            this.nmArrayGrowFactor.Name = "nmArrayGrowFactor";
            this.nmArrayGrowFactor.Size = new System.Drawing.Size(79, 20);
            this.nmArrayGrowFactor.TabIndex = 20;
            this.nmArrayGrowFactor.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nmArrayGrowFactor.ValueChanged += new System.EventHandler(this.ObjValueChanged);
            // 
            // nmArrayInitialSize
            // 
            this.nmArrayInitialSize.Location = new System.Drawing.Point(102, 146);
            this.nmArrayInitialSize.Maximum = new decimal(new int[] {
            9000000,
            0,
            0,
            0});
            this.nmArrayInitialSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmArrayInitialSize.Name = "nmArrayInitialSize";
            this.nmArrayInitialSize.Size = new System.Drawing.Size(90, 20);
            this.nmArrayInitialSize.TabIndex = 19;
            this.nmArrayInitialSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nmArrayInitialSize.ValueChanged += new System.EventHandler(this.ObjValueChanged);
            // 
            // nmNumberOfTests
            // 
            this.nmNumberOfTests.Location = new System.Drawing.Point(102, 94);
            this.nmNumberOfTests.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nmNumberOfTests.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nmNumberOfTests.Name = "nmNumberOfTests";
            this.nmNumberOfTests.Size = new System.Drawing.Size(90, 20);
            this.nmNumberOfTests.TabIndex = 18;
            this.nmNumberOfTests.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nmNumberOfTests.ValueChanged += new System.EventHandler(this.ObjValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Array grow factor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Array initial size:";
            // 
            // cbAutoOpenPlots
            // 
            this.cbAutoOpenPlots.AutoSize = true;
            this.cbAutoOpenPlots.Checked = true;
            this.cbAutoOpenPlots.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoOpenPlots.Location = new System.Drawing.Point(102, 71);
            this.cbAutoOpenPlots.Name = "cbAutoOpenPlots";
            this.cbAutoOpenPlots.Size = new System.Drawing.Size(254, 17);
            this.cbAutoOpenPlots.TabIndex = 11;
            this.cbAutoOpenPlots.Text = "Auto open generated plot files (Gnuplot required)";
            this.cbAutoOpenPlots.UseVisualStyleBackColor = false;
            this.cbAutoOpenPlots.CheckedChanged += new System.EventHandler(this.ButtonClick);
            // 
            // pbLoad
            // 
            this.pbLoad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbLoad.Location = new System.Drawing.Point(0, 507);
            this.pbLoad.Name = "pbLoad";
            this.pbLoad.Size = new System.Drawing.Size(438, 23);
            this.pbLoad.TabIndex = 15;
            // 
            // lbProjectUrl
            // 
            this.lbProjectUrl.AutoSize = true;
            this.lbProjectUrl.Location = new System.Drawing.Point(266, 491);
            this.lbProjectUrl.Name = "lbProjectUrl";
            this.lbProjectUrl.Size = new System.Drawing.Size(166, 13);
            this.lbProjectUrl.TabIndex = 16;
            this.lbProjectUrl.TabStop = true;
            this.lbProjectUrl.Text = "Project @ Google code repository";
            // 
            // lbCredits
            // 
            this.lbCredits.AutoSize = true;
            this.lbCredits.Location = new System.Drawing.Point(5, 465);
            this.lbCredits.Name = "lbCredits";
            this.lbCredits.Size = new System.Drawing.Size(138, 39);
            this.lbCredits.TabIndex = 17;
            this.lbCredits.Text = "Developed by:\r\nTiago Conceição Nº11903\r\nGonçalo Lampreia Nº11906";
            // 
            // lbTimeElapsed
            // 
            this.lbTimeElapsed.AutoSize = true;
            this.lbTimeElapsed.Location = new System.Drawing.Point(266, 465);
            this.lbTimeElapsed.Name = "lbTimeElapsed";
            this.lbTimeElapsed.Size = new System.Drawing.Size(88, 13);
            this.lbTimeElapsed.TabIndex = 21;
            this.lbTimeElapsed.Text = "Time Elapsed: 0s";
            // 
            // tmClock
            // 
            this.tmClock.Interval = 1000;
            this.tmClock.Tick += new System.EventHandler(this.TmClockTick);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(5, 430);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(74, 13);
            this.lbStatus.TabIndex = 22;
            this.lbStatus.Text = "Status: Ready";
            // 
            // gbControls
            // 
            this.gbControls.Controls.Add(this.btnStart);
            this.gbControls.Controls.Add(this.btnPause);
            this.gbControls.Controls.Add(this.btnStop);
            this.gbControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbControls.Location = new System.Drawing.Point(0, 352);
            this.gbControls.Name = "gbControls";
            this.gbControls.Size = new System.Drawing.Size(438, 65);
            this.gbControls.TabIndex = 23;
            this.gbControls.TabStop = false;
            this.gbControls.Text = "Controls";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Test";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.cblAlgorithms);
            this.pnlTop.Controls.Add(this.rtbLog);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 25);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(438, 94);
            this.pnlTop.TabIndex = 24;
            // 
            // rtbLog
            // 
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Location = new System.Drawing.Point(0, 0);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(438, 94);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // btnStart
            // 
            this.btnStart.Image = global::eda12131190311906.Properties.Resources.play;
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.Location = new System.Drawing.Point(6, 19);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(106, 37);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Image = global::eda12131190311906.Properties.Resources.pause;
            this.btnPause.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPause.Location = new System.Drawing.Point(168, 19);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(106, 37);
            this.btnPause.TabIndex = 13;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Image = global::eda12131190311906.Properties.Resources.stop;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop.Location = new System.Drawing.Point(326, 19);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(106, 37);
            this.btnStop.TabIndex = 14;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnSaveReportsTo
            // 
            this.btnSaveReportsTo.Image = global::eda12131190311906.Properties.Resources.open_file;
            this.btnSaveReportsTo.Location = new System.Drawing.Point(408, 44);
            this.btnSaveReportsTo.Name = "btnSaveReportsTo";
            this.btnSaveReportsTo.Size = new System.Drawing.Size(24, 22);
            this.btnSaveReportsTo.TabIndex = 10;
            this.btnSaveReportsTo.UseVisualStyleBackColor = true;
            this.btnSaveReportsTo.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnSearchGnuplotExe
            // 
            this.btnSearchGnuplotExe.Image = global::eda12131190311906.Properties.Resources.open_file;
            this.btnSearchGnuplotExe.Location = new System.Drawing.Point(408, 18);
            this.btnSearchGnuplotExe.Name = "btnSearchGnuplotExe";
            this.btnSearchGnuplotExe.Size = new System.Drawing.Size(24, 22);
            this.btnSearchGnuplotExe.TabIndex = 6;
            this.btnSearchGnuplotExe.UseVisualStyleBackColor = true;
            this.btnSearchGnuplotExe.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnAlgorithmsSelectAll
            // 
            this.btnAlgorithmsSelectAll.Image = global::eda12131190311906.Properties.Resources.select_all;
            this.btnAlgorithmsSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlgorithmsSelectAll.Name = "btnAlgorithmsSelectAll";
            this.btnAlgorithmsSelectAll.Size = new System.Drawing.Size(73, 22);
            this.btnAlgorithmsSelectAll.Text = "Select &all";
            this.btnAlgorithmsSelectAll.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnAlgorithmsDeselectAll
            // 
            this.btnAlgorithmsDeselectAll.Image = global::eda12131190311906.Properties.Resources.deselect;
            this.btnAlgorithmsDeselectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlgorithmsDeselectAll.Name = "btnAlgorithmsDeselectAll";
            this.btnAlgorithmsDeselectAll.Size = new System.Drawing.Size(86, 22);
            this.btnAlgorithmsDeselectAll.Text = "&Deselect all";
            this.btnAlgorithmsDeselectAll.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnAlgorithmsInvert
            // 
            this.btnAlgorithmsInvert.Image = global::eda12131190311906.Properties.Resources.select_inverse;
            this.btnAlgorithmsInvert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlgorithmsInvert.Name = "btnAlgorithmsInvert";
            this.btnAlgorithmsInvert.Size = new System.Drawing.Size(107, 22);
            this.btnAlgorithmsInvert.Text = "&Invert selection";
            this.btnAlgorithmsInvert.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnViewLog
            // 
            this.btnViewLog.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnViewLog.CheckOnClick = true;
            this.btnViewLog.Image = global::eda12131190311906.Properties.Resources.bug;
            this.btnViewLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewLog.Name = "btnViewLog";
            this.btnViewLog.Size = new System.Drawing.Size(75, 22);
            this.btnViewLog.Text = "View &Log";
            this.btnViewLog.Click += new System.EventHandler(this.ButtonClick);
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgWorkerDoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BgWorkerProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgWorkerRunWorkerCompleted);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 530);
            this.Controls.Add(this.gbControls);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.lbTimeElapsed);
            this.Controls.Add(this.lbCredits);
            this.Controls.Add(this.lbProjectUrl);
            this.Controls.Add(this.pbLoad);
            this.Controls.Add(this.gbOptions);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.tsAlgortimsBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "eda12131190311906";
            this.tsAlgortimsBar.ResumeLayout(false);
            this.tsAlgortimsBar.PerformLayout();
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmComputeAverageValueWith)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmArrayMaxRandomNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmArrayNumberGrowFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmArrayMinRandomNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmArrayGrowFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmArrayInitialSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmNumberOfTests)).EndInit();
            this.gbControls.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox cblAlgorithms;
        private System.Windows.Forms.ToolStrip tsAlgortimsBar;
        private System.Windows.Forms.ToolStripButton btnAlgorithmsSelectAll;
        private System.Windows.Forms.ToolStripButton btnAlgorithmsDeselectAll;
        private System.Windows.Forms.ToolStripButton btnAlgorithmsInvert;
        private System.Windows.Forms.ToolStripLabel lbAlgorithmsSelected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbGnuplotExecutable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearchGnuplotExe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveReportsTo;
        private System.Windows.Forms.TextBox tbSaveReportsTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.CheckBox cbAutoOpenPlots;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ProgressBar pbLoad;
        private System.Windows.Forms.LinkLabel lbProjectUrl;
        private System.Windows.Forms.Label lbCredits;
        private AbortableBackgroundWorker bgWorker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nmNumberOfTests;
        private System.Windows.Forms.NumericUpDown nmArrayGrowFactor;
        private System.Windows.Forms.NumericUpDown nmArrayInitialSize;
        private System.Windows.Forms.Label lbTimeElapsed;
        private System.Windows.Forms.Timer tmClock;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.GroupBox gbControls;
        private System.Windows.Forms.NumericUpDown nmArrayNumberGrowFactor;
        private System.Windows.Forms.NumericUpDown nmArrayMinRandomNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nmArrayMaxRandomNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbArrayRandomBetweenValues;
        private System.Windows.Forms.ComboBox cbArrayGrowFactorType;
        private System.Windows.Forms.ComboBox cbArrayNumberGrowFactorType;
        private System.Windows.Forms.CheckBox cbCutLowerHigherAvgValue;
        private System.Windows.Forms.NumericUpDown nmComputeAverageValueWith;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.ToolStripButton btnViewLog;
    }
}

