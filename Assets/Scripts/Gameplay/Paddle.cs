using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;


/// <summary>
/// A paddle
/// </summary>
public class Paddle : MonoBehaviour
{
    // Get this for moving paddle
    private Rigidbody2D _rigidbody;

    private float _halfWidthCollider;
    private float _halfHeightCollider;

    private const float BounceAngleHalfRange = 60 * (Mathf.PI / 180);
    
    /// <summary>
    /// Use this for initialize
    /// </summary>
    void Start()
    {
        // Saved this for efficiency
        _rigidbody = GetComponent<Rigidbody2D>();
        _halfWidthCollider = GetComponent<BoxCollider2D>().size.x / 2;
        _halfHeightCollider = GetComponent<BoxCollider2D>().size.y / 2;
    }

    float CalculateClampedX(Vector2 position)
    {
        if (position.x - _halfWidthCollider < ScreenUtils.ScreenLeft)
            position.x = ScreenUtils.ScreenLeft + _halfWidthCollider;
        if (position.x + _halfWidthCollider > ScreenUtils.ScreenRight)
            position.x = ScreenUtils.ScreenRight - _halfWidthCollider;
        return position.x;
    }
    
    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            Vector2 position = transform.position;
            
            position.x += Input.GetAxis("Horizontal") * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;
            position.x = CalculateClampedX(position);
            _rigidbody.MovePosition(position);
        }
    }

    private bool IfTop(float ballPosition, float paddleTop)
    {
        Debug.Log("ball " + ballPosition + " paddle " + paddleTop);
        if (ballPosition + 0.05f < paddleTop)
            return false;
        return true;
    }
    
    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        bool checkTop = IfTop(coll.gameObject.transform.position.y - coll.gameObject.GetComponent<CircleCollider2D>().radius,
                    transform.position.y + _halfHeightCollider);

        if (coll.gameObject.CompareTag("Ball") && checkTop)
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                                               coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                                         _halfWidthCollider;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

      
            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }
}
