MediaChangeWatcher
==================

A .net (c++/cli) wrapper for Window Shell API that allows WinForm or WPF application to receive Media/Drive insertion and removal notifications (via WndProc / Message pump).

Usage
-----

A C## sample application is included in the project (see /Test).

### Example: C##
Create a MediaChangeWatcher instance, and setup window to receive shell notifications:
	
	// Handle is Form.Handle
	MediaChangeWatcher _watcher = new MediaChangeWatcher();
	_watcher.Handle = this.Handle;
	_watcher.Register();

Deregister:

	_watcher.Deregister();

Sample WndProc:

    protected override void WndProc(ref Message m) {
        base.WndProc(ref m);
        
        switch (m.Msg) {
            case 0x458:
                // Something happened...
                break;
        }
    }

Notes
-----

Project file requires Visual Studio 2010 or higher, Visual C++/CLI, and Windows SDK installed.

