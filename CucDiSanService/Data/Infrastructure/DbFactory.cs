namespace CucDiSanService.Data.Infrastructure
{
    using System;
    public interface IDbFactory : IDisposable
    {
        CucDiSanDbContext Init();
    }
    public class DbFactory : Disposable, IDbFactory
    {
        private CucDiSanDbContext dbContext;

        public CucDiSanDbContext Init()
        {
            return dbContext ?? (dbContext = new CucDiSanDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
