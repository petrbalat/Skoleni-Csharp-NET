using System;
using System.Collections.Generic;
using System.Linq;
using Iesi.Collections.Generic;
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
                var query = from klient in session.Query<Klient>().FetchMany(klient => klient.Adresy)
                            orderby klient.Name
                            select klient;
                klients = query.ToArray();
            }

            klients.ForEach(klient => Console.WriteLine(klient));
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
                    var klient = new Klient
                                        {
                                            Name = "Jan Novak",
                                            Adresy = new HashedSet<Adresa>
                                            {
                                                new Adresa {Obec = "Praha", Psc = "12345", Ulice = "Vaclavska"}, new Adresa {Obec = "Brno", Psc = "45678", Ulice = "Moskevska"}
                                            }
                                        };
                    klient.Adresy.ForEach(adresa => adresa.Klient = klient);
                    session.Merge(klient);

                    session.Merge(new Klient
                                      {
                                          Name = "Lojza Mikula",
                                          Adresy = new HashedSet<Adresa>
                                                       {
                                                           new Adresa {Obec = "Hradec Králové", Psc = "55555", Ulice = "Hradecká"},
                                                       }
                                      });

                    klient = new Klient { Name = "Franta Bezdomova", };
                    klient.Adresy.ForEach(adresa => adresa.Klient = klient);
                    session.Merge(klient);

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