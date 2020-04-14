using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionsCoins : MonoBehaviour
{

    PlayerStateController player = new PlayerStateController();
    void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if(collidedObject.tag == "Player")
        {
            Destroy(gameObject);
            player.points = player.points + 1;
            Debug.Log(player.points);
        }
    }
}
