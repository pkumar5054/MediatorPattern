namespace Mediator.Simplified
{
    /// <summary>
    /// Abstract Colleague  Member
    /// </summary>
    public abstract class AbstractColleagueMember
    {
        private IMediator? _mediator;
        public string Name { get; set; }
        public AbstractColleagueMember(string name)
        {
            Name = name;
        }

        internal void SetMediator(IMediator mediator)
        {
            _mediator = mediator;
        }
       
        public void SendTo<T>(string message) where T : AbstractColleagueMember
        {
            _mediator?.SendTo<T>(Name, message);
        }

        public void Send(string message)
        {
            _mediator?.Broadcast(Name, message);
        }

        public virtual void HandleNotification(string from, string message)
        {
            System.Console.WriteLine($"Message {from} to {Name}: {message}");
        }
    }

}
