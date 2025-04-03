using System;

namespace AccountService.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this._insert = this._update = DateTime.UtcNow;
        }

        public Int32 Id { get; set; }

        public DateTime _insert { get; set; }

        public DateTime _update { get; set; }
    }
}