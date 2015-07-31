namespace Compression
{
    partial class Separation
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.cyclesNumeric = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.hiddenNumeric = new System.Windows.Forms.NumericUpDown();
            this.runButton = new System.Windows.Forms.Button();
            this.parametersLabel = new System.Windows.Forms.Label();
            this.etaLabel = new System.Windows.Forms.Label();
            this.alphaLabel = new System.Windows.Forms.Label();
            this.etaNumeric = new System.Windows.Forms.NumericUpDown();
            this.alphaNumeric = new System.Windows.Forms.NumericUpDown();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cyclesNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hiddenNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.etaNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.cyclesNumeric);
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.hiddenNumeric);
            this.splitContainer2.Panel1.Controls.Add(this.runButton);
            this.splitContainer2.Panel1.Controls.Add(this.parametersLabel);
            this.splitContainer2.Panel1.Controls.Add(this.etaLabel);
            this.splitContainer2.Panel1.Controls.Add(this.alphaLabel);
            this.splitContainer2.Panel1.Controls.Add(this.etaNumeric);
            this.splitContainer2.Panel1.Controls.Add(this.alphaNumeric);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1300, 616);
            this.splitContainer2.SplitterDistance = 186;
            this.splitContainer2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Cycles";
            // 
            // cyclesNumeric
            // 
            this.cyclesNumeric.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.cyclesNumeric.Location = new System.Drawing.Point(59, 177);
            this.cyclesNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.cyclesNumeric.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.cyclesNumeric.Name = "cyclesNumeric";
            this.cyclesNumeric.Size = new System.Drawing.Size(113, 20);
            this.cyclesNumeric.TabIndex = 9;
            this.cyclesNumeric.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(13, 581);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.clear);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Hidden";
            // 
            // hiddenNumeric
            // 
            this.hiddenNumeric.Location = new System.Drawing.Point(59, 139);
            this.hiddenNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.hiddenNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hiddenNumeric.Name = "hiddenNumeric";
            this.hiddenNumeric.Size = new System.Drawing.Size(113, 20);
            this.hiddenNumeric.TabIndex = 6;
            this.hiddenNumeric.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // runButton
            // 
            this.runButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.runButton.Location = new System.Drawing.Point(96, 581);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 5;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // parametersLabel
            // 
            this.parametersLabel.AutoSize = true;
            this.parametersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parametersLabel.Location = new System.Drawing.Point(12, 24);
            this.parametersLabel.Name = "parametersLabel";
            this.parametersLabel.Size = new System.Drawing.Size(122, 25);
            this.parametersLabel.TabIndex = 4;
            this.parametersLabel.Text = "Parameters";
            // 
            // etaLabel
            // 
            this.etaLabel.AutoSize = true;
            this.etaLabel.Location = new System.Drawing.Point(12, 103);
            this.etaLabel.Name = "etaLabel";
            this.etaLabel.Size = new System.Drawing.Size(23, 13);
            this.etaLabel.TabIndex = 3;
            this.etaLabel.Text = "Eta";
            // 
            // alphaLabel
            // 
            this.alphaLabel.AutoSize = true;
            this.alphaLabel.Location = new System.Drawing.Point(12, 67);
            this.alphaLabel.Name = "alphaLabel";
            this.alphaLabel.Size = new System.Drawing.Size(34, 13);
            this.alphaLabel.TabIndex = 2;
            this.alphaLabel.Text = "Alpha";
            // 
            // etaNumeric
            // 
            this.etaNumeric.DecimalPlaces = 2;
            this.etaNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.etaNumeric.Location = new System.Drawing.Point(59, 101);
            this.etaNumeric.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.etaNumeric.Name = "etaNumeric";
            this.etaNumeric.Size = new System.Drawing.Size(113, 20);
            this.etaNumeric.TabIndex = 1;
            this.etaNumeric.Value = new decimal(new int[] {
            16,
            0,
            0,
            131072});
            // 
            // alphaNumeric
            // 
            this.alphaNumeric.DecimalPlaces = 2;
            this.alphaNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.alphaNumeric.Location = new System.Drawing.Point(59, 65);
            this.alphaNumeric.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.alphaNumeric.Name = "alphaNumeric";
            this.alphaNumeric.Size = new System.Drawing.Size(113, 20);
            this.alphaNumeric.TabIndex = 0;
            this.alphaNumeric.Value = new decimal(new int[] {
            46,
            0,
            0,
            131072});
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chart2);
            this.splitContainer1.Size = new System.Drawing.Size(1110, 616);
            this.splitContainer1.SplitterDistance = 433;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1110, 433);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.SizeChanged += new System.EventHandler(this.pictureBox1_SizeChanged);
            this.pictureBox1.Click += new System.EventHandler(this.addPoint);
            // 
            // chart2
            // 
            chartArea1.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea1);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart2.Legends.Add(legend1);
            this.chart2.Location = new System.Drawing.Point(0, 0);
            this.chart2.Name = "chart2";
            this.chart2.Size = new System.Drawing.Size(1110, 175);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            // 
            // Separation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 616);
            this.Controls.Add(this.splitContainer2);
            this.Name = "Separation";
            this.Text = "Separation";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cyclesNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hiddenNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.etaNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaNumeric)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown cyclesNumeric;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown hiddenNumeric;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Label parametersLabel;
        private System.Windows.Forms.Label etaLabel;
        private System.Windows.Forms.Label alphaLabel;
        private System.Windows.Forms.NumericUpDown etaNumeric;
        private System.Windows.Forms.NumericUpDown alphaNumeric;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}