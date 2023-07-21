using System;
using System.Collections.Generic;

namespace testebanco.Models
{
    public partial class Tblarquivo
    {
        public Tblarquivo()
        {
            Tblkits = new HashSet<Tblkit>();
        }

        public uint IdArquivo { get; set; }
        public string NumeroArquivo { get; set; } = null!;
        public string NomeCliente { get; set; } = null!;
        public uint IdSituacao { get; set; }

        public virtual Tblsituacao IdSituacaoNavigation { get; set; } = null!;
        public virtual ICollection<Tblkit> Tblkits { get; set; }
    }
}
