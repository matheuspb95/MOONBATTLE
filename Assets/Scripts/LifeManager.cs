﻿using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour {
    public int kills;
    public int DamageTaken;
    public int Lifes;
    public float initialLaunchForce;
    public int PlayerNumber;
    Rigidbody2D body;
    public GameObject LastAttacker;
    public GameObject lifesContainer;
    public GameObject particles;
    Vector3 spawnPosition;
    UiController ui;
    // Use this for initialization
    void Start () {
        ui = GameObject.FindObjectOfType<UiController>();
        body = GetComponent<Rigidbody2D>();
        spawnPosition = transform.position;
        kills = 0;
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ReceiveAttack(Vector2 direction)
    {
        Vector2 vel = (initialLaunchForce + DamageTaken) * direction.normalized;
        body.AddForce(vel);
        DamageTaken += 50;
        ui.UpdateDamage(PlayerNumber, DamageTaken / 6);
    }

    public void Kill()
    {
        kills++;
        ui.UpdateKills(PlayerNumber, kills);
    }

    public void Die()
    {        
        Lifes--;
        body.velocity = Vector2.zero;
        GetComponent<Renderer>().enabled = false;
        LastAttacker.GetComponent<LifeManager>().Kill();
        GameObject NewPart = Instantiate(particles);
        NewPart.transform.position = transform.position;
        NewPart.transform.LookAt(GameObject.Find("Moon").transform);
        NewPart.SetActive(true);
        ui.DecreaseLife(lifesContainer);

        StartCoroutine(ReSpawn());
        
    }

    IEnumerator ReSpawn()
    {
        yield return new WaitForSeconds(1f);
        Spawn();
    }

    public void Spawn()
    {
        if (Lifes > 0)
        {
            GetComponent<Renderer>().enabled = true;
            DamageTaken = 0;
            ui.UpdateDamage(PlayerNumber, DamageTaken / 6);
            transform.position = spawnPosition;
        }
        else
        {
            Destroy(gameObject);
            GameObject.FindObjectOfType<MainScene>().GameOver();
        }
        
    }
}
