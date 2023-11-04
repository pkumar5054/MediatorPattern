using Mediator.Simplified;
using System;

namespace Mediator.ATC
{
    /// <summary>
    /// Concrete Colleague SpiceJet592
    /// </summary>
    public class ConcreteColleagueSpiceJet592 : AbstractColleagueMember
    {
        public ConcreteColleagueSpiceJet592(string name) : base(name)
        {
        }

        public override void HandleNotification(string from, string message)
        {
            Console.WriteLine($"{Name} Notified: Flight#-{from},{message}");           
        }
    }

}
