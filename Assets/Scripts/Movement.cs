using UnityEngine;
using System.Collections;

public class Movement : ObjectController {
    public float velocity;
    public float maxVelocity;
    public float JumpForce;
    public float gravityForce;
    public float AttackForce;
    public int DamageTaken;
    public float initialLaunchForce;
    public bool canJump;
    public bool canAttack;
    public bool attacking;
    float walkDirection;
    public int PlayerNumber;
	// Use this for initialization
	public override void Start () {
        base.Start();
        canJump = false;
        canAttack = true;
        walkDirection = 0;
    }
	
	// Update is called once per frame
	void Update () {
        /*
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
            Jump();   
        }
        */
	}

    public void Walk(float direction)
    {
        if (canAttack)
        {
            walkDirection = direction;
            if (direction < 0) transform.localScale = new Vector3(1, 1);
            else if (direction > 0) transform.localScale = new Vector3(1, -1);
            float dirx = Mathf.Cos(Mathf.Deg2Rad * body.rotation);
            float diry = Mathf.Sin(Mathf.Deg2Rad * body.rotation);

            Vector2 vel = -velocity * new Vector2(dirx, diry) * direction;
            if (vel.magnitude > maxVelocity)
                vel = vel.normalized * maxVelocity;
            body.AddForce(vel);
        }        
    }

    public void Jump()
    {
        if (canJump)
        {
            float dirx = Mathf.Cos(Mathf.Deg2Rad * body.rotation - 90);
            float diry = Mathf.Sin(Mathf.Deg2Rad * body.rotation - 90);

            Vector2 force = new Vector2(dirx, diry) * JumpForce;
            body.AddForce(force);
        }        
    }

    public void Attack()
    {
        if(walkDirection != 0 && canAttack)
        {
            attacking = true;
            canAttack = false;
            if (walkDirection < 0) transform.localScale = new Vector3(1, 1);
            else if (walkDirection > 0) transform.localScale = new Vector3(1, -1);
            float dirx = Mathf.Cos(Mathf.Deg2Rad * body.rotation);
            float diry = Mathf.Sin(Mathf.Deg2Rad * body.rotation);

            Vector2 vel = -AttackForce * new Vector2(dirx, diry) * walkDirection;
            body.AddForce(vel);
            StartCoroutine(CanAttack());
            StartCoroutine(EndAttack());
        }
    }

    IEnumerator CanAttack()
    {
        yield return new WaitForSeconds(0.75f);
        canAttack = true;
    }

    IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(0.2f);
        attacking = false;
    }

    public void ReceiveAttack(Vector2 direction) {
        Vector2 vel = (initialLaunchForce + DamageTaken) * direction.normalized;
        body.AddForce(vel);
        DamageTaken += 50;
        GameObject.FindObjectOfType<UiController>().UpdateDamage(PlayerNumber, DamageTaken/6);
    }
}
