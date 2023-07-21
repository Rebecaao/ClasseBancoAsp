using System;
using System.Collections.Generic;

namespace testebanco.Models
{
    public partial class Tblkit
    {
        public uint IdKit { get; set; }
        public string Iccid { get; set; } = null!;
        public uint IdBolsaDeDez { get; set; }
        public uint IdCaixaInner { get; set; }
        public uint IdCaixaOuter { get; set; }
        public uint IdPallet { get; set; }
        public uint IdArquivo { get; set; }
        public uint IdSituacao { get; set; }

        public virtual Tblarquivo IdArquivoNavigation { get; set; } = null!;
        public virtual Tblbolsadedez IdBolsaDeDezNavigation { get; set; } = null!;
        public virtual Tblcaixainner IdCaixaInnerNavigation { get; set; } = null!;
        public virtual Tblcaixaouter IdCaixaOuterNavigation { get; set; } = null!;
        public virtual Tblpallet IdPalletNavigation { get; set; } = null!;
        public virtual Tblsituacao IdSituacaoNavigation { get; set; } = null!;
    }
}
