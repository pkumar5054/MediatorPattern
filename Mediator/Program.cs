using Mediator.ATC;
using Mediator.PM;
using System;

using System.Configuration;

Console.Title = "Mediator Pattern";

string? mediatorType = ConfigurationManager.AppSettings["MediatorType"];

switch(mediatorType)
    {
        case "ATC":
            //Create an object for Concrete Mediator implmenting Interface IMediator
            ConcreteMediatorATC concreteMediatorATCManager = new();

            //Create an object Concrete Colleague for flight Indigo 792 derived from abstract class AbstractColleagueMember 
            var indigo792 = new ConcreteColleagueIndigo792("Indigo792");

            //Create an object Concrete Colleague for flight Air India 707 derived from abstract class AbstractColleagueMember 
            var airIndia707 = new ConcreteColleagueAirIndia707("AirIndia707");

            //Create an object Concrete Colleague for flight Spice Jet 592 derived from abstract class AbstractColleagueMember 
            var spiceJet592 = new ConcreteColleagueSpiceJet592("SpiceJet592");

            //Create an object Concrete Colleague for flight Air Asia 504 derived from abstract class AbstractColleagueMember 
            var airAsia504 = new ConcreteColleagueAirAsia504("AirAsia504");

            //Register the Colleague objects [indigo792, airIndia707, spiceJet592] with the Mediator [concreteMediatorATCManager]
            concreteMediatorATCManager.RegisterMember(indigo792);
            concreteMediatorATCManager.RegisterMember(airIndia707);
            concreteMediatorATCManager.RegisterMember(spiceJet592);
            concreteMediatorATCManager.RegisterMember(airAsia504);

            //Broadcast Message via ATC Mediator
            indigo792.Send("Attention Please!! Ready to land  on runway 001 @ 12:15 hrs.");
            Console.WriteLine("---");
            Thread.Sleep(5000);

            //Specific Member Message to Flight#: AirIndia707 from Flight#: Indigo792
            indigo792.SendTo<ConcreteColleagueAirIndia707>("Landed on the runway 001. All clear for landing.");
            Console.WriteLine("---");
            Thread.Sleep(5000);

            //Specific Member Message to Flight#: SpiceJet592 from Flight#: Indigo792
            indigo792.SendTo<ConcreteColleagueSpiceJet592>("Parked at bay #5.");
            Console.WriteLine("---");
            Thread.Sleep(5000);

            //Specific Member Message to Flight#: AirAsia504 from Flight#: Indigo792
            indigo792.SendTo<ConcreteColleagueAirAsia504>("Passengers off boarding, will clear the bay #5 by 13:00 hrs.");

        break;
        case "PM":
            //Create an object for Concrete Mediator implmenting Interface IMediator
            ConcreteMediatorProjectManager concreteMediatorProjectManager = new();

            var asis = new ConcreteColleagueDeveloper("Asis");
            var muneesh = new ConcreteColleagueDeveloper("Muneesh");
            var rajesh = new ConcreteColleagueTeamLead("Rajesh");
            var vinod = new ConcreteColleagueBusinessAnalyst("Vinod");
            var jampala = new ConcreteColleagueDeveloper("Jampala");

            concreteMediatorProjectManager.RegisterMember(asis);
            concreteMediatorProjectManager.RegisterMember(muneesh);
            concreteMediatorProjectManager.RegisterMember(rajesh);
            concreteMediatorProjectManager.RegisterMember(vinod);
            concreteMediatorProjectManager.RegisterMember(jampala);

            //Broadcast Message via Project Manager Mediator to get the Design Document from the Business Analyst
            rajesh.Send("Vinod, Please can we get the latest Design Document for phase-1 implementation ?");
            Console.WriteLine("---");
            Thread.Sleep(5000);

            //Broadcast Message via Project Manager Mediator to get let the Tech Lead and Team know the status
            vinod.Send("It's under final review, will send in next 1hr !!");
            Console.WriteLine("---");
            Thread.Sleep(5000);

            //Specific Member Message to Flight#: SpiceJet592 from Flight#: Indigo792        
            vinod.SendTo<ConcreteColleagueTeamLead>("Please check your inbox send it across..thanks");                       
        break;

    default:
        Console.WriteLine("Please uncomment 'MediatorType' setting app.config");
        break;
}

Console.ReadKey();
