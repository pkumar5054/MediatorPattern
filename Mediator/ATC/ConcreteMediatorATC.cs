using Mediator.Simplified;

namespace Mediator.ATC
{


    /// <summary>
    /// Concrete Mediator Project Manager
    /// </summary>
    public class ConcreteMediatorATC : IMediator
    {
        private readonly Dictionary<string, AbstractColleagueMember> members = new();

        public void RegisterMember(AbstractColleagueMember member)
        {
            member.SetMediator(this);
            if (!members.ContainsKey(member.Name))
            {
                members.Add(member.Name, member);
            }
        }

        public void Broadcast(string from, string message)
        {
            Console.WriteLine($"*** {GetType().Name} Notified for Boradcast Message: Flight#-{from}, {message} ***");

            Console.WriteLine($"BroadCasting now to all flights scheduled to land in next 30 minutes");


            foreach (var member in members.Values)
            {
                if (member.Name != from)
                {
                    Thread.Sleep(3000);
                    member.HandleNotification(from, message);
                }
            }
        }

        public void SendTo<T>(string from, string message) where T : AbstractColleagueMember
        {           
            foreach (var member in members.Values.OfType<T>())
            {
                Console.WriteLine($"*** {GetType().Name} is notfied by Flight#-{from}, to inform {member.Name}: '{message}' ***");              
                member.HandleNotification(from, message);
            }
        }
    }

}
