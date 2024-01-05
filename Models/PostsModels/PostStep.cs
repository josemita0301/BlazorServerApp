using Google.Cloud.Firestore;

namespace BlazorServerApp.Models.PostsModels
{
    public class PostStep
    {
        public PostStep()
        {

        }

        public string PostStepId { get; set; }

        [FirestoreProperty]
        public int StepNumber { get; set; }

        [FirestoreProperty]
        public string StepName { get; set; }

        [FirestoreProperty]
        public string Description { get; set; }

        [FirestoreProperty]
        public string StepImage { get; set; }

        [FirestoreProperty]
        public string UserPostId { get; set; }

        [FirestoreProperty]
        public int TimeNeeded { get; set; }

        public List<Material> StepMaterials { get; set; }
    }
}
