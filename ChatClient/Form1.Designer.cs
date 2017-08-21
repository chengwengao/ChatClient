﻿namespace ChatClient
{
    partial class FClient
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
            this.txtCMsg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnBeginListen = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCMsg
            // 
            this.txtCMsg.Location = new System.Drawing.Point(83, 302);
            this.txtCMsg.Multiline = true;
            this.txtCMsg.Name = "txtCMsg";
            this.txtCMsg.Size = new System.Drawing.Size(435, 79);
            this.txtCMsg.TabIndex = 27;
            this.txtCMsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCMsg_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "IP：";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(83, 387);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 24;
            this.btnSend.Text = "发送消息";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(83, 79);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsg.Size = new System.Drawing.Size(435, 156);
            this.txtMsg.TabIndex = 23;
            // 
            // btnBeginListen
            // 
            this.btnBeginListen.Location = new System.Drawing.Point(428, 30);
            this.btnBeginListen.Name = "btnBeginListen";
            this.btnBeginListen.Size = new System.Drawing.Size(90, 23);
            this.btnBeginListen.TabIndex = 22;
            this.btnBeginListen.Text = "连接到服务端";
            this.btnBeginListen.UseVisualStyleBackColor = true;
            this.btnBeginListen.Click += new System.EventHandler(this.btnBeginListen_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(301, 30);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(103, 21);
            this.txtPort.TabIndex = 21;
            this.txtPort.Text = "8088";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "PORT：";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(83, 30);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(123, 21);
            this.txtIP.TabIndex = 19;
            this.txtIP.Text = "192.168.1.47";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "聊天内容:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 29;
            this.label4.Text = "天之涯:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(83, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "清空聊天记录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(211, 387);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 31;
            this.button2.Text = "清空消息";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 498);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCMsg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.btnBeginListen);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIP);
            this.Name = "FClient";
            this.Text = "客户端";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCMsg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnBeginListen;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
