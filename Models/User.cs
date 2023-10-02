using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace BlazorServerApp.Models
{
    public class User
    {
        public User(){ }

        public User(int? age, string name, string password, string username, string email)
        {
            Age = age;
            Name = name;
            Password = password;
            Username = username;
            Email = email;
        }

        public string UserId { get; set; }

        [FirestoreProperty]
        public Nullable<int> Age { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }

        [FirestoreProperty]
        public string Password { get; set; }

        [FirestoreProperty]
        public string Username { get; set; }

        [FirestoreProperty]
        public string Email { get; set; }

    }
}
