using System;

namespace Appeals.Domain
{
    public class Appeal
    {   
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }

        public Guid AppealTypeId { get; set; }
        public AppealType Type { get; set; }
    }
}
