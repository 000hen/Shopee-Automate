namespace Shopee_Automate.Forms
{
    partial class Panel
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
            this.setLoginInformation = new System.Windows.Forms.Button();
            this.setAuto = new System.Windows.Forms.Button();
            this.unsetAuto = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.generateBAT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.removeCookies = new System.Windows.Forms.Button();
            this.setDiscordWebhook = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // setLoginInformation
            // 
            this.setLoginInformation.Location = new System.Drawing.Point(12, 72);
            this.setLoginInformation.Name = "setLoginInformation";
            this.setLoginInformation.Size = new System.Drawing.Size(158, 51);
            this.setLoginInformation.TabIndex = 0;
            this.setLoginInformation.Text = "設定帳號密碼";
            this.setLoginInformation.UseVisualStyleBackColor = true;
            this.setLoginInformation.Click += new System.EventHandler(this.setLoginInformation_Click);
            // 
            // setAuto
            // 
            this.setAuto.Location = new System.Drawing.Point(12, 129);
            this.setAuto.Name = "setAuto";
            this.setAuto.Size = new System.Drawing.Size(158, 51);
            this.setAuto.TabIndex = 1;
            this.setAuto.Text = "設定自動登入";
            this.setAuto.UseVisualStyleBackColor = true;
            this.setAuto.Click += new System.EventHandler(this.setAuto_Click);
            // 
            // unsetAuto
            // 
            this.unsetAuto.Location = new System.Drawing.Point(176, 129);
            this.unsetAuto.Name = "unsetAuto";
            this.unsetAuto.Size = new System.Drawing.Size(158, 51);
            this.unsetAuto.TabIndex = 2;
            this.unsetAuto.Text = "解除自動化領取";
            this.unsetAuto.UseVisualStyleBackColor = true;
            this.unsetAuto.Click += new System.EventHandler(this.unsetAuto_Click);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(197, 278);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(158, 51);
            this.start.TabIndex = 3;
            this.start.Text = "開始執行";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // generateBAT
            // 
            this.generateBAT.Location = new System.Drawing.Point(361, 278);
            this.generateBAT.Name = "generateBAT";
            this.generateBAT.Size = new System.Drawing.Size(158, 51);
            this.generateBAT.TabIndex = 4;
            this.generateBAT.Text = "生成執行 BAT 檔案";
            this.generateBAT.UseVisualStyleBackColor = true;
            this.generateBAT.Click += new System.EventHandler(this.generateBAT_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(192, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 43);
            this.label1.TabIndex = 5;
            this.label1.Text = "自動化蝦幣領取設定";
            // 
            // richTextBox1
            // 
            this.richTextBox1.AutoWordSelection = true;
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(360, 72);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(336, 168);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "您好使用者!\n\n這是一個能夠讓你自動化領取蝦幣的工具。您需要先點選「設定帳號密碼」來設定這個工具的登入帳號密碼，登入成功後您可以點選「設定自動化領取」讓這個工具可" +
    "以在每天執行。\n\n我是開發者Muisnow，這是我第一次自主撰寫C#應用程式，部分代碼魔改自 https://github.com/wdzeng/shopee-" +
    "coins-bot 的JavaScript代碼。如有錯誤，敬請解諒。";
            // 
            // removeCookies
            // 
            this.removeCookies.Location = new System.Drawing.Point(176, 72);
            this.removeCookies.Name = "removeCookies";
            this.removeCookies.Size = new System.Drawing.Size(158, 51);
            this.removeCookies.TabIndex = 8;
            this.removeCookies.Text = "刪除登入Cookies";
            this.removeCookies.UseVisualStyleBackColor = true;
            this.removeCookies.Click += new System.EventHandler(this.removeCookies_Click);
            // 
            // setDiscordWebhook
            // 
            this.setDiscordWebhook.Location = new System.Drawing.Point(12, 186);
            this.setDiscordWebhook.Name = "setDiscordWebhook";
            this.setDiscordWebhook.Size = new System.Drawing.Size(158, 51);
            this.setDiscordWebhook.TabIndex = 9;
            this.setDiscordWebhook.Text = "設定Discord頻道通知";
            this.setDiscordWebhook.UseVisualStyleBackColor = true;
            this.setDiscordWebhook.Click += new System.EventHandler(this.setDiscordWebhook_Click);
            // 
            // Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 341);
            this.Controls.Add(this.setDiscordWebhook);
            this.Controls.Add(this.removeCookies);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.generateBAT);
            this.Controls.Add(this.start);
            this.Controls.Add(this.unsetAuto);
            this.Controls.Add(this.setAuto);
            this.Controls.Add(this.setLoginInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MdiChildrenMinimizedAnchorBottom = false;
            this.MinimizeBox = false;
            this.Name = "Panel";
            this.Text = "自動領取蝦皮設定";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button setLoginInformation;
        private System.Windows.Forms.Button setAuto;
        private System.Windows.Forms.Button unsetAuto;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button generateBAT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button removeCookies;
        private System.Windows.Forms.Button setDiscordWebhook;
    }
}