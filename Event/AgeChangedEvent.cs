namespace EventSourcingSample.Event
{
    class AgeChangedEvent : IEvent
    {
        public Person Person { get; set; }
        public int oldAge, newAge;

        public AgeChangedEvent(Person person, int oldAge, int newAge)
        {
            Person = person;
            this.oldAge = oldAge;
            this.newAge = newAge;
        }
        public override string ToString()
            => $"Id değeri {Person.Id} olan personelin yaşı değiştirilmiştir.\nEski yaş : {oldAge}\nYeni yaş : {oldAge}";
    }
}
