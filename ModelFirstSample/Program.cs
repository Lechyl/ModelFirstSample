using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirstSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var database = new BloggingContent())
            {


                start:

                Console.WriteLine("Type [Delete] for Delete Options | Type [1] for reading a specific Blog | Type [2] for new Blog | Type [3] for Novel Options");
                var functions = Console.ReadLine();
                
                if(functions == "2") { 
                // Create and save a new Blog 
                Console.Write("\nEnter a name for a new Blog: ");
                var name = Console.ReadLine();

                Console.Write("Enter a new Url: ");
                var url = Console.ReadLine();

                var blog = new Blog { Name = name, Url = url };

                database.Blogs.Add(blog);

                database.SaveChanges();

                }
                // Display all Blogs from the database 



                var query = from b in database.Blogs
                            orderby b.Name
                            select b;

                var queryNovel = from a in database.Novels
                                 orderby a.Name
                                 select a;


                if (functions == "Delete")
                {
                    retry1:
                    Console.WriteLine("[1] Delete blogs data | [2] Delete specific blog data | [3] Delete Novels Data | [4] Delete specific Novel data | [5] Delete all data");
                    var deleteData = Console.ReadLine();
                    if (deleteData == "1")
                    {
                        foreach (var item in query)
                        {
                            database.Blogs.Remove(item);

                        }
                    }
                    else if(deleteData == "2")
                    {
                        Console.Write("\nThe Name of the Specific Blog :");
                        var deleteSpecificBlog = Console.ReadLine();
                        foreach(var item in query)
                        {
                            if(deleteSpecificBlog == item.Name)
                            {
                                database.Blogs.Remove(item);
                            }
                        }
                    }
                    else if (deleteData == "3")
                    {
                        
                        foreach (var item in queryNovel)
                        {
                            database.Novels.Remove(item);

                        }
                    }
                    else if (deleteData == "4")
                    {
                        Console.Write("\nThe Name of the Specific Blog :");
                        var deleteSpecificNovel = Console.ReadLine();
                        foreach (var item in queryNovel)
                        {
                            if (deleteSpecificNovel == item.Name)
                            {
                                database.Novels.Remove(item);
                            }
                        }
                    }
                    else if (deleteData == "5")
                    {
                        foreach (var item in queryNovel)
                        {
                            database.Novels.Remove(item);

                        }

                        foreach (var item in query)
                        {
                            database.Blogs.Remove(item);

                        }

                    }
                    else
                    {
                        Console.WriteLine("Wrong character\n\n");
                        goto retry1;
                    }
                    database.SaveChanges();
                }



                if(functions == "1")
                {
                    Console.Write("Name of the blog? ");
                    var specificBlog = Console.ReadLine();
                    Console.WriteLine("\n\n");

                    foreach (var item in query)
                    {
                        if(specificBlog == item.Name)
                        {
                            Console.WriteLine("Name of Blog : " + item.Name);
                            Console.WriteLine("Url of Blog : " + item.Url);
                            Console.WriteLine("\n\n\n");
                        }
                    }
                }

                if(functions ==  "1" || functions == "2")
                { 
                      Console.WriteLine("All blogs in the database:");
                      foreach (var item in query)
                      {
                          Console.WriteLine(item.Name);
                      }
                }
                if (functions == "3")
                {
                    int novelChapter;
                    Console.Write("Type [1] for listing new novels, Type [2] for finding specific novel, Type any Characters for Novels Overview :");
                    var type = Console.ReadLine();

                    if(type == "1")
                    {
                        Console.Write("The Name of the New Novel :");
                        var novelName = Console.ReadLine();

                        Retry:
                        Console.Write("The Number of Chapters released :");

                        if (!Int32.TryParse(Console.ReadLine(), out novelChapter))
                        {
                            Console.WriteLine("The Chapter wasn't in right format, please try again");
                            goto Retry;
                        }

                        Console.Write("The Genres of the Novel :");
                        var novelGenre = Console.ReadLine();

                        var novel = new Novel { Name = novelName, Chapters = novelChapter, Genre = novelGenre };

                        database.Novels.Add(novel);
                        database.SaveChanges();
                    }
                    else if (type == "2")
                    {
                        Console.Write("The Name of specific Novel :");
                        var specificNovel = Console.ReadLine();

                        foreach(var item in queryNovel)
                        {
                            if(specificNovel == item.Name)
                            {
                                Console.WriteLine(Environment.NewLine + item.Name);
                                Console.WriteLine("Chapters : "+ item.Chapters);
                                Console.WriteLine("Genre : " +item.Genre);
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Novels Overview \n___________________________________");
                    }

                    Console.WriteLine("\nAll Novels in the database:");
                    foreach (var item in queryNovel)
                    {
                        Console.WriteLine(item.Name);
                    }
                    Console.WriteLine("\n\n");
                }

                goto start;
            }
            
        }
    }

}
