namespace SudokuSolver
{
    partial class frmPossibilites
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
            this.lblCell = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.chk3 = new System.Windows.Forms.CheckBox();
            this.chk4 = new System.Windows.Forms.CheckBox();
            this.chk5 = new System.Windows.Forms.CheckBox();
            this.chk6 = new System.Windows.Forms.CheckBox();
            this.chk7 = new System.Windows.Forms.CheckBox();
            this.chk8 = new System.Windows.Forms.CheckBox();
            this.chk9 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblCell
            // 
            this.lblCell.AutoSize = true;
            this.lblCell.Location = new System.Drawing.Point(34, 9);
            this.lblCell.Name = "lblCell";
            this.lblCell.Size = new System.Drawing.Size(115, 13);
            this.lblCell.TabIndex = 0;
            this.lblCell.Text = "Cell in row X, column X";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 176);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chk1
            // 
            this.chk1.AutoSize = true;
            this.chk1.Location = new System.Drawing.Point(67, 25);
            this.chk1.Name = "chk1";
            this.chk1.Size = new System.Drawing.Size(32, 17);
            this.chk1.TabIndex = 4;
            this.chk1.Text = "1";
            this.chk1.UseVisualStyleBackColor = true;
            // 
            // chk2
            // 
            this.chk2.AutoSize = true;
            this.chk2.Location = new System.Drawing.Point(67, 41);
            this.chk2.Name = "chk2";
            this.chk2.Size = new System.Drawing.Size(32, 17);
            this.chk2.TabIndex = 5;
            this.chk2.Text = "2";
            this.chk2.UseVisualStyleBackColor = true;
            // 
            // chk3
            // 
            this.chk3.AutoSize = true;
            this.chk3.Location = new System.Drawing.Point(67, 57);
            this.chk3.Name = "chk3";
            this.chk3.Size = new System.Drawing.Size(32, 17);
            this.chk3.TabIndex = 5;
            this.chk3.Text = "3";
            this.chk3.UseVisualStyleBackColor = true;
            // 
            // chk4
            // 
            this.chk4.AutoSize = true;
            this.chk4.Location = new System.Drawing.Point(67, 73);
            this.chk4.Name = "chk4";
            this.chk4.Size = new System.Drawing.Size(32, 17);
            this.chk4.TabIndex = 5;
            this.chk4.Text = "4";
            this.chk4.UseVisualStyleBackColor = true;
            // 
            // chk5
            // 
            this.chk5.AutoSize = true;
            this.chk5.Location = new System.Drawing.Point(67, 89);
            this.chk5.Name = "chk5";
            this.chk5.Size = new System.Drawing.Size(32, 17);
            this.chk5.TabIndex = 5;
            this.chk5.Text = "5";
            this.chk5.UseVisualStyleBackColor = true;
            // 
            // chk6
            // 
            this.chk6.AutoSize = true;
            this.chk6.Location = new System.Drawing.Point(67, 105);
            this.chk6.Name = "chk6";
            this.chk6.Size = new System.Drawing.Size(32, 17);
            this.chk6.TabIndex = 5;
            this.chk6.Text = "6";
            this.chk6.UseVisualStyleBackColor = true;
            // 
            // chk7
            // 
            this.chk7.AutoSize = true;
            this.chk7.Location = new System.Drawing.Point(67, 121);
            this.chk7.Name = "chk7";
            this.chk7.Size = new System.Drawing.Size(32, 17);
            this.chk7.TabIndex = 5;
            this.chk7.Text = "7";
            this.chk7.UseVisualStyleBackColor = true;
            // 
            // chk8
            // 
            this.chk8.AutoSize = true;
            this.chk8.Location = new System.Drawing.Point(67, 137);
            this.chk8.Name = "chk8";
            this.chk8.Size = new System.Drawing.Size(32, 17);
            this.chk8.TabIndex = 5;
            this.chk8.Text = "8";
            this.chk8.UseVisualStyleBackColor = true;
            // 
            // chk9
            // 
            this.chk9.AutoSize = true;
            this.chk9.Location = new System.Drawing.Point(67, 153);
            this.chk9.Name = "chk9";
            this.chk9.Size = new System.Drawing.Size(32, 17);
            this.chk9.TabIndex = 5;
            this.chk9.Text = "9";
            this.chk9.UseVisualStyleBackColor = true;
            // 
            // frmPossibilites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(182, 209);
            this.Controls.Add(this.chk9);
            this.Controls.Add(this.chk8);
            this.Controls.Add(this.chk7);
            this.Controls.Add(this.chk6);
            this.Controls.Add(this.chk5);
            this.Controls.Add(this.chk4);
            this.Controls.Add(this.chk3);
            this.Controls.Add(this.chk2);
            this.Controls.Add(this.chk1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblCell);
            this.Name = "frmPossibilites";
            this.Text = "Possibilites";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblCell;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.CheckBox chk1;
        public System.Windows.Forms.CheckBox chk2;
        public System.Windows.Forms.CheckBox chk3;
        public System.Windows.Forms.CheckBox chk4;
        public System.Windows.Forms.CheckBox chk5;
        public System.Windows.Forms.CheckBox chk6;
        public System.Windows.Forms.CheckBox chk7;
        public System.Windows.Forms.CheckBox chk8;
        public System.Windows.Forms.CheckBox chk9;
    }
}