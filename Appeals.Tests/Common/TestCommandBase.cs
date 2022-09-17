using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appeals.Persistence;

namespace Appeals.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly AppealsDbContext Context;

        public TestCommandBase()
        {
            Context = AppealsContextFactory.Create();
        }

        public void Dispose()
        {
            AppealsContextFactory.Destroy(Context);
        }
    }
}
