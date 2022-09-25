namespace EventSourcingSample.Feature.Command
{
    class ChangeNamePersonCommandRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class ChangeNamePersonCommandHandler
    {
        public ChangeNamePersonCommandResponse ChangeName(ChangeNamePersonCommandRequest request)
        {
            Person person = PersonSource.PersonList.FirstOrDefault(p => p.Id == request.Id);
            string oldName = person.Name;
            person.ChangeName(request.Name);
            return new ChangeNamePersonCommandResponse
            {
                OldName = oldName,
                Person = person
            };
        }
    }
    class ChangeNamePersonCommandResponse
    {
        public string OldName { get; set; }
        public Person Person { get; set; }
    }
}
