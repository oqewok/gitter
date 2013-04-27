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

namespace gitter.Git.AccessLayer
{
	using System;
	using System.Collections.Generic;

	public sealed class ReferencesData
	{
		#region Data

		private readonly IList<BranchData> _heads;
		private readonly IList<BranchData> _remotes;
		private readonly IList<TagData> _tags;
		private readonly RevisionData _stash;

		#endregion

		#region .ctor

		public ReferencesData(IList<BranchData> heads, IList<BranchData> remotes, IList<TagData> tags, RevisionData stash)
		{
			_heads = heads;
			_remotes = remotes;
			_tags = tags;
			_stash = stash;
		}

		#endregion

		#region Properties

		public IList<BranchData> Heads
		{
			get { return _heads; }
		}

		public IList<BranchData> Remotes
		{
			get { return _remotes; }
		}

		public IList<TagData> Tags
		{
			get { return _tags; }
		}

		public RevisionData Stash
		{
			get { return _stash; }
		}

		#endregion
	}
}
