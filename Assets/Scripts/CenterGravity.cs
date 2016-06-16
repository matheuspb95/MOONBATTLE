using UnityEngine;
using System.Collections;

public class CenterGravity : MonoBehaviour {
    public float gravity;
    Rigidbody2D body;
    public float MaxDistance;
    public float DragDistance;
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
                float dist = Vector2.Distance((Vector2)transform.position, b.position);
                if(DragDistance > dist)
                {
                    b.drag = 3;
                }else
                {
                    b.drag = 0;
                }
                if (MaxDistance > dist)
                {
                    Vector3 dir = (Vector2)transform.position - b.position;

                    Vector3 force = dir.normalized * gravity;
                    Vector3 f = force / (dist * dist);
                    b.AddForce(f);
                    try
                    {
                        b.GetComponent<Movement>().gravityForce = f.magnitude;
                    }
                    catch { }


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
}
