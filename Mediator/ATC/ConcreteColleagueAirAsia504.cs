using Mediator.Simplified;
using System;

namespace Mediator.ATC
{
    /// <summary>
    /// Concrete Colleague AirAsia504
    /// </summary>
    public class ConcreteColleagueAirAsia504 : AbstractColleagueMember
    {
        public ConcreteColleagueAirAsia504(string name) : base(name)
        {
        }

        public override void HandleNotification(string from, string message)
        {
            Console.WriteLine($"{Name} Notified: Flight#-{from},{message}");           
        }
    }

}
