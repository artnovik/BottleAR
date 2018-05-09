using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimationController : MonoBehaviour
{
    public void AssignButtonsTransforms()
    {
        MainMenuManager.Instance.AssignButtonsTransforms();
    }
}