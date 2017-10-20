namespace EFCore2Playgrounds.Model.OneToOne
{
    public class Author
    {
        public int Id { get; private set; }
        public Biography Biography { get; private set; }

        private Author() {}

        private Author(Biography biography)
        {
            Biography = biography;
        }

        public static Author New(Biography biography)
        {
            return new Author(biography);
        }
    }
}
