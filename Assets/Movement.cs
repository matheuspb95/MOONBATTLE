using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    Rigidbody2D body;
    public float velocity;
    public float maxVelocity;
    public float JumpForce;
    bool canJump;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        canJump = false;
    }
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetAxisRaw("Horizontal") != 0)
        {
            if (Input.GetAxisRaw("Horizontal") < 0) transform.localScale = new Vector3(1, 1);
            else if (Input.GetAxisRaw("Horizontal") > 0) transform.localScale = new Vector3(1, -1);
            float dirx = Mathf.Cos(Mathf.Deg2Rad * body.rotation);
            float diry = Mathf.Sin(Mathf.Deg2Rad * body.rotation);

            Vector2 vel = -velocity * new Vector2(dirx, diry) * Input.GetAxisRaw("Horizontal");
            if (vel.magnitude > maxVelocity)
                vel = vel.normalized * maxVelocity;
            body.AddForce(vel);
        }
        if (Input.GetButtonDown("Jump") && canJump)
        {
            float dirx = Mathf.Cos(Mathf.Deg2Rad * body.rotation - 90);
            float diry = Mathf.Sin(Mathf.Deg2Rad * body.rotation - 90);

            Vector2 force = new Vector2(dirx, diry) * JumpForce;
            body.AddForce(force);
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        canJump = true;
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        canJump = false;
    }
}
