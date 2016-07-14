﻿using UnityEngine;
using System.Collections;

public class Movement : ObjectController {
    public float velocity;
    public float maxVelocity;
    public float JumpForce;
    public float gravityForce;
    public float AttackForce;
    public bool canJump;
    public bool canAttack;
    public bool attacking;
    public ParticleSystem smoke;
    public GameObject AttackEffect;
    public float DashTime;
    float walkDirection;
	// Use this for initialization
	public override void Start () {
        base.Start();
        var em = smoke.emission;
        em.enabled = false;
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

    public void SetEmission(bool emit)
    {
        var em = smoke.emission;
        em.enabled = emit;
    }

    public void Walk(float direction)
    {
        if (canAttack)
        {
            walkDirection = direction;
            if (direction < 0) transform.localScale = new Vector3(2, -2);
            else if (direction > 0) transform.localScale = new Vector3(-2, -2);
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
            float dirx = Mathf.Cos(Mathf.Deg2Rad * (body.rotation - 90));
            float diry = Mathf.Sin(Mathf.Deg2Rad * (body.rotation - 90));

            Vector2 force = new Vector2(dirx, diry) * JumpForce;
            body.AddForce(force);
        }        
    }

    IEnumerator Dash()
    {
        float EndTime = Time.time + DashTime;
        canAttack = false;
        attacking = true;
        AttackEffect.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = false;
        while (EndTime > Time.time && attacking)
        {
            yield return new WaitForFixedUpdate();            
            if (walkDirection < 0) transform.localScale = new Vector3(2, -2);
            else if (walkDirection > 0) transform.localScale = new Vector3(-2, -2);
            body.rotation = body.rotation - 1f;
            float dirx = Mathf.Cos(Mathf.Deg2Rad * body.rotation);
            float diry = Mathf.Sin(Mathf.Deg2Rad * body.rotation);
            Vector2 vel = -AttackForce * new Vector2(dirx, diry) * walkDirection;
            body.velocity = vel;
        }
        body.velocity = Vector2.zero;
        AttackEffect.SetActive(false);
        GetComponent<SpriteRenderer>().enabled = true;
        canAttack = true;
        attacking = false;
    }

    public void Attack()
    {
        if(walkDirection != 0 && canAttack)
        {
            StartCoroutine(Dash());
        }
    }
}
