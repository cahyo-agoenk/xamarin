using System;
using Xamarin.Forms;
using Qrawd_web;
using Qrawd_web.Droid;
using Xamarin.Forms.Platform.Android;
using Android.Text;
using Android.Views;
using Android.Graphics;

[assembly: ExportRenderer(typeof(MyLabel), typeof(MyLabelRenderer))]
namespace Qrawd_web.Droid
{
    public class MyLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (Control != null) {
                //this.Control.SetMaxLines(1);
                //this.Control.SetSingleLine(true);
                //this.Control.Ellipsize = TextUtils.TruncateAt.End;
                //this.Control.Gravity = GravityFlags.Top|GravityFlags.Left;
            }
            try {
                this.Control.Typeface = Typeface.CreateFromAsset(Forms.Context.Assets, "fonts/GothamRounded-Book.otf");  // font name specified here
                System.Diagnostics.Debug.WriteLine("ANDROID_Label - Font Family Set To: GothamRounded-Book.");
            } catch (System.Exception) {
                Typeface font = Typeface.Create(Typeface.SansSerif, TypefaceStyle.Normal);  // font name specified here
                this.Control.Typeface = font;
                System.Diagnostics.Debug.WriteLine("ANDROID_Label - Fonts/gotham-rounded-book.otf Not Found.");
                System.Diagnostics.Debug.WriteLine("ANDROID_Label - Font Family Set To: SansSerif.");
            }
        }
    }
}