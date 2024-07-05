using BlazorServerApp.Models.PostsModels;
using BlazorServerApp.Models.Users;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace BlazorServerApp.Controllers
{
    public class PostController
    {
        private FirestoreDb firestoreDb;

        public PostController()
        {
            firestoreDb = FirestoreDb.Create("blazorserverdb");
        }

        #region CRUD Post
        public async Task<string> CreatePost(UserPost newPost)
        {
            try
            {
                CollectionReference postsRef = firestoreDb.Collection("UserPost");

                // Creando el diccionario con todas las propiedades necesarias.
                Dictionary<string, object> postDict = new Dictionary<string, object>
        {
            { "CraftName", newPost.CraftName },
            { "Difficulty", newPost.Difficulty },
            { "EventDate", newPost.EventDate },
            { "EventName", newPost.EventName },
            { "IsPublic", newPost.IsPublic },
            { "PostDescription", newPost.PostDescription },
            { "PublishDate", newPost.PublishDate },
            { "Rating", newPost.Rating },
            { "StepCount", newPost.StepCount },
            { "UserId", newPost.UserId },
            { "VideoLink", newPost.VideoLink },
            // La propiedad Image no se agrega porque mencionaste que no debe aparecer
        };

                DocumentReference docRef = await postsRef.AddAsync(postDict);

                return docRef.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el post: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> EditPost(UserPost postToUpdate)
        {
            if (string.IsNullOrEmpty(postToUpdate.UserPostId))
            {
                Console.WriteLine("UserPostId no puede estar vacío al editar un post.");
                return false;
            }

            try
            {
                DocumentReference postRef = firestoreDb.Collection("UserPost").Document(postToUpdate.UserPostId);

                Dictionary<string, object> postUpdated = new Dictionary<string, object>
                {
                    { "CraftName", postToUpdate.CraftName },
                    { "Difficulty", postToUpdate.Difficulty },
                    { "EventDate", postToUpdate.EventDate },
                    { "EventName", postToUpdate.EventName },
                    { "IsPublic", postToUpdate.IsPublic },
                    { "PostDescription", postToUpdate.PostDescription },
                    { "PublishDate", postToUpdate.PublishDate },
                    { "Rating", postToUpdate.Rating },
                    { "StepCount", postToUpdate.StepCount },
                    { "UserId", postToUpdate.UserId },
                    { "VideoLink", postToUpdate.VideoLink },
                    // La propiedad Image no se actualiza porque mencionaste que no debe aparecer
                };

                await postRef.UpdateAsync(postUpdated);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar el post: {ex.Message}");
                return false;
            }
        }

        public async Task<List<UserPost>> GetAllPosts()
        {
            List<UserPost> UserPosts = new List<UserPost>();

            try
            {
                Query userPostQuery = firestoreDb.Collection("UserPost");
                QuerySnapshot userPostQuerySnapShot = await userPostQuery.GetSnapshotAsync();

                foreach (DocumentSnapshot documentSnapShot in userPostQuerySnapShot.Documents)
                {
                    if (documentSnapShot.Exists)
                    {
                        Dictionary<string, object> userPost = documentSnapShot.ToDictionary();
                        string json = JsonConvert.SerializeObject(userPost);

                        UserPost loopUserPost = JsonConvert.DeserializeObject<UserPost>(json);

                        loopUserPost.UserPostId = documentSnapShot.Id;

                        UserPosts.Add(loopUserPost);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener todos los posts: {ex.Message}");
                return UserPosts;
            }
            return UserPosts;
        }

        public async Task<List<UserPost>> GetPostsForCertainDay(DateTime specialDate, string searchTerm)
        {
            List<UserPost> userPosts = new List<UserPost>();

            try
            {
                Query userQuery = firestoreDb.Collection("UserPost");
                QuerySnapshot userQuerySnapShot = await userQuery.GetSnapshotAsync();

                foreach (DocumentSnapshot documentSnapShot in userQuerySnapShot.Documents)
                {
                    if (documentSnapShot.Exists)
                    {
                        Dictionary<string, object> post = documentSnapShot.ToDictionary();
                        string json = JsonConvert.SerializeObject(post);

                        UserPost loopUser = JsonConvert.DeserializeObject<UserPost>(json);

                        loopUser.UserId = documentSnapShot.Id;

                        userPosts.Add(loopUser);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener todos los posts: {ex.Message}");
                return userPosts;
            }
            return userPosts;
        }

        public async Task<UserPost> GetPostById(string userPostId)
        {
            UserPost userPost = null;

            try
            {
                DocumentReference docRef = firestoreDb.Collection("UserPost").Document(userPostId);
                DocumentSnapshot documentSnapShot = await docRef.GetSnapshotAsync();

                if (documentSnapShot.Exists)
                {
                    Dictionary<string, object> userData = documentSnapShot.ToDictionary();
                    string json = JsonConvert.SerializeObject(userData);

                    userPost = JsonConvert.DeserializeObject<UserPost>(json);

                    userPost.UserPostId = documentSnapShot.Id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el usuario con el id: {ex.Message}");
            }

            return userPost;
        }

        public async Task<bool> DeletePost(string userPostId)
        {
            try
            {
                DocumentReference userPostRef = firestoreDb.Collection("UserPost").Document(userPostId);
                await userPostRef.DeleteAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al borrar el post: {ex.Message}");
                return false;
            }
        }

        #endregion

        #region PostValidations

        public bool ValidateStepTimeDifficulty(int difficulty, int totalTime)
        {
            if (difficulty == 1)
            {
                if (totalTime > 5)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (difficulty == 2)
            {
                if (totalTime > 10)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (difficulty == 3)
            {
                if (totalTime > 20)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (difficulty == 4)
            {
                if (totalTime > 30)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (difficulty == 5)
            {
                if (totalTime > 60)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (difficulty == 6)
            {
                if (totalTime > 90)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (difficulty == 7)
            {
                if (totalTime > 120)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (difficulty == 8)
            {
                if (totalTime > 180)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (difficulty == 9)
            {
                if (totalTime > 240)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (difficulty == 10)
            {
                if (totalTime > 600)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }

}
