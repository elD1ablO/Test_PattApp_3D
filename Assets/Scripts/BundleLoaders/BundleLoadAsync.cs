using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class BundleLoadAsync : MonoBehaviour
{

    [SerializeField] string bundleName = "testbundle";
    [SerializeField] string[] assetName = new[] { "BG1", "BG2", "BG3" };
    int lvlIndex;
    int newIndex;
    void OnEnable()
    {
        LoadNewBG();
    }
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

        AssetBundleRequest assetRequest = localAssetBundle.LoadAssetAsync<GameObject>(assetName[lvlIndex]);
        yield return assetRequest;

        GameObject prefab = assetRequest.asset as GameObject;
        Instantiate(prefab);

        localAssetBundle.Unload(false);
    }
    public void LoadNewBG(int index)
    {
        lvlIndex = index;
    }
    void LoadNewBG()
    {
        lvlIndex = newIndex;
    }
}
