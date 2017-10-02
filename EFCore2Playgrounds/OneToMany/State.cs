using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore2Playgrounds.OneToMany
{
    public class State
    {
        public static State Draft = new State(1, nameof(Draft));
        public static State Staging = new State(2, nameof(Staging));
        public static State Release = new State(3, nameof(Release));
        public static State Processing = new State(4, nameof(Processing));
        public static State Delete = new State(5, nameof(Delete));

        public int Id { get; protected set; }
        public string Name { get; protected set; }

        protected State()
        {
            
        }

        public State(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static IReadOnlyCollection<State> GetStatus()
        {
            return new[] { Draft, Staging, Release, Processing, Delete };
        }

        public static State FindBy(int id)
        {
            var state = GetStatus().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new ArgumentOutOfRangeException($"Invalid id {id}");
            }

            return state;
        }
    }
}
