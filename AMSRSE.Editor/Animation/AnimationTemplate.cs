using AMSRSE.Editor.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media.Animation;

namespace AMSRSE.Editor.Animation
{
    [ContentProperty("Setters")]
    public class AnimationTemplate : Freezable
    {
        #region Dependency Properties

        public static readonly DependencyProperty SettersProperty =
            DependencyProperty.Register("Setters", typeof(XamlSafeObservableCollection<Setter>), typeof(AnimationTemplate));

        public static readonly DependencyProperty TemplateProperty =
            DependencyProperty.RegisterAttached("Template", typeof(AnimationTemplate), typeof(AnimationTemplate), new PropertyMetadata(null, OnAnimationTemplatePropertyChanged/*, CoerceAnimationTemplateProperty*/));

        #endregion Dependency Properties

        #region Properties

        public XamlSafeObservableCollection<Setter> Setters
        {
            get { return (XamlSafeObservableCollection<Setter>)GetValue(SettersProperty); }
            set { SetValue(SettersProperty, value); }
        }

        #endregion Properties

        #region Members

        private bool _templateApplied;

        #endregion Members

        #region Ctor

        public AnimationTemplate()
        {
            Setters = new XamlSafeObservableCollection<Setter>();
        }

        public AnimationTemplate(XamlSafeObservableCollection<Setter> setters)
        {
            Setters = setters;
        }

        #endregion Ctor

        #region Dependency Property Callbacks

        private static void OnAnimationTemplatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Timeline anim && e.NewValue is AnimationTemplate at)
            {
                for (int i = 0; i < at.Setters.Count; i++)
                    anim.SetValue(at.Setters[i].Property, at.Setters[i].Value);

                at._templateApplied = true;
            }
        }

        private static object CoerceAnimationTemplateProperty(DependencyObject d, object value)
        {
            AnimationTemplate animTemplate = null;

            if (value is AnimationTemplate at)
            {
                if (DesignerProperties.GetIsInDesignMode(d))
                    return at;

                else
                {
                    //animTemplate = at.Clone() as AnimationTemplate;
                    //animTemplate.Freeze();
                }
            }

            return animTemplate;
        }

        #endregion Dependency Property Callbacks

        #region Attached Property Methods

        public static AnimationTemplate GetTemplate(Timeline obj)
        {
            return (AnimationTemplate)obj.GetValue(TemplateProperty);
        }

        public static void SetTemplate(Timeline obj, AnimationTemplate value)
        {
            obj.SetValue(TemplateProperty, value);
        }

        #endregion Attached Property Methods

        #region Methods

        protected override Freezable CreateInstanceCore()
        {
            var at = new AnimationTemplate(Setters);

            return at;
        }

        #endregion Methods
    }
}
