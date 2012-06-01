using System;
using System.Collections.Generic;
using System.Linq;
using Iesi.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using TestLanguage.Hibernate.Entity;

namespace TestLanguage.Hibernate
{
    [TestFixture]
    class TestNHibernate
    {
        [Test]
        public void Test()
        {
            ISession session = OpenSession();

            var qyery = from kl in session.Query<Klient>()
                        where kl.Adresy.All(adresa => adresa.Obec == "Praha")
                        select kl;

            if (true)
            {
                qyery = qyery.BezStornovanych();
            }

            var klients = qyery.ToArray();
            Console.WriteLine(klients);
        }

        [Test]
        public void CreateDb()
        {
            Configuration configuration = CreateConfiguration();
            new SchemaExport(configuration).Execute(true, true, false);
            using (ISession session = OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    //1
                    var klient = new Klient
                    {
                        Name = "Jan Novak",
                        Adresy = new HashedSet<Adresa>
                        {
                            new Adresa {Obec = "Praha", Psc = "12345", Ulice = "Vaclavska"}, 
                            new Adresa {Obec = "Brno", Psc = "45678", Ulice = "Moskevska"}
                        }
                    };
                    klient.Adresy.ForEach(adresa => adresa.Klient = klient);
                    session.Merge(klient);

                    //2
                    klient = new Klient
                    {
                        Name = "Lojza Mikula",
                        Adresy = new HashedSet<Adresa>
                        {
                            new Adresa {Obec = "Hradec Králové", Psc = "55555", Ulice = "Hradecká"},
                        }
                    };
                    klient.Adresy.ForEach(adresa => adresa.Klient = klient);
                    session.Merge(klient);

                    //3
                    klient = new Klient { Name = "Franta Bezdomova", Adresy = new HashedSet<Adresa>() };
                    klient.Adresy.ForEach(adresa => adresa.Klient = klient);
                    session.Merge(klient);

                    //4
                    klient = new Klient
                    {
                        Name = "Jozan Vyřazený",
                        DatumStornovani = new DateTime(2010, 10, 1),
                        Adresy = new HashedSet<Adresa>
                        {
                            new Adresa {Obec = "Praha", Psc = "78552", Ulice = "V Ulici"},
                        }
                    };
                    klient.Adresy.ForEach(adresa => adresa.Klient = klient);
                    session.Merge(klient);

                    transaction.Commit();
                }
            }
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