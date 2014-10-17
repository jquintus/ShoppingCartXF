using Autofac;
using ShoppingCart.Droid.Services;
using ShoppingCart.Services;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(ShoppingCart.Views.AboutPage), typeof(ShoppingCart.Droid.Renderers.DroidAboutPageRenderer))]

namespace ShoppingCart.Droid
{
    public class DroidSetup : AppSetup
    {
        protected override void RegisterDepenencies(ContainerBuilder cb)
        {
            base.RegisterDepenencies(cb);

            cb.RegisterType<DroidLogger>().As<ILogger>().SingleInstance();
            cb.RegisterType<DroidScanner>().As<IScanner>().SingleInstance();
            cb.RegisterType<DroidThemer>().As<IThemer>().SingleInstance();
        }
    }
}