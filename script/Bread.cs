﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : MonoBehaviour
{
    public static int carbonhydrate;
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
        Bread.carbonhydrate= Bread.carbonhydrate+1;
        Destroy(gameObject);

    }
}
