using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour {
    public int DamageTaken;
    public int Lifes;
    public float initialLaunchForce;
    public int PlayerNumber;
    Rigidbody2D body;
    public GameObject LastAttacker;
    Vector3 spawnPosition;
    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
        spawnPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ReceiveAttack(Vector2 direction)
    {
        Vector2 vel = (initialLaunchForce + DamageTaken) * direction.normalized;
        body.AddForce(vel);
        DamageTaken += 50;
        GameObject.FindObjectOfType<UiController>().UpdateDamage(PlayerNumber, DamageTaken / 6);
    }

    public void Die()
    {

    }

    public void Spawn()
    {

    }
}
