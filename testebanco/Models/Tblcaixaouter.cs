using System;
using System.Collections.Generic;

namespace testebanco.Models
{
    public partial class Tblcaixaouter
    {
        public Tblcaixaouter()
        {
            Tblcaixainners = new HashSet<Tblcaixainner>();
            Tblkits = new HashSet<Tblkit>();
        }

        public uint IdCaixaOuter { get; set; }
        public uint QuantidaCaixaInner { get; set; }
        public uint IdSituacao { get; set; }
        public uint IdPallet { get; set; }

        public virtual Tblpallet IdPalletNavigation { get; set; } = null!;
        public virtual Tblsituacao IdSituacaoNavigation { get; set; } = null!;
        public virtual ICollection<Tblcaixainner> Tblcaixainners { get; set; }
        public virtual ICollection<Tblkit> Tblkits { get; set; }
    }
}
