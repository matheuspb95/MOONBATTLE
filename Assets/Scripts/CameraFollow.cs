using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollow : MonoBehaviour {
    private Camera camera;
    public float MinimalSize;
    public float MaxSize;
    Vector3 TargetPosition;
    private int div;
    public float posx = 0;
    public float posy = 0;
    public float MaxDist = 0;
    public List<Transform> Targets = new List<Transform>();
    public float LimitX;
    public float LimitY;
    public float halfWidthScreen;
    public float halfHeightScreen;

    // Use this for initialization
    void Start () {
        camera = gameObject.GetComponent<Camera>();
        //MinimalSize = camera.orthographicSize;
    }

    // Update is called once per frame
    void Update () {
        /*
        gameObject.transform.position = new Vector3 ((target1.position.x + target2.position.x) / 2,
			(target1.position.y + target2.position.y) / 2, 
			gameObject.transform.position.z);

        if ((target1.position.x - target2.position.x) > 1 && camera.orthographicSize < 2) {
			camera.orthographicSize = Mathf.SmoothDamp (size, size + (target1.position.x - target2.position.x) / 20, ref vec, vecl);
        }

        if ((target2.position.x - target1.position.x) > 1 && camera.orthographicSize < 2) {
			camera.orthographicSize = Mathf.SmoothDamp (size, size + (target2.position.x - target1.position.x) / 20, ref vec, vecl);
        }
        */

        posx = posy = div = 0;
        foreach (Transform target in Targets)
        {
            if(target != null)
            {
                div++;
                posx = (posx + target.localPosition.x);
                posy = (posy + target.localPosition.y);
            }            
        }

        halfWidthScreen = camera.orthographicSize * camera.aspect;
        halfHeightScreen = camera.orthographicSize;

        float MaxX = LimitX - halfWidthScreen;
        float MaxY = LimitY - halfHeightScreen;
        
        if ((posy / div) > MaxY)
            posy = MaxY * div;
        if ((posy / div) < -MaxY)
            posy = -MaxY * div;
        if ((posx / div) > MaxX)
            posx = MaxX * div;
        if ((posx / div) < -MaxX)
            posx = -MaxX * div;
        
        transform.position = new Vector3(posx / div, posy / div, transform.position.z);
        TargetPosition = transform.position;
        
        //MaxSize = LimitY;
        MaxSize = MinimalSize;
        for (int i = 0; i < Targets.Count; i++)
        { 
            {
                for (int j = 0; j < Targets.Count; j++)
                {
                    if (i != j)
                    {
                    if(Targets[i] != null && Targets[j] != null)
                    {
                        float dist = Vector2.Distance(Targets[i].position, Targets[j].position);
                        if (dist > MaxSize) MaxSize = dist;
                    }
                        
                    }
                }
            }
        }
        float n = 0;
        if (MaxDist > MaxSize)
            camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, MaxSize, ref n, 0.1f);
        else if (MaxDist > MinimalSize)
            camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, (MaxDist * 2 * MinimalSize), ref n, 0.1f);
        else
            camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, MinimalSize, ref n, 0.1f);


    }
}
