using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField]
    private float m_crawlBarrier = 0.01f; // the speed on an axis that counts as if the object is moving in a straight line on that axis
    [SerializeField]
    private float m_moveForce = 10;
    private Rigidbody2D m_Rigidbody2D;

    // Use this for initialization
    private void Awake () {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Move();
    }
    private void FixedUpdate()
    {
        // make sure the enemy is not stuck moving in a straight line on any axis
        Vector2 velocity = m_Rigidbody2D.velocity;
        if ((-m_crawlBarrier < velocity.x && velocity.x < m_crawlBarrier) || (-m_crawlBarrier < velocity.y && velocity.y < m_crawlBarrier))
        {
            Debug.Log("Enemy randomizing move! old velocity: " + velocity);
            Stop();
            Move();
        }
    }

    private void Stop()
    {
        m_Rigidbody2D.velocity = Vector2.zero;
        m_Rigidbody2D.angularVelocity = 0;
    }

    // bounce twords a direction
    private void Move () {
        // randomize the bounce direction
        float angle = Random.Range(0, 359);
        float radians = angle * (Mathf.PI / 180);

        Vector2 angleVector = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
        angleVector.Normalize();
        Debug.Log("Enemy moves: " + angleVector);
        m_Rigidbody2D.AddForce(angleVector * m_moveForce);
    }
}
