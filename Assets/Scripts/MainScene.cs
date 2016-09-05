using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainScene : GenericSceneManager
{

    public GameObject gameOver;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene("Main");
        }
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public override void EnterCollision(GameObject obj1, GameObject obj2)
    {
        if (obj1.CompareTag("Player"))
        {
            if (obj2.CompareTag("Player"))
            {
                if (obj1.GetComponent<Movement>().attacking && !obj2.GetComponent<Movement>().attacking)
                {
                    obj2.GetComponent<LifeManager>().ReceiveAttack(obj1.GetComponent<Rigidbody2D>().velocity,
																   obj1.GetComponent<Movement>().ChargeForce);
                    obj2.GetComponent<LifeManager>().LastAttacker = obj1.gameObject;
                    obj1.GetComponent<Movement>().attacking = false;
                    Debug.Log("Stop");
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
                //obj1.GetComponent<Rigidbody2D>().drag = 3;
            }else if (obj2.CompareTag("Limits"))
            {
                obj1.GetComponent<LifeManager>().Die();
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
                //obj1.GetComponent<Rigidbody2D>().drag = 0;
            }
        }
    }
}