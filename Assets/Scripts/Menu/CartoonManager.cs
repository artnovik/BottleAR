using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CartoonManager : MonoBehaviour
{
    [SerializeField] private GameObject fadeImageFromStart;
    [SerializeField] private GameObject fadeImageToMenu;

    [SerializeField] private GameObject buttonSkip;

    [SerializeField] private VideoPlayer vid;

    private void Start()
    {
        buttonSkip.SetActive(false);
        fadeImageToMenu.SetActive(false);

        fadeImageFromStart.SetActive(true);

        vid.Pause();

        vid.loopPointReached += VideoEnded;
    }

    public void PlayCartoon()
    {
        vid.Play();
    }

    public void EnableSkipButton()
    {
        buttonSkip.SetActive(true);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void VideoEnded(VideoPlayer vp)
    {
        fadeImageToMenu.SetActive(true);
    }
}