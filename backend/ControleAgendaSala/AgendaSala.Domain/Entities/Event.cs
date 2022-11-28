
namespace AgendaSala.Domain.Entities
{
    public class Event
    {
        public virtual int Id { get; set; }
        public virtual DateTime EventDate { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual DateTime Duration { get; set; }
        public virtual Room Room { get; set; }
        public virtual User User { get; set; }

    }
}
