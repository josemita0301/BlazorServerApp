using BlazorServerApp.Models;
using BlazorServerApp.Utils;
using Newtonsoft.Json;

namespace BlazorServerApp.Services
{
    public class EmployeeService
    {
        private readonly HttpClient _httpClient;
        private readonly DecryptSymmetricService _decryptSymmetricService;

        public EmployeeService(HttpClient httpClient, DecryptSymmetricService decryptSymmetricService)
        {
            _httpClient = httpClient;
            _decryptSymmetricService = decryptSymmetricService;
        }

        public async Task<List<Empleado>> GetEmployeesAsync()
        {
            var encryptedData = await _httpClient.GetStringAsync("https://localhost:44343/api/share/get-employees");
            var decryptedData = _decryptSymmetricService.DecryptSymmetric(encryptedData);
            return JsonConvert.DeserializeObject<List<Empleado>>(decryptedData);
        }
    }
}
