using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace AMSRSE.Editor.Animation
{
    [MarkupExtensionReturnType(typeof(AnimationTemplate))]
    public class AnimationTemplateExtension : MarkupExtension
    {
        #region Properties

        public AnimationTemplate Template { get; set; }

        #endregion Properties

        #region Ctor

        public AnimationTemplateExtension(AnimationTemplate template)
        {
            Template = template;
        }

        #endregion Ctor

        #region Methods

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Template;
        }

        #endregion Methods
    }
}
