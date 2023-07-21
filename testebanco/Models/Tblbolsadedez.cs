using System;
using System.Collections.Generic;

namespace testebanco.Models
{
    public partial class Tblbolsadedez
    {
        public Tblbolsadedez()
        {
            Tblkits = new HashSet<Tblkit>();
        }

        public uint IdBolsaDeDez { get; set; }
        public uint QuantidaKit { get; set; }
        public uint IdSituacao { get; set; }
        public uint IdCaixaInner { get; set; }

        public virtual Tblcaixainner IdCaixaInnerNavigation { get; set; } = null!;
        public virtual Tblsituacao IdSituacaoNavigation { get; set; } = null!;
        public virtual ICollection<Tblkit> Tblkits { get; set; }
    }
}
