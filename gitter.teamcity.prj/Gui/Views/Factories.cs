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

namespace gitter.TeamCity.Gui.Views
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	using gitter.Framework;
	using gitter.Framework.Controls;

	using Resources = gitter.TeamCity.Properties.Resources;

	sealed class BuildTypeBuildsViewFactory : ViewFactoryBase
	{
		public BuildTypeBuildsViewFactory()
			: base(Guids.BuildTypeBuildsViewGuid, Resources.StrBuilds, CachedResources.Bitmaps["ImgBuildType"], false)
		{
		}

		protected override ViewBase CreateViewCore(IWorkingEnvironment environment, IDictionary<string, object> parameters)
		{
			return new BuildTypeBuildsView(environment, parameters);
		}
	}
}
