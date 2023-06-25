using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

public class WebRequestAPI : MonoBehaviour
{
    // ChatGPT API�̃G���h�|�C���gURL
    private const string apiEndpoint = "https://api.openai.com/v1/chat/completions";

    // ChatGPT API�L�[
    private const string apiKey = "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";

    // ���N�G�X�g�̃w�b�_�[
    private const string authorizationHeader = "Bearer " + apiKey;

    private string _responceText = default;
    public string ResponceText => _responceText;

    public async UniTask SendChatGPTRequest(string message)
    {
        // ���N�G�X�g�̃{�f�B�f�[�^���쐬
        var requestData = new { messages = new[] { new { role = "system", content = message } } };
        var requestBody = JsonUtility.ToJson(requestData);

        // ���N�G�X�g�̍쐬
        var request = new UnityWebRequest(apiEndpoint, "POST");
        request.SetRequestHeader("Authorization", authorizationHeader);
        request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(requestBody));
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // ���N�G�X�g�̑��M
        await SendRequestAsync(request);
    }

    private async UniTask SendRequestAsync(UnityWebRequest request)
    {
        await request.SendWebRequest(); 

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("ChatGPT API request failed: " + request.error);
        }
        else
        {
            // ���X�|���X���󂯎��
            _responceText = request.downloadHandler.text;
        }
    }
}
