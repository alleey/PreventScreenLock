namespace PreventScreenLock.App
{
    partial class SettingsForm
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
            btnOK = new Button();
            chkAutoLaunch = new CheckBox();
            chkMinimized = new CheckBox();
            chkAutoDisable = new CheckBox();
            SuspendLayout();
            // 
            // btnOK
            // 
            btnOK.Location = new Point(311, 152);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(94, 46);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // chkAutoLaunch
            // 
            chkAutoLaunch.AutoSize = true;
            chkAutoLaunch.Location = new Point(29, 42);
            chkAutoLaunch.Name = "chkAutoLaunch";
            chkAutoLaunch.Size = new Size(174, 24);
            chkAutoLaunch.TabIndex = 1;
            chkAutoLaunch.Text = "Launch with Windows";
            chkAutoLaunch.UseVisualStyleBackColor = true;
            // 
            // chkMinimized
            // 
            chkMinimized.AutoSize = true;
            chkMinimized.Location = new Point(29, 79);
            chkMinimized.Name = "chkMinimized";
            chkMinimized.Size = new Size(151, 24);
            chkMinimized.TabIndex = 2;
            chkMinimized.Text = "Launch Minimized";
            chkMinimized.UseVisualStyleBackColor = true;
            // 
            // chkAutoDisable
            // 
            chkAutoDisable.AutoSize = true;
            chkAutoDisable.Location = new Point(29, 116);
            chkAutoDisable.Name = "chkAutoDisable";
            chkAutoDisable.Size = new Size(234, 24);
            chkAutoDisable.TabIndex = 3;
            chkAutoDisable.Text = "Disable Screen Lock on Launch";
            chkAutoDisable.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 210);
            Controls.Add(chkAutoDisable);
            Controls.Add(chkMinimized);
            Controls.Add(chkAutoLaunch);
            Controls.Add(btnOK);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOK;
        private CheckBox chkAutoLaunch;
        private CheckBox chkMinimized;
        private CheckBox chkAutoDisable;
    }
}