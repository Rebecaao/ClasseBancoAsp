using System;
using System.Collections.Generic;

namespace testebanco.Data
{
    public partial class Tblpallet
    {
        public Tblpallet()
        {
            Tblcaixaouters = new HashSet<Tblcaixaouter>();
            Tblkits = new HashSet<Tblkit>();
        }

        public uint IdPallet { get; set; }
        public uint QuantidaCaixaOuter { get; set; }
        public uint IdSituacao { get; set; }

        public virtual Tblsituacao IdSituacaoNavigation { get; set; } = null!;
        public virtual ICollection<Tblcaixaouter> Tblcaixaouters { get; set; }
        public virtual ICollection<Tblkit> Tblkits { get; set; }
    }
}
