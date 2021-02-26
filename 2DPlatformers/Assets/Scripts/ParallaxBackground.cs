using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    private float length, startpos;
    public GameObject cam;
    public float parallaxAmount;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = (cam.transform.position.x * parallaxAmount);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
    }
}
