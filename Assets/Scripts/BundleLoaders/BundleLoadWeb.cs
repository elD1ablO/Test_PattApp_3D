using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class BundleLoadWeb : MonoBehaviour
{
    /*[SerializeField] string bundleURL = "http://localhost/assetbundles/testbundle";
    [SerializeField] string[] assetName = new[] { "BG1", "BG2", "BG3" };
     IEnumerator Start()
    {
        using (WWW web = new WWW(bundleURL)) 
        {
        yield return web;

        AssetBundle remoteAssetBundle = web.assetBundle;
        if( remoteAssetBundle == null)
        {
            Debug.LogError("Failed to download AssetBundle");
            yield break;
        }

        Instantiate(remoteAssetBundle.LoadAsset(assetName[0]));
        remoteAssetBundle.Unload(false);

        }
    }*/

}
