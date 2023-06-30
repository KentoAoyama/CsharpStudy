using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Cysharp.Threading.Tasks;

public class ConversationManager : MonoBehaviour
{
    [SerializeField]
    private ChatGPTConnection _gptConnection;

    [SerializeField]
    private Text _responceText = default;

    [SerializeField]
    private InputField _requestInputField = default;

    [SerializeField]
    private Button _sendRequestButton = default;

    [SerializeField]
    private Text _responceWaiting = default;

    private void Start()
    {
        //SecretKeyの値を持つstaticクラスを使用する
        _gptConnection = new(ChatGPTSecretKey.key);

        if (_sendRequestButton != null)
            _sendRequestButton
                .OnClickAsObservable()
                .Subscribe(_ => SendRequest().Forget());
    }

    private async UniTask SendRequest()
    {
        if (_responceWaiting != null)
            _responceWaiting.text = "ChatGPT Responce Waiting!!";

        await _gptConnection.RequestAsync(_requestInputField.text);

        if (_responceWaiting != null)
            _responceWaiting.text = "ChatGPT Responce Returned!!";

        if (_responceText != null)
            _responceText.text = _gptConnection.GetCurrentMessage();
    }
}
