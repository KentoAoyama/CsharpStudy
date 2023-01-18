using UnityEngine;
using Zenject;

/// <summary>
/// Zenject‚É‚æ‚Á‚ÄˆË‘¶«’“ü‚ğ‚³‚ê‚éƒNƒ‰ƒX
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
