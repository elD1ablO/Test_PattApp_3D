using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class BundleLoadAsync : MonoBehaviour
{

    [SerializeField] string bundleName = "test";
    [SerializeField] string[] assetName = new[] { "BG1", "BG2", "BG3" };

    [SerializeField] GameObject background;

    int lvlIndex = 0;
    int newIndex;
    
    void Awake()
    {
        StartCoroutine(LoadNewBG(lvlIndex));
    }

    void Update()
    {
        
    }

    public void ReloadBG(int index)
    {
        StartCoroutine(LoadNewBG(index));
    }

    IEnumerator LoadNewBG(int index)
    {
        AssetBundleCreateRequest asyncBundleRequest = AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, bundleName));
        yield return asyncBundleRequest;

        AssetBundle localAssetBundle = asyncBundleRequest.assetBundle;

        if (localAssetBundle == null)
        {
            Debug.LogError("Failed to load AsseetBundle!");
            yield break;
        }

        AssetBundleRequest assetRequest = localAssetBundle.LoadAssetAsync<Sprite>(assetName[index]);
        yield return assetRequest;

        Sprite newBG = assetRequest.asset as Sprite;
        background.GetComponent<SpriteRenderer>().sprite = newBG;

        localAssetBundle.Unload(false);
    }

}
