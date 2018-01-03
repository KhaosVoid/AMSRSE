using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace AMSRSE.Editor.Effects
{
	public class GlowEffect : BlendModeEffect
	{
		static GlowEffect()
		{
			_pixelShader.UriSource = new Uri("/AMSRSE.Editor;component/Effects/GlowEffect.ps", UriKind.Relative);
		}

		public GlowEffect()
		{
			this.PixelShader = _pixelShader;
		}

		private static PixelShader _pixelShader = new PixelShader();
	}
}
