﻿namespace Esercitazione_19_07.Models
{
    public class Verbale
    {
        public int IdVerbale { get; set; }

        public DateTime DataViolazione { get; set; }


        public string IndirizzoViolazione { get; set; }

        public string Nominativo_Agente { get; set; }


        public DateTime DataTrascrizioneVerbale { get; set; }


        public decimal Importo { get; set; }

        public int DecurtamentoPunti { get; set; }

        public int FK_Violazione { get; set; }

        public int FK_Anagrafica { get; set; }
    }
}
