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

	using gitter.Framework;

	/// <summary>Information about <see cref="Submodule"/>.</summary>
	public sealed class SubmoduleData : INamedObject
	{
		#region Data

		private readonly string _name;
		private string _path;
		private string _url;

		#endregion

		#region .ctor

		/// <summary>Create <see cref="SubmoduleData"/>.</summary>
		/// <param name="name">Submodule name.</param>
		public SubmoduleData(string name)
		{
			_name = name;
		}

		#endregion

		#region Properties

		/// <summary>Submodule name.</summary>
		public string Name
		{
			get { return _name; }
		}

		/// <summary>Submodule path.</summary>
		public string Path
		{
			get { return _path; }
			set { _path = value; }
		}

		/// <summary>Submodule URL.</summary>
		public string Url
		{
			get { return _url; }
			set { _url = value; }
		}

		#endregion
	}
}
