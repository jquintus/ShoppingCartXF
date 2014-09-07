using Autofac;
using ShoppingCart.Services;
using ShoppingCart.WinPhone.Services;

namespace ShoppingCart.WinPhone
{
    public class WinPhoneSetup : AppSetup
    {
        protected override void RegisterDepenencies(ContainerBuilder cb)
        {
            base.RegisterDepenencies(cb);

            cb.RegisterType<WinPhoneLogger>().As<ILogger>().SingleInstance();
            cb.RegisterType<WinPhoneScanner>().As<IScanner>().SingleInstance();
            cb.RegisterType<WinPhoneThemer>().As<IThemer>().SingleInstance();
        }
    }
}