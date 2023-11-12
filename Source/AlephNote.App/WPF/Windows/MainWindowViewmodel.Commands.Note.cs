﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using AlephNote.Common.Settings;
using AlephNote.PluginInterface.Util;
using AlephNote.WPF.Dialogs;
using MSHC.WPF.MVVM;
using Microsoft.Win32;
using MSHC.Lang.Collections;
using Ookii.Dialogs.Wpf;
using ScintillaNET;
using System.Web;

namespace AlephNote.WPF.Windows
{
	public partial class MainWindowViewmodel
	{
		public ICommand CreateNewNoteCommand              => new RelayCommand(CreateNote);
		public ICommand CreateNewNoteFromClipboardCommand => new RelayCommand(CreateNoteFromClipboard);
		public ICommand CreateNewNoteFromTextfileCommand  => new RelayCommand(CreateNewNoteFromTextfile);
		public ICommand ExportCommand                     => new RelayCommand(ExportNote);
		public ICommand DeleteCommand                     => new RelayCommand(DeleteNote);
		public ICommand DocumentSearchCommand             => new RelayCommand(ShowDocSearchBar);
		public ICommand DocumentContinueSearchCommand     => new RelayCommand(ContinueSearch);
		public ICommand CloseDocumentSearchCommand        => new RelayCommand(HideDocSearchBar);
		public ICommand InsertSnippetCommand              => new RelayCommand<string>(InsertSnippet);
		public ICommand ChangePathCommand                 => new RelayCommand(() => Owner.PathEditor.ChangePath());
		public ICommand DuplicateNoteCommand              => new RelayCommand(DuplicateNote);
		public ICommand PinUnpinNoteCommand               => new RelayCommand(PinUnpinNote);
		public ICommand LockUnlockNoteCommand             => new RelayCommand(LockUnlockNote);
        public ICommand ExportFrontmatterCommand          => new RelayCommand(ExportFrontmatter);
        public ICommand InsertHyperlinkCommand            => new RelayCommand(InsertHyperlink);
		public ICommand InsertFilelinkCommand             => new RelayCommand(InsertFilelink);
		public ICommand InsertNotelinkCommand             => new RelayCommand(InsertNotelink);
		public ICommand InsertMaillinkCommand             => new RelayCommand(InsertMaillink);
		public ICommand MoveCurrentLineUpCommand          => new RelayCommand(MoveCurrentLineUp);
		public ICommand MoveCurrentLineDownCommand        => new RelayCommand(MoveCurrentLineDown);
		public ICommand DuplicateCurrentLineCommand       => new RelayCommand(DuplicateCurrentLine);
		public ICommand CopyCurrentLineCommand            => new RelayCommand(CopyCurrentLine);
		public ICommand CutCurrentLineCommand             => new RelayCommand(CutCurrentLine);
		public ICommand CopyAllowLineCommand              => new RelayCommand(CopyAllowLine);
		public ICommand CutAllowLineCommand               => new RelayCommand(CutAllowLine);
		public ICommand AddTagCommand                     => new RelayCommand<string>(AddTagToNote);
		public ICommand RemoveTagCommand                  => new RelayCommand<string>(RemoveTagFromNote);

		private void ExportNote()
		{
			if (SelectedNote == null) return;

			var selection = AllSelectedNotes.ToList();
			if (selection.Count > 1)
			{
				var dialog = new VistaFolderBrowserDialog();
				if (!(dialog.ShowDialog() ?? false)) return;

				try
				{
					var directory = dialog.SelectedPath;
					foreach (var note in selection)
					{
						var filenameRaw = ANFilenameHelper.StripStringForFilename(note.Title);
						var filename = filenameRaw;
						var ext = SelectedNote.HasTagCaseInsensitive(AppSettings.TAG_MARKDOWN) ? ".md" : ".txt";

						int i = 1;
						while (File.Exists(Path.Combine(directory, filename + ext)))
						{
							i++;
							filename = $"{filenameRaw} ({i})";
						}

						File.WriteAllText(Path.Combine(directory, filename + ext), note.Text, Encoding.UTF8);
					}
				}
				catch (Exception e)
				{
					App.Logger.Error("Main", "Could not write to file", e);
					ExceptionDialog.Show(Owner, "Could not write to file", e, string.Empty);
				}
			}
			else
			{
				var sfd = new SaveFileDialog();

				if (SelectedNote.HasTagCaseInsensitive(AppSettings.TAG_MARKDOWN))
				{
					sfd.Filter = "Markdown files (*.md)|*.md";
					sfd.FileName = SelectedNote.Title + ".md";
				}
				else
				{
					sfd.Filter = "Text files (*.txt)|*.txt";
					sfd.FileName = SelectedNote.Title + ".txt";
				}

				if (sfd.ShowDialog() != true) return;
				try
				{
					File.WriteAllText(sfd.FileName, SelectedNote.Text, Encoding.UTF8);
				}
				catch (Exception e)
				{
					App.Logger.Error("Main", "Could not write to file", e);
					ExceptionDialog.Show(Owner, "Could not write to file", e, string.Empty);
				}
			}
		}

		private void DeleteNote()
		{
			try
			{
				if (SelectedNote == null) return;
				if (Settings.IsReadOnlyMode) return;

				var selection = AllSelectedNotes.ToList();
				if (selection.Count > 1)
				{
					if (MessageBox.Show(Owner, $"Do you really want to delete {selection.Count} notes?", "Delete multiple notes?", MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;

					foreach (var note in selection) Repository.DeleteNote(note, true);

					SelectedNote = Repository.Notes.FirstOrDefault();
				}
				else
				{
					if (MessageBox.Show(Owner, "Do you really want to delete this note?", "Delete note?", MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;

					Repository.DeleteNote(SelectedNote, true);

					SelectedNote = Repository.Notes.FirstOrDefault();
				}
			}
			catch (Exception e)
			{
				App.Logger.Error("Main", "Could not delete note(s)", e);
				ExceptionDialog.Show(Owner, "Could not delete note(s)", e, string.Empty);
			}
		}

		private void DuplicateNote()
		{
			if (SelectedNote == null) return;
			if (Settings.IsReadOnlyMode) return;

			if (Owner.Visibility == Visibility.Hidden) ShowMainWindow();

			var selection = AllSelectedNotes.ToList();
			if (selection.Count > 1)
			{
				if (MessageBox.Show(Owner, $"Do you really want to duplicate {selection.Count} notes?", "Duplicate multiple notes?", MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;

				var lastNote = SelectedNote;
				foreach (var note in selection)
				{
					var title = note.Title;
					var path = note.Path;
					var text = note.Text;
					var tags = note.Tags.ToList();

					var ntitle = title + " (copy)";
					var i = 2;
					while (Repository.Notes.Any(n => n.Title.ToLower() == ntitle.ToLower())) ntitle = title + " (copy-" + (i++) + ")";
					title = ntitle;

					lastNote = Repository.CreateNewNote(path);

					lastNote.Title = title;
					lastNote.Text = text;
					lastNote.Tags.SynchronizeCollection(tags);
				}

				SelectedNote = lastNote;
			}
			else
			{
				var title = SelectedNote.Title;
				var path = SelectedNote.Path;
				var text = SelectedNote.Text;
				var tags = SelectedNote.Tags.ToList();

				var ntitle = title + " (copy)";
				var i = 2;
				while (Repository.Notes.Any(n => n.Title.ToLower() == ntitle.ToLower())) ntitle = title + " (copy-" + (i++) + ")";
				title = ntitle;

				SelectedNote = Repository.CreateNewNote(path);

				SelectedNote.Title = title;
				SelectedNote.Text = text;
				SelectedNote.Tags.SynchronizeCollection(tags);
			}
		}

		private void PinUnpinNote()
		{
			if (Settings.IsReadOnlyMode) return;

			if (!Repository.SupportsPinning)
			{
				MessageBox.Show(Owner, "Pinning notes is not supported by your note provider", "Unsupported operation!", MessageBoxButton.OK);
				return;
			}

			if (SelectedNote == null) return;

			var selection = AllSelectedNotes.ToList();
			if (selection.Count > 1)
			{
				var newpin = !selection[0].IsPinned;

				if (MessageBox.Show(Owner, $"Do you really want to {(newpin ? "pin" : "unpin")} {selection.Count} notes?", $"{(newpin ? "Pin" : "Unpin")} multiple note?", MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;

				foreach (var note in selection) note.IsPinned = newpin;
			}
			else
			{
				SelectedNote.IsPinned = !SelectedNote.IsPinned;
			}
		}

		private void LockUnlockNote()
		{
			if (Settings.IsReadOnlyMode) return;

			if (!Repository.SupportsLocking)
			{
				MessageBox.Show(Owner, "Locking notes is not supported by your note provider", "Unsupported operation!", MessageBoxButton.OK);
				return;
			}

			if (SelectedNote == null) return;

			var selection = AllSelectedNotes.ToList();
			if (selection.Count > 1)
			{
				var newlock = !selection[0].IsLocked;

				if (MessageBox.Show(Owner, $"Do you really want to {(newlock ? "lock" : "unlock")} {selection.Count} notes?", $"{(newlock ? "Lock" : "Unlock")} multiple note?", MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;

				foreach (var note in selection) note.IsLocked = newlock;
			}
			else
			{
				SelectedNote.IsLocked = !SelectedNote.IsLocked;
			}
		}

        private void ExportFrontmatter()
		{
            if (SelectedNote == null) return;

            var dialog = new VistaFolderBrowserDialog();
            if (!(dialog.ShowDialog() ?? false)) return;

            try
            {
				var tnow = DateTime.UtcNow;

                var directory = dialog.SelectedPath;
                foreach (var note in Repository.Notes)
                {
					var subpath = note.Path.Enumerate().Select(p => ANFilenameHelper.StripStringForFilename(p)).ToArray();

                    var filename = ANFilenameHelper.StripStringForFilename(note.Title) + ".md";

                    var filedir = Path.Combine((new string[] { directory }).AsEnumerable().Concat(subpath).ToArray());

					Directory.CreateDirectory(filedir);

                    var filedest = Path.Combine((new string[] { directory }).AsEnumerable().Concat(subpath).Concat(new string[] { filename }).ToArray());

                    var mdfm = "---\n";
                    mdfm += $"id: {note.UniqueName}\n";
                    mdfm += $"title: {note.Title}\n";
                    mdfm += $"updated: {note.ModificationDate.ToUniversalTime():yyyy-MM-dd HH:mm:ss}Z\n";
                    mdfm += $"created: {note.CreationDate.ToUniversalTime():yyyy-MM-dd HH:mm:ss}Z\n";
                    mdfm += $"exported: {tnow.ToUniversalTime():yyyy-MM-dd HH:mm:ss}Z\n";
                    mdfm += $"locked: {note.IsLocked.ToString().ToLower()}\n";
                    mdfm += $"pinned: {note.IsPinned.ToString().ToLower()}\n";
                    mdfm += $"conflict: {note.IsConflictNote.ToString().ToLower()}\n";
                    mdfm += $"tags: [{string.Join(", ", note.Tags.Select(p => '"' + HttpUtility.JavaScriptStringEncode(p) + '"'))}]\n";
                    mdfm += $"path: [{string.Join(", ", note.Path.Enumerate().Select(p => '"' + HttpUtility.JavaScriptStringEncode(p) + '"'))}]\n";
                    mdfm += $"---\n";
                    mdfm += $"\n";
                    mdfm += note.Text;

					if (File.Exists(filedest)) { throw new Exception($"File {filedest} already exists"); }

                    File.WriteAllText(filedest, mdfm, Encoding.UTF8);
                }
            }
            catch (Exception e)
            {
                App.Logger.Error("Main", "Could not write to file", e);
                ExceptionDialog.Show(Owner, "Could not write to file", e, string.Empty);
            }
        }
			

        private void AddTagToNote(string t)
		{
			if (SelectedNote == null) return;
			if (Settings.IsReadOnlyMode) return;

			if (!Repository.SupportsTags)
			{
				MessageBox.Show(Owner, "Tags are not supported by your note provider", "Unsupported operation!", MessageBoxButton.OK);
				return;
			}
			
			if (SelectedNote == null) return;

			var selection = AllSelectedNotes.ToList();
			if (selection.Count > 1)
			{
				if (MessageBox.Show(Owner, $"Do you really want to add the tag [{t}] to {selection.Count} notes?", $"Add tag?", MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;

				foreach (var note in selection)
				{
					if (note.IsLocked) continue;
					if (!note.Tags.Contains(t)) note.Tags.Add(t);
				}
			}
			else
			{
				if (SelectedNote.IsLocked) return;
				if (!SelectedNote.Tags.Contains(t)) SelectedNote.Tags.Add(t);
			}
		}

		private void RemoveTagFromNote(string t)
		{
			if (SelectedNote == null) return;

			if (!Repository.SupportsTags)
			{
				MessageBox.Show(Owner, "Tags are not supported by your note provider", "Unsupported operation!", MessageBoxButton.OK);
				return;
			}
			
			if (SelectedNote == null) return;

			var selection = AllSelectedNotes.ToList();
			if (selection.Count > 1)
			{
				if (MessageBox.Show(Owner, $"Do you really want to remove the tag [{t}] from {selection.Count} notes?", $"Remove tag?", MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;

				foreach (var note in selection)
				{
					if (note.IsLocked) continue;
					if (note.Tags.Contains(t)) note.Tags.Remove(t);
				}
			}
			else
			{
				if (SelectedNote.IsLocked) return;
				if (SelectedNote.Tags.Contains(t)) SelectedNote.Tags.Remove(t);
			}
		}

		private void CreateNote()
		{
			try
			{
				var path = Owner.NotesViewControl.GetNewNotesPath();
				if (Owner.Visibility == Visibility.Hidden) ShowMainWindow();
				SelectedNote = Repository.CreateNewNote(path);

				Owner.SetFocus(Settings.FocusAfterCreateNote);
			}
			catch (Exception e)
			{
				ExceptionDialog.Show(Owner, "Cannot create note", e, string.Empty);
			}
		}

		private void CreateNoteFromClipboard()
		{
			var notepath = Owner.NotesViewControl.GetNewNotesPath();

			if (Clipboard.ContainsFileDropList())
			{
				if (Owner.Visibility == Visibility.Hidden) ShowMainWindow();

				foreach (var path in Clipboard.GetFileDropList())
				{
					var filename = Path.GetFileNameWithoutExtension(path) ?? "New note from unknown file";
					var filecontent = File.ReadAllText(path);

					SelectedNote = Repository.CreateNewNote(notepath);
					SelectedNote.Title = filename;
					SelectedNote.Text = filecontent;
				}
			}
			else if (Clipboard.ContainsText())
			{
				if (Owner.Visibility == Visibility.Hidden) ShowMainWindow();

				var notetitle = "New note from clipboard";
				var notecontent = Clipboard.GetText();
				if (!string.IsNullOrWhiteSpace(notecontent))
				{
					SelectedNote = Repository.CreateNewNote(notepath);
					SelectedNote.Title = notetitle;
					SelectedNote.Text = notecontent;
				}
			}
		}

		private void CreateNewNoteFromTextfile()
		{
			var notepath = Owner.NotesViewControl.GetNewNotesPath();

			var ofd = new OpenFileDialog
			{
				Multiselect = true,
				ShowReadOnly = true,
				DefaultExt = ".txt",
				Title = "Import new notes from text files",
				CheckFileExists = true,
				Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
			};

			if (ofd.ShowDialog() != true) return;

			try
			{
				foreach (var path in ofd.FileNames)
				{
					var filename = Path.GetFileNameWithoutExtension(path) ?? "New note from unknown file";
					var filecontent = File.ReadAllText(path);

					SelectedNote = Repository.CreateNewNote(notepath);
					SelectedNote.Title = filename;
					SelectedNote.Text = filecontent;
				}
			}
			catch (Exception ex)
			{
				ExceptionDialog.Show(Owner, "Reading file failed", "Creating note from file failed due to an error", ex);
			}
		}

		private void ShowDocSearchBar()
		{
			Owner.ShowDocSearchBar();
		}

		private void HideDocSearchBar()
		{
			Owner.HideDocSearchBar();
		}

		private void ContinueSearch()
		{
			if (!Settings.DocSearchEnabled) return;
			if (Owner.DocumentSearchBar.Visibility != Visibility.Visible) return;

			Owner.DocumentSearchBar.ContinueSearch();
		}

		private void InsertSnippet(string snip)
		{
			if (SelectedNote == null) return;

			snip = _spsParser.Parse(snip, Repository, SelectedNote, out bool succ);

			if (!succ)
			{
				App.Logger.Warn("Main", "Snippet has invalid format: '" + snip + "'");
			}

			Owner.NoteEdit.ReplaceSelection(snip);

			Owner.FocusScintilla();
		}

		private void InsertHyperlink()
		{
			if (SelectedNote == null) return;

			if (!GenericInputDialog.ShowInputDialog(Owner, "Insert website address", "Hyperlink location", "", out var url)) return;
			if (string.IsNullOrWhiteSpace(url)) return;

			if (!(url.ToLower().StartsWith("http://") || url.ToLower().StartsWith("https://"))) url = "https://" + url;

			Owner.NoteEdit.ReplaceSelection(url);
			Owner.FocusScintilla();
		}

		private void InsertFilelink()
		{
			if (SelectedNote == null) return;

			var ofd = new OpenFileDialog();

			var inst = MainWindow.Instance;

			if (inst != null && inst.IsVisible && inst.IsActive && !inst.IsClosed)
			{
				if (ofd.ShowDialog(inst) != true) return;
			}
			else
			{
				if (ofd.ShowDialog() != true) return;
			}

			var uri = new Uri(ofd.FileName).AbsoluteUri;

			Owner.NoteEdit.ReplaceSelection(uri);
			Owner.FocusScintilla();
		}

		private void InsertMaillink()
		{
			if (SelectedNote == null) return;

			if (!GenericInputDialog.ShowInputDialog(Owner, "Insert mail address", "Email address", "", out var url)) return;
			if (string.IsNullOrWhiteSpace(url)) return;

			url = "mailto:" + url;

			Owner.NoteEdit.ReplaceSelection(url);
			Owner.FocusScintilla();
		}

		private void InsertNotelink()
		{
			if (SelectedNote == null) return;

			if (!NoteChooserDialog.ShowInputDialog(Owner, "Choose note to link", Repository, null, out var note)) return;

			var uri = "note://" + note.UniqueName;

			Owner.NoteEdit.ReplaceSelection(uri);
			Owner.FocusScintilla();
		}

		private void MoveCurrentLineUp()
		{
			if (SelectedNote == null) return;

			var hasSelection = Owner.NoteEdit.Selections.Any(s => s.End - s.Start > 1);

			Owner.NoteEdit.ExecuteCmd(Command.MoveSelectedLinesUp);

			if (!hasSelection) Owner.NoteEdit.SetEmptySelection(Owner.NoteEdit.CurrentPosition);
		}

		private void MoveCurrentLineDown()
		{
			if (SelectedNote == null) return;

			var hasSelection = Owner.NoteEdit.Selections.Any(s => s.End - s.Start > 1);

			Owner.NoteEdit.ExecuteCmd(Command.MoveSelectedLinesDown);

			if (!hasSelection) Owner.NoteEdit.SetEmptySelection(Owner.NoteEdit.CurrentPosition);
		}

		private void DuplicateCurrentLine()
		{
			if (SelectedNote == null) return;

			var lineidx = Owner.NoteEdit.CurrentLine;
			var lines = Owner.NoteEdit.Lines;
			if (lineidx < 0 || lineidx >= lines.Count) return;

			if (lineidx == lines.Count - 1)
				Owner.NoteEdit.InsertText(lines[lineidx].EndPosition, "\r\n" + lines[lineidx].Text);
			else
				Owner.NoteEdit.InsertText(lines[lineidx].EndPosition, lines[lineidx].Text);
		}

		private void CopyCurrentLine()
		{
			if (SelectedNote == null) return;

			var lineidx = Owner.NoteEdit.CurrentLine;
			var lines = Owner.NoteEdit.Lines;
			if (lineidx < 0 || lineidx >= lines.Count) return;

			Owner.NoteEdit.CopyRange(lines[lineidx].Position, lines[lineidx].EndPosition);
		}

		private void CutCurrentLine()
		{
			if (SelectedNote == null) return;

			var lineidx = Owner.NoteEdit.CurrentLine;
			var lines = Owner.NoteEdit.Lines;
			if (lineidx < 0 || lineidx >= lines.Count) return;

			Owner.NoteEdit.CopyRange(lines[lineidx].Position, lines[lineidx].EndPosition);
			Owner.NoteEdit.DeleteRange(lines[lineidx].Position, lines[lineidx].Length);
		}

		private void CopyAllowLine()
		{
			if (SelectedNote == null) return;

			Owner.NoteEdit.CopyAllowLine();
		}

		private void CutAllowLine()
		{
			if (SelectedNote == null) return;

			var lineidx = Owner.NoteEdit.CurrentLine;
			var lines = Owner.NoteEdit.Lines;
			if (lineidx < 0 || lineidx >= lines.Count) return;

			var hasSelection = Owner.NoteEdit.Selections.Any(s => s.End - s.Start > 1);

			if (hasSelection)
			{
				Owner.NoteEdit.Cut();
			}
			else
			{
				Owner.NoteEdit.CopyAllowLine();
				Owner.NoteEdit.DeleteRange(lines[lineidx].Position, lines[lineidx].Length);
			}
		}
	}
}