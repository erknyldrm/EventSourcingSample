namespace EventSourcingSample.Feature.Query
{
    class GetPersonQueryRequest
    {
        public int Id { get; set; }
    }

    class GetPersonQueryHandler
    {
        public GetPersonQueryResponse GetPerson(GetPersonQueryRequest request)
        {
            Person person = PersonSource.PersonList.FirstOrDefault(p => p.Id == request.Id);
            return new GetPersonQueryResponse
            {
                Person = person
            };
        }
    }

    class GetPersonQueryResponse
    {
        public Person Person;
    }
}
