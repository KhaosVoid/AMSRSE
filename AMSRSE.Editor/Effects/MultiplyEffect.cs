using System;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace AMSRSE.Editor.Effects
{
	public class MultiplyEffect : BlendModeEffect
	{
		static MultiplyEffect()
		{
			_pixelShader.UriSource = new Uri("/AMSRSE.Editor;component/Effects/MultiplyEffect.ps", UriKind.Relative);
		}

		public MultiplyEffect()
		{
			this.PixelShader = _pixelShader;
		}

		private static PixelShader _pixelShader = new PixelShader();
	}
}
