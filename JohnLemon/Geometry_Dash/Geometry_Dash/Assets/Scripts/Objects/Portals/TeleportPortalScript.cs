using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPortalScript : MonoBehaviour
{
    PlayerStateListener player = new PlayerStateListener();

    void OnTriggerEnter2D(Collider2D collidedObject)
    {
        collidedObject.SendMessage("teleportPortalPlayer");
    }
}
