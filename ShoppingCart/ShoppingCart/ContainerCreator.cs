using Autofac;
using ShoppingCart.Services;
using ShoppingCart.ViewModels;
using Xamarin.Forms;

namespace ShoppingCart
{
    /// <summary>
    /// Creates an instance of the AutoFac container
    /// </summary>
    /// <remarks>
    /// https://github.com/autofac/Autofac/wiki
    /// </remarks>
    public class ContainerCreator
    {
        public static IContainer CreateContainer()
        {
            ContainerBuilder cb = new ContainerBuilder();

            // Services
            cb.RegisterType<LoginService>().As<ILoginService>().SingleInstance();
            cb.RegisterType<ProductLoader>().As<IProductLoader>().SingleInstance();
            cb.RegisterType<ProductService>().As<IProductService>().SingleInstance();
            cb.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            cb.RegisterInstance(DependencyService.Get<IScanner>()).As<IScanner>().SingleInstance();

            // View Models
            cb.RegisterType<CategoriesListViewModel>().SingleInstance();
            cb.RegisterType<LoginViewModel>().SingleInstance();
            cb.RegisterType<ProductsListViewModel>().SingleInstance();
            cb.RegisterType<ProductViewModel>().SingleInstance();
            cb.RegisterType<WelcomeViewModel>().SingleInstance();

            return cb.Build();
        }
    }
}