#region Copyright Notice
/*
 * gitter - VCS repository management tool
 * Copyright (C) 2013  Popovskiy Maxim Vladimirovitch <amgine.gitter@gmail.com>
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

namespace gitter.Git.Gui.Views
{
	using System;
	using System.ComponentModel;
	using System.Windows.Forms;

	using gitter.Git.Gui.Dialogs;

	using Resources = gitter.Git.Gui.Properties.Resources;

	/// <summary>Toolbar for <see cref="SubmodulesView"/>.</summary>
	[ToolboxItem(false)]
	internal sealed class SubmodulesToolbar : ToolStrip
	{
		#region Data

		private readonly SubmodulesView _submodulesView;
		private readonly ToolStripButton _btnAddSubmodule;

		#endregion

		/// <summary>Initializes a new instance of the <see cref="SubmodulesToolbar"/> class.</summary>
		/// <param name="submodulesView">Host view.</param>
		public SubmodulesToolbar(SubmodulesView submodulesView)
		{
			Verify.Argument.IsNotNull(submodulesView, "submodulesView");

			_submodulesView = submodulesView;

			Items.Add(new ToolStripButton(Resources.StrRefresh, CachedResources.Bitmaps["ImgRefresh"],
				(sender, e) =>
				{
					_submodulesView.RefreshContent();
				})
				{
					DisplayStyle = ToolStripItemDisplayStyle.Image,
				});
			Items.Add(new ToolStripSeparator());
			Items.Add(_btnAddSubmodule = new ToolStripButton(Resources.StrAddSubmodule, CachedResources.Bitmaps["ImgSubmoduleAdd"],
				(sender, e) =>
				{
					using(var dlg = new AddSubmoduleDialog(_submodulesView.Repository))
					{
						dlg.Run(_submodulesView);
					}
				})
				{
					DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
				});
		}
	}
}
