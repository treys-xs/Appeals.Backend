using System.Collections.Generic;

namespace Appeals.Application.Appeals.Queries.GetAppealList
{
    public class AppealListVm
    {
        public IList<AppealLookupDto> Appeals { get; set; }
    }
}
