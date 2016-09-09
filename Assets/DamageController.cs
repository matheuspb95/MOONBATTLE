using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DamageController : MonoBehaviour {
    public List<Sprite> Niveis;
    bool neardeath;
	// Use this for initialization
	void Start () {
        neardeath = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetSprite(int i)
    {
        GetComponent<Image>().sprite = Niveis[i];
    }

    public void SetDamage(float damage)
    {
        if(damage < 25)
        {
            SetSprite(0);
            neardeath = false;
        }
        else if(damage < 50)
        {
            SetSprite(1);
        }
        else if (damage < 75)
        {
            SetSprite(2);
        }
        else if(damage < 100)
        {
            SetSprite(3);
        }else
        {
            neardeath = true;
            StartCoroutine(NearDeath());
        }
    }

    IEnumerator NearDeath()
    {
        while (neardeath)
        {
            yield return new WaitForSeconds(0.3f);
            SetSprite(4);
            yield return new WaitForSeconds(0.3f);
            SetSprite(5);
        }
    }
}