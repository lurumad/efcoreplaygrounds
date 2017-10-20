namespace EFCore2Playgrounds.Model.OneToOne
{
    public class Biography
    {
        public int Id { get; private set; }
        public string Text { get; private set; }

        private Biography() {}

        private Biography(string text)
        {
            Text = text;
        }

        public static Biography New(string text)
        {
            return new Biography(text);
        }
    }
}
