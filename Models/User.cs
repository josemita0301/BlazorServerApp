using Google.Cloud.Firestore;

namespace BlazorServerApp.Models
{
    public class User
    {
        public User(){ }

        public User(string role, int age, string name, string password, string username, string email, string salt)
        {
            Age = age;
            Role = role;
            Name = name;
            Password = password;
            Username = username;
            Email = email;
            Salt = salt;
        }
        public string UserId { get; set; }

        [FirestoreProperty]
        public string Role { get; set; }


        [FirestoreProperty]
        public int Age { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }

        [FirestoreProperty]
        public string Password { get; set; }

        [FirestoreProperty]
        public string Username { get; set; }

        [FirestoreProperty]
        public string Email { get; set; }

        [FirestoreProperty]
        public string Salt { get; set; }

        public string Observation { get; set; }

    }
}
