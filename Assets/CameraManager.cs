using UnityEngine;
using UnityStandardAssets.ImageEffects;
using System.Collections;

public class CameraManager : MonoBehaviour {
    CRT crtEffect;
    NoiseAndGrain noiseEffect;
    VignetteAndChromaticAberration aberrationEffect;
    // Use this for initialization
    void Start () {
        crtEffect = GetComponent<CRT>();
        noiseEffect = GetComponent<NoiseAndGrain>();
        aberrationEffect = GetComponent<VignetteAndChromaticAberration>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            crtEffect.enabled = !crtEffect.enabled;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            noiseEffect.enabled = !noiseEffect.enabled;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            aberrationEffect.enabled = !aberrationEffect.enabled;
        }
    }
}
