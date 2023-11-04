using Mediator.Simplified;
using System;

namespace Mediator.PM
{
    /// <summary>
    /// Concrete Colleague Business Analyst
    /// </summary>
    public class ConcreteColleagueBusinessAnalyst : AbstractColleagueMember
    {
        public ConcreteColleagueBusinessAnalyst(string name) : base(name)
        {
        }

        public override void HandleNotification(string from, string message)
        {
            Console.WriteLine($"{Name} Notified: {message}");
        }
    }

}
