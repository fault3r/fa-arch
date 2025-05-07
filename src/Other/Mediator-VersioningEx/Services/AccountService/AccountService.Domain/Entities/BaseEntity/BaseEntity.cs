using System;

namespace AccountService.Domain.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this._insert = this._update = DateTime.UtcNow;
        }

        public required int Id { get; set; }

        public required DateTime _insert { get; set; }
        
        public required DateTime _update { get; set; }
    }
}