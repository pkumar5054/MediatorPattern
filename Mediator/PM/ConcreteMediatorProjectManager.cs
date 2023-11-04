using Mediator.Simplified;
using System.Collections.Generic;
using System.Linq;

namespace Mediator.PM
{


    /// <summary>
    /// Concrete Mediator Project Manager
    /// </summary>
    public class ConcreteMediatorProjectManager : IMediator
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
            Console.WriteLine($"*** {GetType().Name} Notified to broadcast Message from {from}: {message} ***");
            Thread.Sleep(2000);
            Console.WriteLine($"-- Broadcasting message to all Team Members --");

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
                Console.WriteLine($"*** {GetType().Name} is Notfied by {from}, to inform {member.Name}: '{message}' ***");
                member.HandleNotification(from, message);
            }
        }
    }

}
