namespace SudokuSolver
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSoduku = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.chkStep = new System.Windows.Forms.CheckBox();
            this.btnStep = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cmsGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modifyPossibilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nudNSteps = new System.Windows.Forms.NumericUpDown();
            this.chkSaveProgress = new System.Windows.Forms.CheckBox();
            this.btnEuler = new System.Windows.Forms.Button();
            this.btnCheckSol = new System.Windows.Forms.Button();
            this.btnCheckVi = new System.Windows.Forms.Button();
            this.btnProjEul2 = new System.Windows.Forms.Button();
            this.nudEulProb = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoduku)).BeginInit();
            this.cmsGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNSteps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEulProb)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSoduku
            // 
            this.dgvSoduku.AllowUserToAddRows = false;
            this.dgvSoduku.AllowUserToDeleteRows = false;
            this.dgvSoduku.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSoduku.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSoduku.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSoduku.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSoduku.Location = new System.Drawing.Point(16, 15);
            this.dgvSoduku.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSoduku.MultiSelect = false;
            this.dgvSoduku.Name = "dgvSoduku";
            this.dgvSoduku.RowHeadersWidth = 80;
            this.dgvSoduku.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSoduku.Size = new System.Drawing.Size(471, 273);
            this.dgvSoduku.TabIndex = 0;
            this.dgvSoduku.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSoduku_CellMouseDown);
            this.dgvSoduku.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvSoduku_Paint);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "C1";
            this.Column1.Name = "Column1";
            this.Column1.Width = 30;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "C2";
            this.Column2.Name = "Column2";
            this.Column2.Width = 30;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "C3";
            this.Column3.Name = "Column3";
            this.Column3.Width = 30;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "C4";
            this.Column4.Name = "Column4";
            this.Column4.Width = 30;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "C5";
            this.Column5.Name = "Column5";
            this.Column5.Width = 30;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "C6";
            this.Column6.Name = "Column6";
            this.Column6.Width = 30;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "C7";
            this.Column7.Name = "Column7";
            this.Column7.Width = 30;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "C8";
            this.Column8.Name = "Column8";
            this.Column8.Width = 30;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "C9";
            this.Column9.Name = "Column9";
            this.Column9.Width = 30;
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(51, 300);
            this.btnSolve.Margin = new System.Windows.Forms.Padding(4);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(100, 28);
            this.btnSolve.TabIndex = 5;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(51, 400);
            this.btnRestart.Margin = new System.Windows.Forms.Padding(4);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(100, 28);
            this.btnRestart.TabIndex = 8;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(15, 4);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(100, 28);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // chkStep
            // 
            this.chkStep.AutoSize = true;
            this.chkStep.Location = new System.Drawing.Point(51, 336);
            this.chkStep.Margin = new System.Windows.Forms.Padding(4);
            this.chkStep.Name = "chkStep";
            this.chkStep.Size = new System.Drawing.Size(136, 21);
            this.chkStep.TabIndex = 3;
            this.chkStep.Text = "Solve X at a time";
            this.chkStep.UseVisualStyleBackColor = true;
            this.chkStep.CheckedChanged += new System.EventHandler(this.chkStep_CheckedChanged);
            // 
            // btnStep
            // 
            this.btnStep.Location = new System.Drawing.Point(51, 364);
            this.btnStep.Margin = new System.Windows.Forms.Padding(4);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(100, 28);
            this.btnStep.TabIndex = 6;
            this.btnStep.Text = "Next Step";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Visible = false;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(523, 15);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(495, 447);
            this.txtLog.TabIndex = 9;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(380, 300);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(100, 28);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(380, 336);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Soduku Board.txt";
            // 
            // cmsGrid
            // 
            this.cmsGrid.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifyPossibilitiesToolStripMenuItem});
            this.cmsGrid.Name = "cmsGrid";
            this.cmsGrid.Size = new System.Drawing.Size(206, 28);
            // 
            // modifyPossibilitiesToolStripMenuItem
            // 
            this.modifyPossibilitiesToolStripMenuItem.Name = "modifyPossibilitiesToolStripMenuItem";
            this.modifyPossibilitiesToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.modifyPossibilitiesToolStripMenuItem.Text = "Modify Possibilities";
            this.modifyPossibilitiesToolStripMenuItem.Click += new System.EventHandler(this.modifyPossibilitiesToolStripMenuItem_Click);
            // 
            // nudNSteps
            // 
            this.nudNSteps.Location = new System.Drawing.Point(199, 335);
            this.nudNSteps.Margin = new System.Windows.Forms.Padding(4);
            this.nudNSteps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNSteps.Name = "nudNSteps";
            this.nudNSteps.Size = new System.Drawing.Size(60, 22);
            this.nudNSteps.TabIndex = 4;
            this.nudNSteps.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNSteps.Visible = false;
            // 
            // chkSaveProgress
            // 
            this.chkSaveProgress.AutoSize = true;
            this.chkSaveProgress.Location = new System.Drawing.Point(341, 368);
            this.chkSaveProgress.Margin = new System.Windows.Forms.Padding(4);
            this.chkSaveProgress.Name = "chkSaveProgress";
            this.chkSaveProgress.Size = new System.Drawing.Size(170, 21);
            this.chkSaveProgress.TabIndex = 10;
            this.chkSaveProgress.Text = "Save Solved Numbers";
            this.chkSaveProgress.UseVisualStyleBackColor = true;
            // 
            // btnEuler
            // 
            this.btnEuler.Location = new System.Drawing.Point(124, 4);
            this.btnEuler.Margin = new System.Windows.Forms.Padding(4);
            this.btnEuler.Name = "btnEuler";
            this.btnEuler.Size = new System.Drawing.Size(100, 28);
            this.btnEuler.TabIndex = 11;
            this.btnEuler.Text = "Proj Euler";
            this.btnEuler.UseVisualStyleBackColor = true;
            this.btnEuler.Click += new System.EventHandler(this.btnEuler_Click);
            // 
            // btnCheckSol
            // 
            this.btnCheckSol.Location = new System.Drawing.Point(232, 4);
            this.btnCheckSol.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheckSol.Name = "btnCheckSol";
            this.btnCheckSol.Size = new System.Drawing.Size(100, 28);
            this.btnCheckSol.TabIndex = 12;
            this.btnCheckSol.Text = "Check Solt\'n";
            this.btnCheckSol.UseVisualStyleBackColor = true;
            this.btnCheckSol.Click += new System.EventHandler(this.btnCheckSol_Click);
            // 
            // btnCheckVi
            // 
            this.btnCheckVi.Location = new System.Drawing.Point(232, 38);
            this.btnCheckVi.Name = "btnCheckVi";
            this.btnCheckVi.Size = new System.Drawing.Size(100, 28);
            this.btnCheckVi.TabIndex = 13;
            this.btnCheckVi.Text = "Check Violt\'n";
            this.btnCheckVi.UseVisualStyleBackColor = true;
            this.btnCheckVi.Click += new System.EventHandler(this.btnCheckVi_Click);
            // 
            // btnProjEul2
            // 
            this.btnProjEul2.Location = new System.Drawing.Point(121, 39);
            this.btnProjEul2.Name = "btnProjEul2";
            this.btnProjEul2.Size = new System.Drawing.Size(103, 28);
            this.btnProjEul2.TabIndex = 14;
            this.btnProjEul2.Text = "Proj Eul 2";
            this.btnProjEul2.UseVisualStyleBackColor = true;
            this.btnProjEul2.Click += new System.EventHandler(this.btnProjEul2_Click);
            // 
            // nudEulProb
            // 
            this.nudEulProb.Location = new System.Drawing.Point(65, 43);
            this.nudEulProb.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEulProb.Name = "nudEulProb";
            this.nudEulProb.Size = new System.Drawing.Size(50, 22);
            this.nudEulProb.TabIndex = 15;
            this.nudEulProb.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEuler);
            this.panel1.Controls.Add(this.btnCheckSol);
            this.panel1.Controls.Add(this.nudEulProb);
            this.panel1.Controls.Add(this.btnCheckVi);
            this.panel1.Controls.Add(this.btnProjEul2);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Location = new System.Drawing.Point(176, 396);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 78);
            this.panel1.TabIndex = 16;
            this.panel1.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 492);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkSaveProgress);
            this.Controls.Add(this.nudNSteps);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.chkStep);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.dgvSoduku);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "Sudoku Solver";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoduku)).EndInit();
            this.cmsGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudNSteps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEulProb)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSoduku;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.CheckBox chkStep;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ContextMenuStrip cmsGrid;
        private System.Windows.Forms.ToolStripMenuItem modifyPossibilitiesToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown nudNSteps;
        private System.Windows.Forms.CheckBox chkSaveProgress;
        private System.Windows.Forms.Button btnEuler;
        private System.Windows.Forms.Button btnCheckSol;
        private System.Windows.Forms.Button btnCheckVi;
        private System.Windows.Forms.Button btnProjEul2;
        private System.Windows.Forms.NumericUpDown nudEulProb;
        private System.Windows.Forms.Panel panel1;
    }
}

