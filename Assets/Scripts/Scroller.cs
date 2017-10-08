using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour {

    // Use this for initialization
    public float scrollSpeed = 0.5F;
    public MeshRenderer rend;
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        rend.sortingLayerName = "Background";
    }
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
