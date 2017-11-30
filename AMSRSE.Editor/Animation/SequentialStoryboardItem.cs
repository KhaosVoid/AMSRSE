using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.Editor.Animation
{
    public abstract class SequentialStoryboardItem : DependencyObject
    {
        #region Enums

        public enum AnimationStates
        {
            Animating, Stopped, Paused
        }

        #endregion Enums

        #region Dependency Properties

        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(SequentialStoryboardItem));

        public static readonly DependencyProperty IndexProperty =
            DependencyProperty.Register("Index", typeof(uint), typeof(SequentialStoryboardItem));

        public static readonly DependencyPropertyKey AnimationStatePropertyKey =
            DependencyProperty.RegisterReadOnly("AnimationState", typeof(AnimationStates), typeof(SequentialStoryboardItem), new PropertyMetadata(AnimationStates.Stopped));

        public static readonly DependencyProperty AnimationStateProperty =
            AnimationStatePropertyKey.DependencyProperty;

        #endregion Dependency Properties

        #region Properties

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public uint Index
        {
            get { return (uint)GetValue(IndexProperty); }
            set { SetValue(IndexProperty, value); }
        }

        public AnimationStates AnimationState
        {
            get { return (AnimationStates)GetValue(AnimationStateProperty); }
            protected set { SetValue(AnimationStatePropertyKey, value); }
        }

        #endregion Properties

        #region Members

        //protected bool isStartOne;

        #endregion Members

        #region Events

        public delegate void StartedHandler(SequentialStoryboardItem ssbi);
        public event StartedHandler Started;

        public delegate void PausedHandler(SequentialStoryboardItem ssbi);
        public event PausedHandler Paused;

        public delegate void StoppedHandler(SequentialStoryboardItem ssbi);
        public event StoppedHandler Stopped;

        public delegate void CompletedHandler(SequentialStoryboardItem ssbi);
        public event CompletedHandler Completed;

        #endregion Events

        #region Ctor

        public SequentialStoryboardItem()
        {

        }

        #endregion Ctor

        #region Methods

        protected void RaiseCompletedEvent()
        {
            AnimationState = AnimationStates.Stopped;
            Completed?.Invoke(this);
        }

        public virtual void Start()
        {
            AnimationState = AnimationStates.Animating;
            Started?.Invoke(this);
        }

        //public virtual void StartOne(uint index)
        //{
        //    isStartOne = true;
        //    AnimationState = AnimationStates.Animating;
        //    Started?.Invoke();
        //}

        public virtual void Pause()
        {
            AnimationState = AnimationStates.Paused;
            Paused?.Invoke(this);
        }

        public virtual void Stop()
        {
            //isStartOne = false;
            AnimationState = AnimationStates.Stopped;
            Stopped?.Invoke(this);
        }

        #endregion Methods
    }
}
