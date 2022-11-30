using System;

namespace Portfolio.Domain.AppCode.Infrastructure
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedTime { get; set; }= DateTime.UtcNow.AddHours(4);

        public DateTime? DeletedDate { get; set; }
    }
}
