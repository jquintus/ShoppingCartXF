using ShoppingCart.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.WinPhone.Services
{
    public class WinPhoneLogger : ILogger
    {
        public void Error(string message)
        {
            Console.WriteLine("ERROR:  " + message);
        }

        public void Error(string format, params object[] args)
        {
            Console.WriteLine("ERROR:  " + format, args);
        }

        public void Error(Exception ex, string message)
        {
            Console.WriteLine("ERROR:  " + message);
            Console.WriteLine(ex.ToString());
        }

        public void Error(Exception ex, string format, params object[] args)
        {
            Console.WriteLine("ERROR:  " + format, args);
            Console.WriteLine(ex.ToString());
        }

        public void Info(string message)
        {
            Console.WriteLine("INFO:  " + message);
        }

        public void Info(string format, params object[] args)
        {
            Console.WriteLine("INFO:  " + format, args);
        }

        public void Info(Exception ex, string message)
        {
            Console.WriteLine("INFO:  " + message);
            Console.WriteLine(ex.ToString());
        }

        public void Info(Exception ex, string format, params object[] args)
        {
            Console.WriteLine("INFO:  " + format, args);
            Console.WriteLine(ex.ToString());
        }
    }
}
