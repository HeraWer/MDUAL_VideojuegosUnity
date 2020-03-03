using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesCollider : MonoBehaviour
{
    PlayerStateListener player = new PlayerStateListener();

    void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if (collidedObject.tag == "Player")
        {
            collidedObject.SendMessage("hitDeathTrigger");
            player.resetStatus();
        }
    }

}
