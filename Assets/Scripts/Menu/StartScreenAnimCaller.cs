using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenAnimCaller : MonoBehaviour
{
    [SerializeField] private StartScreenManager startScreenManager;

    public void NextAnimation()
    {
        startScreenManager.NextAnimation();
        gameObject.GetComponent<Animator>().enabled = false;
    }

    public void Final()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        startScreenManager.CrossFadeBetweenStartAndMenu();
    }
}