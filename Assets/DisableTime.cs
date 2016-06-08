using UnityEngine;
using System.Collections;

public class DisableTime : MonoBehaviour
{
    public float time;
    // Use this for initialization
    void Start()
    {

    }

    public void OnEnable()
    {
        StartCoroutine(Disable());
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
