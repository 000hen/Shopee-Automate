namespace Shopee_Automate.Forms
{
    partial class DiscordWebhookSetup
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
            this.webhookInput = new System.Windows.Forms.TextBox();
            this.sendTestMessage = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Discord Webhook 連結:";
            // 
            // webhookInput
            // 
            this.webhookInput.Location = new System.Drawing.Point(250, 29);
            this.webhookInput.Name = "webhookInput";
            this.webhookInput.Size = new System.Drawing.Size(363, 23);
            this.webhookInput.TabIndex = 1;
            this.webhookInput.TextChanged += new System.EventHandler(this.webhookInput_TextChanged);
            // 
            // sendTestMessage
            // 
            this.sendTestMessage.Location = new System.Drawing.Point(12, 64);
            this.sendTestMessage.Name = "sendTestMessage";
            this.sendTestMessage.Size = new System.Drawing.Size(138, 41);
            this.sendTestMessage.TabIndex = 2;
            this.sendTestMessage.Text = "發送測試用訊息";
            this.sendTestMessage.UseVisualStyleBackColor = true;
            this.sendTestMessage.Click += new System.EventHandler(this.sendTestMessage_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(540, 93);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(73, 22);
            this.cancel.TabIndex = 7;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // submit
            // 
            this.submit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.submit.Location = new System.Drawing.Point(461, 93);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(73, 22);
            this.submit.TabIndex = 6;
            this.submit.Text = "確認";
            this.submit.UseVisualStyleBackColor = true;
            // 
            // DiscordWebhookSetup
            // 
            this.AcceptButton = this.submit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(628, 127);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.sendTestMessage);
            this.Controls.Add(this.webhookInput);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiscordWebhookSetup";
            this.Text = "DiscordWebhookSetup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox webhookInput;
        private System.Windows.Forms.Button sendTestMessage;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button submit;
    }
}