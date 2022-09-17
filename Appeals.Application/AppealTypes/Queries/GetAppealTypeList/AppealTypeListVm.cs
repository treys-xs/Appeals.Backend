using System.Collections.Generic;
using Appeals.Domain;

namespace Appeals.Application.AppealTypes.Queries.GetAppealTypeList
{
    public class AppealTypeListVm
    {
        public IList<AppealTypeDto> AppealTypes { get; set; }
    }
}
