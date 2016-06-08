using UnityEngine;
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
        LastAttacker.GetComponent<LifeManager>().Kill();
        particles.transform.position = transform.position;
        particles.SetActive(true);
        if (Lifes > 0)
        {
            ui.DecreaseLife(lifesContainer);           
            Spawn();
        }else
        {
            Destroy(gameObject);
            GameObject.FindObjectOfType<MainScene>().GameOver();
        }
    }

    public void Spawn()
    {
        body.velocity = Vector2.zero;
        DamageTaken = 0;
        ui.UpdateDamage(PlayerNumber, DamageTaken / 6);
        transform.position = spawnPosition;
    }
}
