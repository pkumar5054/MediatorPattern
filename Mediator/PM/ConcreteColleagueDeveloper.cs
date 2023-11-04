using Mediator.Simplified;
using System;

namespace Mediator.PM
{
    /// <summary>
    /// Concrete Colleague Developer
    /// </summary>
    public class ConcreteColleagueDeveloper : AbstractColleagueMember
    {
        public ConcreteColleagueDeveloper(string name) : base(name)
        {
        }

        public override void HandleNotification(string from, string message)
        {
            Console.WriteLine($"{Name} Notified: {message}");
        }
    }

}
