using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfScene : MonoBehaviour
{
    private UI_Panel ui;

    private void Awake()
    {
        ui = FindObjectOfType<UI_Panel>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            ui.Score = 1;
            other.gameObject.SetActive(false);
        }
    }
 
}
