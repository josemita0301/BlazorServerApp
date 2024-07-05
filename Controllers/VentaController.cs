using BlazorServerApp.Models;
using BlazorServerApp.Models.Users;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;

namespace BlazorServerApp.Controllers
{
    public class VentaController
    {
        private FirestoreDb firestoreDb;

        public VentaController()
        {
            firestoreDb = FirestoreDb.Create("blazorserverdb");
        }

        public async Task<bool> CreateVenta(Venta newVenta)
        {
            try
            {
                CollectionReference ventaRef = firestoreDb.Collection("Venta");

                Dictionary<string, object> ventaDict = new Dictionary<string, object>
                {
                    { "cuotaMonto", Convert.ToDouble(newVenta.cuotaMonto)},
                    { "fecha", newVenta.fecha},
                    { "idUser", newVenta.idUser},
                    { "producto", newVenta.producto}
                };

                await ventaRef.AddAsync(ventaDict);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear la venta: {ex.Message}");
                return false;
            }
        }

        public async Task<List<Venta>> GetAllVentas()
        {
            List<Venta> ventas = new List<Venta>();

            try
            {
                Query ventaQuery = firestoreDb.Collection("Venta");
                QuerySnapshot ventaQuerySnapShot = await ventaQuery.GetSnapshotAsync();

                foreach (DocumentSnapshot documentSnapShot in ventaQuerySnapShot.Documents)
                {
                    if (documentSnapShot.Exists)
                    {
                        Dictionary<string, object> venta = documentSnapShot.ToDictionary();
                        string json = JsonConvert.SerializeObject(venta);

                        Venta loopVenta = JsonConvert.DeserializeObject<Venta>(json);

                        loopVenta.VentaId = documentSnapShot.Id;

                        loopVenta.Vendedor = await GetVendedorById(loopVenta.idUser);

                        ventas.Add(loopVenta);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener todas las ventas: {ex.Message}");
                return ventas;
            }
            return ventas;
        }

        public async Task<User> GetVendedorById(string userId)
        {
            User vendedor = null;

            try
            {
                DocumentReference docRef = firestoreDb.Collection("User").Document(userId);
                DocumentSnapshot documentSnapShot = await docRef.GetSnapshotAsync();

                if (documentSnapShot.Exists)
                {
                    Dictionary<string, object> userData = documentSnapShot.ToDictionary();
                    string json = JsonConvert.SerializeObject(userData);

                    vendedor = JsonConvert.DeserializeObject<User>(json);

                    vendedor.UserId = userId;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el vendedor con el id: {ex.Message}");
            }

            return vendedor;
        }
    }
}
