MediaChangeWatcher
==================

A .net (c++/cli) wrapper for Window Shell API that allows WinForm or WPF application to receive Media/Drive insertion and removal notifications (via WndProc / Message pump).

Usage
-----

A C# sample application is included in the project (see /Test).

![Sample App Snip](https://github.com/downloads/johanns/MediaChangeWatcher/MCWTestApp.PNG)

### Example:
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
            // Media changes message have a value of 0x458
            case 0x458:
                // Something changed...
                break;
        }
    }

Binaries:
---------

Precompiled (.net 4.0) binaries are available here: 
    
    https://github.com/downloads/johanns/MediaChangeWatcher/MediaChangeWatcher_anyCPU.net4.zip

Notes
-----

Project file requires Visual Studio 2010 or higher, Visual C++/CLI, and Windows SDK installed (Vista or later).

License
-------

Copyright (C) 2012 Johanns Gregorian

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.