using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
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
            Configuration configuration = CreateConfiguration();
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            IEnumerable<Klient> klients = null;
            using (var session = sessionFactory.OpenSession())
            {
                var query = from klient in session.Query<Klient>().FetchMany(klient => klient.Adresy)
                            orderby klient.Name
                            select klient;
                klients = query.BezStornovanych().ToArray();
            }

            Console.WriteLine(klients);
        }

        [Test]
        public void CreateDb()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "db.sdf");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            var en = new SqlCeEngine("Data Source=|DataDirectory|db.sdf");
            en.CreateDatabase();
            Configuration configuration = CreateConfiguration();
            new SchemaExport(configuration).Execute(true, true, false);

            Console.WriteLine(configuration);
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