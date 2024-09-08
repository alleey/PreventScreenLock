namespace PreventScreenLock.App
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ToolStripSeparator toolStripSeparator1;
            ToolStripMenuItem screenLockToolStripMenuItem;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            disableToolStrip = new ToolStripMenuItem();
            btnPreventLock = new Button();
            contextMenuStrip = new ContextMenuStrip(components);
            showToolStrip = new ToolStripMenuItem();
            exitToolStrip = new ToolStripMenuItem();
            label1 = new Label();
            linkSettings = new LinkLabel();
            toolStripSeparator1 = new ToolStripSeparator();
            screenLockToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(134, 6);
            // 
            // screenLockToolStripMenuItem
            // 
            screenLockToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { disableToolStrip });
            screenLockToolStripMenuItem.Name = "screenLockToolStripMenuItem";
            screenLockToolStripMenuItem.Size = new Size(137, 22);
            screenLockToolStripMenuItem.Text = "Screen &Lock";
            // 
            // disableToolStrip
            // 
            disableToolStrip.Name = "disableToolStrip";
            disableToolStrip.Size = new Size(112, 22);
            disableToolStrip.Text = "Disable";
            disableToolStrip.Click += disableToolStrip_Click;
            // 
            // btnPreventLock
            // 
            btnPreventLock.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnPreventLock.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPreventLock.Location = new Point(12, 73);
            btnPreventLock.Margin = new Padding(3, 2, 3, 2);
            btnPreventLock.Name = "btnPreventLock";
            btnPreventLock.Size = new Size(367, 116);
            btnPreventLock.TabIndex = 0;
            btnPreventLock.Text = "Disable Screen Lock";
            btnPreventLock.UseVisualStyleBackColor = true;
            btnPreventLock.Click += btnPreventLock_Click;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { screenLockToolStripMenuItem, toolStripSeparator1, showToolStrip, exitToolStrip });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(138, 76);
            // 
            // showToolStrip
            // 
            showToolStrip.Name = "showToolStrip";
            showToolStrip.Size = new Size(137, 22);
            showToolStrip.Text = "&Show";
            showToolStrip.Click += showToolStrip_Click;
            // 
            // exitToolStrip
            // 
            exitToolStrip.Name = "exitToolStrip";
            exitToolStrip.Size = new Size(137, 22);
            exitToolStrip.Text = "E&xit";
            exitToolStrip.Click += exitToolStrip_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Location = new Point(11, 7);
            label1.Name = "label1";
            label1.Size = new Size(368, 34);
            label1.TabIndex = 1;
            label1.Text = "Prevents screen locks, even under domain-enforced policies. Keep your screen active during critical tasks without interruptions.";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // linkSettings
            // 
            linkSettings.AutoSize = true;
            linkSettings.Location = new Point(273, 45);
            linkSettings.Name = "linkSettings";
            linkSettings.Size = new Size(101, 15);
            linkSettings.TabIndex = 2;
            linkSettings.TabStop = true;
            linkSettings.Text = "Launch options ...";
            linkSettings.LinkClicked += linkSettings_LinkClicked;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 198);
            Controls.Add(linkSettings);
            Controls.Add(label1);
            Controls.Add(btnPreventLock);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "MainForm";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PreventScreenLock";
            Resize += MainForm_Resize;
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPreventLock;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem showToolStrip;
        private ToolStripMenuItem exitToolStrip;
        private ToolStripMenuItem disableToolStrip;
        private Label label1;
        private LinkLabel linkSettings;
    }
}
