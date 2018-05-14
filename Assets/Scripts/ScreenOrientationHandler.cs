using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenOrientationHandler : MonoBehaviour
{
    public ScreenOrientation screenOrientation;

    private void Start()
    {
        Screen.orientation = screenOrientation;

        IfCartoonScene();
    }

    private void IfCartoonScene()
    {
        if (SceneManager.GetActiveScene().name == "Cartoon")
        {
            StartCoroutine(IfCartoonSceneRoutine());
        }
    }

    private IEnumerator IfCartoonSceneRoutine()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = false;
        yield return new WaitForSeconds(0.5f);
        Screen.orientation = screenOrientation;
    }
}