using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject buttonGoToSearchGO;
    [SerializeField] private Animator mainScreenAnimator;

    [SerializeField] private Animator backgroundAnimator;

    [SerializeField] private GameObject buttonGoToHomeGO;
    [SerializeField] private Animator searchScreenAnimator;

    [SerializeField] private InputField searchBarInputField;

    [SerializeField] private Text textNotFound;

    [SerializeField] private GameObject ButtonsScenesContainer;

    [SerializeField] private GameObject[] allButtons;

    private Button[] buttonComponentsMas;

    [SerializeField] private Vector2[] allButtonsTransformPositions;

    #region Singleton

    public static MainMenuManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    private void Start()
    {
        searchBarInputField.onValueChanged.AddListener(delegate { OnInputFieldTextChange(searchBarInputField.text); });

        textNotFound.gameObject.SetActive(false);
        textNotFound.text = string.Empty;

        searchScreenAnimator.enabled = false;
        mainScreenAnimator.enabled = false;
        backgroundAnimator.enabled = false;

        // Initialize all arrays

        buttonComponentsMas = ButtonsScenesContainer.GetComponentsInChildren<Button>();

        allButtons = new GameObject[buttonComponentsMas.Length];

        for (int i = 0; i < allButtons.Length; i++)
        {
            allButtons[i] = buttonComponentsMas[i].gameObject;
        }

        AssignButtonsTransforms();
    }

    public void AssignButtonsTransforms()
    {
        allButtonsTransformPositions = new Vector2[allButtons.Length];

        for (int i = 0; i < allButtonsTransformPositions.Length; i++)
        {
            allButtonsTransformPositions[i] = allButtons[i].transform.position;
        }
    }

    public void AnimateScreens()
    {
        var clickedButtonGO = EventSystem.current.currentSelectedGameObject;

        if (!mainScreenAnimator.enabled || !searchScreenAnimator.enabled || !backgroundAnimator.enabled)
        {
            mainScreenAnimator.enabled = true;
            searchScreenAnimator.enabled = true;
            backgroundAnimator.enabled = true;
            mainScreenAnimator.StopPlayback();
            searchScreenAnimator.StopPlayback();
            backgroundAnimator.StopPlayback();
        }

        if (clickedButtonGO == buttonGoToSearchGO)
        {
            mainScreenAnimator.Play("MainScreenAnimationDown");
            searchScreenAnimator.Play("SearchScreenAnimationUp");
            backgroundAnimator.Play("BackgroundAnimationRight");
        }
        else if (clickedButtonGO == buttonGoToHomeGO)
        {
            searchBarInputField.text = string.Empty;
            //OnInputFieldTextChange(string.Empty);
            mainScreenAnimator.Play("MainScreenAnimationUp");
            searchScreenAnimator.Play("SearchScreenAnimationDown");
            backgroundAnimator.Play("BackgroundAnimationLeft");
        }
    }

    public void LoadScene()
    {
        //var clickedButtonData = EventSystem.current.currentSelectedGameObject.GetComponent<ButtonData>();
        var clickedButton = EventSystem.current.currentSelectedGameObject;

        //if (clickedButtonData.sceneToLoad != null)
        //{
        string sceneToLoadName = clickedButton.name.Replace("Button", string.Empty);
        SceneManager.LoadScene(sceneToLoadName);
        //}
    }

    public void OnInputFieldTextChange(string searchText)
    {
        textNotFound.gameObject.SetActive(false);
        textNotFound.text = string.Empty;

        if (searchText == string.Empty)
        {
            for (int i = 0; i < allButtons.Length; i++)
            {
                allButtons[i].transform.position = allButtonsTransformPositions[i];
                allButtons[i].SetActive(true);
            }

            return;
        }

        CultureInfo languageCultureInfo = CultureInfo.CurrentCulture;
        var buttonListToReturn = allButtons.Where(buttonMatched =>
            languageCultureInfo.CompareInfo.IndexOf(buttonMatched.GetComponent<ButtonData>().applicationName,
                searchText, CompareOptions.IgnoreCase) >= 0).ToList();

        if (buttonListToReturn.Count == 0)
        {
            textNotFound.gameObject.SetActive(true);
            textNotFound.text = "No Apps found matching " + searchText;
        }

        foreach (var button in allButtons)
        {
            button.SetActive(false);
        }

        for (int i = 0; i < buttonListToReturn.Count; i++)
        {
            buttonListToReturn[i].transform.position = allButtonsTransformPositions[i];
            buttonListToReturn[i].SetActive(true);
        }
    }

    public void GoToWebSite()
    {
        Application.OpenURL("http://eymaaar.ch/");
    }
}