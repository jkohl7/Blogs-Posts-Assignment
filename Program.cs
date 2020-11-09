using System;
using NLog.Web;
using System.IO;
using System.Linq;

namespace BlogsConsole
{
    class Program
    {
        // create static instance of Logger
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
            logger.Info("Program started");

            string start = null;
                do{
            Console.WriteLine("1. Display blogs");
            Console.WriteLine("2. Add blog");
            Console.WriteLine("3. Create post");
            Console.WriteLine("4. Display posts");
            Console.WriteLine("Press enter to quit");
            start = Console.ReadLine();

            if (start == "1")
            {
                try
            {
                
                var db = new BloggingContext();
                // Display all Blogs from the database
                var query = db.Blogs.OrderBy(b => b.Name);

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            }else if (start == "2")
            {

             try
            {
                

                // Create and save a new Blog
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                var blog = new Blog { Name = name };

                var db = new BloggingContext();
                db.AddBlog(blog);
                logger.Info("Blog added - {name}", name);

                // Display all Blogs from the database
                var query = db.Blogs.OrderBy(b => b.Name);

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            logger.Info("Program ended");
            }else if (start == "3")
            {

            }else if (start == "4")
            {

            }

            }while (start == "1" || start == "2" || start == "3" || start == "4");
        }
    }
}
