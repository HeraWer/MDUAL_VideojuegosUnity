﻿using UnityEngine;
using
System.Collections;
public class PlayerBulletParabolicController : MonoBehaviour
{
    //Se li assignara un objecte automaticament, en crear una bala a PlayerStateListener
    public GameObject
    playerObject = null;
    public float bulletSpeed = 15.0f;
    private float selfDestructTimer = 0.0f;
    public void launchBulletParabolic()
    { // Volem que el Player dispari cap al costat al que mira.
      // Aixo ens ho indica el component "local scale" ha de ser trigger

        float mainXScale = playerObject.transform.localPosition.x;
        Vector2 bulletForce;
        if (mainXScale < 0.0f)
        {
            // Disparar cap a l'esquerra
            bulletForce = new Vector2(bulletSpeed * -1.0f, 5.0f);
        }
        else
        {
            // Disparar cap a la dreta
            bulletForce = new Vector2(bulletSpeed, 5.0f);
        }
        GetComponent<Rigidbody2D>().velocity = bulletForce;
        //Establir moment d'autodestrucció
        selfDestructTimer = Time.time + 1.0f;
    }
    void Update()
    {
        //Destruir l'objecte si ha consumit el temps
        if (selfDestructTimer > 0.0f)
        {
            if (selfDestructTimer < Time.time)
                Destroy(gameObject);
        }
    }
}