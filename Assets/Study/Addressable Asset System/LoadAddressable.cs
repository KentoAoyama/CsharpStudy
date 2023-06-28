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
        //AsyncOperationHandle型の変数に生成したアセットの戻り値を格納できる
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

        //アンロードした場合、そのアセットへの参照がなくなったら破棄される仕様らしい
        Addressables.ReleaseInstance(_handle);

        Debug.Log("AddressableAssetをアンロードしました");
    }
}
