using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Johanns
{
    public partial class TestApplication : Form
    {
        MediaChangeWatcher _mw = null;
     
        // We need to look for the a message with the following value.
        // In windows.h (SDK) WM_USER is defined as 0x0400; change messages are 0x0400 + 0x58
        const int WM_USER_MEDIACHANGED = 0x0458;

        public TestApplication() {
            InitializeComponent();

            _mw = new MediaChangeWatcher();

            this.HandleCreated += new EventHandler(OnHandleCreated);
            this.FormClosing += new FormClosingEventHandler(OnFormClosing);
        }

        void OnHandleCreated(object sender, EventArgs e) {
            // Pass the form Window Handle (hWnd) to MediaChangeWatcher instance.
            _mw.Handle = Handle;
        }

        void OnFormClosing(object sender, FormClosingEventArgs e) {
            // Deregister the notification hook before exiting.
            _mw.Deregister();
        }

        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
            
            // Looks for, and process the Media Changed message sent by the shell
            switch (m.Msg) {
                case WM_USER_MEDIACHANGED:
                    _lbEvents.Items.Add(addAction(ref m));
                    break;
            }
        }

        string addAction(ref Message m) {
            string s = string.Format("Drive/Media {0}: ", MediaChangeWatcher.GetPathFromIDList(m.WParam));

            switch ((MediaChangeWatcherFlags)m.LParam) {
                case MediaChangeWatcherFlags.DriveAdded:
                    s += "Drive Added";
                    break;
                case MediaChangeWatcherFlags.DriveRemoved:
                    s += "Drive Removed";
                    break;
                case MediaChangeWatcherFlags.MediaInserted:
                    s += "Media Inserted";
                    break;
                case MediaChangeWatcherFlags.MediaRemoved:
                    s += "Media Removed";
                    break;
                default:
                    s += "Other Action";
                    break;
            }

            return s;
        }

        private void OnRegisterClick(object sender, EventArgs e) {            
           // Check to make sure that we aren't already registered
            if (!_mw.IsRegistered) {
                try {
                    // Register our window handle with the shell
                    _mw.Register();
                    _lbStatus.Text = "Registered";
                }
                catch (MediaChangeWatcherException m) {
                    _lbEvents.Items.Add(m.Message);
                }
            }
        }

        private void OnDeregisterClick(object sender, EventArgs e) {            
            // Are we already registered?
            if (_mw.IsRegistered) {
                try {
                    // Stop the Shell from sending us change notifications
                    _mw.Deregister();
                    _lbStatus.Text = "Not Registered";
                }
                catch (MediaChangeWatcherException m) {
                    _lbEvents.Items.Add(m.Message);
                }
            }
        }
    }
}
