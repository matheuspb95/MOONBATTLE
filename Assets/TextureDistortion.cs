using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class TextureDistortion : MonoBehaviour {

    public Shader shader;
    public Material material;
    // Use this for initialization
    void Start()
    {
        material = new Material(shader);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
    {
        Graphics.Blit(sourceTexture, destTexture, material);
    }
}
