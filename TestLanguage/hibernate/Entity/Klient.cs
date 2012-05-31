using System;
using Iesi.Collections.Generic;

namespace TestLanguage.Hibernate.Entity
{
    public class Klient : IStorno
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual DateTime? DatumStornovani { get; set; }

        public virtual ISet<Adresa> Adresy { get; set; }
    }

    public class Adresa
    {
        public virtual int Id { get; set; }

        public virtual string Ulice { get; set; }

        public virtual string Psc { get; set; }

        public virtual string Obec { get; set; }
    }

    public interface IStorno
    {
        DateTime? DatumStornovani { get; set; }
    }
}