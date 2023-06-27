using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadAddressable : MonoBehaviour
{
    [SerializeField]
    private AssetReference _assetReference;

    private AsyncOperationHandle _handle;

    void Start()
    {
        StartCoroutine(Load(_assetReference));
    }

    private IEnumerator Load(AssetReference assetReference)
    {
        _handle = assetReference.InstantiateAsync();

        yield return _handle;

        Debug.Log("AddressableAssetをロードしました");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnLoad();
        }
    }

    private void UnLoad()
    {
        if (!_handle.IsValid()) return;

        Addressables.ReleaseInstance(_handle);

        Debug.Log("AddressableAssetをアンロードしました");
    }
}
