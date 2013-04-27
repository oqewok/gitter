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

namespace gitter.Git
{
	using System;

	using gitter.Framework;

	public abstract class TreeContentData : INamedObject
	{
		private readonly string _hash;
		private readonly int _mode;
		private readonly string _name;

		internal TreeContentData(string hash, int mode, string name)
		{
			_hash = hash; ;
			_name = name;
			_mode = mode;
		}

		public string SHA1
		{
			get { return _hash; }
		}

		public string Name
		{
			get { return _name; }
		}

		public int Mode
		{
			get { return _mode; }
		}

		public abstract TreeContentType Type { get; }
	}
}
