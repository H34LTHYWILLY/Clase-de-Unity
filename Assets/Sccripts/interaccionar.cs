using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaccionar : MonoBehaviour
{

    public float maxDistance = 100;

    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        //float valor = 1;

        //valor = Sumar(ref valor, -1);

        //Sumar(ref valor, -1);

        //print("sumar:" + valor);

        //print("multiplicar: " + Multiplicar(3, 4));
    }


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (StateMachine.Instance.CambiarEstado(ECharacterState.inspeccionando))
            {
                Interact();
                
            }
            else if (StateMachine.Instance.ObtenerEstado() == ECharacterState.inspeccionando)
            {
                StopInteracting();

            }


        }

    }

    void Interact()
    {
        RaycastHit raycastHit;

        bool golpeandoAlgo = Physics.Raycast(transform.position, transform.forward, out raycastHit, maxDistance);

        if (golpeandoAlgo == true)
        {
            print(raycastHit.transform.name);

            IBaseReact baseClass = raycastHit.transform.GetComponent<IBaseReact>();

            if (baseClass != null)
            {
                baseClass.Interaccionar();
            }
        }

    }

    void StopInteracting()
    {
        StateMachine.Instance.CambiarEstado(ECharacterState.moviendose);
    }


    //float Sumar(ref float uno, float dos)
    //{
    //    uno += dos;
    //    return uno;
    //}

    //float Multiplicar(float valor1, float multiplicador)
    //{
    //    return SumarNveces(0, valor1, multiplicador);
    //}
    //float SumarNveces(float valor1, float suma, float numeroDeVeces)
    //{
    //    if (numeroDeVeces == 1)
    //    {
    //        return Sumar(valor1, suma);
    //    }

    //    return Sumar(suma, SumarNveces(valor1, suma, numeroDeVeces - 1));
    //}
}
