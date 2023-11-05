using BlazorServerApp.Authentication;
using BlazorServerApp.Models.Users;
using BlazorServerApp.Pages.User;
using BlazorServerAppServices.Helpers;
using Firebase.Auth;
using Google.Cloud.Firestore;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using User = BlazorServerApp.Models.Users.User;

namespace BlazorServerApp.Controllers
{
    public class UserController
    {
        private FirestoreDb firestoreDb;

        public UserController()
        {
            firestoreDb = FirestoreDb.Create("blazorserverdb");
        }

        #region CRUD User
        public async Task<bool> CreateUser(User newUser)
        {
            try
            {
                string saltCreate = DateTime.Now.ToString();

                CollectionReference usersRef = firestoreDb.Collection("User");

                if (string.IsNullOrEmpty(newUser.Role))
                {
                    newUser.Role = "User";
                }

                Dictionary<string, object> userDict = new Dictionary<string, object>
                {
                    { "age", newUser.Age },
                    { "name", newUser.Name },
                    { "password", Hashing.HashPassword($"{newUser.Password}{saltCreate}")},
                    { "username", newUser.Username },
                    { "email", newUser.Email },
                    { "role", newUser.Role },
                    { "salt", saltCreate}
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

                string saltEdit = DateTime.Now.ToString();

                DocumentReference userRef = firestoreDb.Collection("User").Document(userToUpdate.UserId);

                Dictionary<string, object> updates = new Dictionary<string, object>
                {
                    { "age", userToUpdate.Age },
                    { "name", userToUpdate.Name },
                    { "password", Hashing.HashPassword($"{userToUpdate.Password}{saltEdit}")},
                    { "username", userToUpdate.Username },
                    { "email", userToUpdate.Email },
                    { "role", userToUpdate.Role },
                    { "salt", saltEdit }
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

        #endregion

        #region Login

        public async Task<bool> LoginUser(UserToLogin userToLogin, CustomAuthenticationStateProvider customAuthStateProvider)
        {
            try
            {
                // Consulta para el correo
                Query emailQuery = firestoreDb.Collection("User").WhereEqualTo("email", userToLogin.Email);
                QuerySnapshot emailQuerySnapshot = await emailQuery.GetSnapshotAsync();

                // Consulta para el nombre de usuario
                Query usernameQuery = firestoreDb.Collection("User").WhereEqualTo("username", userToLogin.Email);
                QuerySnapshot usernameQuerySnapshot = await usernameQuery.GetSnapshotAsync();

                DocumentSnapshot userDocument = null;

                if (emailQuerySnapshot.Documents.Count > 0)
                {
                    userDocument = emailQuerySnapshot.Documents[0];
                }
                else if (usernameQuerySnapshot.Documents.Count > 0)
                {
                    userDocument = usernameQuerySnapshot.Documents[0];
                }

                if (userDocument != null)
                {
                    Dictionary<string, object> userData = userDocument.ToDictionary();
                    string json = JsonConvert.SerializeObject(userData);

                    User userFromDb = JsonConvert.DeserializeObject<User>(json);
                    userFromDb.UserId = userDocument.Id;
                    userToLogin.Role = userFromDb.Role;
                    userToLogin.id = userFromDb.UserId;

                    if (Hashing.HashPassword($"{userToLogin.Password}{userFromDb.Salt}") == userFromDb.Password)
                    {
                        await customAuthStateProvider.UpdateAuthenticationState(userToLogin);
                        return true;
                    }
                    else 
                        return false;
                }
                else
                {
                    return false; // No se encontró el usuario con ese correo o nombre de usuario
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el usuario: {ex.Message}");
                return false;
            }
        }
        #endregion
    }
}
