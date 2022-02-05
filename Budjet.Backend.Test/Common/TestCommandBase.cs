using Budjet.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budjet.Backend.Test.Common
{
    public class TestCommandBase : IDisposable
    {
        protected readonly BudjetDbContext Context;

        public TestCommandBase()
        {
            Context = BudjetContextFactory.Create();
        }

        public void Dispose()
        {
            BudjetContextFactory.Destroy(Context);
        }
    }
}

