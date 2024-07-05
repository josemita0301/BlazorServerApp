using Google.Cloud.Kms.V1;
using Google.Protobuf;
using System.Text;

namespace BlazorServerApp.Utils
{
    public class DecryptSymmetricService
    {
        public string DecryptSymmetric(
          string base64Ciphertext, string projectId = "blazorserverdb", string locationId = "global", string keyRingId = "TestKeyRing", string keyId = "TestKey")
        {
            // Create the client.
            KeyManagementServiceClient client = KeyManagementServiceClient.Create();

            // Build the key name.
            CryptoKeyName keyName = new CryptoKeyName(projectId, locationId, keyRingId, keyId);

            // Convert the Base64 string to byte array
            byte[] ciphertext = Convert.FromBase64String(base64Ciphertext);

            // Call the API.
            DecryptResponse result = client.Decrypt(keyName, ByteString.CopyFrom(ciphertext));

            // Get the plaintext. Cryptographic plaintexts and ciphertexts are always byte arrays.
            byte[] plaintext = result.Plaintext.ToByteArray();

            // Return the result.
            return Encoding.UTF8.GetString(plaintext);
        }
    }
}
