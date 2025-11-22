using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parpadear : MonoBehaviour
{
    [SerializeField] RectTransform parpadoSuperior;
    [SerializeField] RectTransform parpadoInferior;

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

        float parpadoHeight = parpadoSuperior.rect.height;

        Vector3 posicionInicialSuperior = new Vector3(0, -parpadoHeight, 0);
        Vector3 posicionInicialInferior = new Vector3(0, parpadoHeight, 0);

        Vector3 posicionFinalSuperior = Vector3.zero;
        Vector3 posicionFinalInferior = Vector3.zero;

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
         

            parpadoSuperior.anchoredPosition = Vector3.Lerp(posicionInicialSuperior, posicionFinalSuperior, porcentajeDeApertura);
            parpadoInferior.anchoredPosition = Vector3.Lerp(posicionInicialInferior, posicionFinalInferior, porcentajeDeApertura);

            yield return null;
        }

        isCoroutineRunning = false;
    }
}
