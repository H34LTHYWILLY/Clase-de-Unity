using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacioncamara : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        mainCamara = GetCamera();
    }

    // Update is called once per frame

    public float velocidadX = 500;
    public float velocidadY = 450; 
    public Transform mainCamara = null;


    void Update()
    {
        if (StateMachine.Instance.ObtenerEstado() != ECharacterState.moviendose)
        {
            return;
        }

        float rotacionX = Input.GetAxisRaw("Mouse X");

        float rotacionY = Input.GetAxisRaw("Mouse Y");

        Vector3 rotation = transform.rotation.eulerAngles;

        Vector3 rotacionCamara = mainCamara.rotation.eulerAngles;

        transform.rotation = Quaternion.Euler(0f, rotation.y + velocidadX * rotacionX * Time.deltaTime, 0f);

        mainCamara.localRotation = Quaternion.Euler(rotacionCamara.x + velocidadY * rotacionY * Time.deltaTime * -1, 0f, 0f);

    }

    private Transform GetCamera()
    {
       Transform camara = transform.GetChild(0);
        return camara;
    }
}
