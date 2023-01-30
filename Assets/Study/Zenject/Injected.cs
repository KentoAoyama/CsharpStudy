using UnityEngine;
using Zenject;

/// <summary>
/// Zenject�ɂ���Ĉˑ��������������N���X
/// </summary>
public class Injected : MonoBehaviour
{
    [Inject]
    private IExample _example;

    private void Start()
    {
        _example.Test();
    }
}
