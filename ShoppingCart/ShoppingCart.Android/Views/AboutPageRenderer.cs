using Android.App;
using Android.Views;
using Android.Widget;
using ShoppingCart.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms.Platform.Android;

namespace ShoppingCart.Droid.Views
{
    public class AboutPageRenderer : PageRenderer
    {
        private Android.Views.View view;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Page> e)
        {
            base.OnElementChanged(e);

            AboutViewModel viewModel = App.AboutViewModel;
            var activity = this.Context as Activity;
            view = activity.LayoutInflater.Inflate(Resource.Layout.AboutLayout, this, false);

            var blogButton = view.FindViewById<Button>(Resource.Id.button_blog);
            var codeButton = view.FindViewById<Button>(Resource.Id.button_code);

            blogButton.Click += (sender, ev) => viewModel.OpenUrlCommand.Execute(viewModel.BlogUrl);
            codeButton.Click += (sender, ev) => viewModel.OpenUrlCommand.Execute(viewModel.CodeUrl);
            AddView(view);
        }

        /// <summary>
        /// Ensure that the view covers the entire screen
        /// </summary>
        /// <param name="changed"></param>
        /// <param name="l">Left</param>
        /// <param name="t">Top</param>
        /// <param name="r">Right</param>
        /// <param name="b">Bottom</param>
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);
            view.Measure(msw, msh);
            view.Layout(0, 0, r - l, b - t);
        }
    }
}