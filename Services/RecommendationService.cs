using BlazorServerApp.Controllers;
using BlazorServerApp.Models;
using BlazorServerApp.Models.PostsModels;
using MessagePack.Formatters;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using System.IO.IsolatedStorage;
using System.Security.Cryptography.X509Certificates;

namespace BlazorServerApp.Services
{
    public class RecommendationService
    {

        public static async Task<List<MaterialFilter>> GetMostUsedMaterials(string DateFrom, string DateTo)
        {
            try
            {
                DateTime dateTimeFrom = DateTime.ParseExact(DateFrom, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateTimeTo = DateTime.ParseExact(DateTo, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                List<MaterialFilter> MostUsedMaterials = new List<MaterialFilter>();

                PostController postController = new PostController();
                MaterialController materialController = new MaterialController();
                PostStepController postStepController = new PostStepController();
                PostStepController userController = new PostStepController();

                List<UserPost> AllPosts = await postController.GetAllPosts();
                List<PostStep> AllSteps = await postStepController.GetAllSteps();
                List<Material> AllMaterials = await materialController.GetAllMaterials();

                foreach (UserPost post in AllPosts)
                {
                    DateTime dateTimeChecked = DateTime.ParseExact(post.PublishDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (dateTimeChecked >= dateTimeFrom && dateTimeChecked <= dateTimeTo)
                    {
                        Console.WriteLine("Yup");
                    }
                    else
                    {
                        continue;
                    }

                    List<PostStep> steps = AllSteps.Where(p => p.UserPostId == post.UserPostId).ToList();

                    foreach (var step in steps)
                    {
                        List<Material> stepMaterials = AllMaterials.Where(p => p.PostStepId == step.PostStepId).ToList();

                        foreach (var material in stepMaterials)
                        {
                            bool found = false;
                            for (int i = 0; i < MostUsedMaterials.Count; i++)
                            {
                                if (MostUsedMaterials[i].Nombre.ToLower().Trim().Equals(material.NombreMaterial.ToLower().Trim()))
                                {
                                    MostUsedMaterials[i].Cantidad += (int) decimal.Round((decimal)(material.Cantidad), 0);
                                    found = true;
                                }
                            }

                            if (!found)
                            {
                                MaterialFilter materialFilter = new MaterialFilter() { Cantidad = (int)decimal.Round((decimal)(material.Cantidad), 0), Nombre = material.NombreMaterial };
                                MostUsedMaterials.Add(materialFilter);
                            }
                        }
                    }
                }

                MostUsedMaterials = MostUsedMaterials.OrderByDescending(m => m.Cantidad).Take(10).ToList();

                return MostUsedMaterials;
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                return new List<MaterialFilter>();
            }
        }

        public static async Task<List<UserPost>> GetFilteredPosts(string DateFrom, string DateTo)
        {
            try
            {
                DateTime dateTimeFrom = DateTime.ParseExact(DateFrom, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateTimeTo = DateTime.ParseExact(DateTo, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                PostController postController = new PostController();

                List<UserPost> AllPosts = await postController.GetAllPosts();

                List<UserPost> FilteredPosts = new List<UserPost>();

                foreach (UserPost post in AllPosts)
                {
                    DateTime dateTimeChecked = DateTime.ParseExact(post.PublishDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (dateTimeChecked >= dateTimeFrom && dateTimeChecked <= dateTimeTo)
                    {
                        FilteredPosts.Add(post);
                    }
                    else
                    {
                        continue;
                    }

                }

                return FilteredPosts;
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                return new List<UserPost>();
            }
        }

        public static async Task<List<List<UserPost>>> GetRecommendedData(List<MaterialFilter> materials, double wantedPrice, int difficulty, string UserId)
        {
            try
            {
                List<List<UserPost>> bigPostList = new List<List<UserPost>>();

                List<UserPost> postsToRecommend = new List<UserPost>();

                PostController postController = new PostController();
                MaterialController materialController = new MaterialController();
                PostStepController postStepController = new PostStepController();
                PostStepController userController = new PostStepController();

                List<UserPost> userPostsD1 = new List<UserPost>();
                List<UserPost> userPostsD2 = new List<UserPost>();
                List<UserPost> userPostsD3 = new List<UserPost>();
                List<UserPost> userPostsD4 = new List<UserPost>();
                List<UserPost> userPostsD5 = new List<UserPost>();


                List<UserPost> AllPosts = await postController.GetAllPosts();
                List<PostStep> AllSteps = await postStepController.GetAllSteps();
                List<Material> AllMaterials = await materialController.GetAllMaterials();

                List<UserPost> UserPosts = GetSpecificUserPosts(AllPosts, UserId);

                foreach (UserPost post in AllPosts)
                {
                    List<PostStep> steps = AllSteps.Where(p => p.UserPostId == post.UserPostId).ToList();
                    List<Material> materialsFound = new List<Material>();

                    int totalMaterialsOfAllSteps = 0;

                    bool MaterialsFoundBool = false;
                    bool MaterialsCountBool = false;


                    double totalSum = 0;

                    foreach (var step in steps)
                    {
                        List<Material> stepMaterials = AllMaterials.Where(p => p.PostStepId == step.PostStepId).ToList();

                        totalMaterialsOfAllSteps = totalMaterialsOfAllSteps + stepMaterials.Count;

                        foreach (var material in stepMaterials)
                        {
                            foreach (MaterialFilter materialFiltro in materials)
                            {
                                if (material.NombreMaterial.Trim().ToLower() == materialFiltro.Nombre.Trim().ToLower())
                                {
                                    if (material.Cantidad <= materialFiltro.Cantidad)
                                    {
                                        materialsFound.Add(material);
                                    }
                                }
                            }
                        }
                    }

                    if (materialsFound.Count == 0)
                    {
                        materialsFound = new List<Material>();
                        continue;
                    }

                    if (materialsFound.Count != totalMaterialsOfAllSteps)
                    {
                        materialsFound = new List<Material>();
                        continue;
                    }

                    foreach (var item in materialsFound)
                    {
                        double totalMaterial = item.Cantidad * item.PrecioUnitario;

                        totalSum = totalSum + totalMaterial;
                    }

                    double MaxRange = 0;
                    double MinRange = 0;

                    MaxRange = (double)wantedPrice + ((double)wantedPrice * 0.1);
                    MinRange = (double)wantedPrice - ((double)wantedPrice * 0.1);

                    if (totalSum <= MaxRange)
                    {
                        postsToRecommend.Add(post);
                    }
                }

                if (difficulty == 0)
                {
                    foreach (var item in postsToRecommend)
                    {
                        if (item.Difficulty == 1)
                        {
                            userPostsD1.Add(item);
                        }
                        else if (item.Difficulty == 2)
                        {
                            userPostsD2.Add(item);
                        }
                        else if (item.Difficulty == 4)
                        {
                            userPostsD3.Add(item);
                        }
                        else if (item.Difficulty == 5)
                        {
                            userPostsD5.Add(item);
                        }
                    }

                    bigPostList.Add(userPostsD1);
                    bigPostList.Add(userPostsD2);
                    bigPostList.Add(userPostsD3);
                    bigPostList.Add(userPostsD4);
                    bigPostList.Add(userPostsD5);
                }
                else
                {
                    bigPostList.Add(postsToRecommend);
                }

                return bigPostList;
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                return new List<List<UserPost>>();
            }
        }

        public static List<UserPost> GetSpecificUserPosts(List<UserPost> up, string userId)
        {
            return up.Where(up => up.UserId == userId).ToList();
        }
    }
}
