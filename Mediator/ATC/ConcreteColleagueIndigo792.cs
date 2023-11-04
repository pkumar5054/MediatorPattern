using Mediator.Simplified;
using System;

namespace Mediator.ATC
{
    /// <summary>
    /// Concrete Colleague Indigo792
    /// </summary>
    public class ConcreteColleagueIndigo792 : AbstractColleagueMember
    {
        public ConcreteColleagueIndigo792(string name) : base(name)
        {
        }

        public override void HandleNotification(string from, string message)
        {          
            Console.WriteLine($"{Name} Notified: Flight#-{from},{message}");
        }
    }

}
