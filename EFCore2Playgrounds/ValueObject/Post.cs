using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore2Playgrounds.ValueObject
{
    public class Post
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public Slug Slug { get; private set; }

        private Post() { }

        private Post(string title)
        {
            Slug = (Slug)title;
        }

        public static Post New(string title)
        {
            return new Post(title);
        }
    }
}
