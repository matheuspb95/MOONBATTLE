using UnityEngine;
using System.Collections;

public class MainScene : GenericSceneManager
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void EnterCollision(GameObject obj1, GameObject obj2)
    {
        if (obj1.CompareTag("Player"))
        {
            if (obj2.CompareTag("Player"))
            {
                if (obj1.GetComponent<Movement>().attacking && !obj2.GetComponent<Movement>().attacking)
                {
                    obj2.GetComponent<Movement>().ReceiveAttack(obj1.GetComponent<Rigidbody2D>().velocity);
                    obj1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    

                }
                else if (obj1.GetComponent<Movement>().attacking && obj2.GetComponent<Movement>().attacking)
                {
                    Debug.Log("3");
                }
                else if (!obj1.GetComponent<Movement>().attacking && !obj2.GetComponent<Movement>().attacking)
                {
                    Debug.Log("4");
                }
            }else if (obj2.CompareTag("Moon"))
            {
                obj1.GetComponent<Movement>().canJump = true;
                //obj1.GetComponent<Movement>().canAttack = true;
            }
        }
    }
}
