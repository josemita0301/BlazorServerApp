using BlazorServerApp.Models.PostsModels;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace BlazorServerApp.Controllers
{
    public class PostStepController
    {
        private FirestoreDb firestoreDb;

        public PostStepController()
        {
            firestoreDb = FirestoreDb.Create("blazorserverdb");
        }

        #region CRUD PostSteps
        public async Task<bool> CreateSteps(List<PostStep> steps)
        {
            try
            {
                MaterialController mc = new MaterialController();

                foreach (var newStep in steps)
                {
                    CollectionReference postStepRef = firestoreDb.Collection("PostStep");

                    Dictionary<string, object> postStepDict = new Dictionary<string, object>
                    {
                        { "Description", newStep.Description},
                        { "StepImage", newStep.StepImage},
                        { "StepName", newStep.StepName},
                        { "StepNumber", newStep.StepNumber},
                        { "UserPostId", newStep.UserPostId},
                        { "timeNeeded", newStep.TimeNeeded}
                    };

                    DocumentReference docRef = await postStepRef.AddAsync(postStepDict);

                    foreach (var item in newStep.StepMaterials)
                    {
                        item.PostStepId = docRef.Id;
                    }

                    await mc.CreateMaterials(newStep.StepMaterials);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el usuario: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> CreateStep(PostStep newStep)
        {
            try
            {

                CollectionReference postStepRef = firestoreDb.Collection("PostStep");

                Dictionary<string, object> postStepDict = new Dictionary<string, object>
                    {
                        { "Description", newStep.Description},
                        { "StepImage", newStep.StepImage},
                        { "StepName", newStep.StepName},
                        { "StepNumber", newStep.StepNumber},
                        { "UserPostId", newStep.UserPostId},
                        { "timeNeeded", newStep.TimeNeeded}
                    };

                await postStepRef.AddAsync(postStepDict);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el usuario: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> EditStep(PostStep stepToUpdate)
        {
            if (string.IsNullOrEmpty(stepToUpdate.PostStepId))
            {
                Console.WriteLine("PostStepId no puede estar vacío al editar un usuario.");
                return false;
            }

            try
            {
                DocumentReference postStepRef = firestoreDb.Collection("PostStep").Document(stepToUpdate.PostStepId);

                Dictionary<string, object> postStepDict = new Dictionary<string, object>
                    {
                        { "Description", stepToUpdate.Description},
                        { "StepImage", stepToUpdate.StepImage},
                        { "StepName", stepToUpdate.StepName},
                        { "StepNumber", stepToUpdate.StepNumber},
                        { "UserPostId", stepToUpdate.UserPostId},
                        { "timeNeeded", stepToUpdate.TimeNeeded}
                    };

                await postStepRef.UpdateAsync(postStepDict);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar el usuario: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> EditSteps(List<PostStep> stepsToUpdate)
        {
            if (stepsToUpdate.Count <= 0)
            {
                Console.WriteLine("PostStepId no puede estar vacío al editar un usuario.");
                return false;
            }

            try
            {
                foreach (var item in stepsToUpdate)
                {
                    if (item.PostStepId == null)
                    {
                        await CreateStep(item); continue;
                    }

                    await EditStep(item);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar el usuario: {ex.Message}");
                return false;
            }
        }

        public async Task<List<PostStep>> GetAllSteps()
        {
            List<PostStep> steps = new List<PostStep>();

            try
            {
                Query postStepQuery = firestoreDb.Collection("PostStep");
                QuerySnapshot postStepQuerySnapShot = await postStepQuery.GetSnapshotAsync();

                foreach (DocumentSnapshot documentSnapShot in postStepQuerySnapShot.Documents)
                {
                    if (documentSnapShot.Exists)
                    {
                        Dictionary<string, object> postStep = documentSnapShot.ToDictionary();
                        string json = JsonConvert.SerializeObject(postStep);

                        PostStep loopPostStep = JsonConvert.DeserializeObject<PostStep>(json);

                        loopPostStep.PostStepId = documentSnapShot.Id;

                        steps.Add(loopPostStep);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener todos los pasos: {ex.Message}");
                return steps;
            }
            return steps;
        }

        public async Task<PostStep> GetPostStepById(string postStepId)
        {
            PostStep step = null;

            try
            {
                DocumentReference docRef = firestoreDb.Collection("PostStep").Document(postStepId);
                DocumentSnapshot documentSnapShot = await docRef.GetSnapshotAsync();

                if (documentSnapShot.Exists)
                {
                    Dictionary<string, object> userData = documentSnapShot.ToDictionary();
                    string json = JsonConvert.SerializeObject(userData);

                    step = JsonConvert.DeserializeObject<PostStep>(json);

                    step.PostStepId = postStepId;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el usuario con el id: {ex.Message}");
            }

            return step;
        }

        public async Task<bool> DeletePostSteps(List<PostStep> stepsToDelete)
        {
            try
            {
                foreach (PostStep postStep in stepsToDelete)
                {
                    DocumentReference postStepRef = firestoreDb.Collection("PostStep").Document(postStep.PostStepId);
                    await postStepRef.DeleteAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al borrar el paso: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeletePostStep(string postStepId)
        {
            try
            {
                DocumentReference postStepRef = firestoreDb.Collection("PostStep").Document(postStepId);
                await postStepRef.DeleteAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al borrar el paso: {ex.Message}");
                return false;
            }
        }

        #endregion
    }
}