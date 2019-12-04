using UnityEngine;
using System.Collections;
public class EnemyRespawner : MonoBehaviour
{
    //Variable que saca un enemigo
    public GameObject spawnEnemy = null;
    // Variable que sirve para decir cuanto tiempo tardara en aparecer otro enemigo de os vorteces cuando uno a muerto.
    float respawnTime = 0.0f;

    // Estos dos metodos los que hacen es detectar cuando un enemigo a muerto entonces lanzar el metodo scheduleRespawn
    void OnEnable()
    {
        EnemyControllerScript.enemyDied += scheduleRespawn;
    }
    void OnDisable()
    {
        EnemyControllerScript.enemyDied -= scheduleRespawn;
    }
    // Este metodo lo que hace es que cuando muere enemigo llaman a este metodo y el random del if decide si reparecen los enemigos o no.
    // Si reaparecen reaparecen en el tiempo que hemos marcado en el respawnTime, en este caso Time.time + 2.5f
    void scheduleRespawn(int enemyScore)
    {
        // Randomly decide if we will respawn or not
        if (Random.Range(0, 10) < 5)
            return;
        respawnTime = Time.time + 2.5f;
    }
    // Este metodo comprueba que el respawnTime es mas grande que 0.0f para que puedan reaparecer
    // Una vez que es mayor revisa que el respawnTime es menor que el Time.time que por norma declarado arriba va a ser menor porque al Time.time se le suma el 2.5f
    // Finalmente el respawnTime se reseta a 0.0f y se inicia la reaparacion del enemygo en la posicion transform.position que es la posicion que le tenemos asignada
    // en unity en los vortices.
    void Update()
    {
        if (respawnTime > 0.0f)
        {
            if (respawnTime < Time.time)
        {
                respawnTime = 0.0f;
                GameObject newEnemy =
                Instantiate(spawnEnemy) as GameObject;
                newEnemy.transform.position = transform.position;
            }
        }
    }
}