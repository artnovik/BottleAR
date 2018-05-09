using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonData : MonoBehaviour
{
    public string applicationName;
    public Object sceneToLoad;
    public string sceneToLoadName;

    //private void Start()
    //{
    //    applicationName = GetComponentInChildren<Text>().text;

    //    if (sceneToLoad != null)
    //        sceneToLoadName = sceneToLoad.name;
    //}

    private void Start()
    {
        applicationName = GetComponentInChildren<Text>().text;
        sceneToLoadName = applicationName;
    }
}