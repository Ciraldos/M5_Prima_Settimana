using System.ComponentModel.DataAnnotations;

namespace Esercitazione_Settimana_W7.Models
{
    public class EmailModel
    {
        [Display(Name = "Destinatario")]
        public string ToEmail { get; set; }

        [Display(Name = "Oggetto del contatto")]

        public string Subject { get; set; }

        [Display(Name = "Il tuo messaggio")]

        public string Message { get; set; }

    }
}
