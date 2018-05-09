using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using Vuforia;

public class LabelManager : MonoBehaviour
{
    [SerializeField] private GameObject destroyedVersion;

    [SerializeField] private VideoPlayer videoPlayer;

    [SerializeField] private Renderer labelForVideoMeshRenderer;

    private const float delay = 3f;

    private void Awake()
    {
        videoPlayer.enabled = false;
        destroyedVersion.SetActive(false);
        labelForVideoMeshRenderer.material.color = Color.white;
    }

    private void Start()
    {
        Destroy(delay);
    }

    private void Destroy(float delay)
    {
        StartCoroutine(Destruction(delay));
    }

    private IEnumerator Destruction(float delay)
    {
        yield return new WaitForSeconds(delay);
        destroyedVersion.SetActive(true);
        labelForVideoMeshRenderer.material.color = Color.black;

        //yield return new WaitForSeconds(1f);
        videoPlayer.enabled = true;
        videoPlayer.Pause();
        yield return new WaitForSeconds(1f);
        videoPlayer.Play();
        labelForVideoMeshRenderer.material.color = Color.white;

        yield return new WaitForSeconds(5f);
        Destroy(destroyedVersion);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private bool flash = false;

    public void Flashlight()
    {
        CameraDevice.Instance.SetFlashTorchMode(!flash);
        flash = !flash;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}