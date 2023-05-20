using System;

namespace Shopee_Automate.Forms
{
    partial class ScheduleTimeSet
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
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timePicker
            // 
            this.timePicker.CustomFormat = "tt hh:mm:ss";
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePicker.Location = new System.Drawing.Point(164, 24);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(115, 23);
            this.timePicker.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "設定執行時間";
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(372, 66);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(73, 22);
            this.cancel.TabIndex = 7;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // submit
            // 
            this.submit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.submit.Location = new System.Drawing.Point(293, 66);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(73, 22);
            this.submit.TabIndex = 6;
            this.submit.Text = "確認";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // ScheduleTimeSet
            // 
            this.AcceptButton = this.submit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(457, 100);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ScheduleTimeSet";
            this.Text = "ScheduleTimeSet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker timePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button submit;
    }
}