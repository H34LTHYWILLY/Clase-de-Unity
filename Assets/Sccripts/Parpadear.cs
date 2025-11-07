using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parpadear : MonoBehaviour
{

    [SerializeField] GameObject parpadoSuperior;

    [SerializeField] GameObject parpadoInferior;

    [SerializeField] float distanciaEntreParpados = 0.5f;

    [SerializeField] float distanciaInicialEntreParpados = 0.25f;

    [SerializeField] float tiempoDeParpadeo = 1f;

    bool abierto = false;
    bool isCoroutineRunning = false;

    void Start()
    {
        Abrir();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Abrir();
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            Cerrar();
        }
    }
    void Abrir()
    {
        if (abierto || isCoroutineRunning)
        {
            return;
        }

        StartCoroutine("MovimientoDeParpados", true);
        abierto = true;

    }
    void Cerrar()
    {
        if (!abierto || isCoroutineRunning)
        {
            return;
        }

        StartCoroutine("MovimientoDeParpados", false);
        abierto = false;
    }

    // Corrutina
    
    IEnumerator MovimientoDeParpados(bool bEstaAbriendo)
    {
        isCoroutineRunning = true;

        Vector3 posicionInicialSuperior = new Vector3(0, distanciaInicialEntreParpados, parpadoSuperior.transform.localPosition.z);

        Vector3 posicionInicialInferior = new Vector3(0, -distanciaInicialEntreParpados, parpadoSuperior.transform.localPosition.z);

        Vector3 posicionFinalSuperior = new Vector3(0, distanciaEntreParpados, parpadoSuperior.transform.localPosition.z);

        Vector3 posicionFinalInferior = new Vector3(0, -distanciaEntreParpados, parpadoSuperior.transform.localPosition.z);


        float porcentajeDeApertura = bEstaAbriendo ? 0 : 1; //condicional ternario



        while ((bEstaAbriendo == true & porcentajeDeApertura != 1) | (bEstaAbriendo == false & porcentajeDeApertura != 0))
        {
            if (bEstaAbriendo == true) 
            {
                porcentajeDeApertura += Time.deltaTime / tiempoDeParpadeo;

                if (porcentajeDeApertura > 1)
                {
                    porcentajeDeApertura = 1;
                }
            }
            else
            {
                porcentajeDeApertura -= Time.deltaTime / tiempoDeParpadeo;

                if (porcentajeDeApertura < 0)
                {
                    porcentajeDeApertura = 0;
                }
            }
         

            parpadoSuperior.transform.localPosition = Vector3.Lerp(posicionInicialSuperior, posicionFinalSuperior, porcentajeDeApertura);

            parpadoInferior.transform.localPosition = Vector3.Lerp(posicionInicialInferior, posicionFinalInferior, porcentajeDeApertura);

            yield return null;
        }

        isCoroutineRunning = false;

    }
}
