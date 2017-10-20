using System;

namespace EFCore2Playgrounds.Model.ValueObject
{
    public class Title
    {
        public string Value { get; protected set; }

        private Title() { }

        private Title(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            Value = value;
        }

        public static Title New(string value)
        {
            return new Title(value);
        }

        public static implicit operator string(Title title)
        {
            return title.Value;
        }

        public static explicit operator Title(string value)
        {
            return new Title(value);
        }
    }
}
