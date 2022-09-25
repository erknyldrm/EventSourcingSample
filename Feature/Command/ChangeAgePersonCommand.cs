using System;

namespace EventSourcingSample.Feature.Command
{
    class ChangeAgePersonCommandRequest
    {
        public int Id { get; set; }
        public int Age { get; set; }
    }

    class ChangeAgePersonCommandHandler
    {
        public ChangeAgePersonCommandResponse ChangeAge(ChangeAgePersonCommandRequest request)
        {
            Person person = PersonSource.PersonList.FirstOrDefault(p => p.Id == request.Id);
            int oldAge = person.Age;
            person.ChangeAge(request.Age);
            return new ChangeAgePersonCommandResponse
            {
                OldAge = oldAge,
                Person = person
            };
        }
    }

    class ChangeAgePersonCommandResponse
    {
        public int OldAge { get; set; }
        public Person Person { get; set; }
    }
}
