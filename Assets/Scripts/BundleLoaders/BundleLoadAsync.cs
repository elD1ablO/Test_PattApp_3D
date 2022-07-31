using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class BundleLoadAsync : MonoBehaviour
{

    [SerializeField] string bundleName = "test";
    [SerializeField] string[] assetName = new[] { "BG1", "BG2", "BG3" };

    [SerializeField] GameObject background;

    int lvlIndex;
    int newIndex;
    
    IEnumerator Start()
    {
        AssetBundleCreateRequest asyncBundleRequest = AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, bundleName));
        yield return asyncBundleRequest;

        AssetBundle localAssetBundle = asyncBundleRequest.assetBundle;

        if (localAssetBundle == null)
        {
            Debug.LogError("Failed to load AsseetBundle!");
            yield break;
        }

        AssetBundleRequest assetRequest = localAssetBundle.LoadAssetAsync<Sprite>(assetName[0]);
        yield return assetRequest;

        Sprite newBG = assetRequest.asset as Sprite;
        background.GetComponent<SpriteRenderer>().sprite = newBG;
        //Instantiate(newBG);

        localAssetBundle.Unload(false);
    }
    /*
    public void LoadNewBG(int index)
    {
        lvlIndex = index;
    }
    void LoadNewBG()
    {
        lvlIndex = newIndex;
    }*/
}
