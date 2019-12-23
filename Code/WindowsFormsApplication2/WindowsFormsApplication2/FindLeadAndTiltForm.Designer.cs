namespace WindowsFormsApplication2
{
    partial class FindLeadAndTiltForm
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
            this.finalLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dynamicLabel = new System.Windows.Forms.Label();
            this.maximumForceForLeadTilt = new System.Windows.Forms.Label();
            this.leadTiltForMimimumForces = new System.Windows.Forms.Label();
            this.minForceTIllNow = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Next = new System.Windows.Forms.Button();
            this.tiltMax = new System.Windows.Forms.TextBox();
            this.leadMax = new System.Windows.Forms.TextBox();
            this.tiltMin = new System.Windows.Forms.TextBox();
            this.leadMin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // finalLabel
            // 
            this.finalLabel.Font = new System.Drawing.Font("Helvetica LT Std Cond", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.finalLabel.Location = new System.Drawing.Point(82, 39);
            this.finalLabel.Name = "finalLabel";
            this.finalLabel.Size = new System.Drawing.Size(304, 48);
            this.finalLabel.TabIndex = 0;
            this.finalLabel.Text = "Lead = 0 degrees Tilt = 10 degrees";
            this.finalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Helvetica LT Std Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(192, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 145);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(438, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // dynamicLabel
            // 
            this.dynamicLabel.Font = new System.Drawing.Font("Helvetica LT Std Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dynamicLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dynamicLabel.Location = new System.Drawing.Point(46, 27);
            this.dynamicLabel.Name = "dynamicLabel";
            this.dynamicLabel.Size = new System.Drawing.Size(438, 23);
            this.dynamicLabel.TabIndex = 3;
            this.dynamicLabel.Text = "Lead = 0 degrees Tilt = 10 degrees";
            this.dynamicLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // maximumForceForLeadTilt
            // 
            this.maximumForceForLeadTilt.Font = new System.Drawing.Font("Helvetica LT Std Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maximumForceForLeadTilt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.maximumForceForLeadTilt.Location = new System.Drawing.Point(46, 52);
            this.maximumForceForLeadTilt.Name = "maximumForceForLeadTilt";
            this.maximumForceForLeadTilt.Size = new System.Drawing.Size(438, 23);
            this.maximumForceForLeadTilt.TabIndex = 4;
            this.maximumForceForLeadTilt.Text = "Lead = 0 degrees Tilt = 10 degrees";
            this.maximumForceForLeadTilt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // leadTiltForMimimumForces
            // 
            this.leadTiltForMimimumForces.Font = new System.Drawing.Font("Helvetica LT Std Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leadTiltForMimimumForces.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.leadTiltForMimimumForces.Location = new System.Drawing.Point(46, 77);
            this.leadTiltForMimimumForces.Name = "leadTiltForMimimumForces";
            this.leadTiltForMimimumForces.Size = new System.Drawing.Size(438, 23);
            this.leadTiltForMimimumForces.TabIndex = 5;
            this.leadTiltForMimimumForces.Text = "Lead = 0 degrees Tilt = 10 degrees";
            this.leadTiltForMimimumForces.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // minForceTIllNow
            // 
            this.minForceTIllNow.Font = new System.Drawing.Font("Helvetica LT Std Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minForceTIllNow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.minForceTIllNow.Location = new System.Drawing.Point(46, 102);
            this.minForceTIllNow.Name = "minForceTIllNow";
            this.minForceTIllNow.Size = new System.Drawing.Size(438, 23);
            this.minForceTIllNow.TabIndex = 6;
            this.minForceTIllNow.Text = "Lead = 0 degrees Tilt = 10 degrees";
            this.minForceTIllNow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.Next);
            this.panel1.Controls.Add(this.tiltMax);
            this.panel1.Controls.Add(this.leadMax);
            this.panel1.Controls.Add(this.tiltMin);
            this.panel1.Controls.Add(this.leadMin);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(8, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 157);
            this.panel1.TabIndex = 7;
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(163, 128);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(126, 26);
            this.Next.TabIndex = 5;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // tiltMax
            // 
            this.tiltMax.Location = new System.Drawing.Point(252, 91);
            this.tiltMax.Name = "tiltMax";
            this.tiltMax.Size = new System.Drawing.Size(62, 20);
            this.tiltMax.TabIndex = 4;
            // 
            // leadMax
            // 
            this.leadMax.Location = new System.Drawing.Point(252, 58);
            this.leadMax.Name = "leadMax";
            this.leadMax.Size = new System.Drawing.Size(62, 20);
            this.leadMax.TabIndex = 2;
            // 
            // tiltMin
            // 
            this.tiltMin.Location = new System.Drawing.Point(148, 91);
            this.tiltMin.Name = "tiltMin";
            this.tiltMin.Size = new System.Drawing.Size(62, 20);
            this.tiltMin.TabIndex = 3;
            // 
            // leadMin
            // 
            this.leadMin.Location = new System.Drawing.Point(148, 58);
            this.leadMin.Name = "leadMin";
            this.leadMin.Size = new System.Drawing.Size(62, 20);
            this.leadMin.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Helvetica LT Std Light", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label5.Location = new System.Drawing.Point(222, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "to";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Helvetica LT Std Light", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label4.Location = new System.Drawing.Point(222, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "to";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Helvetica LT Std Light", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label3.Location = new System.Drawing.Point(76, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "From tilt";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Helvetica LT Std Light", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label2.Location = new System.Drawing.Point(76, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "From lead";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Helvetica LT Std Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Location = new System.Drawing.Point(75, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Provide lead and tilt ranges in degrees";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FindLeadAndTiltForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(464, 181);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.minForceTIllNow);
            this.Controls.Add(this.leadTiltForMimimumForces);
            this.Controls.Add(this.maximumForceForLeadTilt);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.finalLabel);
            this.Controls.Add(this.dynamicLabel);
            this.MaximizeBox = false;
            this.Name = "FindLeadAndTiltForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Lead And Tilt Angles";
            this.Load += new System.EventHandler(this.OutputForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label finalLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label dynamicLabel;
        private System.Windows.Forms.Label maximumForceForLeadTilt;
        private System.Windows.Forms.Label leadTiltForMimimumForces;
        private System.Windows.Forms.Label minForceTIllNow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.TextBox tiltMax;
        private System.Windows.Forms.TextBox leadMax;
        private System.Windows.Forms.TextBox tiltMin;
        private System.Windows.Forms.TextBox leadMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}