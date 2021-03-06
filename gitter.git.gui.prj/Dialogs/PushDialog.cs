#region Copyright Notice
/*
 * gitter - VCS repository management tool
 * Copyright (C) 2014  Popovskiy Maxim Vladimirovitch <amgine.gitter@gmail.com>
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion

namespace gitter.Git.Gui.Dialogs
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Windows.Forms;

	using gitter.Framework;
	using gitter.Framework.Controls;
	using gitter.Framework.Mvc;
	using gitter.Framework.Mvc.WinForms;

	using gitter.Git.Gui.Controllers;
	using gitter.Git.Gui.Controls;
	using gitter.Git.Gui.Interfaces;

	using Resources = gitter.Git.Gui.Properties.Resources;

	[ToolboxItem(false)]
	public partial class PushDialog : GitDialogBase, IPushView, IExecutableDialog
	{
		#region Helpers

		private sealed class BranchesInputSource : IUserInputSource<ICollection<Branch>>, IWin32ControlInputSource
		{
			#region Data

			private readonly ReferencesListBox _referencesListBox;

			#endregion

			#region .ctor

			public BranchesInputSource(ReferencesListBox referencesListBox)
			{
				Assert.IsNotNull(referencesListBox);

				_referencesListBox = referencesListBox;
			}

			#endregion

			#region IUserInputSource<ICollection<Branch>> Members

			public ICollection<Branch> Value
			{
				get
				{
					var list = new List<Branch>(_referencesListBox.Items.Count);
					foreach(BranchListItem item in _referencesListBox.Items)
					{
						if(item.CheckedState == CheckedState.Checked)
						{
							var refItem = item as IRevisionPointerListItem;
							if(refItem != null)
							{
								var branch = refItem.RevisionPointer as Branch;
								if(branch != null)
								{
									list.Add(branch);
								}
							}
						}
					}
					return list;
				}
				set
				{
					if(value == null || value.Count == 0)
					{
						foreach(var item in _referencesListBox.Items)
						{
							item.CheckedState = CheckedState.Unchecked;
						}
						return;
					}
					foreach(var item in _referencesListBox.Items)
					{
						var refItem = item as IRevisionPointerListItem;
						if(refItem != null)
						{
							var branch = refItem.RevisionPointer as Branch;
							if(branch != null)
							{
								item.CheckedState = value.Contains(branch) ?
									CheckedState.Checked : CheckedState.Unchecked;
							}
						}
					}
				}
			}

			#endregion

			#region IUserInputSource Members

			public bool IsReadOnly
			{
				get { return !_referencesListBox.Enabled; }
				set { _referencesListBox.Enabled = !value; }
			}

			#endregion

			#region IWin32ControlInputSource Members

			public Control Control
			{
				get { return _referencesListBox; }
			}

			#endregion
		}

		#endregion

		#region Data

		private readonly Repository _repository;
		private readonly IUserInputSource<PushTo> _pushToInput;
		private readonly IUserInputSource<Remote> _remoteInput;
		private readonly IUserInputSource<string> _urlInput;
		private readonly IUserInputSource<ICollection<Branch>> _referencesInput;
		private readonly IUserInputSource<bool> _forceOverwriteInput;
		private readonly IUserInputSource<bool> _thinPackInput;
		private readonly IUserInputSource<bool> _sendTagsInput;
		private readonly IUserInputErrorNotifier _errorNotifier;
		private readonly IPushController _controller;

		#endregion

		#region .ctor

		public PushDialog(Repository repository)
		{
			Verify.Argument.IsNotNull(repository, "repository");

			_repository = repository;

			InitializeComponent();
			Localize();

			var inputs = new IUserInputSource[]
			{
				_pushToInput = new RadioButtonGroupInputSource<PushTo>(
					new[]
					{
						Tuple.Create(_radRemote, gitter.Git.Gui.Interfaces.PushTo.Remote),
						Tuple.Create(_radUrl,    gitter.Git.Gui.Interfaces.PushTo.Url),
					}),
				_remoteInput         = PickerInputSource.Create(_remotePicker),
				_urlInput            = new TextBoxInputSource(_txtUrl),
				_referencesInput     = new BranchesInputSource(_lstReferences),
				_forceOverwriteInput = new CheckBoxInputSource(_chkForceOverwriteBranches),
				_thinPackInput       = new CheckBoxInputSource(_chkUseThinPack),
				_sendTagsInput       = new CheckBoxInputSource(_chkSendTags),
			};
			_errorNotifier = new UserInputErrorNotifier(NotificationService, inputs);


			_picWarning.Image = CachedResources.Bitmaps["ImgWarning"];

			_lstReferences.LoadData(_repository, ReferenceType.LocalBranch, false, false, null);
			_lstReferences.EnableCheckboxes();

			if(!_repository.Head.IsDetached)
			{
				foreach(BranchListItem item in _lstReferences.Items)
				{
					if(item.DataContext == _repository.Head.Pointer)
					{
						item.CheckedState = CheckedState.Checked;
						break;
					}
				}
			}

			_remotePicker.LoadData(repository);
			Remote remote = null;
			lock(repository.Remotes.SyncRoot)
			{
				foreach(var r in repository.Remotes)
				{
					remote = r;
					break;
				}
			}
			_remotePicker.SelectedValue = remote;

			_controller = new PushController(repository) { View = this };
		}

		#endregion

		#region Properties

		protected override string ActionVerb
		{
			get { return Resources.StrPush; }
		}

		public Repository Repository
		{
			get { return _repository; }
		}

		public IUserInputSource<PushTo> PushTo
		{
			get { return _pushToInput; }
		}

		public IUserInputSource<Remote> Remote
		{
			get { return _remoteInput; }
		}

		public IUserInputSource<string> Url
		{
			get { return _urlInput; }
		}

		public IUserInputSource<ICollection<Branch>> References
		{
			get { return _referencesInput; }
		}

		public IUserInputSource<bool> ForceOverwrite
		{
			get { return _forceOverwriteInput; }
		}

		public IUserInputSource<bool> ThinPack
		{
			get { return _thinPackInput; }
		}

		public IUserInputSource<bool> SendTags
		{
			get { return _sendTagsInput; }
		}

		public IUserInputErrorNotifier ErrorNotifier
		{
			get { return _errorNotifier; }
		}

		#endregion

		#region Methods

		private void Localize()
		{
			Text = Resources.StrPush;

			_lstReferences.Style = GitterApplication.DefaultStyle;
			_lblBranches.Text = Resources.StrBranchesToPush.AddColon();
			_grpPushTo.Text = Resources.StrPushTo;
			_radRemote.Text = Resources.StrRemote;
			_radUrl.Text = Resources.StrUrl;
			_grpOptions.Text = Resources.StrOptions;
			_chkForceOverwriteBranches.Text = Resources.StrForceOverwriteRemoteBranches;
			_lblUseWithCaution.Text = Resources.StrUseWithCaution;
			_chkUseThinPack.Text = Resources.StrUseThinPack;
			_chkSendTags.Text = Resources.StrSendTags;

			ToolTipService.Register(_chkForceOverwriteBranches, Resources.TipPushForceOverwrite);
			ToolTipService.Register(_chkUseThinPack, Resources.TipUseTinPack);
			ToolTipService.Register(_chkSendTags, Resources.TipSendTags);
		}

		private void OnForceOverwriteCheckedChanged(object sender, EventArgs e)
		{
			_pnlWarning.Visible = _chkForceOverwriteBranches.Checked;
		}

		private void OnUrlTextChanged(object sender, EventArgs e)
		{
			if(_txtUrl.TextLength != 0)
			{
				_radUrl.Checked = true;
			}
		}

		private void OnRemotePickerSelectedIndexChanged(object sender, EventArgs e)
		{
			if(_remotePicker.SelectedValue != null)
			{
				_radRemote.Checked = true;
			}
		}

		#endregion

		#region IExecutableDialog

		public bool Execute()
		{
			return _controller.TryPush();
		}

		#endregion
	}
}
