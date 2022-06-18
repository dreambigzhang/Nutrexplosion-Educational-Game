using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float horizontal = 0.0f;
    public float lRange = 8.7f;
    public float rRange = 9.7f;
    public static float moveSpeed = 15.0f;
    //Define the speed at which the object moves.
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10.0f;
    }
    // Update is called once per frame
    void Update()
    {   if (transform.position.x < -lRange)
        { transform.position = new Vector3(-lRange, transform.position.y, transform.position.z); }
        if (transform.position.x > rRange)
        { transform.position = new Vector3(rRange, transform.position.y, transform.position.z); }
        float horizontalInput = Input.GetAxis("Horizontal");
        //Get the value of the Horizontal input axis.
        transform.Translate(new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime);
    }
}
