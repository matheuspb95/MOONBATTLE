using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
    public GameObject Prefab;
    public float BulletVelocity;
    Rigidbody2D body;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = (GameObject)Instantiate(Prefab, transform.position, Quaternion.Euler(transform.eulerAngles));
            bullet.SetActive(true);
            float dirx = Mathf.Cos(Mathf.Deg2Rad * body.rotation);
            float diry = Mathf.Sin(Mathf.Deg2Rad * body.rotation);

            Vector2 vel = -BulletVelocity * new Vector2(dirx, diry) * ((transform.localScale.y < 0) ? 1:-1);

            bullet.GetComponent<Rigidbody2D>().velocity = vel;
        }
	}
}
