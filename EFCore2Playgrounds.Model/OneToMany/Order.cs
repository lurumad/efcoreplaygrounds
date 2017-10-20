namespace EFCore2Playgrounds.Model.OneToMany
{
    public class Order
    {
        public int Id { get; set; }
        internal int StateId;
        internal State _state;
        internal State State => _state;

        public Order()
        {
            StateId = State.Draft.Id;
        }

        public void Release()
        {
            StateId = State.Release.Id;
        }
    }
}