using BlazorServerApp.Models;
using Google.Cloud.Firestore;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

namespace BlazorServerApp.Controllers
{
    public class UserController
    {
        private FirestoreDb firestoreDb;

        public UserController()
        {
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

        public async Task<User> GetUserById(string userId)
        {
            User user = null;

            try
            {
                DocumentReference docRef = firestoreDb.Collection("User").Document(userId);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    Dictionary<string, object> userData = snapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(userData);

                    user = JsonConvert.DeserializeObject<User>(json);
                    user.UserId = snapshot.Id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el usuario: {ex.Message}");
            }

            return user;
        }

        public async Task<bool> DeleteUser(string userId)
        {
            try
            {
                DocumentReference userRef = firestoreDb.Collection("User").Document(userId);
                await userRef.DeleteAsync();
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AddUser(User user)
        {
            try
            {

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> EditUser(User editedUser)
        {
            try
            {

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
