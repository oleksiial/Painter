﻿using Painter.Models;
using Painter.Views;
using System.Collections.Generic;

namespace Painter.Controllers
{
	public class XCommand
	{
		private PDraw _activePDraw = null;
		private IPluginFigure _activePlugin = null;
		private PluginManager _pluginManager = null;

		public XCommand()
		{
			_pluginManager = new PluginManager();
		}


		public PDraw ActivePDraw
		{
			set
			{
				_activePDraw = value;
				_activePlugin.ActiveFigure = _activePDraw.ActiveFigure;
			}
		}

		public IPluginFigure ActivePlugin { set => _activePlugin = value; }        
        public List<IPluginFigure> FigurePlugins { get => _pluginManager.figurePlugins; }

		

		int dCalls = 0;
		public void Debug()
		{
			System.Diagnostics.Debug.WriteLine("debug" + dCalls++);
			if (dCalls % 2 == 1)
				Localization.Locale = "ru";
			else
				Localization.Locale = "en";
		}

		public PFigure PluginProcess(PFigure figure)
		{
			if (_activePlugin == null)
				return figure;
			return _activePlugin.Process(figure);
		}

		
	}
}
