using UnityEngine;
using
System.Collections;
public class DestroyOnCollision : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D hitObj)
    {
        if(hitObj.gameObject.tag == "Platform" || hitObj.gameObject.tag == "Enemy")
        {
            Debug.Log("DestroyOnCollision. Bala col.lisiona amb objecte: " + hitObj.tag);
            DestroyObject(gameObject);
        }
        
    }
}
