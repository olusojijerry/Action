namespace Actio.Common.Event{
    public class UserCreated : IEvent
    {
        public string Email { get; }
        public string Name { get; }

        public UserCreated()
        {
            
        }

        public UserCreated(string email, string name)
        {
            this.Email = email;
            this.Name = name;
        }
    }
}