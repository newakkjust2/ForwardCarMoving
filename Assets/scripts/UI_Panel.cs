using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Panel : MonoBehaviour, IDragHandler ,IBeginDragHandler
{
    [SerializeField] private float dragMultiplyer = 2;
   [SerializeField] private TMP_Text scoreText;
   [SerializeField] private Rigidbody[] obstacles;
   
    private int score = 0, lastscore;
    public int Score
    {
        get => score;
        set
        {
            score++;
            scoreText.text = score.ToString();
        }
    } 
    private Transform _player;
    
    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (lastscore == score)
        {
            Debug.Log("drag");
            Vector2 force = eventData.delta * dragMultiplyer;
            obstacles[NearestObstacle()].AddForce(force.x, 0, force.y);
        }
    }

    private int NearestObstacle()
    {
        int index = 0;
        float min = 1000;
        for (var i = 0; i < obstacles.Length; i++)
        {
            float newPos = obstacles[i].position.z - _player.position.z; 
            if ( newPos > 0)
            { 
                if (newPos < min)
                {
                    min = newPos;
                    index = i;
                } 
            }
        } 
        return index;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        lastscore = score;
    }
}
