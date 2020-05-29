using System;

namespace Section1Ex2
{
    public class Post
    {
        private string _title;
        private string _description;
        private readonly DateTime _timestamp;
        private int _upVote = 0;
        private int _downVote = 0;

        public int UpVote { get { return _upVote; } }

        public int DownVote { get { return _downVote; } }


        public Post(string title, string desc)
        {
            this._timestamp = DateTime.Now;
            this._title = title;
            this._description = desc;
        }


        public void ShowPost()
        {
            int divSize = Math.Max(this._title.Length + 7, this._description.Length + 9);
            string div1 = new String('=', divSize);
            string div2 = new String('-', divSize);
            Console.WriteLine("\n{0}", div1);
            Console.WriteLine("Title: {0}\n[Timestamp: {1}]", this._title, this._timestamp);
            Console.WriteLine("{0}", div2);
            Console.WriteLine("Comment: {0}", this._description);
            Console.WriteLine("{0}", div1);
        }


        public void Vote(string vote)
        {
            if (vote.ToLower() == "up") _upVote += 1;
            else if (vote.ToLower() == "down") _downVote += 1;
            else throw new Exception("Invalid Vote");
        }

    }

}
