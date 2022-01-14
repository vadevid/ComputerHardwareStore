using MagazinKompTechniki;

namespace MagazinKompTechnikiDLL
{
    static class Context
    {
        public static ApplicationContext Db
        { get; private set; }
        internal static void AddDb(ApplicationContext application)
        {
            Db = application;
        }
    }
}
