namespace EFCore2Playgrounds.Model.ValueObject
{
    public class Post
    {
        public int Id { get; private set; }
        public Title Title { get; private set; }
        public Slug Slug { get; private set; }

        private Post() { }

        private Post(Title title)
        {
            Title = title;
            Slug = (Slug)title.Value;
        }

        public static Post New(Title title)
        {
            return new Post(title);
        }
    }
}
