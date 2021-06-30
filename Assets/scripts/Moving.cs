
using UnityEngine.Events;
using UnityEngine;

public class Moving : MonoBehaviour
{
    
    [SerializeField] private ParticleSystem explosionPS;
    [SerializeField] private float speed = 10f;
    private bool _move;
    private Vector3 _dirSpeed;

    private Coroutine _handler;


    void Start()
    {
        _dirSpeed = Vector3.forward * speed;
    }

    public void StopMoving()
    {
        _move = false;
    }

    public void Finish()
    {
        StopMoving();
    }

    public void Explosion()
    {
        StopMoving();
        explosionPS.Play();
    }
    
    public void StartMoving()
    {
        _move = true;
    }
   
    void FixedUpdate()
    {
        if (_move)
        {
            transform.position += _dirSpeed * Time.fixedDeltaTime;
        }
        
    }
}
