using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ECharacterState
{
   moviendose,
   inspeccionando,
   movimientoDesabilitado,
   movimientoyCamaraDesabilitado,
}

public class StateMachine : MonoBehaviour
{

    static public StateMachine Instance;

    ECharacterState state = ECharacterState.moviendose;

    public ECharacterState ObtenerEstado()
    {
       return state;

    }

    public bool CambiarEstado(ECharacterState EstadoNuevo)
    {
        switch(state)
        {
            case ECharacterState.movimientoyCamaraDesabilitado: 
                if (EstadoNuevo == ECharacterState.inspeccionando)
                {
                    return false;
                }
                break;

            case ECharacterState.movimientoDesabilitado:
                if (EstadoNuevo == ECharacterState.inspeccionando)
                {
                    return false;
                }
                break;
        
        }

        if (EstadoNuevo == state) 
        {
            return false;
        }

        print("Estado " + state + " cambia a " + EstadoNuevo);
        state = EstadoNuevo;
        return true;


    }

    void Start()
    {
       Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
