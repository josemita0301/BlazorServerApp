using BlazorServerApp.Models.PostsModels;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace BlazorServerApp.Controllers
{
    public class MaterialController
    {
        private FirestoreDb firestoreDb;

        public MaterialController()
        {
            firestoreDb = FirestoreDb.Create("blazorserverdb");
        }

        #region CRUD Materials
        public async Task<bool> CreateMaterial(Material newMaterial)
        {
            try
            {
                CollectionReference materialRef = firestoreDb.Collection("Material");

                Dictionary<string, object> materialDict = new Dictionary<string, object>
                {
                    { "Alto", (double)newMaterial.Alto },
                    { "Ancho", (double)newMaterial.Ancho },
                    { "Cantidad", (double)newMaterial.Cantidad },
                    { "Color", newMaterial.Color },
                    { "InfoAdicional", newMaterial.InfoAdicional },
                    { "Largo", (double)newMaterial.Largo },
                    { "NombreMaterial", newMaterial.NombreMaterial },
                    { "Peso", (double)newMaterial.Peso },
                    { "PostStepId", newMaterial.PostStepId },
                    { "PrecioUnitario", (double)newMaterial.PrecioUnitario },
                    { "PrecioUnitarioDivisa", newMaterial.PrecioUnitarioDivisa },
                    { "Textura", newMaterial.Textura },
                    { "UnidadDePeso", newMaterial.UnidadDePeso },
                    { "UnidadMedida", newMaterial.UnidadMedida }
                };

                await materialRef.AddAsync(materialDict);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el material: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> CreateMaterials(List<Material> newMaterials)
        {
            try
            {
                foreach (Material newMaterial in newMaterials)
                {
                    await CreateMaterial(newMaterial);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el material: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> EditMaterial(Material materialToUpdate)
        {
            if (string.IsNullOrEmpty(materialToUpdate.PostStepId))
            {
                Console.WriteLine("PostStepId no puede estar vacío al editar un material.");
                return false;
            }

            try
            {
                DocumentReference materialRef = firestoreDb.Collection("Material").Document(materialToUpdate.PostStepId);

                Dictionary<string, object> postStepDict = new Dictionary<string, object>
                    {
                        { "Alto", materialToUpdate.Alto },
                    { "Ancho", materialToUpdate.Ancho },
                    { "Cantidad", materialToUpdate.Cantidad },
                    { "Color", materialToUpdate.Color },
                    { "InfoAdicional", materialToUpdate.InfoAdicional },
                    { "Largo", materialToUpdate.Largo },
                    { "NombreMaterial", materialToUpdate.NombreMaterial },
                    { "Peso", materialToUpdate.Peso },
                    { "PostStepId", materialToUpdate.PostStepId },
                    { "PrecioUnitario", materialToUpdate.PrecioUnitario },
                    { "PrecioUnitarioDivisa", materialToUpdate.PrecioUnitarioDivisa },
                    { "Textura", materialToUpdate.Textura },
                    { "UnidadDePeso", materialToUpdate.UnidadDePeso },
                    { "UnidadMedida", materialToUpdate.UnidadMedida }
                    };

                await materialRef.UpdateAsync(postStepDict);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar el material: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> EditMaterials(List<Material> materialsToUpdate)
        {
            if (materialsToUpdate.Count <= 0)
            {
                Console.WriteLine("PostStepId no puede estar vacío al editar un material.");
                return false;
            }

            try
            {
                foreach (var materialToUpdate in materialsToUpdate)
                {
                    await EditMaterial(materialToUpdate);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar el material: {ex.Message}");
                return false;
            }
        }
        public async Task<List<Material>> GetAllMaterials()
        {
            List<Material> materials = new List<Material>();

            try
            {
                Query materialQuery = firestoreDb.Collection("Material");
                QuerySnapshot materialQuerySnapshot = await materialQuery.GetSnapshotAsync();

                foreach (DocumentSnapshot documentSnapshot in materialQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> material = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(material);

                        Material loopMaterial = JsonConvert.DeserializeObject<Material>(json);

                        loopMaterial.MaterialId = documentSnapshot.Id;

                        materials.Add(loopMaterial);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener todos los materiales: {ex.Message}");
            }

            return materials;
        }

        public async Task<Material> GetMaterialById(string materialId)
        {
            try
            {
                DocumentReference docRef = firestoreDb.Collection("Material").Document(materialId);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    Material material = snapshot.ConvertTo<Material>();
                    material.PostStepId = snapshot.Id;
                    return material;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el material con el id: {ex.Message}");
            }

            return null;
        }

        public async Task<bool> DeleteMaterials(List<Material> materials)
        {
            try
            {
                foreach (var item in materials)
                {
                    DocumentReference materialRef = firestoreDb.Collection("Material").Document(item.MaterialId);
                    await materialRef.DeleteAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al borrar el material: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteMaterial(string materialId)
        {
            try
            {
                DocumentReference materialRef = firestoreDb.Collection("Material").Document(materialId);
                await materialRef.DeleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al borrar el material: {ex.Message}");
                return false;
            }
        }
        #endregion
    }
}
