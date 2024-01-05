using Google.Cloud.Firestore;
using System.Globalization;

namespace BlazorServerApp.Models
{
    public class Evento
    {
        public Evento()
        {

        }

        public string EventId { get; set; }

        [FirestoreProperty]
        public string Nombre { get; set; }

        [FirestoreProperty]
        public string Fecha { get; set; }

        [FirestoreProperty]
        public string TipoEvento { get; set; }

        public DateTime EventDateToDatetime()
        {
            return DateTime.ParseExact(this.Fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}
