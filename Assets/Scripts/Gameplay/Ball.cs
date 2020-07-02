using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;


/// <summary>
/// A ball
/// </summary>
public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    
    void Start()
    {
        float angle = 270f * (Mathf.PI / 180);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(direction * Time.deltaTime * ConfigurationUtils.BallImpulseForce, 
                                                ForceMode2D.Impulse);
    }

    public void SetDirection(Vector2 direction)
    {
        _rigidbody2D.velocity = direction * Time.deltaTime * ConfigurationUtils.BallImpulseForce;
    }
    
    void Update()
    {
        
    }
}
