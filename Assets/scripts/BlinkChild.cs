using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkChild : MonoBehaviour
{
    private GameObject _child;
    void Start()
    {
        _child = transform.GetChild(0).gameObject;
        StartCoroutine(Blinking());
    }

    IEnumerator Blinking()
    {
        while (true)
        {
            _child.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            _child.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
