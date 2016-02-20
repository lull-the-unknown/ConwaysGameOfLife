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
            this.label1 = new System.Windows.Forms.Label();
            this.grpGameUnit = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWidth_GameUnit = new System.Windows.Forms.TextBox();
            this.txtHeight_GameUnit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grpGameBoard = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHeight_GameBoard = new System.Windows.Forms.TextBox();
            this.txtWidth_GameBoard = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.optColorMode = new System.Windows.Forms.ComboBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnEditField = new System.Windows.Forms.Button();
            this.picOut = new System.Windows.Forms.PictureBox();
            this.trkZoom = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblZoom = new System.Windows.Forms.Label();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.grpGameUnit.SuspendLayout();
            this.grpGameBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkZoom)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.grpGameUnit.Controls.Add(this.label5);
            this.grpGameUnit.Controls.Add(this.label4);
            this.grpGameUnit.Controls.Add(this.txtHeight_GameUnit);
            this.grpGameUnit.Controls.Add(this.txtWidth_GameUnit);
            this.grpGameUnit.Controls.Add(this.label3);
            this.grpGameUnit.Controls.Add(this.label2);
            this.grpGameUnit.Location = new System.Drawing.Point(15, 15);
            this.grpGameUnit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpGameUnit.Name = "grpGameUnit";
            this.grpGameUnit.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpGameUnit.Size = new System.Drawing.Size(237, 111);
            this.grpGameUnit.TabIndex = 1;
            this.grpGameUnit.TabStop = false;
            this.grpGameUnit.Text = "Game Unit";
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
            // txtWidth_GameUnit
            // 
            this.txtWidth_GameUnit.Location = new System.Drawing.Point(69, 30);
            this.txtWidth_GameUnit.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.txtWidth_GameUnit.Name = "txtWidth_GameUnit";
            this.txtWidth_GameUnit.Size = new System.Drawing.Size(47, 26);
            this.txtWidth_GameUnit.TabIndex = 3;
            this.txtWidth_GameUnit.Text = "10";
            this.txtWidth_GameUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeight_GameUnit
            // 
            this.txtHeight_GameUnit.Location = new System.Drawing.Point(69, 70);
            this.txtHeight_GameUnit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHeight_GameUnit.Name = "txtHeight_GameUnit";
            this.txtHeight_GameUnit.Size = new System.Drawing.Size(47, 26);
            this.txtHeight_GameUnit.TabIndex = 4;
            this.txtHeight_GameUnit.Text = "10";
            this.txtHeight_GameUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(116, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 10, 3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "cells";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(116, 73);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 10, 3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "cells";
            // 
            // grpGameBoard
            // 
            this.grpGameBoard.Controls.Add(this.optColorMode);
            this.grpGameBoard.Controls.Add(this.label10);
            this.grpGameBoard.Controls.Add(this.label6);
            this.grpGameBoard.Controls.Add(this.label7);
            this.grpGameBoard.Controls.Add(this.txtHeight_GameBoard);
            this.grpGameBoard.Controls.Add(this.txtWidth_GameBoard);
            this.grpGameBoard.Controls.Add(this.label8);
            this.grpGameBoard.Controls.Add(this.label9);
            this.grpGameBoard.Location = new System.Drawing.Point(15, 134);
            this.grpGameBoard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpGameBoard.Name = "grpGameBoard";
            this.grpGameBoard.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpGameBoard.Size = new System.Drawing.Size(237, 156);
            this.grpGameBoard.TabIndex = 2;
            this.grpGameBoard.TabStop = false;
            this.grpGameBoard.Text = "Game Board";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(116, 73);
            this.label6.Margin = new System.Windows.Forms.Padding(0, 10, 3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "game boards";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(116, 33);
            this.label7.Margin = new System.Windows.Forms.Padding(0, 10, 3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "game boards";
            // 
            // txtHeight_GameBoard
            // 
            this.txtHeight_GameBoard.Location = new System.Drawing.Point(69, 70);
            this.txtHeight_GameBoard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHeight_GameBoard.Name = "txtHeight_GameBoard";
            this.txtHeight_GameBoard.Size = new System.Drawing.Size(47, 26);
            this.txtHeight_GameBoard.TabIndex = 4;
            this.txtHeight_GameBoard.Text = "1";
            this.txtHeight_GameBoard.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtWidth_GameBoard
            // 
            this.txtWidth_GameBoard.Location = new System.Drawing.Point(69, 30);
            this.txtWidth_GameBoard.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.txtWidth_GameBoard.Name = "txtWidth_GameBoard";
            this.txtWidth_GameBoard.Size = new System.Drawing.Size(47, 26);
            this.txtWidth_GameBoard.TabIndex = 3;
            this.txtWidth_GameBoard.Text = "1";
            this.txtWidth_GameBoard.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 73);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Height:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 33);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 10, 0, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Width:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 113);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 20);
            this.label10.TabIndex = 7;
            this.label10.Text = "Color:";
            // 
            // optColorMode
            // 
            this.optColorMode.FormattingEnabled = true;
            this.optColorMode.Items.AddRange(new object[] {
            "Black & White"});
            this.optColorMode.Location = new System.Drawing.Point(75, 110);
            this.optColorMode.Name = "optColorMode";
            this.optColorMode.Size = new System.Drawing.Size(156, 28);
            this.optColorMode.TabIndex = 8;
            this.optColorMode.Text = "Black & White";
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(15, 325);
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
            this.btnStop.Location = new System.Drawing.Point(96, 325);
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
            this.btnQuit.Location = new System.Drawing.Point(177, 325);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 38);
            this.btnQuit.TabIndex = 11;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnEditField
            // 
            this.btnEditField.Enabled = false;
            this.btnEditField.Location = new System.Drawing.Point(15, 369);
            this.btnEditField.Name = "btnEditField";
            this.btnEditField.Size = new System.Drawing.Size(237, 38);
            this.btnEditField.TabIndex = 12;
            this.btnEditField.Text = "Edit Game Board";
            this.btnEditField.UseVisualStyleBackColor = true;
            // 
            // picOut
            // 
            this.picOut.BackColor = System.Drawing.Color.White;
            this.picOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOut.Location = new System.Drawing.Point(258, 12);
            this.picOut.Margin = new System.Windows.Forms.Padding(0);
            this.picOut.Name = "picOut";
            this.picOut.Size = new System.Drawing.Size(500, 500);
            this.picOut.TabIndex = 13;
            this.picOut.TabStop = false;
            // 
            // trkZoom
            // 
            this.trkZoom.LargeChange = 3;
            this.trkZoom.Location = new System.Drawing.Point(2, 25);
            this.trkZoom.Minimum = 1;
            this.trkZoom.Name = "trkZoom";
            this.trkZoom.Size = new System.Drawing.Size(189, 56);
            this.trkZoom.TabIndex = 14;
            this.trkZoom.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trkZoom.Value = 10;
            this.trkZoom.Scroll += new System.EventHandler(this.trkZoom_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblZoom);
            this.groupBox1.Controls.Add(this.trkZoom);
            this.groupBox1.Location = new System.Drawing.Point(15, 437);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 93);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zoom";
            // 
            // lblZoom
            // 
            this.lblZoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblZoom.Location = new System.Drawing.Point(188, 25);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(43, 50);
            this.lblZoom.TabIndex = 15;
            this.lblZoom.Text = "x10";
            this.lblZoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Enabled = false;
            this.vScrollBar1.LargeChange = 5;
            this.vScrollBar1.Location = new System.Drawing.Point(758, 12);
            this.vScrollBar1.Maximum = 10;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 500);
            this.vScrollBar1.TabIndex = 16;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(258, 512);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(500, 18);
            this.hScrollBar1.TabIndex = 17;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnPlay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(782, 540);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picOut);
            this.Controls.Add(this.btnEditField);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.grpGameBoard);
            this.Controls.Add(this.grpGameUnit);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.grpGameUnit.ResumeLayout(false);
            this.grpGameUnit.PerformLayout();
            this.grpGameBoard.ResumeLayout(false);
            this.grpGameBoard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkZoom)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TextBox txtHeight_GameUnit;
        private System.Windows.Forms.TextBox txtWidth_GameUnit;
        private System.Windows.Forms.GroupBox grpGameBoard;
        private System.Windows.Forms.ComboBox optColorMode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHeight_GameBoard;
        private System.Windows.Forms.TextBox txtWidth_GameBoard;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnEditField;
        private System.Windows.Forms.PictureBox picOut;
        private System.Windows.Forms.TrackBar trkZoom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
    }
}

