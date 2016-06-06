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
                    obj2.GetComponent<LifeManager>().ReceiveAttack(obj1.GetComponent<Rigidbody2D>().velocity);
                    obj2.GetComponent<LifeManager>().LastAttacker = obj1.gameObject;
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
                obj1.GetComponent<Rigidbody2D>().drag = 3;
            }else if (obj2.CompareTag("Limits"))
            {
                obj2.GetComponent<LifeManager>().Die();
            }
        }
    }

    public override void ExitCollision(GameObject obj1, GameObject obj2)
    {
        if (obj1.CompareTag("Player"))
        {
            if (obj2.CompareTag("Moon"))
            {
                obj1.GetComponent<Movement>().canJump = false;
                obj1.GetComponent<Rigidbody2D>().drag = 0;
            }
        }
    }
}