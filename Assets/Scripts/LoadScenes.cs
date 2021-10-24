using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
public class LoadScenes : MonoBehaviour
{
#if UNITY_ANDROID
    public string gameId = "4146801";
    public string surfacingId = "Interstitial_Android";
#elif UNITY_IOS
    public string gameId = "4146800";
    public string surfacingId = "Interstitial_iOS";
#endif
    bool testMode = false;

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void RestartGame()
    {
        ShowAd();
        SceneManager.LoadScene("Game");
    }

    void ShowAd()
    {
        if (Random.Range(0,2) == 0 && Advertisement.IsReady(surfacingId))
        {
            Advertisement.Show(surfacingId);
        }
        else
        {
            Debug.Log("Restart ad is not");
        }
    }
}
