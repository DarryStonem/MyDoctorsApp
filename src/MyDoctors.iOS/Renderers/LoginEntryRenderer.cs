using System;
using System.ComponentModel;
using System.Drawing;
using MyDoctors.Controls;
using MyDoctors.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LoginEntry), typeof(LoginEntryRenderer))]
namespace MyDoctors.iOS.Renderers
{
    public class LoginEntryRenderer : EntryRenderer
    {
        #region Public Properties

        public LoginEntry LoginElement => Element as LoginEntry;

        #endregion

        public LoginEntryRenderer()
        {
        }

        protected override UITextField CreateNativeControl()
        {
            var control = new UITextField(RectangleF.Empty)
            {
                BorderStyle = UITextBorderStyle.RoundedRect,
                ClipsToBounds = true
            };

            UpdateBackground(control);

            return control;
        }

        protected void UpdateBackground(UITextField control)
        {
            if (control == null) return;
            control.Layer.CornerRadius = LoginElement.CornerRadius;
            control.Layer.BorderWidth = LoginElement.BorderThickness;
            control.Layer.BorderColor = LoginElement.BorderColor.ToCGColor();
        }
    }
}