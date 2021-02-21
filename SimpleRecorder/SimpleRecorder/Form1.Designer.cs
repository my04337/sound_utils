
namespace SimpleRecorder
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.startRecordingButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.inputDeviceListSelector = new System.Windows.Forms.ComboBox();
            this.inputDeviceReloadButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inputChannelSelector = new System.Windows.Forms.ComboBox();
            this.stopRecordingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startRecordingButton
            // 
            this.startRecordingButton.Location = new System.Drawing.Point(12, 90);
            this.startRecordingButton.Name = "startRecordingButton";
            this.startRecordingButton.Size = new System.Drawing.Size(137, 70);
            this.startRecordingButton.TabIndex = 0;
            this.startRecordingButton.Text = "録音";
            this.startRecordingButton.UseVisualStyleBackColor = true;
            this.startRecordingButton.Click += new System.EventHandler(this.startRecordingButton_Click);
            // 
            // inputDeviceListSelector
            // 
            this.inputDeviceListSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputDeviceListSelector.FormattingEnabled = true;
            this.inputDeviceListSelector.Location = new System.Drawing.Point(12, 21);
            this.inputDeviceListSelector.Name = "inputDeviceListSelector";
            this.inputDeviceListSelector.Size = new System.Drawing.Size(170, 20);
            this.inputDeviceListSelector.TabIndex = 1;
            this.inputDeviceListSelector.SelectedIndexChanged += new System.EventHandler(this.inputDeviceListSelector_SelectedIndexChanged);
            // 
            // inputDeviceReloadButton
            // 
            this.inputDeviceReloadButton.Location = new System.Drawing.Point(415, 15);
            this.inputDeviceReloadButton.Name = "inputDeviceReloadButton";
            this.inputDeviceReloadButton.Size = new System.Drawing.Size(49, 31);
            this.inputDeviceReloadButton.TabIndex = 2;
            this.inputDeviceReloadButton.Text = "再読込";
            this.inputDeviceReloadButton.UseVisualStyleBackColor = true;
            this.inputDeviceReloadButton.Click += new System.EventHandler(this.inputDeviceReloadButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "入力デバイス";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "入力チャネル";
            // 
            // inputChannelSelector
            // 
            this.inputChannelSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputChannelSelector.FormattingEnabled = true;
            this.inputChannelSelector.Location = new System.Drawing.Point(219, 21);
            this.inputChannelSelector.Name = "inputChannelSelector";
            this.inputChannelSelector.Size = new System.Drawing.Size(170, 20);
            this.inputChannelSelector.TabIndex = 5;
            this.inputChannelSelector.SelectedIndexChanged += new System.EventHandler(this.inputChannelSelector_SelectedIndexChanged);
            // 
            // stopRecordingButton
            // 
            this.stopRecordingButton.Location = new System.Drawing.Point(155, 90);
            this.stopRecordingButton.Name = "stopRecordingButton";
            this.stopRecordingButton.Size = new System.Drawing.Size(137, 70);
            this.stopRecordingButton.TabIndex = 6;
            this.stopRecordingButton.Text = "停止";
            this.stopRecordingButton.UseVisualStyleBackColor = true;
            this.stopRecordingButton.Click += new System.EventHandler(this.stopRecordingButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stopRecordingButton);
            this.Controls.Add(this.inputChannelSelector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputDeviceReloadButton);
            this.Controls.Add(this.inputDeviceListSelector);
            this.Controls.Add(this.startRecordingButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startRecordingButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox inputDeviceListSelector;
        private System.Windows.Forms.Button inputDeviceReloadButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox inputChannelSelector;
        private System.Windows.Forms.Button stopRecordingButton;
    }
}

