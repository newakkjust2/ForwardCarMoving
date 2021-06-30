 
using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] fireworks;
    [HideInInspector]
    public UnityEvent finishEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Moving>().StopMoving();
            foreach (var firework in fireworks)
            {
                firework.Play();
            }
        }
    }
}
