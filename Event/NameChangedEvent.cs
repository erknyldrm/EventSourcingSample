namespace EventSourcingSample.Event
{
    class NameChangedEvent : IEvent
    {
        public Person Person { get; set; }
        public string oldName, newName;
        public NameChangedEvent(Person person, string oldName, string newName)
        {
            Person = person;
            this.oldName = oldName;
            this.newName = newName;
        }
        public override string ToString()
        => $"Id değeri {Person.Id} olan personelin adı değiştirilmiştir.\nEski adı : {oldName}\nYeni adı : {newName}";
    }
}
