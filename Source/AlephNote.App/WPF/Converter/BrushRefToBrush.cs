﻿using AlephNote.WPF.MVVM;
using AlephNote.Common.Themes;
using System.Windows.Media;
using System.Linq;
using System;
using System.Windows;
using AlephNote.WPF.Extensions;

namespace AlephNote.WPF.Converter
{
	class BrushRefToBrush : OneWayConverter<BrushRef, Brush>
	{
		protected override Brush Convert(BrushRef value, object parameter)
		{
			if (value.BrushType == BrushRefType.Solid)
			{
				var c = value.GradientSteps.First().Item2;
				return new SolidColorBrush(Color.FromArgb(c.A, c.R, c.G, c.B));
			}
			else if (value.BrushType == BrushRefType.Gradient_Vertical)
			{
				return new LinearGradientBrush()
				{
					StartPoint = new Point(0, 0),
					EndPoint   = new Point(0, 1),
					GradientStops = new GradientStopCollection(value.GradientSteps.Select(p => new GradientStop(p.Item2.ToWCol(), p.Item1))),
				};
			}
			else if (value.BrushType == BrushRefType.Gradient_Horizontal)
			{
				return new LinearGradientBrush()
				{
					StartPoint = new Point(0, 0),
					EndPoint   = new Point(1, 0),
					GradientStops = new GradientStopCollection(value.GradientSteps.Select(p => new GradientStop(p.Item2.ToWCol(), p.Item1))),
				};
			}
			else
			{
				throw new Exception("Unknown BrushRefType: " + value.BrushType);
			}
		}
	}
}
