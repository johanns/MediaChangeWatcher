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
        const int WM_USER_MEDIACHANGED = 0x0400 + 88;

        public TestApplication() {
            InitializeComponent();

            _mw = new MediaChangeWatcher();

            this.HandleCreated += new EventHandler(OnHandleCreated);
            this.FormClosing += new FormClosingEventHandler(OnFormClosing);
        }

        void OnHandleCreated(object sender, EventArgs e) {
            _mw.Handle = Handle;
        }

        void OnFormClosing(object sender, FormClosingEventArgs e) {
            _mw.Deregister();
        }

        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
            
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
            if (!_mw.IsRegistered) {
                try {
                    _mw.Register();
                    _lbStatus.Text = "Registered";
                }
                catch (MediaChangeWatcherException m) {
                    _lbEvents.Items.Add(m.Message);
                }
            }
        }

        private void OnDeregisterClick(object sender, EventArgs e) {            
            if (_mw.IsRegistered) {
                try {
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
