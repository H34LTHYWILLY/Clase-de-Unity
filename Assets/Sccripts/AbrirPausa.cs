using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPausa : MonoBehaviour
{
    bool estaPausado = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {

            if (estaPausado == false)
            {
                print("pausado");
                estaPausado = true;
                Time.timeScale = 0f;
            }
            else
            {
                print("Reanudar");
                estaPausado = false;
                Time.timeScale = 1.0f;
            }
        }
    }
}
