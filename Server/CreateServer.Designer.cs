namespace Server
{
    partial class CreateServer
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
            this.txbIPServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbPortServer = new System.Windows.Forms.TextBox();
            this.btnAutoMakeIP = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbIPServer
            // 
            this.txbIPServer.Location = new System.Drawing.Point(102, 28);
            this.txbIPServer.Name = "txbIPServer";
            this.txbIPServer.Size = new System.Drawing.Size(155, 20);
            this.txbIPServer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port Server";
            // 
            // txbPortServer
            // 
            this.txbPortServer.Location = new System.Drawing.Point(102, 66);
            this.txbPortServer.Name = "txbPortServer";
            this.txbPortServer.Size = new System.Drawing.Size(155, 20);
            this.txbPortServer.TabIndex = 2;
            this.txbPortServer.Text = "7777";
            // 
            // btnAutoMakeIP
            // 
            this.btnAutoMakeIP.Location = new System.Drawing.Point(280, 26);
            this.btnAutoMakeIP.Name = "btnAutoMakeIP";
            this.btnAutoMakeIP.Size = new System.Drawing.Size(75, 23);
            this.btnAutoMakeIP.TabIndex = 4;
            this.btnAutoMakeIP.Text = "Tự tạo IP";
            this.btnAutoMakeIP.UseVisualStyleBackColor = true;
            this.btnAutoMakeIP.Click += new System.EventHandler(this.btnAutoMakeIP_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(100, 101);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Tạo";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(182, 101);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Hủy";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // CreateServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 143);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnAutoMakeIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbPortServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbIPServer);
            this.Name = "CreateServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo Server Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbIPServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbPortServer;
        private System.Windows.Forms.Button btnAutoMakeIP;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnExit;
    }
}