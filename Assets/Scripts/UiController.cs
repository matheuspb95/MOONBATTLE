using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UiController : MonoBehaviour {
    public Text damageTxt1;
    public Text damageTxt2;
    public Text damageTxt3;
    public Text damageTxt4;
    public List<Text> scores = new List<Text>();
    public void DecreaseLife(GameObject lifesContainer)
    {
        GameObject lifeObj = lifesContainer.transform.GetChild(lifesContainer.transform.childCount - 1).gameObject;
        Destroy(lifeObj);
    }

    public void UpdateKills(int player, int Kills)
    {
        scores[player-1].text = "Kills: " + Kills;
    }

    public void UpdateDamage(int player, float damage)
    {
        switch (player)
        {
            case 1:
                if(damageTxt1 != null)
                {
					damageTxt1.text = "" + Mathf.RoundToInt(damage) + "%";
                }
                break;
            case 2:
                if(damageTxt2 != null)
                {
					damageTxt2.text = "" + Mathf.RoundToInt(damage) + "%";
                }
                break;
            case 3:
                if(damageTxt3 != null)
                {
					damageTxt3.text = "" + Mathf.RoundToInt(damage) + "%";
                }
                break;
            case 4:
                if(damageTxt4 != null)
                {
					damageTxt4.text = "" + Mathf.RoundToInt(damage) + "%";
                }
                break;
        }        
    }
}
