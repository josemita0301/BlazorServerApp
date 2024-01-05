using Google.Cloud.Firestore;

namespace BlazorServerApp.Models.PostsModels
{
    public class Material
    {
        public Material()
        {

        }

        public string MaterialId { get; set; }

        [FirestoreProperty]
        public double Alto { get; set; }

        [FirestoreProperty]
        public double Ancho { get; set; }

        [FirestoreProperty]
        public double Cantidad { get; set; }

        [FirestoreProperty]
        public string Color { get; set; }

        [FirestoreProperty]
        public string InfoAdicional { get; set; }

        [FirestoreProperty]
        public double Largo { get; set; }

        [FirestoreProperty]
        public string NombreMaterial { get; set; }

        [FirestoreProperty]
        public double Peso { get; set; }

        [FirestoreProperty]
        public string PostStepId { get; set; }

        [FirestoreProperty]
        public double PrecioUnitario { get; set; }

        [FirestoreProperty]
        public string PrecioUnitarioDivisa { get; set; }

        [FirestoreProperty]
        public string Textura { get; set; }

        [FirestoreProperty]
        public string UnidadDePeso { get; set; }

        [FirestoreProperty]
        public string UnidadMedida { get; set; }
    }
}
