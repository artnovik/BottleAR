using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBottleManager : MonoBehaviour
{
    [SerializeField]
    private Object relatedSceneToLoad;

    public void LoadBottleScene()
    {
        SceneManager.LoadScene(relatedSceneToLoad.name);
    }
}
