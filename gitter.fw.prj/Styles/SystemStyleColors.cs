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
	using System.Drawing;

	public sealed class SystemStyleColors : IGitterStyleColors
	{
		public Color WorkArea
		{
			get { return Color.FromArgb(41, 57, 85); }
		}

		public Color Window
		{
			get { return SystemColors.Window; }
		}

		public Color ScrollBarSpacing
		{
			get { return SystemColors.Window; }
		}

		public Color Separator
		{
			get { return Color.FromArgb(209, 226, 252); }
		}

		public Color Alternate
		{
			get { return Color.WhiteSmoke; }
		}

		public Color WindowText
		{
			get { return SystemColors.WindowText; }
		}

		public Color GrayText
		{
			get { return SystemColors.GrayText; }
		}

		public Color HyperlinkText
		{
			get { return Color.Blue; }
		}

		public Color HyperlinkTextHotTrack
		{
			get { return Color.Blue; }
		}

		public Color FileHeaderColor1				{ get { return Color.FromArgb(245, 245, 245); } }
		public Color FileHeaderColor2				{ get { return Color.FromArgb(232, 232, 232); } }
		public Color FilePanelBorder				{ get { return Color.Gray; } }
		public Color LineContextForeground			{ get { return Color.FromArgb(0, 0, 0); } }
		public Color LineContextBackground			{ get { return Color.FromArgb(255, 255, 255); } }
		public Color LineAddedForeground			{ get { return Color.FromArgb(0, 100, 0); } }
		public Color LineAddedBackground			{ get { return Color.FromArgb(221, 255, 233); } }
		public Color LineRemovedForeground			{ get { return Color.FromArgb(200, 0, 0); } }
		public Color LineRemovedBackground			{ get { return Color.FromArgb(255, 238, 238); } }
		public Color LineNumberForeground			{ get { return Color.Gray; } }
		public Color LineNumberBackground			{ get { return Color.FromArgb(247, 247, 247); } }
		public Color LineNumberBackgroundHover		{ get { return LineNumberBackground.Darker(0.1f); } }
		public Color LineHeaderForeground			{ get { return Color.Gray; } }
		public Color LineHeaderBackground			{ get { return Color.FromArgb(247, 247, 247); } }
		public Color LineSelectedBackground			{ get { return Color.FromArgb(173, 214, 255); } }
		public Color LineSelectedBackgroundHover	{ get { return LineSelectedBackground.Darker(0.1f); } }
		public Color LineBackgroundHover			{ get { return LineSelectedBackground.Lighter(0.3f); } }
	}
}
