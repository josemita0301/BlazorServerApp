using Google.Cloud.Kms.V1;
using Google.Protobuf;
using System.Text;

namespace BlazorServerApp.Utils
{
    public class EncryptSymmetricService
    {

        public string EncryptSymmetric(
            string message = "Este es un mensaje cifrado",
          string projectId = "blazorserverdb", string locationId = "global", string keyRingId = "TestKeyRing", string keyId = "TestKey")
        {
            // Create the client.
            KeyManagementServiceClient client = KeyManagementServiceClient.Create();

            // Build the key name.
            CryptoKeyName keyName = new CryptoKeyName(projectId, locationId, keyRingId, keyId);

            // Convert the message into bytes. Cryptographic plaintexts and ciphertexts are always byte arrays.
            byte[] plaintext = Encoding.UTF8.GetBytes(message);

            // Call the API.
            EncryptResponse result = client.Encrypt(keyName, ByteString.CopyFrom(plaintext));

            // Convert the ciphertext to a Base64 string.
            string encryptedMessage = Convert.ToBase64String(result.Ciphertext.ToByteArray());

            return encryptedMessage;
        }
    }
}
