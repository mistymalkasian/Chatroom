namespace TCP_UI_Client
{
    partial class Client1 
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label_IP = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.textIP = new System.Windows.Forms.TextBox();
            this.textPort = new System.Windows.Forms.TextBox();
            this.textMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnStart.Location = new System.Drawing.Point(608, 70);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(97, 28);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnStop.Location = new System.Drawing.Point(720, 70);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(97, 28);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Location = new System.Drawing.Point(109, 76);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(24, 17);
            this.label_IP.TabIndex = 2;
            this.label_IP.Text = "IP:";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(347, 76);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(38, 17);
            this.labelPort.TabIndex = 3;
            this.labelPort.Text = "Port:";
            // 
            // textIP
            // 
            this.textIP.Location = new System.Drawing.Point(139, 74);
            this.textIP.Name = "textIP";
            this.textIP.Size = new System.Drawing.Size(153, 22);
            this.textIP.TabIndex = 4;
            this.textIP.Text = "192.168.0.119";
            this.textIP.TextChanged += new System.EventHandler(this.textIP_TextChanged);
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(391, 73);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(145, 22);
            this.textPort.TabIndex = 5;
            this.textPort.Text = "14234";
            this.textPort.TextChanged += new System.EventHandler(this.textPort_TextChanged);
            // 
            // textMessage
            // 
            this.textMessage.Location = new System.Drawing.Point(112, 130);
            this.textMessage.Multiline = true;
            this.textMessage.Name = "textMessage";
            this.textMessage.Size = new System.Drawing.Size(704, 476);
            this.textMessage.TabIndex = 6;
            this.textMessage.TextChanged += new System.EventHandler(this.textMessage_TextChanged);
            // 
            // Client1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(860, 646);
            this.Controls.Add(this.textMessage);
            this.Controls.Add(this.textPort);
            this.Controls.Add(this.textIP);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.label_IP);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "Client1";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.TextBox textMessage;
    }
}

