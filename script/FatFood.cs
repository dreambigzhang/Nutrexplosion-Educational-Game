using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FatFood : MonoBehaviour
{
    public static int fat;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        FatFood.fat = FatFood.fat + 1;
        PlayerControl.moveSpeed = PlayerControl.moveSpeed - 1.2f;
        Destroy(gameObject);

    }
}
