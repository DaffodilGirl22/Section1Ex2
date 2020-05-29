using System;
using System.Collections.Generic;

namespace Section1Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Dictionary<string, string> {
                        { "up", "Like Post" },
                        { "down", "DisLike Post" },
                        { "show", "Show Post Likes" },
                        { "quit", "Quit" }
            };

            Console.Write(">> Please input post title: ");
            var title = Console.ReadLine();
            Console.Write(">> Please input post comment: ");
            var desc = Console.ReadLine();
            
            var post = new Post(title, desc);
            post.ShowPost();

            bool doRun = true;
            while (doRun)
            {
                try
                {
                    var action = ListOptions(options);
                    if (action == "up" || action == "down") post.Vote(action);
                    else if (action == "show")
                    {
                        Console.WriteLine("\n--> Post Likes: {0}; Dislikes: {1}", post.UpVote, post.DownVote);
                    }
                    else if (action == "quit") doRun = false;
                    else Console.WriteLine(">> Unknown option - try again");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


        static string ListOptions(Dictionary<string,string> optlist)
        {
            var options = new List<string>();
            foreach (var d in optlist) options.Add(d.Key);

            Console.WriteLine("\n>> Please select option:");
            int idx = 0;
            foreach (var opt in optlist)
            {
                Console.WriteLine("{0,3}. {1}", idx+1, optlist[options[idx++]]);
            }
            return options[InputInteger("Input option number", 1, optlist.Count)-1];
        }


        public static int InputInteger(string text, int? min, int? max)
        {
            bool ok = false;
            int num = 0;
            string range;

            // Number range display
            if (min.HasValue && max.HasValue) { range = " (" + min + "-" + max + ")"; }
            else if (max.HasValue) { range = " (<=" + max + ")"; }
            else if (min.HasValue) { range = " (>=" + min + ")"; }
            else range = "";

            if (!min.HasValue) { min = int.MinValue; }
            if (!max.HasValue) { max = int.MaxValue; }

            if (string.IsNullOrEmpty(text)) { text = "Input an integer"; }
            while (!ok)
            {
                Console.Write("{0}{1}: ", text, range);
                string numstr = Console.ReadLine();
                ok = int.TryParse(numstr, out num);
                ok = (ok && num >= min && num <= max);
                if (!ok) Console.WriteLine("Invalid input - please try again");
            }
            return num;
        }
    }

}
