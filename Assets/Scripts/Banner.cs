using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class Banner : MonoBehaviour
{
// #if UNITY_ANDROID
//     public string gameId = "4146801";
//     public string surfacingId = "Banner_Android";
// #elif UNITY_IOS
//     public string gameId = "4146800";
//     public string surfacingId = "Banner_iOS";
// #endif
//     public bool testMode = false;

//     void Start()
//     {
//         Advertisement.Initialize(gameId, testMode);
//         Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
//         StartCoroutine(ShowBannerWhenInitialized());
//     }

//     IEnumerator ShowBannerWhenInitialized()
//     {
//         while (!Advertisement.isInitialized)
//         {
//             yield return new WaitForSeconds(0.5f);
//         }
//         Advertisement.Banner.Show(surfacingId);
//     }
}