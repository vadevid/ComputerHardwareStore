using MagazinKompTechniki;
using Microsoft.EntityFrameworkCore.Design;

namespace MagazinKompTechnikiDLL
{
    class SampleContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            return new ApplicationContext(ApplicationContext.GetDB());
        }
    }
}
