namespace EventSourcingSample.Feature.Command
{
    class CreatePersonCommandRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class CreatePersonCommandHandler
    {
        public CreatePersonCommandResponse CreatePerson(CreatePersonCommandRequest request)
        {
            PersonSource.PersonList.Add(new Person(request.Id, request.Name, request.Age));
            return new CreatePersonCommandResponse
            {
                Person = PersonSource.PersonList.Last()
            };
        }
    }

    class CreatePersonCommandResponse
    {
        public Person Person { get; set; }
    }
}
