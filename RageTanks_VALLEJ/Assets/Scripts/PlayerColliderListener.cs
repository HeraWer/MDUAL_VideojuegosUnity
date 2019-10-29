using UnityEngine;
using
System.Collections;
public class PlayerColliderListener : MonoBehaviour
{
    public PlayerStateListener targetStateListener = null;
    void OnTriggerEnter2D(Collider2D collidedObject)
    {
        switch (collidedObject.tag)
        {
            case "Platform":
                // Quan el Player cau en una plataforma, canviar l'estat.
                Debug.Log(collidedObject.tag);
                targetStateListener.onStateChange(
                PlayerStateController.playerStates.landing);
                break;
        }
    }
}
