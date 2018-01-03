using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace AMSRSE.Editor.Effects
{
	public class OverlayEffect : BlendModeEffect
	{
		static OverlayEffect()
		{
			_pixelShader.UriSource = new Uri("pack://application:,,,/AMSRSE.Editor;component/Effects/OverlayEffect.ps", UriKind.Absolute);
		}

		public OverlayEffect()
		{
			this.PixelShader = _pixelShader;
		}

		private static PixelShader _pixelShader = new PixelShader();
	}
}
