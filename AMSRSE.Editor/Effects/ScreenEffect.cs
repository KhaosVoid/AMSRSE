using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace AMSRSE.Editor.Effects
{
	public class ScreenEffect : BlendModeEffect
	{
		static ScreenEffect()
		{
			_pixelShader.UriSource = new Uri("pack://application:,,,/AMSRSE.Editor;component/Effects/ScreenEffect.ps");
		}

		public ScreenEffect()
		{
			this.PixelShader = _pixelShader;
		}

		private static PixelShader _pixelShader = new PixelShader();
	}
}
