using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShoppingCart.Async
{
    public static class AsyncImageSource
    {
        public static NotifyTaskCompletion<ImageSource> FromTask(Task<ImageSource> task, ImageSource defaultSource)
        {
            return new NotifyTaskCompletion<ImageSource>(task, defaultSource);
        }

        public static NotifyTaskCompletion<ImageSource> FromUriAndResource(string uri, string resource)
        {
            var u = new Uri(uri);
            return FromUriAndResource(u, resource);
        }

        public static NotifyTaskCompletion<ImageSource> FromUriAndResource(Uri uri, string resource)
        {
            var t = Task.Run(() => ImageSource.FromUri(uri));
            var defaultResouce = ImageSource.FromResource(resource);

            return FromTask(t, defaultResouce);
        }
    }
}