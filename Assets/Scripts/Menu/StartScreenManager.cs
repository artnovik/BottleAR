using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreenManager : MonoBehaviour
{
    private Image[] menuEverythingIncludingBackground;

    //[SerializeField]
    //private GameObject allMenuImagesContainer;

    private Image[] startEverythingIncludingBackground;

    [SerializeField] private GameObject allImagesContainer;

    private Image[] allImages;

    [SerializeField] private GameObject allLettersContainer;

    private Image[] allLettersImages;

    private int currentActiveAnimatorNumber;

    [SerializeField] private Animator[] allAnimatorsSequence;

    private readonly Color32 startColor = new Color32(255, 255, 255, 0);

    private void Start()
    {
        startEverythingIncludingBackground = gameObject.GetComponentsInChildren<Image>();
        //menuEverythingIncludingBackground = allMenuImagesContainer.GetComponentsInChildren<Image>();

        allImages = allImagesContainer.GetComponentsInChildren<Image>();
        allLettersImages = allLettersContainer.GetComponentsInChildren<Image>();

        foreach (var animator in gameObject.GetComponentsInChildren<Animator>())
        {
            animator.enabled = false;
        }

        //foreach (var image in menuEverythingIncludingBackground)
        //{
        //    image.color = new Color32(255,255,255,0);
        //}

        foreach (var image in allImages)
        {
            image.gameObject.GetComponent<Animator>().enabled = false;
            image.color = startColor;
        }

        NextAnimation();
    }

    public void CrossFadeBetweenStartAndMenu()
    {
        StartCoroutine(CrossFadeBetweenStartAndMenuRoutine(1f));
    }

    private IEnumerator CrossFadeBetweenStartAndMenuRoutine(float duration)
    {
        foreach (var image in startEverythingIncludingBackground)
        {
            image.CrossFadeAlpha(0f, duration, true);
        }

        yield return new WaitForSeconds(duration);
        //foreach (var image in startEverythingIncludingBackground)
        //{
        //    image.CrossFadeAlpha(1f, duration, true);
        //}

        //yield return new WaitForSeconds(duration);
        //Debug.Log(Time.timeSinceLevelLoad);
        SceneManager.LoadScene("MainMenu");
    }

    public void NextAnimation()
    {
        if (allAnimatorsSequence[currentActiveAnimatorNumber] != null)
        {
            allAnimatorsSequence[currentActiveAnimatorNumber].enabled = true;

            if (currentActiveAnimatorNumber == 2)
            {
                GetComponent<AudioSource>().Play();
            }

            currentActiveAnimatorNumber++;
        }
    }
}