using System;
using System.Collections.Generic;

namespace Appeals.Domain
{
    public class AppealType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Appeal> Appeals { get; set; }
    }
}
