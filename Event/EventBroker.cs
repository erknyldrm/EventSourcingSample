using EventSourcingSample.Feature.Command;
using EventSourcingSample.Feature.Query;

namespace EventSourcingSample.Event
{
    class EventBroker
    {
        public List<IEvent> allEvents = new();
        public event EventHandler<object> Commands;
        public event EventHandler<object> Queries;

        public EventBroker()
        {

            this.Commands += EventBroker_Commands;
            this.Queries += EventBroker_Queries;
        }

        private void EventBroker_Queries(object? sender, object query)
        {
            if (query is GetPersonQueryRequest req1)
            {
                GetPersonQueryHandler handler = new GetPersonQueryHandler();
                GetPersonQueryResponse response = handler.GetPerson(req1);
                Console.WriteLine($"Id\tName\tAge");
                Console.WriteLine($"{response.Person.Id}\t{response.Person.Name}\t{response.Person.Age}\n***********");
            }
            //Eğer gelen Query 'GetAllPersonQueryRequest' türündense
            else if (query is GetAllPersonQueryRequest req2)
            {
                GetAllPersonQueryHandler handler = new GetAllPersonQueryHandler();
                List<GetAllPersonQueryResponse> response = handler.GetAll(req2);
                Console.WriteLine($"Id\tName\tAge");
                response.ForEach(person => Console.WriteLine($"{person.Id}\t{person.Name}\t{person.Age}"));
                Console.WriteLine("***********");
            }
        }

        private void EventBroker_Commands(object? sender, object command)
        {
            if (command is ChangeAgePersonCommandRequest req1)
            {
                ChangeAgePersonCommandHandler handler = new();
                ChangeAgePersonCommandResponse response = handler.ChangeAge(req1);

                this.allEvents.Add(new AgeChangedEvent(response.Person, response.OldAge, req1.Age));
            }
            else if (command is ChangeNamePersonCommandRequest req2)
            {
                ChangeNamePersonCommandHandler handler = new ChangeNamePersonCommandHandler();
                ChangeNamePersonCommandResponse response = handler.ChangeName(req2);

                this.allEvents.Add(new NameChangedEvent(response.Person, response.OldName, req2.Name));
            }
            //Eğer gelen Command 'CreatePersonCommandRequest' türündense
            else if (command is CreatePersonCommandRequest req3)
            {
                CreatePersonCommandHandler handler = new CreatePersonCommandHandler();
                CreatePersonCommandResponse response = handler.CreatePerson(req3);

                this.allEvents.Add(new PersonCreatedEvent(response.Person));
            }
        }

        public void Command(object command) => Commands(this, command);

        public void Query(object query) => Queries(this, query);
        public void WriteAllEvent() => allEvents.ForEach(@event => Console.WriteLine($"{@event.ToString()}\n***********"));
    }
}
