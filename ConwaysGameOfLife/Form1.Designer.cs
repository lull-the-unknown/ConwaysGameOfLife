namespace ConwaysGameOfLife
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.grpGameUnit = new System.Windows.Forms.GroupBox();
            this.chkWrapEdges = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.optColorMode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnEditBoard = new System.Windows.Forms.Button();
            this.picOut = new System.Windows.Forms.PictureBox();
            this.trkZoom = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblZoom = new System.Windows.Forms.Label();
            this.timerGameTick = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.trkSpeed = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpGameUnit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkZoom)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkSpeed)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 0;
            // 
            // grpGameUnit
            // 
            this.grpGameUnit.Controls.Add(this.chkWrapEdges);
            this.grpGameUnit.Controls.Add(this.label5);
            this.grpGameUnit.Controls.Add(this.optColorMode);
            this.grpGameUnit.Controls.Add(this.label4);
            this.grpGameUnit.Controls.Add(this.label10);
            this.grpGameUnit.Controls.Add(this.txtHeight);
            this.grpGameUnit.Controls.Add(this.txtWidth);
            this.grpGameUnit.Controls.Add(this.label3);
            this.grpGameUnit.Controls.Add(this.label2);
            this.grpGameUnit.Location = new System.Drawing.Point(15, 15);
            this.grpGameUnit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpGameUnit.Name = "grpGameUnit";
            this.grpGameUnit.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpGameUnit.Size = new System.Drawing.Size(237, 289);
            this.grpGameUnit.TabIndex = 1;
            this.grpGameUnit.TabStop = false;
            this.grpGameUnit.Text = "Game Unit";
            // 
            // chkWrapEdges
            // 
            this.chkWrapEdges.AutoSize = true;
            this.chkWrapEdges.Checked = true;
            this.chkWrapEdges.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWrapEdges.Enabled = false;
            this.chkWrapEdges.Location = new System.Drawing.Point(69, 147);
            this.chkWrapEdges.Name = "chkWrapEdges";
            this.chkWrapEdges.Size = new System.Drawing.Size(123, 24);
            this.chkWrapEdges.TabIndex = 9;
            this.chkWrapEdges.Text = "Wrap Edges";
            this.chkWrapEdges.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(187, 73);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 10, 3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "cells";
            // 
            // optColorMode
            // 
            this.optColorMode.FormattingEnabled = true;
            this.optColorMode.Items.AddRange(new object[] {
            "On/Off"});
            this.optColorMode.Location = new System.Drawing.Point(69, 106);
            this.optColorMode.Name = "optColorMode";
            this.optColorMode.Size = new System.Drawing.Size(162, 28);
            this.optColorMode.TabIndex = 8;
            this.optColorMode.Text = "On/Off";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 10, 3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "cells";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 94);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 40);
            this.label10.TabIndex = 7;
            this.label10.Text = "Color\r\n  Mode:";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(69, 70);
            this.txtHeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(118, 26);
            this.txtHeight.TabIndex = 4;
            this.txtHeight.Text = "1,000";
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHeight.Leave += new System.EventHandler(this.CheckTextBoxes);
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(69, 30);
            this.txtWidth.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(118, 26);
            this.txtWidth.TabIndex = 3;
            this.txtWidth.Text = "1,000";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtWidth.Leave += new System.EventHandler(this.CheckTextBoxes);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Height:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 0, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Width:";
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(15, 311);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 38);
            this.btnPlay.TabIndex = 9;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(96, 311);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 38);
            this.btnStop.TabIndex = 10;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.Location = new System.Drawing.Point(177, 311);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 38);
            this.btnQuit.TabIndex = 11;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnEditBoard
            // 
            this.btnEditBoard.Enabled = false;
            this.btnEditBoard.Location = new System.Drawing.Point(15, 355);
            this.btnEditBoard.Name = "btnEditBoard";
            this.btnEditBoard.Size = new System.Drawing.Size(237, 38);
            this.btnEditBoard.TabIndex = 12;
            this.btnEditBoard.Text = "Edit Game Board";
            this.btnEditBoard.UseVisualStyleBackColor = true;
            // 
            // picOut
            // 
            this.picOut.BackColor = System.Drawing.Color.White;
            this.picOut.Location = new System.Drawing.Point(0, 0);
            this.picOut.Margin = new System.Windows.Forms.Padding(0);
            this.picOut.Name = "picOut";
            this.picOut.Size = new System.Drawing.Size(100, 100);
            this.picOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picOut.TabIndex = 13;
            this.picOut.TabStop = false;
            // 
            // trkZoom
            // 
            this.trkZoom.AutoSize = false;
            this.trkZoom.LargeChange = 1;
            this.trkZoom.Location = new System.Drawing.Point(2, 25);
            this.trkZoom.Minimum = 1;
            this.trkZoom.Name = "trkZoom";
            this.trkZoom.Size = new System.Drawing.Size(189, 34);
            this.trkZoom.TabIndex = 14;
            this.trkZoom.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trkZoom.Value = 1;
            this.trkZoom.Scroll += new System.EventHandler(this.trkZoom_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblZoom);
            this.groupBox1.Controls.Add(this.trkZoom);
            this.groupBox1.Location = new System.Drawing.Point(15, 399);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 68);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zoom";
            // 
            // lblZoom
            // 
            this.lblZoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblZoom.Location = new System.Drawing.Point(188, 25);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(43, 34);
            this.lblZoom.TabIndex = 15;
            this.lblZoom.Text = "x10";
            this.lblZoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerGameTick
            // 
            this.timerGameTick.Interval = 200;
            this.timerGameTick.Tick += new System.EventHandler(this.timerGameTick_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSpeed);
            this.groupBox2.Controls.Add(this.trkSpeed);
            this.groupBox2.Location = new System.Drawing.Point(15, 473);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 68);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Speed";
            // 
            // lblSpeed
            // 
            this.lblSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSpeed.Location = new System.Drawing.Point(188, 25);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(43, 34);
            this.lblSpeed.TabIndex = 15;
            this.lblSpeed.Text = "x99";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trkSpeed
            // 
            this.trkSpeed.AutoSize = false;
            this.trkSpeed.LargeChange = 1;
            this.trkSpeed.Location = new System.Drawing.Point(2, 25);
            this.trkSpeed.Maximum = 15;
            this.trkSpeed.Name = "trkSpeed";
            this.trkSpeed.Size = new System.Drawing.Size(189, 34);
            this.trkSpeed.TabIndex = 14;
            this.trkSpeed.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trkSpeed.Value = 15;
            this.trkSpeed.Scroll += new System.EventHandler(this.trkSpeed_Scroll);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.picOut);
            this.panel1.Location = new System.Drawing.Point(258, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 514);
            this.panel1.TabIndex = 19;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnPlay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(780, 553);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEditBoard);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.grpGameUnit);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ClientSizeChanged += new System.EventHandler(this.Form1_ClientSizeChanged);
            this.grpGameUnit.ResumeLayout(false);
            this.grpGameUnit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkZoom)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trkSpeed)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpGameUnit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.ComboBox optColorMode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnEditBoard;
        private System.Windows.Forms.PictureBox picOut;
        private System.Windows.Forms.TrackBar trkZoom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.Timer timerGameTick;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.TrackBar trkSpeed;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkWrapEdges;
    }
}

