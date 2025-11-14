using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaccionar : MonoBehaviour
{

    public float maxDistance = 100;

    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (StateMachine.Instance.ObtenerEstado() == ECharacterState.moviendose)
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
                StateMachine.Instance.CambiarEstado(ECharacterState.inspeccionando);
                baseClass.Interaccionar();
            }
        }

    }

    void StopInteracting()
    {
        StateMachine.Instance.CambiarEstado(ECharacterState.moviendose);
    }

}
