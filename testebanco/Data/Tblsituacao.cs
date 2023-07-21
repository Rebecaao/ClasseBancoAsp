using System;
using System.Collections.Generic;

namespace testebanco.Data
{
    public partial class Tblsituacao
    {
        public Tblsituacao()
        {
            Tblarquivos = new HashSet<Tblarquivo>();
            Tblbolsadedezs = new HashSet<Tblbolsadedez>();
            Tblcaixainners = new HashSet<Tblcaixainner>();
            Tblcaixaouters = new HashSet<Tblcaixaouter>();
            Tblkits = new HashSet<Tblkit>();
            Tblpallets = new HashSet<Tblpallet>();
        }

        public uint IdSituacao { get; set; }
        public string Situacao { get; set; } = null!;

        public virtual ICollection<Tblarquivo> Tblarquivos { get; set; }
        public virtual ICollection<Tblbolsadedez> Tblbolsadedezs { get; set; }
        public virtual ICollection<Tblcaixainner> Tblcaixainners { get; set; }
        public virtual ICollection<Tblcaixaouter> Tblcaixaouters { get; set; }
        public virtual ICollection<Tblkit> Tblkits { get; set; }
        public virtual ICollection<Tblpallet> Tblpallets { get; set; }
    }
}
