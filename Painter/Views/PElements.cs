﻿using System.Windows.Forms;
using Painter.Controllers;
using System.Drawing;

namespace Painter.Views
{
	public class PElements : Panel
	{
		private XCommand _xCommand;

		public PElements(XCommand xCommand)
		{
			_xCommand = xCommand;

			int y = 50;
			RadioButton r = new RadioButton();
			r.Text = "Empty Figure";
			r.Location = new Point(10, y);
			r.Checked = true;
			y += 20;
			r.CheckedChanged += delegate
			{
				if (r.Checked)
					_xCommand.ActivePlugin = null;
			};
			Controls.Add(r);

			foreach (var plugin in PluginManager.figurePlugins)
			{
				RadioButton rb = plugin.GetElements();
				rb.Location = new Point(10, y);
				rb.CheckedChanged += delegate
				{
					if (rb.Checked)
						_xCommand.ActivePlugin = plugin;
				};
				y += 20;
				Controls.Add(rb);
			}
		}
	}
}
