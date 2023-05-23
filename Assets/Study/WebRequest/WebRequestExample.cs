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
        // ���N�G�X�g���URL���w��
        string url = "http://abehiroshi.la.coocan.jp/abe-top-20190328-2.jpg";

        // UnityWebRequest���쐬
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);

        // ���N�G�X�g�𑗐M���A���X�|���X��҂�
        yield return request.SendWebRequest();

        // ���X�|���X�̏���
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
        }
        else
        {
            // �e�N�X�`����Image�ɐݒ�
            Texture2D texture = DownloadHandlerTexture.GetContent(request);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
            image.sprite = sprite;
        }
    }
}
