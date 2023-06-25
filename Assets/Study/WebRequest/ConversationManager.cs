using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Cysharp.Threading.Tasks;

public class ConversationManager : MonoBehaviour
{
    [SerializeField]
    private WebRequestAPI _requestAPI;

    [SerializeField]
    private Text _responceText = default;

    [SerializeField]
    private InputField _requestInputField = default;

    [SerializeField]
    private Button _sendRequestButton = default;

    private void Start()
    {
        _sendRequestButton
            .OnClickAsObservable()
            .Subscribe(_ => SendRequest().Forget());
    }

    private async UniTask SendRequest()
    {
        await _requestAPI.SendChatGPTRequest(_requestInputField.text);

        _responceText.text = _requestAPI.ResponceText;
    }
}
