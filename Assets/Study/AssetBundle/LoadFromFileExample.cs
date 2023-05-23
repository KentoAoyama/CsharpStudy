using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadFromFileExample : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    
    void Start()
    {
        var bundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "assetbundletest"));
        
        if (bundle == null)
        {
            Debug.LogWarning("assetbundletest���ǂݍ��߂܂���ł���");
            return;
        }

        var sprite = bundle.LoadAsset<Sprite>("TestImage");

        if (sprite == null)
        {
            Debug.LogWarning("TestImage���ǂݍ��߂܂���ł���");
            return;
        }

        _image.sprite = sprite;

        // AssetBundle�̃��^�����A�����[�h
        bundle.Unload(false);
    }
}
