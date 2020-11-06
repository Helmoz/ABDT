using System;

namespace ProductsApp.Core.Entities
{
    public class UserSession : BaseEntity
    {
        public UserSession(Guid userId, DateTime visitDateTime)
        {
            UserId = userId;
            VisitDateTime = visitDateTime;
        }
        
        public Guid UserId { get; set; }

        public DateTime VisitDateTime { get; set; }
    }
}