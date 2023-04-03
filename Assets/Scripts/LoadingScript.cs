using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadingScript : MonoBehaviour
{
   public VideoPlayer player;

    private void Start()
    {
        player.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer player)
    {
        SceneManager.LoadSceneAsync(2);
    }
}
