// MediaChangeWatcher.h
#define WM_USER_MEDIACHANGED WM_USER+88

#pragma once

#include <windows.h>
#include <shlobj.h>
#pragma comment(lib,"shell32.lib")

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace System::Text;

namespace Johanns {
	public ref class MediaChangeWatcher {
	public:
		MediaChangeWatcher() : m_ulSHChangeNotifyRegister(0), m_hWnd(IntPtr::Zero) {};
		MediaChangeWatcher(IntPtr^);
		~MediaChangeWatcher();

		void Register();
		void Deregister();

		property IntPtr^ Handle {
			IntPtr^ get() { return this->m_hWnd; }
			void set(IntPtr^ handle) { this->m_hWnd = handle; }
		};

		property bool IsRegistered {
			bool get() { return m_ulSHChangeNotifyRegister != 0 ?  true : false; }
		}

		static System::String^ GetPathFromIDList(IntPtr wParam);
	private:
		IntPtr^ m_hWnd;
		ULONG m_ulSHChangeNotifyRegister;
	};

	public ref class MediaChangeWatcherException : public ApplicationException {
	public:
		MediaChangeWatcherException() : ApplicationException() {};
		MediaChangeWatcherException(System::String^ message) : ApplicationException(message) {};
	};

	public enum class MediaChangeWatcherFlags
	{
		RenameItem = 0x00000001,
		Create = 0x00000002,
		Delete = 0x00000004,
		MadeDirectory = 0x00000008,
		RemovedDirectory = 0x00000010,
		MediaInserted = 0x00000020,
		MediaRemoved = 0x00000040,
		DriveRemoved = 0x00000080,
		DriveAdded = 0x00000100,
		NetworkShareAdded = 0x00000200,
		NetworkShareRemoved = 0x00000400,
		AttributedChanged = 0x00000800,
		DirectoryUpdated = 0x00001000,
		ItemUpdated = 0x00002000,
		ServerDisconnected = 0x00004000,
		ImageUpdated = 0x00008000,
		DriveAddedviaGUI = 0x00010000,
		DirectoryRenamed = 0x00020000,
		Free = 0x00040000
	};

	typedef struct {
		// dwItem1 contains the previous PIDL or name of the folder. 
		DWORD dwItem1;
		// dwItem2 contains the new PIDL or name of the folder. 
		DWORD dwItem2;
	} SHNOTIFYSTRUCT;
}
