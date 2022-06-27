using System;

namespace Abstract_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager=new ProductManager(new Factory1());
            productManager.GetAll();
            Console.ReadLine();
        }
    }
    public abstract class Logging
    {
        public abstract void Log(string message);
    }
    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with log4net"); 
        }
    }
    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with nLoggger");
        }
    }
    public abstract class Caching
    {
        public abstract void Cache(string data);
    }
    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with MemCache"); 
        }
    }
    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with Redis");
        }
    }
    public abstract class CrossingCuttingConcernsFactory1
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }
    public class Factory1 : CrossingCuttingConcernsFactory1
    {
        public override Caching CreateCaching()
        {
            return new MemCache();
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
    }
    public class Factory2 : CrossingCuttingConcernsFactory1
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }
    public class ProductManager
    {
        private CrossingCuttingConcernsFactory1 _crossingCuttingConcernsFactory1;
        private Logging _logging;
        private Caching _caching;
        public ProductManager(CrossingCuttingConcernsFactory1 crossingCuttingConcernsFactory1)
        {
            _crossingCuttingConcernsFactory1 = crossingCuttingConcernsFactory1;
            _logging = _crossingCuttingConcernsFactory1.CreateLogger();
            _caching = _crossingCuttingConcernsFactory1.CreateCaching();
        }

        public void GetAll()
        {
            _logging.Log("Logged");
            _caching.Cache("Data");
            Console.WriteLine("Products listed!");
        }
    }

}
