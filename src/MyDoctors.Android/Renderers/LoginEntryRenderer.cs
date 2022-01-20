using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using MyDoctors.Controls;
using MyDoctors.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LoginEntry), typeof(LoginEntryRenderer))]
namespace MyDoctors.Droid.Renderers
{
    public class LoginEntryRenderer : EntryRenderer
    {
        #region Public Properties

        public LoginEntry LoginElement => Element as LoginEntry;

        #endregion

        public LoginEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginElement.CornerRadius))
            {
                UpdateBackground();
            }
            else if (e.PropertyName == nameof(LoginElement.BorderThickness))
            {
                UpdateBackground();
            }
            else if (e.PropertyName == nameof(LoginElement.BorderColor))
            {
                UpdateBackground();
            }

            base.OnElementPropertyChanged(sender, e);
        }

        protected override FormsEditText CreateNativeControl()
        {
            var control = base.CreateNativeControl();
            UpdateBackground(control);
            return control;
        }

        protected override void UpdateBackgroundColor()
        {
            UpdateBackground();
        }

        protected override void UpdateBackground()
        {
            UpdateBackground(Control);
        }

        private void UpdateBackground(FormsEditText control)
        {
            if (control == null)
                return;

            var gradientDrawable = new GradientDrawable();
            gradientDrawable.SetColor(Element.BackgroundColor.ToAndroid());
            gradientDrawable.SetCornerRadius(Context.ToPixels(LoginElement.CornerRadius));
            gradientDrawable.SetStroke((int)Context.ToPixels(LoginElement.BorderThickness), LoginElement.BorderColor.ToAndroid());
            control.SetBackground(gradientDrawable);
        }
    }
}