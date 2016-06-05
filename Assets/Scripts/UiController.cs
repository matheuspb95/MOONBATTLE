using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UiController : MonoBehaviour {
    public Text damageTxt1;
    public Text damageTxt2;
    public Text damageTxt3;
    public Text damageTxt4;

    public void UpdateDamage(int player, int damage)
    {
        switch (player)
        {
            case 1:
                if(damageTxt1 != null)
                {
                    damageTxt1.text = "" + damage + "%";
                }
                break;
            case 2:
                if(damageTxt2 != null)
                {
                    damageTxt2.text = "" + damage + "%";
                }
                break;
            case 3:
                if(damageTxt3 != null)
                {
                    damageTxt3.text = "" + damage + "%";
                }
                break;
            case 4:
                if(damageTxt4 != null)
                {
                    damageTxt4.text = "" + damage + "%";
                }
                break;
        }        
    }
}
