﻿using BlazorServerApp.Models.Users;
using Google.Cloud.Firestore;
using System.Globalization;

namespace BlazorServerApp.Models
{
    public class Venta
    {

        public string VentaId { get; set; }

        [FirestoreProperty]
        public string fecha { get; set; }

        [FirestoreProperty]
        public string idUser { get; set; }

        [FirestoreProperty]
        public string producto { get; set; }

        [FirestoreProperty]
        public decimal cuotaMonto { get; set; }

        public User Vendedor { get; set; }


        public DateTime FechaToDateTime()
        {
            return DateTime.ParseExact(this.fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}
