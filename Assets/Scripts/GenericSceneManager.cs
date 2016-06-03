using UnityEngine;
using System.Collections;
using System;

public class GenericSceneManager : MonoBehaviour
{
    public void Awake()
    {
        _instance = GetComponent<GenericSceneManager>();
    }

    private static GenericSceneManager _instance;
    public static GenericSceneManager manager
    {
        get
        {
            if (FindObjectsOfType<GenericSceneManager>().Length > 1)
            {
                Debug.LogError("Mais de 1 SceneManager encontrado na cena");
            }

            if(_instance == null)
            {
                Debug.LogError("SceneManager nao encontrado");
            }

            return _instance;
        }
    }

    public virtual void EnterCollision(GameObject obj1, GameObject obj2)
    {
        //Debug.Log(obj1.ToString() + "/" + obj2.ToString());
    }

    public virtual void StayCollision(GameObject obj1, GameObject obj2)
    {
        //Debug.Log(obj1.ToString() + "/" + obj2.ToString());
    }

    public virtual void ExitCollision(GameObject obj1, GameObject obj2)
    {
        //Debug.Log(obj1.ToString() + "/" + obj2.ToString());
    }
}
