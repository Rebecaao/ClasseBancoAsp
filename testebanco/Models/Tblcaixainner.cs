using System;
using System.Collections.Generic;

namespace testebanco.Models
{
    public partial class Tblcaixainner
    {
        public Tblcaixainner()
        {
            Tblbolsadedezs = new HashSet<Tblbolsadedez>();
            Tblkits = new HashSet<Tblkit>();
        }

        public uint IdCaixaInner { get; set; }
        public uint QuantidaBolsaDeDez { get; set; }
        public uint IdSituacao { get; set; }
        public uint IdCaixaOuter { get; set; }

        public virtual Tblcaixaouter IdCaixaOuterNavigation { get; set; } = null!;
        public virtual Tblsituacao IdSituacaoNavigation { get; set; } = null!;
        public virtual ICollection<Tblbolsadedez> Tblbolsadedezs { get; set; }
        public virtual ICollection<Tblkit> Tblkits { get; set; }
    }
}
