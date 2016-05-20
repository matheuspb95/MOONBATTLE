using UnityEngine;
using System.Collections;

public class CenterGravity : MonoBehaviour {
    public float gravity;
    Rigidbody2D body;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //Criar uma lista de rigibody e adicionalos quando sao criados
	    foreach(Rigidbody2D b in GameObject.FindObjectsOfType<Rigidbody2D>())
        {
            if(b != body)
            {
                Vector3 dir = (Vector2)transform.position - b.position;
                float dist = Vector2.Distance((Vector2)transform.position, b.position);
                Vector3 force = dir.normalized * gravity;

                b.AddForce(force * dist);

                float angle = Vector3.Angle(dir, Vector3.up);

                if (b.position.x < transform.position.x)
                {
                    b.rotation = -angle;
                }
                else
                {
                    b.rotation = angle;
                }
            }
        }
	}
}
