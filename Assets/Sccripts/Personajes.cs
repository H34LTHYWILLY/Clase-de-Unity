using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personajes : MonoBehaviour
{
    public float velocidad = 10;

    public Vector3[] posiciones;
    
    int guardadorDeIndex = 0;

    bool moviendo = false;

    float porcentageDeMovimiento = 0;

    private void Start()
    {
        posiciones[0] = transform.position;
    }
    void Update()
    {
       if (moviendo == true)
        {
            Vector3 distanciaARecorrer = posiciones[guardadorDeIndex] - posiciones[guardadorDeIndex -1];

            float longitudDeLaDistancia = distanciaARecorrer.magnitude;

            porcentageDeMovimiento += velocidad * Time.deltaTime / longitudDeLaDistancia;

            if (porcentageDeMovimiento > 1)
            {
                porcentageDeMovimiento = 1;
            }

            float porcentageSuavizado = (float)(-(Math.Cos((Math.PI * porcentageDeMovimiento)) - 1) / 2);

            transform.position = Vector3.Lerp(posiciones[guardadorDeIndex - 1], posiciones[guardadorDeIndex], porcentageSuavizado);

            if (porcentageDeMovimiento == 1)
            {
               moviendo = false;
               porcentageDeMovimiento = 0;
            }

        }
       
    }

    public void CambiarPosicion()
    {
        if (guardadorDeIndex == posiciones.Length -1)
        {
            return;
        }
        guardadorDeIndex += 1;
        moviendo = true;
        
    }

}
