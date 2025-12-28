using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoInspeccionable : ObjetoInteraccionable
{
    [SerializeField] GameObject posicionDeInspeccion;

    Vector3 posicionInicial;

    Quaternion rotacionInicial;
    public override void Interaccionar()
    {

        if (StateMachine.Instance.ObtenerEstado() == ECharacterState.inspeccionando)
        {
            DejarDeInspeccionar();
        }
        else
        {
            Inspeccionar();
        }
    }

    public void Inspeccionar()
    {
        StateMachine.Instance.CambiarEstado(ECharacterState.inspeccionando);

        transform.position = posicionDeInspeccion.transform.position;

        transform.rotation = posicionDeInspeccion.transform.rotation;
    }

    public void DejarDeInspeccionar()
    {
        StateMachine.Instance.CambiarEstado(ECharacterState.moviendose);

        transform.position = posicionInicial;

        transform.rotation = rotacionInicial;
    }

    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;

        rotacionInicial = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
