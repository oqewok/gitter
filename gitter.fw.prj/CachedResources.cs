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

namespace gitter.Framework
{
	using System;
	using System.Collections.Generic;
	using System.Resources;

	public class CachedResources<T>
	{
		#region Data

		private readonly Dictionary<string, T> _cache;
		private readonly ResourceManager _manager;

		#endregion

		#region .ctor

		public CachedResources(ResourceManager manager)
		{
			Verify.Argument.IsNotNull(manager, "manager");

			_manager = manager;
			_cache = new Dictionary<string, T>();
		}

		#endregion

		public T this[string name]
		{
			get
			{
				T resource;
				if(!_cache.TryGetValue(name, out resource))
				{
					resource = (T)_manager.GetObject(name);
					_cache.Add(name, resource);
				}
				return resource;
			}
		}
	}
}
