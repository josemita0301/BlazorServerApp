using BlazorServerApp.Models;
using BlazorServerApp.Models.PostsModels;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace BlazorServerApp.Controllers
{
    public class EventController
    {
        private FirestoreDb firestoreDb;

        public EventController()
        {
            firestoreDb = FirestoreDb.Create("blazorserverdb");
        }

        #region CRUD Post

        public async Task<List<Evento>> GetAllEventos()
        {
            List<Evento> Eventos = new List<Evento>();

            try
            {
                Query eventoQuery = firestoreDb.Collection("Event");
                QuerySnapshot eventoQuerySnapShot = await eventoQuery.GetSnapshotAsync();

                foreach (DocumentSnapshot documentSnapShot in eventoQuerySnapShot.Documents)
                {
                    if (documentSnapShot.Exists)
                    {
                        Dictionary<string, object> userPost = documentSnapShot.ToDictionary();
                        string json = JsonConvert.SerializeObject(userPost);

                        Evento loopEvento = JsonConvert.DeserializeObject<Evento>(json);

                        loopEvento.EventId = documentSnapShot.Id;

                        Eventos.Add(loopEvento);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener todos los eventos: {ex.Message}");
                return Eventos;
            }
            return Eventos;
        }

        #endregion
    }
}
