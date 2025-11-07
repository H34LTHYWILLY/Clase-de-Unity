using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Temporal : MonoBehaviour
{
   

    Personajes[] personajes;
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach(Personajes catolico in personajes)
            {
                catolico.CambiarPosicion();
            }
        }
        
    }
    private void Awake()
    {
        personajes = GameObject.FindObjectsOfType<Personajes>();
    }
}
