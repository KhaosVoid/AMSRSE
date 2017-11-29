using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace AMSRSE.Editor.Effects
{
	public class BlendModeEffect : ShaderEffect
	{
		public BlendModeEffect()
		{
			UpdateShaderValue(InputProperty);
			UpdateShaderValue(TextureProperty);
		}

		public Brush Input
		{
			get { return (Brush)GetValue(InputProperty); }
			set { SetValue(InputProperty, value); }
		}
		public static readonly DependencyProperty InputProperty =
			ShaderEffect.RegisterPixelShaderSamplerProperty
			(
				"Input",
				typeof(BlendModeEffect),
				0
			);

		public Brush Texture
		{
			get { return (Brush)GetValue(TextureProperty); }
			set { SetValue(TextureProperty, value); }
		}
		public static readonly DependencyProperty TextureProperty =
			ShaderEffect.RegisterPixelShaderSamplerProperty
			(
				"Texture",
				typeof(BlendModeEffect),
				1
			);
	}
}
