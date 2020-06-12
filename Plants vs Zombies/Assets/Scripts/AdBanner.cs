using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdBanner : MonoBehaviour {

    public string gameId = "3628723";
    public string placementId = "Options";
    public bool testMode = true;

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        while(!Advertisement.IsReady (placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show (placementId);
    }
}