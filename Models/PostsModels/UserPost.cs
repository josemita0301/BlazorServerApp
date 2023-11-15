using Google.Cloud.Firestore;

namespace BlazorServerApp.Models.PostsModels
{
    [FirestoreData]
    public class UserPost
    {
        public UserPost()
        {
        }

        public string UserPostId { get; set; }

        [FirestoreProperty]
        public string CraftName { get; set; }

        [FirestoreProperty]
        public int Difficulty { get; set; }

        [FirestoreProperty]
        public string EventDateId { get; set; }

        [FirestoreProperty]
        public bool IsPublic { get; set; }

        [FirestoreProperty]
        public string PostDescription { get; set; }

        [FirestoreProperty]
        public string PublishDate { get; set; }

        [FirestoreProperty]
        public int Rating { get; set; }

        [FirestoreProperty]
        public int StepCount { get; set; }

        [FirestoreProperty]
        public string UserId { get; set; }

        [FirestoreProperty]
        public string VideoLink { get; set; }

        [FirestoreProperty]
        public List<string> Image { get; set; }
    }
}
