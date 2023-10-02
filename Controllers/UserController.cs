using BlazorServerApp.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System.ComponentModel;

namespace BlazorServerApp.Controllers
{
    public class UserController
    {
        private FirestoreDb firestoreDb;

        public UserController()
        {
            string CredentialPath = "C:\\Users\\USUARIO\\source\\repos\\BlazorServerApp\\blazorserverdb-firebase-adminsdk-d6ztc-72ee8cbfb5.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", CredentialPath);

            firestoreDb = FirestoreDb.Create("blazorserverdb");
        }

        public async Task<List<User>> GetAllUsers()
        {
            List<User> users = new List<User>();

            try
            {
                Query userQuery = firestoreDb.Collection("User");
                QuerySnapshot userQuerySnapShot = await userQuery.GetSnapshotAsync();

                foreach (DocumentSnapshot documentSnapShot in userQuerySnapShot.Documents)
                {
                    if (documentSnapShot.Exists)
                    {
                        Dictionary<string, object> user = documentSnapShot.ToDictionary();
                        string json = JsonConvert.SerializeObject(user);
                        
                        User loopUser = JsonConvert.DeserializeObject<User>(json);

                        loopUser.UserId = documentSnapShot.Id;

                        users.Add(loopUser);
                    }
                }
            }
            catch (Exception ex)
            {
                return users;
            }

            return users;
        }
    }
}
