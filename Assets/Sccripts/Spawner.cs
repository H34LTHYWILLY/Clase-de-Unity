using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Puerta puerta;
    public GameObject objetoASpawnear;

    // Start is called before the first frame update
    void Start()
    {
        puerta.alAbrir = Spawnear;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawnear ()
    {
        Instantiate(objetoASpawnear, transform.position, transform.rotation);
    }   
}
