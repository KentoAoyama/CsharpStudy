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
        //AsyncOperationHandle�^�̕ϐ��ɐ��������A�Z�b�g�̖߂�l���i�[�ł���
        _handle = assetReference.InstantiateAsync();

        yield return _handle;

        Debug.Log("AddressableAsset�����[�h���܂���");
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

        //�A�����[�h�����ꍇ�A���̃A�Z�b�g�ւ̎Q�Ƃ��Ȃ��Ȃ�����j�������d�l�炵��
        Addressables.ReleaseInstance(_handle);

        Debug.Log("AddressableAsset���A�����[�h���܂���");
    }
}
