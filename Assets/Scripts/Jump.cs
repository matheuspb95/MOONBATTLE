using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
    /*[SerializeField]
    Vector3 Offset;*/
    [SerializeField]
    Transform target;
    /*[SerializeField]
    Vector3 SpawnBoxRightOffset, SpawnBoxLeftOffset;*/
    [SerializeField]
    float initialAngle;
    private bool IsTurnedRight = true;
    private GameObject Controller;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Jumper()
    {
        Debug.Log("!GAGA");
        //target = VarHolder.CurrentJumpTarget;
        var rigid = GetComponent<Rigidbody>();

        Vector3 p = target.position;

        float gravity = 100;//Physics.gravity.magnitude;
        // ANGULO EM RADIANOS
        float angle = initialAngle * Mathf.Deg2Rad;

        // Posicoes dos objetos no msm plano
        Vector3 planarTarget = new Vector3(p.x, 0, p.z);
        Vector3 planarPostion = new Vector3(transform.position.x, 0, transform.position.z);

        // Planar distance between objects
        float distance = Vector3.Distance(planarTarget, planarPostion);
        // Distancia no eixo y entre os objetos
        float yOffset = transform.position.y - p.y;

        float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));

        Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

        // Rotate 
        float angleBetweenObjects = Vector3.Angle(Vector3.forward, planarTarget - planarPostion);
        Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;

        // Fire!
        rigid.velocity = finalVelocity;

        // Alternative way:
        rigid.AddForce(finalVelocity * rigid.mass, ForceMode.Impulse);
    }
}
