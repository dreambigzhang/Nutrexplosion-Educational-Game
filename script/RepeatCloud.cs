using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatCloud : MonoBehaviour
{ private Vector3 startPos;
    public float cloudspeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime*cloudspeed);
        if (transform.position.x > 15) { transform.position = startPos; }
    }
}
