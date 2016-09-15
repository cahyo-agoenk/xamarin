using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Qrawd_web;
using Qrawd_web.Droid;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Text.Method;
using XLabs.Forms.Extensions;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace Qrawd_web.Droid
{
    public class MyEntryRenderer: EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            var view = (MyEntry)Element;
            if (Control != null) {
                try {
                    if (view.TextColor != null){
                        int ta = int.Parse(Math.Floor(view.TextColor.A < 0 ? 255 : view.TextColor.A * 255).ToString());
                        int tr = int.Parse(Math.Floor(view.TextColor.R < 0 ? 0 : view.TextColor.R * 255).ToString());
                        int tg = int.Parse(Math.Floor(view.TextColor.G < 0 ? 0 : view.TextColor.G * 255).ToString());
                        int tb = int.Parse(Math.Floor(view.TextColor.B < 0 ? 0 : view.TextColor.B * 255).ToString());
                        var tclr = view.TextColor == Xamarin.Forms.Color.Default ? Android.Graphics.Color.Black : Android.Graphics.Color.Argb(ta, tr, tg, tb);
                        Control.SetTextColor(tclr);
                        Control.SetHighlightColor(tclr);
                    }

                    if (view.PlaceholderTextColor != null){
                        int pa = int.Parse(Math.Floor(view.PlaceholderTextColor.A < 0 ? 255 : view.PlaceholderTextColor.A * 255).ToString());
                        int pr = int.Parse(Math.Floor(view.PlaceholderTextColor.R < 0 ? 0 : view.PlaceholderTextColor.R * 255).ToString());
                        int pg = int.Parse(Math.Floor(view.PlaceholderTextColor.G < 0 ? 0 : view.PlaceholderTextColor.G * 255).ToString());
                        int pb = int.Parse(Math.Floor(view.PlaceholderTextColor.B < 0 ? 0 : view.PlaceholderTextColor.B * 255).ToString());
                        var pclr = view.PlaceholderTextColor == Xamarin.Forms.Color.Default ? Android.Graphics.Color.Black : Android.Graphics.Color.Argb(pa, pr, pg, pb);
                        Control.SetHintTextColor(pclr);
                    }

                    if (e.NewElement.IsPassword)
                        Control.TransformationMethod = new PasswordTransformationMethod();

                    Drawable draw = null;
                    switch (view.BorderColor)
                    {
                        case MyBorderColor.Black:
                            draw = ResourceManager.GetDrawable(this.Resources, "TextViewLine_Black.xml");
                            break;
                        case MyBorderColor.White:
                            draw = ResourceManager.GetDrawable(this.Resources, "TextViewLine_White.xml");
                            break;
                        case MyBorderColor.Gray:
                            draw = ResourceManager.GetDrawable(this.Resources, "TextViewLine_Gray.xml");
                            break;
                        default:
                            draw = ResourceManager.GetDrawable(this.Resources, "TextViewLine_Black.xml");
                            break;
                    }
                    draw.SetBounds((int)view.Bounds.Left, (int)view.Bounds.Top, (int)view.Bounds.Right, (int)view.Bounds.Bottom);
                    Control.SetBackground(draw);

                    if(view.Placeholder!=null)
                        Control.Hint = view.Placeholder;

                    if (view.XAlign == Xamarin.Forms.TextAlignment.Center)
                        Control.Gravity = GravityFlags.Bottom | GravityFlags.CenterHorizontal;
                    else if (view.XAlign == Xamarin.Forms.TextAlignment.Start)
                        Control.Gravity = GravityFlags.Bottom | GravityFlags.Start;
                    else if (view.XAlign == Xamarin.Forms.TextAlignment.End)
                        Control.Gravity = GravityFlags.Bottom | GravityFlags.End;
                    else
                        Control.Gravity = GravityFlags.CenterVertical | GravityFlags.Start;
                } catch (Exception ex) {
                    System.Diagnostics.Debug.Write("Android - " + ex.Message);
                }
            }

            SetFont(view);
        }

        private void SetFont(MyEntry view)
        {
            try {
                Control.Typeface = Typeface.CreateFromAsset(Forms.Context.Assets, "fonts/GothamRounded-Book.otf");
            } catch (Exception ex) {
                System.Diagnostics.Debug.Write("Android - " + ex.Message);
                Control.Typeface = Typeface.Default;
            }
        }
    }
}