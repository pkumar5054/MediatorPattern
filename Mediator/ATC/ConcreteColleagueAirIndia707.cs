using Mediator.Simplified;
using System;

namespace Mediator.ATC
{
    /// <summary>
    /// Concrete Colleague AirIndia707
    /// </summary>
    public class ConcreteColleagueAirIndia707 : AbstractColleagueMember
    {
        public ConcreteColleagueAirIndia707(string name) : base(name)
        {
        }

        public override void HandleNotification(string from, string message)
        {
            Console.WriteLine($"{Name} Notified: Flight#-{from},{message}");            
        }
    }

}
