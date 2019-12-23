namespace WindowsFormsApplication2
{
    partial class ToolParametersForm
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
            this.beta = new System.Windows.Forms.TextBox();
            this.alpha = new System.Windows.Forms.TextBox();
            this.r_z = new System.Windows.Forms.TextBox();
            this.r_r = new System.Windows.Forms.TextBox();
            this.r = new System.Windows.Forms.TextBox();
            this.toolParameterNextButton = new System.Windows.Forms.Button();
            this.toolParameterBackButton = new System.Windows.Forms.Button();
            this.d = new System.Windows.Forms.TextBox();
            this.helixAngle = new System.Windows.Forms.TextBox();
            this.rakeAngle = new System.Windows.Forms.TextBox();
            this.noOfFlutes = new System.Windows.Forms.TextBox();
            this.h = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.displayToolProfile = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.constHelix = new System.Windows.Forms.RadioButton();
            this.constLead = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // beta
            // 
            this.beta.Location = new System.Drawing.Point(568, 220);
            this.beta.Name = "beta";
            this.beta.Size = new System.Drawing.Size(167, 20);
            this.beta.TabIndex = 7;
            // 
            // alpha
            // 
            this.alpha.Location = new System.Drawing.Point(568, 190);
            this.alpha.Name = "alpha";
            this.alpha.Size = new System.Drawing.Size(167, 20);
            this.alpha.TabIndex = 6;
            // 
            // r_z
            // 
            this.r_z.Location = new System.Drawing.Point(568, 160);
            this.r_z.Name = "r_z";
            this.r_z.Size = new System.Drawing.Size(167, 20);
            this.r_z.TabIndex = 5;
            // 
            // r_r
            // 
            this.r_r.Location = new System.Drawing.Point(568, 130);
            this.r_r.Name = "r_r";
            this.r_r.Size = new System.Drawing.Size(167, 20);
            this.r_r.TabIndex = 4;
            // 
            // r
            // 
            this.r.Location = new System.Drawing.Point(568, 100);
            this.r.Name = "r";
            this.r.Size = new System.Drawing.Size(167, 20);
            this.r.TabIndex = 3;
            this.r.TextChanged += new System.EventHandler(this.r_TextChanged);
            // 
            // toolParameterNextButton
            // 
            this.toolParameterNextButton.Location = new System.Drawing.Point(609, 401);
            this.toolParameterNextButton.Name = "toolParameterNextButton";
            this.toolParameterNextButton.Size = new System.Drawing.Size(126, 26);
            this.toolParameterNextButton.TabIndex = 1;
            this.toolParameterNextButton.Text = "Next";
            this.toolParameterNextButton.UseVisualStyleBackColor = true;
            this.toolParameterNextButton.Click += new System.EventHandler(this.toolParameterNextButton_Click);
            // 
            // toolParameterBackButton
            // 
            this.toolParameterBackButton.Location = new System.Drawing.Point(48, 401);
            this.toolParameterBackButton.Name = "toolParameterBackButton";
            this.toolParameterBackButton.Size = new System.Drawing.Size(126, 26);
            this.toolParameterBackButton.TabIndex = 12;
            this.toolParameterBackButton.Text = "Back";
            this.toolParameterBackButton.UseVisualStyleBackColor = true;
            this.toolParameterBackButton.Click += new System.EventHandler(this.toolParameterBackButton_Click);
            // 
            // d
            // 
            this.d.Location = new System.Drawing.Point(568, 70);
            this.d.Name = "d";
            this.d.Size = new System.Drawing.Size(167, 20);
            this.d.TabIndex = 2;
            this.d.TextChanged += new System.EventHandler(this.d_TextChanged);
            // 
            // helixAngle
            // 
            this.helixAngle.Location = new System.Drawing.Point(568, 340);
            this.helixAngle.Name = "helixAngle";
            this.helixAngle.Size = new System.Drawing.Size(167, 20);
            this.helixAngle.TabIndex = 11;
            // 
            // rakeAngle
            // 
            this.rakeAngle.Location = new System.Drawing.Point(568, 310);
            this.rakeAngle.Name = "rakeAngle";
            this.rakeAngle.Size = new System.Drawing.Size(167, 20);
            this.rakeAngle.TabIndex = 10;
            // 
            // noOfFlutes
            // 
            this.noOfFlutes.Location = new System.Drawing.Point(568, 280);
            this.noOfFlutes.Name = "noOfFlutes";
            this.noOfFlutes.Size = new System.Drawing.Size(167, 20);
            this.noOfFlutes.TabIndex = 9;
            // 
            // h
            // 
            this.h.Location = new System.Drawing.Point(568, 250);
            this.h.Name = "h";
            this.h.Size = new System.Drawing.Size(167, 20);
            this.h.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.constLead);
            this.panel1.Controls.Add(this.constHelix);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.displayToolProfile);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.toolParameterBackButton);
            this.panel1.Controls.Add(this.helixAngle);
            this.panel1.Controls.Add(this.toolParameterNextButton);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.rakeAngle);
            this.panel1.Controls.Add(this.noOfFlutes);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.h);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.d);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.beta);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.alpha);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.r_z);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.r_r);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.r);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(787, 468);
            this.panel1.TabIndex = 40;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Helvetica LT Std Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label12.Location = new System.Drawing.Point(476, 372);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(260, 15);
            this.label12.TabIndex = 53;
            this.label12.Text = "NOTE: Distances in mm and angles in degress";
            // 
            // displayToolProfile
            // 
            this.displayToolProfile.Location = new System.Drawing.Point(329, 401);
            this.displayToolProfile.Name = "displayToolProfile";
            this.displayToolProfile.Size = new System.Drawing.Size(126, 26);
            this.displayToolProfile.TabIndex = 52;
            this.displayToolProfile.Text = "Display tool profile";
            this.displayToolProfile.UseVisualStyleBackColor = true;
            this.displayToolProfile.Click += new System.EventHandler(this.displayToolProfile_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Helvetica LT Std Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label11.Location = new System.Drawing.Point(278, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(250, 29);
            this.label11.TabIndex = 51;
            this.label11.Text = "Insert Tool Parameters";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(48, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(343, 290);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label10.Location = new System.Drawing.Point(480, 342);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 15);
            this.label10.TabIndex = 49;
            this.label10.Text = "Helix Angle";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label9.Location = new System.Drawing.Point(480, 312);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 15);
            this.label9.TabIndex = 48;
            this.label9.Text = "Rake Angle";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label8.Location = new System.Drawing.Point(478, 282);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 15);
            this.label8.TabIndex = 47;
            this.label8.Text = "No of Flutes";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Location = new System.Drawing.Point(536, 252);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 15);
            this.label7.TabIndex = 46;
            this.label7.Text = "h";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(536, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 15);
            this.label6.TabIndex = 45;
            this.label6.Text = "β";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(536, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 15);
            this.label5.TabIndex = 44;
            this.label5.Text = "α";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(529, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 15);
            this.label4.TabIndex = 43;
            this.label4.Text = "Rz";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(529, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 15);
            this.label3.TabIndex = 42;
            this.label3.Text = "Rr";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(535, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 15);
            this.label2.TabIndex = 41;
            this.label2.Text = "R";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(534, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 15);
            this.label1.TabIndex = 40;
            this.label1.Text = "D";
            // 
            // constHelix
            // 
            this.constHelix.AutoSize = true;
            this.constHelix.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.constHelix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.constHelix.Location = new System.Drawing.Point(48, 370);
            this.constHelix.Name = "constHelix";
            this.constHelix.Size = new System.Drawing.Size(105, 19);
            this.constHelix.TabIndex = 55;
            this.constHelix.TabStop = true;
            this.constHelix.Text = "Constant Helix";
            this.constHelix.UseVisualStyleBackColor = true;
            // 
            // constLead
            // 
            this.constLead.AutoSize = true;
            this.constLead.Font = new System.Drawing.Font("Helvetica LT Std Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.constLead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.constLead.Location = new System.Drawing.Point(283, 370);
            this.constLead.Name = "constLead";
            this.constLead.Size = new System.Drawing.Size(105, 19);
            this.constLead.TabIndex = 56;
            this.constLead.TabStop = true;
            this.constLead.Text = "Constant Lead";
            this.constLead.UseVisualStyleBackColor = true;
            // 
            // ToolParametersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ToolParametersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FAMSim 1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ToolParametersForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox beta;
        private System.Windows.Forms.TextBox alpha;
        private System.Windows.Forms.TextBox r_z;
        private System.Windows.Forms.TextBox r_r;
        private System.Windows.Forms.TextBox r;
        private System.Windows.Forms.Button toolParameterNextButton;
        private System.Windows.Forms.Button toolParameterBackButton;
        private System.Windows.Forms.TextBox d;
        private System.Windows.Forms.TextBox helixAngle;
        private System.Windows.Forms.TextBox rakeAngle;
        private System.Windows.Forms.TextBox noOfFlutes;
        private System.Windows.Forms.TextBox h;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button displayToolProfile;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton constLead;
        private System.Windows.Forms.RadioButton constHelix;
    }
}