using System;
using Warehouse.Persistence;


namespace Warehouse.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly WarehouseDbContext Context;

        public TestCommandBase()
        {
            Context = WarehouseContextFactory.Create();
        }

        public void Dispose()
        {
            WarehouseContextFactory.Destroy(Context);
        }
    }
}
