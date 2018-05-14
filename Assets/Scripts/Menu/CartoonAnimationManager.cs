using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CartoonAnimationManager : MonoBehaviour
{
    [SerializeField] private CartoonManager _cartoonManager;

    private void LaunchCartoon()
    {
        _cartoonManager.PlayCartoon();

        _cartoonManager.EnableSkipButton();
    }

    private void ToMenu()
    {
        _cartoonManager.ToMenu();
    }
}