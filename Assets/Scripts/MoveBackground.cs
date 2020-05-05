using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour

{
    [SerializeField] float speed = 0.02f;

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0, Time.time * speed);
        gameObject.GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
