﻿using System;
using System.Collections.Generic;
using System.Net;

namespace AlephNote.PluginInterface.Impl
{
	public abstract class BasicRemoteConnection : IRemoteStorageConnection
	{
		public static Func<IWebProxy, string, ISimpleJsonRest> SimpleJsonRestWrapper = (rest, proxy) => { throw new NotImplementedException(); };

		public abstract void StartSync(IRemoteStorageSyncPersistance data, List<INote> localnotes, List<INote> localdeletednotes);
		public abstract void FinishSync(out bool immediateResync);

		public abstract bool NeedsUpload(INote note);
		public abstract bool NeedsDownload(INote note);

		public abstract List<string> ListMissingNotes(List<INote> localnotes);

		public abstract RemoteUploadResult UploadNoteToRemote(ref INote note, out INote conflict, out bool keepNoteRemoteDirtyWithConflict, ConflictResolutionStrategy strategy);
		public abstract RemoteDownloadResult UpdateNoteFromRemote(INote note);
		public abstract INote DownloadNote(string id, out bool success);
		public abstract void DeleteNote(INote note);

		public ISimpleJsonRest CreateJsonRestClient(IWebProxy proxy, string host)
		{
			return SimpleJsonRestWrapper(proxy, host);
		}

		public virtual void OnAfterSyncError(INoteRepository repo, Exception e)
        {
			// Do nothing
        }
	}
}
