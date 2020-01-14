using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    //Definicio dels diferents estats del player
    public enum playerStates
    {
        idle = 0,
        left,
        right,
        jump,
        landing,
        falling,
        kill,
        resurrect,
        firingWeapon,
        _stateCount

    }

    // Vector per gestionar temporitzacions en cada estat 
    public static float[] stateDelayTimer = new float[(int)playerStates._stateCount]; 
    //Definicio del delegate playerStateHandler
    public delegate void playerStateHandler(PlayerStateController.playerStates newState);
    //Definicio d'event onStateChange i assignacio de onStateChange com a EventHandler
    public static event playerStateHandler onStateChange;
    // Aquest metode es crida despres de Update() a cada frame.
    void LateUpdate()
    {
        // Recollir l'input actual en el Horizontal axis (eix horitzontal)
        float horizontal = Input.GetAxis("Horizontal");
        //Tractar segons el valor de l'input recollit
        if (!GameStates.gameActive) return;
        if (horizontal != 0f)
        {
            //Hi ha algun moviment: canviar l'estat del protagonista a left o right
            if (horizontal < 0f)
            {
                if (onStateChange != null) onStateChange(PlayerStateController.
                 playerStates.left);
            }
            else
            {
                if (onStateChange != null) onStateChange(PlayerStateController.
                 playerStates.right);
            }
        }
        // Simplement, quan hi ha entrada d'usuari en el axis Jump, generem un event de canvi d'estat cap a l'estat jump.

        else
        //No hi ha cap moviment: canviar l'estat del protagonista a idle
        {
            if (onStateChange != null) onStateChange(PlayerStateController.
             playerStates.idle);
        }

        float jump = Input.GetAxis("Jump");
        if (jump > 0.0f)
        {
            if (onStateChange != null)
                onStateChange(PlayerStateController.playerStates.jump);
        }

        /*if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1), ForceMode2D.Impulse);
        }*/
        //Disparar
        float firing = Input.GetAxis("Fire1");
        if (firing > 0.0f)
        {
            if (onStateChange != null)
                onStateChange(PlayerStateController.playerStates.firingWeapon);
        }

    }

}
