using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BundledObjectsLoader : MonoBehaviour
{
    public string[] assetName = new[] { "BG1", "BG2", "BG3" };
    public string bundleName = "testbundle";

    /*SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    */

    void Start()
    {
              
        AssetBundle localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundleName));

        if (localAssetBundle == null)
        {
            Debug.Log("FAiled to load AssetBundle");
            return;
        }

        GameObject asset = localAssetBundle.LoadAsset<GameObject>(assetName[0]);
        Instantiate(asset);
        localAssetBundle.Unload(false);
    }

    public void LoadNewBG(int index)
    {

    }
}
