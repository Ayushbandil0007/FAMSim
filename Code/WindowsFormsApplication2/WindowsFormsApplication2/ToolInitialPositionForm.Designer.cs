namespace WindowsFormsApplication2
{
    partial class ToolInitialPositionForm
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.rpm = new System.Windows.Forms.TextBox();
            this.horizonatalFeed = new System.Windows.Forms.TextBox();
            this.verticalFeed = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.depth = new System.Windows.Forms.TextBox();
            this.depthLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.toolInitialPositionNext = new System.Windows.Forms.Button();
            this.alpha = new System.Windows.Forms.TextBox();
            this.del_phi = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.del_z = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lebel32 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.Kp = new System.Windows.Forms.TextBox();
            this.Lp = new System.Windows.Forms.TextBox();
            this.beta = new System.Windows.Forms.TextBox();
            this.toolInitialPositionBack = new System.Windows.Forms.Button();
            this.xMargin = new System.Windows.Forms.TextBox();
            this.yMargin = new System.Windows.Forms.TextBox();
            this.stepSize = new System.Windows.Forms.TextBox();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.stepSizeLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.betaLabel = new System.Windows.Forms.Label();
            this.alphaLabel = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.picturePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.rpm);
            this.panel5.Controls.Add(this.horizonatalFeed);
            this.panel5.Controls.Add(this.verticalFeed);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.depth);
            this.panel5.Controls.Add(this.depthLabel);
            this.panel5.Location = new System.Drawing.Point(413, 60);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(341, 161);
            this.panel5.TabIndex = 36;
            // 
            // rpm
            // 
            this.rpm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rpm.Location = new System.Drawing.Point(157, 97);
            this.rpm.Name = "rpm";
            this.rpm.Size = new System.Drawing.Size(167, 20);
            this.rpm.TabIndex = 13;
            // 
            // horizonatalFeed
            // 
            this.horizonatalFeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.horizonatalFeed.Location = new System.Drawing.Point(157, 67);
            this.horizonatalFeed.Name = "horizonatalFeed";
            this.horizonatalFeed.Size = new System.Drawing.Size(167, 20);
            this.horizonatalFeed.TabIndex = 12;
            // 
            // verticalFeed
            // 
            this.verticalFeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.verticalFeed.Location = new System.Drawing.Point(157, 37);
            this.verticalFeed.Name = "verticalFeed";
            this.verticalFeed.Size = new System.Drawing.Size(167, 20);
            this.verticalFeed.TabIndex = 11;
            this.verticalFeed.TextChanged += new System.EventHandler(this.verticalFeed_TextChanged);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(115, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "RPM";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(19, 70);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(127, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "Feed Horizontal (mm/min)";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(31, 40);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(115, 13);
            this.label16.TabIndex = 11;
            this.label16.Text = "Feed Vertical (mm/min)";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Location = new System.Drawing.Point(127, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Machining Parameter";
            // 
            // depth
            // 
            this.depth.Location = new System.Drawing.Point(157, 127);
            this.depth.Name = "depth";
            this.depth.Size = new System.Drawing.Size(167, 20);
            this.depth.TabIndex = 14;
            // 
            // depthLabel
            // 
            this.depthLabel.AutoSize = true;
            this.depthLabel.BackColor = System.Drawing.Color.Transparent;
            this.depthLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.depthLabel.Location = new System.Drawing.Point(86, 130);
            this.depthLabel.Name = "depthLabel";
            this.depthLabel.Size = new System.Drawing.Size(61, 13);
            this.depthLabel.TabIndex = 46;
            this.depthLabel.Text = "Initial depth";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label13.Location = new System.Drawing.Point(25, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "No of Axial Divisions, Lp";
            // 
            // toolInitialPositionNext
            // 
            this.toolInitialPositionNext.AutoEllipsis = true;
            this.toolInitialPositionNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolInitialPositionNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolInitialPositionNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolInitialPositionNext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolInitialPositionNext.Location = new System.Drawing.Point(609, 401);
            this.toolInitialPositionNext.Name = "toolInitialPositionNext";
            this.toolInitialPositionNext.Size = new System.Drawing.Size(126, 26);
            this.toolInitialPositionNext.TabIndex = 1;
            this.toolInitialPositionNext.Text = "Next";
            this.toolInitialPositionNext.UseVisualStyleBackColor = false;
            this.toolInitialPositionNext.Click += new System.EventHandler(this.toolInitialPositionNext_Click_1);
            // 
            // alpha
            // 
            this.alpha.Location = new System.Drawing.Point(199, 265);
            this.alpha.Name = "alpha";
            this.alpha.Size = new System.Drawing.Size(167, 20);
            this.alpha.TabIndex = 33;
            // 
            // del_phi
            // 
            this.del_phi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.del_phi.Location = new System.Drawing.Point(159, 127);
            this.del_phi.Name = "del_phi";
            this.del_phi.Size = new System.Drawing.Size(167, 20);
            this.del_phi.TabIndex = 24;
            this.del_phi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.del_phi_KeyUp);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label12.Location = new System.Drawing.Point(16, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "No of Radial Divisions, Kp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Helvetica LT Std Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(159, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(500, 29);
            this.label1.TabIndex = 37;
            this.label1.Text = "Tool Initial Position and Machining Parameters";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.del_z);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.del_phi);
            this.panel6.Controls.Add(this.lebel32);
            this.panel6.Controls.Add(this.label17);
            this.panel6.Controls.Add(this.Kp);
            this.panel6.Controls.Add(this.Lp);
            this.panel6.Controls.Add(this.label12);
            this.panel6.Controls.Add(this.label13);
            this.panel6.Location = new System.Drawing.Point(413, 227);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(341, 160);
            this.panel6.TabIndex = 38;
            // 
            // del_z
            // 
            this.del_z.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.del_z.Location = new System.Drawing.Point(159, 67);
            this.del_z.Name = "del_z";
            this.del_z.Size = new System.Drawing.Size(167, 20);
            this.del_z.TabIndex = 22;
            this.del_z.KeyUp += new System.Windows.Forms.KeyEventHandler(this.del_z_KeyUp);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(28, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Axial Incremental, del_z";
            // 
            // lebel32
            // 
            this.lebel32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lebel32.AutoSize = true;
            this.lebel32.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lebel32.Location = new System.Drawing.Point(11, 130);
            this.lebel32.Name = "lebel32";
            this.lebel32.Size = new System.Drawing.Size(135, 13);
            this.lebel32.TabIndex = 23;
            this.lebel32.Text = "Radial Incremental, del_phi";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label17.Location = new System.Drawing.Point(112, 11);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(147, 15);
            this.label17.TabIndex = 22;
            this.label17.Text = "Discretization Parameters";
            // 
            // Kp
            // 
            this.Kp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Kp.Location = new System.Drawing.Point(159, 97);
            this.Kp.Name = "Kp";
            this.Kp.Size = new System.Drawing.Size(167, 20);
            this.Kp.TabIndex = 23;
            this.Kp.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Kp_KeyUp);
            // 
            // Lp
            // 
            this.Lp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lp.Location = new System.Drawing.Point(159, 37);
            this.Lp.Name = "Lp";
            this.Lp.Size = new System.Drawing.Size(167, 20);
            this.Lp.TabIndex = 21;
            this.Lp.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Lp_KeyUp);
            // 
            // beta
            // 
            this.beta.Location = new System.Drawing.Point(199, 295);
            this.beta.Name = "beta";
            this.beta.Size = new System.Drawing.Size(167, 20);
            this.beta.TabIndex = 34;
            // 
            // toolInitialPositionBack
            // 
            this.toolInitialPositionBack.AutoEllipsis = true;
            this.toolInitialPositionBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolInitialPositionBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolInitialPositionBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolInitialPositionBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolInitialPositionBack.Location = new System.Drawing.Point(48, 401);
            this.toolInitialPositionBack.Name = "toolInitialPositionBack";
            this.toolInitialPositionBack.Size = new System.Drawing.Size(126, 26);
            this.toolInitialPositionBack.TabIndex = 41;
            this.toolInitialPositionBack.Text = "Back";
            this.toolInitialPositionBack.UseVisualStyleBackColor = false;
            this.toolInitialPositionBack.Click += new System.EventHandler(this.toolInitialPositionBack_Click);
            // 
            // xMargin
            // 
            this.xMargin.Location = new System.Drawing.Point(199, 205);
            this.xMargin.Name = "xMargin";
            this.xMargin.Size = new System.Drawing.Size(167, 20);
            this.xMargin.TabIndex = 31;
            // 
            // yMargin
            // 
            this.yMargin.Location = new System.Drawing.Point(199, 235);
            this.yMargin.Name = "yMargin";
            this.yMargin.Size = new System.Drawing.Size(167, 20);
            this.yMargin.TabIndex = 32;
            // 
            // stepSize
            // 
            this.stepSize.Location = new System.Drawing.Point(199, 325);
            this.stepSize.Name = "stepSize";
            this.stepSize.Size = new System.Drawing.Size(167, 20);
            this.stepSize.TabIndex = 35;
            // 
            // picturePanel
            // 
            this.picturePanel.BackColor = System.Drawing.Color.Transparent;
            this.picturePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picturePanel.Controls.Add(this.stepSize);
            this.picturePanel.Controls.Add(this.stepSizeLabel);
            this.picturePanel.Controls.Add(this.xMargin);
            this.picturePanel.Controls.Add(this.yLabel);
            this.picturePanel.Controls.Add(this.yMargin);
            this.picturePanel.Controls.Add(this.betaLabel);
            this.picturePanel.Controls.Add(this.alphaLabel);
            this.picturePanel.Controls.Add(this.xLabel);
            this.picturePanel.Controls.Add(this.alpha);
            this.picturePanel.Controls.Add(this.beta);
            this.picturePanel.Location = new System.Drawing.Point(28, 60);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(379, 327);
            this.picturePanel.TabIndex = 56;
            // 
            // stepSizeLabel
            // 
            this.stepSizeLabel.AutoSize = true;
            this.stepSizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.stepSizeLabel.ForeColor = System.Drawing.Color.Black;
            this.stepSizeLabel.Location = new System.Drawing.Point(176, 328);
            this.stepSizeLabel.Name = "stepSizeLabel";
            this.stepSizeLabel.Size = new System.Drawing.Size(14, 13);
            this.stepSizeLabel.TabIndex = 59;
            this.stepSizeLabel.Text = "Z";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.BackColor = System.Drawing.Color.Transparent;
            this.yLabel.ForeColor = System.Drawing.Color.Black;
            this.yLabel.Location = new System.Drawing.Point(176, 238);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(14, 13);
            this.yLabel.TabIndex = 58;
            this.yLabel.Text = "Y";
            // 
            // betaLabel
            // 
            this.betaLabel.AutoSize = true;
            this.betaLabel.BackColor = System.Drawing.Color.Transparent;
            this.betaLabel.ForeColor = System.Drawing.Color.Black;
            this.betaLabel.Location = new System.Drawing.Point(176, 298);
            this.betaLabel.Name = "betaLabel";
            this.betaLabel.Size = new System.Drawing.Size(13, 13);
            this.betaLabel.TabIndex = 57;
            this.betaLabel.Text = "β";
            // 
            // alphaLabel
            // 
            this.alphaLabel.AutoSize = true;
            this.alphaLabel.BackColor = System.Drawing.Color.Transparent;
            this.alphaLabel.ForeColor = System.Drawing.Color.Black;
            this.alphaLabel.Location = new System.Drawing.Point(176, 268);
            this.alphaLabel.Name = "alphaLabel";
            this.alphaLabel.Size = new System.Drawing.Size(14, 13);
            this.alphaLabel.TabIndex = 56;
            this.alphaLabel.Text = "α";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.BackColor = System.Drawing.Color.Transparent;
            this.xLabel.ForeColor = System.Drawing.Color.Black;
            this.xLabel.Location = new System.Drawing.Point(176, 208);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(14, 13);
            this.xLabel.TabIndex = 54;
            this.xLabel.Text = "X";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Helvetica LT Std Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(269, 407);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 15);
            this.label3.TabIndex = 57;
            this.label3.Text = "NOTE: Distances in mm and angles in degress";
            // 
            // ToolInitialPositionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.toolInitialPositionNext);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.toolInitialPositionBack);
            this.Controls.Add(this.picturePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ToolInitialPositionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FAMSim 1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ToolInitialPositionForm_FormClosing);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.picturePanel.ResumeLayout(false);
            this.picturePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox rpm;
        private System.Windows.Forms.TextBox horizonatalFeed;
        private System.Windows.Forms.TextBox verticalFeed;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox depth;
        private System.Windows.Forms.Button toolInitialPositionNext;
        private System.Windows.Forms.TextBox alpha;
        private System.Windows.Forms.TextBox del_phi;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lebel32;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox Kp;
        private System.Windows.Forms.TextBox Lp;
        private System.Windows.Forms.TextBox beta;
        private System.Windows.Forms.Button toolInitialPositionBack;
        private System.Windows.Forms.TextBox xMargin;
        private System.Windows.Forms.TextBox yMargin;
        private System.Windows.Forms.Label depthLabel;
        private System.Windows.Forms.TextBox stepSize;
        private System.Windows.Forms.TextBox del_z;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel picturePanel;
        private System.Windows.Forms.Label stepSizeLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label betaLabel;
        private System.Windows.Forms.Label alphaLabel;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label label3;
    }
}