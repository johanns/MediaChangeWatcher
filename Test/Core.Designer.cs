namespace Johanns
{
    partial class TestApplication
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
            this._btnRegister = new System.Windows.Forms.Button();
            this._btnDeregister = new System.Windows.Forms.Button();
            this._lbEvents = new System.Windows.Forms.ListBox();
            this._lbStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _btnRegister
            // 
            this._btnRegister.Location = new System.Drawing.Point(13, 13);
            this._btnRegister.Name = "_btnRegister";
            this._btnRegister.Size = new System.Drawing.Size(75, 23);
            this._btnRegister.TabIndex = 0;
            this._btnRegister.Text = "Register";
            this._btnRegister.UseVisualStyleBackColor = true;
            this._btnRegister.Click += new System.EventHandler(this.OnRegisterClick);
            // 
            // _btnDeregister
            // 
            this._btnDeregister.Location = new System.Drawing.Point(94, 13);
            this._btnDeregister.Name = "_btnDeregister";
            this._btnDeregister.Size = new System.Drawing.Size(75, 23);
            this._btnDeregister.TabIndex = 1;
            this._btnDeregister.Text = "Deregister";
            this._btnDeregister.UseVisualStyleBackColor = true;
            this._btnDeregister.Click += new System.EventHandler(this.OnDeregisterClick);
            // 
            // _lbEvents
            // 
            this._lbEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lbEvents.FormattingEnabled = true;
            this._lbEvents.Location = new System.Drawing.Point(13, 42);
            this._lbEvents.Name = "_lbEvents";
            this._lbEvents.Size = new System.Drawing.Size(419, 173);
            this._lbEvents.TabIndex = 2;
            // 
            // _lbStatus
            // 
            this._lbStatus.AutoSize = true;
            this._lbStatus.Location = new System.Drawing.Point(175, 18);
            this._lbStatus.Name = "_lbStatus";
            this._lbStatus.Size = new System.Drawing.Size(78, 13);
            this._lbStatus.TabIndex = 3;
            this._lbStatus.Text = "Not Registered";
            // 
            // TestApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 222);
            this.Controls.Add(this._lbStatus);
            this.Controls.Add(this._lbEvents);
            this.Controls.Add(this._btnDeregister);
            this.Controls.Add(this._btnRegister);
            this.MinimumSize = new System.Drawing.Size(460, 260);
            this.Name = "TestApplication";
            this.Text = "MediaChangeWatcher Test App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnRegister;
        private System.Windows.Forms.Button _btnDeregister;
        private System.Windows.Forms.ListBox _lbEvents;
        private System.Windows.Forms.Label _lbStatus;
    }
}

