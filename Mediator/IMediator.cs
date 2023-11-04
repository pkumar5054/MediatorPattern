namespace Mediator.Simplified
{
    /// <summary>
    /// Abstraction for Mediator
    /// </summary>
    public interface IMediator
    {
        void RegisterMember(AbstractColleagueMember member);
        void Broadcast(string from, string message);      
        void SendTo<T>(string from, string message) where T : AbstractColleagueMember;
    }

}
