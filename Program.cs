using EventSourcingSample.Event;
using EventSourcingSample.Feature.Command;
using EventSourcingSample.Feature.Query;

EventBroker eventBroker = new();
eventBroker.Command(new CreatePersonCommandRequest { Id = 5, Age = 21, Name = "Muiddin" });
eventBroker.Command(new CreatePersonCommandRequest { Id = 6, Age = 44, Name = "Fadiş" });
eventBroker.Command(new ChangeAgePersonCommandRequest { Id = 2, Age = 55 });
eventBroker.Command(new ChangeAgePersonCommandRequest { Id = 2, Age = 66 });
eventBroker.Command(new ChangeNamePersonCommandRequest { Id = 3, Name = "Serdar" });
eventBroker.WriteAllEvent();
eventBroker.Query(new GetAllPersonQueryRequest());
eventBroker.Query(new GetPersonQueryRequest() { Id = 3 });


Console.WriteLine("Event Sourcing Sample!");
