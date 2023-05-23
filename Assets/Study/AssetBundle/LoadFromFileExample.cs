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
            Debug.LogWarning("assetbundletestが読み込めませんでした");
            return;
        }

        var sprite = bundle.LoadAsset<Sprite>("TestImage");

        if (sprite == null)
        {
            Debug.LogWarning("TestImageが読み込めませんでした");
            return;
        }

        _image.sprite = sprite;

        // AssetBundleのメタ情報をアンロード
        bundle.Unload(false);
    }
}
