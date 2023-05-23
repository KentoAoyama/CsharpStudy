using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;

public class WebRequestExample : MonoBehaviour
{
    [SerializeField]
    private Image image;

    IEnumerator Start()
    {
        // リクエスト先のURLを指定
        string url = "http://abehiroshi.la.coocan.jp/abe-top-20190328-2.jpg";

        // UnityWebRequestを作成
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);

        // リクエストを送信し、レスポンスを待つ
        yield return request.SendWebRequest();

        // レスポンスの処理
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
        }
        else
        {
            // テクスチャをImageに設定
            Texture2D texture = DownloadHandlerTexture.GetContent(request);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
            image.sprite = sprite;
        }
    }
}
