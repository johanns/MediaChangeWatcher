// Copyright (C) 2012 Johanns Gregorian
// See license.txt 

#include "stdafx.h"

#include "MediaChangeWatcher.h"

namespace Johanns {
	MediaChangeWatcher::MediaChangeWatcher(IntPtr^ handle) : m_ulSHChangeNotifyRegister(0) {
		this->Handle = handle;
	}

	MediaChangeWatcher::~MediaChangeWatcher() {
		this->Deregister();
	}

	void MediaChangeWatcher::Register() {
		if (IntPtr::Zero.Equals(this->Handle)) {
			throw gcnew MediaChangeWatcherException("Handle not assigned.");
		}
		
		LPITEMIDLIST pPidl;

		if (::SHGetSpecialFolderLocation(reinterpret_cast<HWND>(Handle->ToInt32()), CSIDL_DESKTOP, &pPidl) == NOERROR) {
			::SHChangeNotifyEntry shcne;
			shcne.pidl = pPidl;
			shcne.fRecursive = TRUE;

			this->m_ulSHChangeNotifyRegister = ::SHChangeNotifyRegister(
				reinterpret_cast<HWND>(Handle->ToInt32()),
				SHCNE_DISKEVENTS,
				SHCNE_MEDIAINSERTED | SHCNE_MEDIAREMOVED | SHCNE_DRIVEADD | SHCNE_DRIVEREMOVED,
				WM_USER_MEDIACHANGED,
				1,
				&shcne);
			
			if (m_ulSHChangeNotifyRegister == 0) {
				throw gcnew MediaChangeWatcherException("Unable to register shell notification hook.");
			}
		} else {
			throw gcnew MediaChangeWatcherException("Unable to get desktop directory location.");
		}
	}

	void MediaChangeWatcher::Deregister() {
		if (m_ulSHChangeNotifyRegister && !::SHChangeNotifyDeregister(this->m_ulSHChangeNotifyRegister)) {
			throw gcnew MediaChangeWatcherException("Unable to deregister shell notification hook.");
		}

		m_ulSHChangeNotifyRegister = 0;
	}
	
	System::String^ MediaChangeWatcher::GetPathFromIDList(IntPtr wParam) {
		SHNOTIFYSTRUCT *shns = reinterpret_cast<SHNOTIFYSTRUCT *>(wParam.ToPointer());
		CHAR szPath[MAX_PATH];

		::SHGetPathFromIDList((struct _ITEMIDLIST *) shns->dwItem1, (LPTSTR) szPath);

		return gcnew String(szPath);
	}
}
