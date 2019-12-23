namespace WindowsFormsApplication2
{
    partial class TaskSelectionForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tilt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lead = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cycles = new System.Windows.Forms.TextBox();
            this.distanceTravel = new System.Windows.Forms.TextBox();
            this.time = new System.Windows.Forms.TextBox();
            this.exportToExcel = new System.Windows.Forms.CheckBox();
            this.taskDisplayCuttingZone = new System.Windows.Forms.RadioButton();
            this.taskSimulateForces = new System.Windows.Forms.RadioButton();
            this.taskLeadTiltAngle = new System.Windows.Forms.RadioButton();
            this.taskButton = new System.Windows.Forms.Button();
            this.TaskSelectionBackButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.getSurfaceRoughnessButton = new System.Windows.Forms.Button();
            this.followingCut = new System.Windows.Forms.RadioButton();
            this.firstCut = new System.Windows.Forms.RadioButton();
            this.stepOver = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tilt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lead);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cycles);
            this.panel1.Controls.Add(this.distanceTravel);
            this.panel1.Controls.Add(this.time);
            this.panel1.Location = new System.Drawing.Point(48, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 177);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(13, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 90;
            this.label5.Text = "Tilt angles";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(7, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 15);
            this.label6.TabIndex = 80;
            this.label6.Text = "Lead angle";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 70;
            this.label4.Text = "Revolutions";
            // 
            // tilt
            // 
            this.tilt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tilt.Location = new System.Drawing.Point(94, 42);
            this.tilt.Name = "tilt";
            this.tilt.Size = new System.Drawing.Size(99, 20);
            this.tilt.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(20, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 70;
            this.label3.Text = "Distance";
            // 
            // lead
            // 
            this.lead.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lead.Location = new System.Drawing.Point(94, 12);
            this.lead.Name = "lead";
            this.lead.Size = new System.Drawing.Size(99, 20);
            this.lead.TabIndex = 23;
            this.lead.TextChanged += new System.EventHandler(this.lead_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 60;
            this.label1.Text = "Time t (min)";
            // 
            // cycles
            // 
            this.cycles.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cycles.Location = new System.Drawing.Point(94, 132);
            this.cycles.Name = "cycles";
            this.cycles.Size = new System.Drawing.Size(99, 20);
            this.cycles.TabIndex = 22;
            this.cycles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cycles_KeyUp);
            // 
            // distanceTravel
            // 
            this.distanceTravel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.distanceTravel.Location = new System.Drawing.Point(94, 102);
            this.distanceTravel.Name = "distanceTravel";
            this.distanceTravel.Size = new System.Drawing.Size(99, 20);
            this.distanceTravel.TabIndex = 21;
            this.distanceTravel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.distanceTravel_KeyUp);
            // 
            // time
            // 
            this.time.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.time.Location = new System.Drawing.Point(94, 72);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(99, 20);
            this.time.TabIndex = 20;
            this.time.KeyUp += new System.Windows.Forms.KeyEventHandler(this.time_KeyUp);
            // 
            // exportToExcel
            // 
            this.exportToExcel.AutoSize = true;
            this.exportToExcel.BackColor = System.Drawing.Color.Transparent;
            this.exportToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exportToExcel.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportToExcel.ForeColor = System.Drawing.Color.White;
            this.exportToExcel.Location = new System.Drawing.Point(48, 364);
            this.exportToExcel.Name = "exportToExcel";
            this.exportToExcel.Size = new System.Drawing.Size(237, 19);
            this.exportToExcel.TabIndex = 25;
            this.exportToExcel.Text = "Export result data to Excel spreadsheet";
            this.exportToExcel.UseVisualStyleBackColor = false;
            // 
            // taskDisplayCuttingZone
            // 
            this.taskDisplayCuttingZone.BackColor = System.Drawing.Color.Transparent;
            this.taskDisplayCuttingZone.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.taskDisplayCuttingZone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.taskDisplayCuttingZone.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskDisplayCuttingZone.ForeColor = System.Drawing.Color.White;
            this.taskDisplayCuttingZone.Location = new System.Drawing.Point(547, 54);
            this.taskDisplayCuttingZone.Name = "taskDisplayCuttingZone";
            this.taskDisplayCuttingZone.Size = new System.Drawing.Size(202, 45);
            this.taskDisplayCuttingZone.TabIndex = 12;
            this.taskDisplayCuttingZone.TabStop = true;
            this.taskDisplayCuttingZone.Text = "Display simulated Engagement Region till time t";
            this.taskDisplayCuttingZone.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.taskDisplayCuttingZone.UseVisualStyleBackColor = false;
            this.taskDisplayCuttingZone.CheckedChanged += new System.EventHandler(this.taskDisplayCuttingZone_CheckedChanged);
            // 
            // taskSimulateForces
            // 
            this.taskSimulateForces.BackColor = System.Drawing.Color.Transparent;
            this.taskSimulateForces.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.taskSimulateForces.Cursor = System.Windows.Forms.Cursors.Hand;
            this.taskSimulateForces.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskSimulateForces.ForeColor = System.Drawing.Color.White;
            this.taskSimulateForces.Location = new System.Drawing.Point(48, 54);
            this.taskSimulateForces.Name = "taskSimulateForces";
            this.taskSimulateForces.Size = new System.Drawing.Size(190, 28);
            this.taskSimulateForces.TabIndex = 1;
            this.taskSimulateForces.TabStop = true;
            this.taskSimulateForces.Text = "Force and Torque simulation";
            this.taskSimulateForces.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.taskSimulateForces.UseVisualStyleBackColor = false;
            this.taskSimulateForces.CheckedChanged += new System.EventHandler(this.taskSimulateForces_CheckedChanged);
            // 
            // taskLeadTiltAngle
            // 
            this.taskLeadTiltAngle.BackColor = System.Drawing.Color.Transparent;
            this.taskLeadTiltAngle.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.taskLeadTiltAngle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.taskLeadTiltAngle.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskLeadTiltAngle.ForeColor = System.Drawing.Color.White;
            this.taskLeadTiltAngle.Location = new System.Drawing.Point(302, 54);
            this.taskLeadTiltAngle.Name = "taskLeadTiltAngle";
            this.taskLeadTiltAngle.Size = new System.Drawing.Size(190, 52);
            this.taskLeadTiltAngle.TabIndex = 11;
            this.taskLeadTiltAngle.TabStop = true;
            this.taskLeadTiltAngle.Text = "Determine values of lead and tilt angles for minimum force";
            this.taskLeadTiltAngle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.taskLeadTiltAngle.UseVisualStyleBackColor = false;
            this.taskLeadTiltAngle.CheckedChanged += new System.EventHandler(this.taskLeadTiltAngle_CheckedChanged);
            // 
            // taskButton
            // 
            this.taskButton.Location = new System.Drawing.Point(609, 401);
            this.taskButton.Name = "taskButton";
            this.taskButton.Size = new System.Drawing.Size(126, 26);
            this.taskButton.TabIndex = 2;
            this.taskButton.Text = "Proceed";
            this.taskButton.UseVisualStyleBackColor = true;
            this.taskButton.Click += new System.EventHandler(this.taskButton_Click);
            // 
            // TaskSelectionBackButton
            // 
            this.TaskSelectionBackButton.Location = new System.Drawing.Point(48, 401);
            this.TaskSelectionBackButton.Name = "TaskSelectionBackButton";
            this.TaskSelectionBackButton.Size = new System.Drawing.Size(126, 28);
            this.TaskSelectionBackButton.TabIndex = 30;
            this.TaskSelectionBackButton.Text = "Back";
            this.TaskSelectionBackButton.UseVisualStyleBackColor = true;
            this.TaskSelectionBackButton.Click += new System.EventHandler(this.TaskSelectionBackButton_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Helvetica LT Std Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(45, 293);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(260, 15);
            this.label7.TabIndex = 100;
            this.label7.Text = "NOTE: Distances in mm and angles in degress";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.getSurfaceRoughnessButton);
            this.panel2.Controls.Add(this.followingCut);
            this.panel2.Controls.Add(this.firstCut);
            this.panel2.Controls.Add(this.stepOver);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(549, 110);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 177);
            this.panel2.TabIndex = 101;
            // 
            // getSurfaceRoughnessButton
            // 
            this.getSurfaceRoughnessButton.Location = new System.Drawing.Point(8, 71);
            this.getSurfaceRoughnessButton.Name = "getSurfaceRoughnessButton";
            this.getSurfaceRoughnessButton.Size = new System.Drawing.Size(184, 26);
            this.getSurfaceRoughnessButton.TabIndex = 100;
            this.getSurfaceRoughnessButton.Text = "Get surface roughness";
            this.getSurfaceRoughnessButton.UseVisualStyleBackColor = true;
            this.getSurfaceRoughnessButton.Click += new System.EventHandler(this.getSurfaceRoughnessButton_Click);
            // 
            // followingCut
            // 
            this.followingCut.BackColor = System.Drawing.Color.Transparent;
            this.followingCut.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.followingCut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.followingCut.Enabled = false;
            this.followingCut.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.followingCut.ForeColor = System.Drawing.Color.White;
            this.followingCut.Location = new System.Drawing.Point(92, 11);
            this.followingCut.Name = "followingCut";
            this.followingCut.Size = new System.Drawing.Size(102, 26);
            this.followingCut.TabIndex = 104;
            this.followingCut.TabStop = true;
            this.followingCut.Text = "Following Cut";
            this.followingCut.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.followingCut.UseVisualStyleBackColor = false;
            this.followingCut.CheckedChanged += new System.EventHandler(this.followingCut_CheckedChanged_1);
            // 
            // firstCut
            // 
            this.firstCut.BackColor = System.Drawing.Color.Transparent;
            this.firstCut.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.firstCut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.firstCut.Enabled = false;
            this.firstCut.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstCut.ForeColor = System.Drawing.Color.White;
            this.firstCut.Location = new System.Drawing.Point(8, 11);
            this.firstCut.Name = "firstCut";
            this.firstCut.Size = new System.Drawing.Size(72, 26);
            this.firstCut.TabIndex = 103;
            this.firstCut.TabStop = true;
            this.firstCut.Text = "Slotting";
            this.firstCut.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.firstCut.UseVisualStyleBackColor = false;
            this.firstCut.CheckedChanged += new System.EventHandler(this.firstCut_CheckedChanged);
            // 
            // stepOver
            // 
            this.stepOver.Enabled = false;
            this.stepOver.Location = new System.Drawing.Point(93, 41);
            this.stepOver.Name = "stepOver";
            this.stepOver.Size = new System.Drawing.Size(99, 20);
            this.stepOver.TabIndex = 101;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 102;
            this.label2.Text = "Step Over";
            // 
            // TaskSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.BackgroundImage = global::WindowsFormsApplication2.Properties.Resources.dmc80fd_db_bear_ritzel_11_rd12_1200x900;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TaskSelectionBackButton);
            this.Controls.Add(this.taskButton);
            this.Controls.Add(this.taskLeadTiltAngle);
            this.Controls.Add(this.taskSimulateForces);
            this.Controls.Add(this.taskDisplayCuttingZone);
            this.Controls.Add(this.exportToExcel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TaskSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FAMSim 1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskSelectionForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox exportToExcel;
        private System.Windows.Forms.RadioButton taskDisplayCuttingZone;
        private System.Windows.Forms.RadioButton taskSimulateForces;
        private System.Windows.Forms.RadioButton taskLeadTiltAngle;
        private System.Windows.Forms.Button taskButton;
        private System.Windows.Forms.Button TaskSelectionBackButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cycles;
        private System.Windows.Forms.TextBox distanceTravel;
        private System.Windows.Forms.TextBox time;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tilt;
        private System.Windows.Forms.TextBox lead;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button getSurfaceRoughnessButton;
        private System.Windows.Forms.RadioButton followingCut;
        private System.Windows.Forms.RadioButton firstCut;
        private System.Windows.Forms.TextBox stepOver;
        private System.Windows.Forms.Label label2;
    }
}