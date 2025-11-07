using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] [Range(0,20)] float velocidadCorriendo = 17;
    [SerializeField][Range(0, 20)] float velocidadAndando = 10;
    Rigidbody rigidBody;

    void Start()
    {
         rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (StateMachine.Instance.ObtenerEstado() != ECharacterState.moviendose)
        {
            return;
        }

        Vector3 direccion = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {
            direccion += Vector3.right;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direccion = direccion + Vector3.back;
        }

        if (Input.GetKey(KeyCode.W))
        {
            direccion = direccion + Vector3.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direccion = direccion + Vector3.left;
        }

        float velocidadActual;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidadActual = velocidadCorriendo;
        }
        else
        {
         velocidadActual= velocidadAndando;
        }

        direccion = direccion.normalized;

        ////transform.position = transform.position + direccion / 100;
        //transform.position = transform.position + (transform.forward * direccion.z * velocidadActual * Time.deltaTime);
        //transform.position = transform.position + (transform.right * direccion.x * velocidadActual * Time.deltaTime);
        //transform.position = transform.position + (transform.up * direccion.y * velocidadActual * Time.deltaTime);


        Vector3 velocidad = transform.forward * direccion.z * velocidadActual + transform.right * direccion.x * velocidadActual;

        rigidBody.velocity = velocidad;
    }
}
