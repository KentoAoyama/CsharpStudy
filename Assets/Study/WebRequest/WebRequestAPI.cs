using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

public class WebRequestAPI : MonoBehaviour
{
    // ChatGPT APIのエンドポイントURL
    private const string apiEndpoint = "https://api.openai.com/v1/chat/completions";

    // ChatGPT APIキー
    private const string apiKey = "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";

    // リクエストのヘッダー
    private const string authorizationHeader = "Bearer " + apiKey;

    private string _responceText = default;
    public string ResponceText => _responceText;

    public async UniTask SendChatGPTRequest(string message)
    {
        // リクエストのボディデータを作成
        var requestData = new { messages = new[] { new { role = "system", content = message } } };
        var requestBody = JsonUtility.ToJson(requestData);

        // リクエストの作成
        var request = new UnityWebRequest(apiEndpoint, "POST");
        request.SetRequestHeader("Authorization", authorizationHeader);
        request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(requestBody));
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // リクエストの送信
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
            // レスポンスを受け取る
            _responceText = request.downloadHandler.text;
        }
    }
}
