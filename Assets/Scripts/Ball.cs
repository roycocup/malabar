using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	Rigidbody rb; 
	float speed = 15f;
    bool isInPlay = false;
    AudioSource audioSource;

	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();

		rb = gameObject.GetComponent<Rigidbody> ();
		rb.mass = 1;
		rb.isKinematic = false; 
		rb.useGravity = true; 

		rb.velocity = Vector2.down * speed;
	}

    private void FixedUpdate()
    {
        if (IsInBounds()){
            isInPlay = true;
        }
            
        if (isInPlay && IsOutOfBounds())
            Die();
    }

    void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag != "Paddles")
			return;

        audioSource.Play();

		// Calculate hit Factor
		float x = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);

		// Calculate direction, set length to 1
		Vector2 dir = new Vector2(x, 1).normalized;

		// Set Velocity with dir * speed
		rb.velocity = dir * speed;

        Vector3 p = transform.position;
        transform.position = new Vector3(p.x, p.y, Random.RandomRange(-10, 10));
	}


	float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth) {
		// ascii art:
		//
		// 1  -0.5  0  0.5   1  <- x value
		// ===================  <- racket
		//
		return (ballPos.x - racketPos.x) / racketWidth;
	}

	public void Die(){
		Destroy (gameObject);
	}

    bool IsOutOfBounds()
    {
        World world = GameObject.Find("GameManager").GetComponent<World>();
        Vector3 p = transform.position; 

        if (p.x < -20 || p.y < -20 || p.x > world.width+10 || p.y > world.height+10)
            return true;
        
        return false;
    }

    bool IsInBounds()
    {
        World world = GameObject.Find("GameManager").GetComponent<World>();
        Vector3 p = transform.position;

        if (p.x > 10 || p.y > 10 || p.x < world.width-10 || p.y < world.height-10)
            return true;

        return false;
    }


}
