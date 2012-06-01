using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using TestLanguage.Hibernate.Entity;
using NHibernate.Linq;

namespace TestLanguage.Hibernate
{
    [TestFixture]
    class TestNHibernate
    {
        [Test]
        public void Test()
        {
            IEnumerable<Klient> klients = null;
            using (ISession session = OpenSession())
            {
                var query = from klient in session.Query<Klient>()
                            where klient.Adresy.Any()
                            orderby klient.Name
                            select klient;
                klients = query.ToArray();
            }

            Console.WriteLine(klients);
        }

        [Test]
        public void CreateDb()
        {
//            string path = Path.Combine(Directory.GetCurrentDirectory(), "db.sdf");
//            if (File.Exists(path))
//            {
//                File.Delete(path);
//            }
//            var en = new SqlCeEngine(string.Format("Data Source={0}", path));
//            en.CreateDatabase();
            Configuration configuration = CreateConfiguration();
            new SchemaExport(configuration).Execute(true, true, false);

            Console.WriteLine(configuration);
        }


        private static ISession OpenSession()
        {
            Configuration configuration = CreateConfiguration();
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
        
        private static Configuration CreateConfiguration()
        {
            Configuration configuration = new Configuration().Configure();
            configuration.AddAssembly(typeof(Klient).Assembly);
            configuration.AddFile("hibernate.cfg.xml");
            return configuration;
        }
    }
}