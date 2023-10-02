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

        public async Task<bool> CreateUser(User newUser)
        {
            try
            {
                CollectionReference usersRef = firestoreDb.Collection("User");

                Dictionary<string, object> userDict = new Dictionary<string, object>
                {
                    { "age", newUser.Age },
                    { "name", newUser.Name },
                    { "password", newUser.Password },
                    { "username", newUser.Username },
                    { "email", newUser.Email }
                };

                await usersRef.AddAsync(userDict);

                return true;  
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el usuario: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> EditUser(User userToUpdate)
        {
            if (string.IsNullOrEmpty(userToUpdate.UserId))
            {
                Console.WriteLine("UserId no puede estar vacío al editar un usuario.");
                return false;
            }

            try
            {
                DocumentReference userRef = firestoreDb.Collection("User").Document(userToUpdate.UserId);

                Dictionary<string, object> updates = new Dictionary<string, object>
                {
                    { "age", userToUpdate.Age },
                    { "name", userToUpdate.Name },
                    { "password", userToUpdate.Password },
                    { "username", userToUpdate.Username },
                    { "email", userToUpdate.Email }
                };

                await userRef.UpdateAsync(updates);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar el usuario: {ex.Message}");
                return false;
            }
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
                Console.WriteLine($"Error al obtener todos los usuarios: {ex.Message}");
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
                DocumentSnapshot documentSnapShot = await docRef.GetSnapshotAsync();

                if (documentSnapShot.Exists)
                {
                    Dictionary<string, object> userData = documentSnapShot.ToDictionary();
                    string json = JsonConvert.SerializeObject(userData);

                    user = JsonConvert.DeserializeObject<User>(json);

                    user.UserId = userId;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el usuario con el id: {ex.Message}");
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
                Console.WriteLine($"Error al borrar el usuario: {ex.Message}");
                return false;
            }
        }
    }
}
