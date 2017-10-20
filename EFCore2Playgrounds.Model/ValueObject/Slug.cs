using System.Text.RegularExpressions;

namespace EFCore2Playgrounds.Model.ValueObject
{
    public class Slug
    {
        public string Value { get; protected set; }

        private Slug() { }

        private Slug(string text)
        {
            Value = Parse(text);
        }

        public static Slug New(string text)
        {
            return new Slug(text);
        }

        private string Parse(string text)
        {
            var slug = text.ToLower();
            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");
            slug = Regex.Replace(slug, @"[\s-]+", " ").Trim();
            slug = slug.Substring(0, slug.Length).Trim();
            slug = Regex.Replace(slug, @"\s", "-");
            return slug;
        }

        public static implicit operator string(Slug slug)
        {
            return slug.Value;
        }

        public static explicit operator Slug(string value)
        {
            return new Slug(value);
        }
    }
}