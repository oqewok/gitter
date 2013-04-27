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

namespace gitter.Git.Gui.Dialogs
{
	using System;

	using gitter.Framework;

	public partial class BranchPropertiesDialog : GitDialogBase
	{
		private Branch _branch;

		public BranchPropertiesDialog(Branch branch)
		{
			Verify.Argument.IsNotNull(branch, "branch");

			_branch = branch;

			InitializeComponent();
		}

		public Branch Branch
		{
			get { return _branch; }
		}
	}
}
