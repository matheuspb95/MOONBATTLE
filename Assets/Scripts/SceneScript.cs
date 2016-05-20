using UnityEngine;
using System.Collections;
using System;

public class SceneScript : MonoBehaviour
{
    public void Awake()
    {
        _instance = GetComponent<SceneScript>();
    }

    private static SceneScript _instance;
    public static SceneScript manager
    {
        get
        {
            if (FindObjectsOfType<SceneScript>().Length > 1)
            {
                Debug.LogError("Mais de 1 SceneManager encontrado na cena");
            }

            if (_instance == null)
            {
                Debug.LogError("SceneManager nao encontrado");
            }

            return _instance;
        }
    }

    public void EnterCollision(GameObject obj1, GameObject obj2)
    {
        Debug.Log(obj1.ToString() + "/" + obj2.ToString());
    }

    public void StayCollision(GameObject obj1, GameObject obj2)
    {
        Debug.Log(obj1.ToString() + "/" + obj2.ToString());
    }

    public void ExitCollision(GameObject obj1, GameObject obj2)
    {
        Debug.Log(obj1.ToString() + "/" + obj2.ToString());
    }
}
