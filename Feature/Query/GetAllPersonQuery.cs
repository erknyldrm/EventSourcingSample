namespace EventSourcingSample.Feature.Query
{
    class GetAllPersonQueryRequest
    {

    }

    class GetAllPersonQueryHandler
    {
        public List<GetAllPersonQueryResponse> GetAll(GetAllPersonQueryRequest request)
        {
            return PersonSource.PersonList.Select(person => new GetAllPersonQueryResponse
            {
                Id = person.Id,
                Age = person.Age,
                Name = person.Name
            }).ToList();
        }
    }

    class GetAllPersonQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
