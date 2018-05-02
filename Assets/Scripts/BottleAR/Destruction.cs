using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    [SerializeField]
    private GameObject _destroyedVersion;

    [SerializeField]
    private GameObject _holeVersion;

    private void Start()
    {
        StartCoroutine(DestructionCoroutine(5f));
    }

    private IEnumerator DestructionCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        _destroyedVersion.SetActive(true);
        _holeVersion.SetActive(true);
        Destroy(gameObject);
        yield break;
    }
}
