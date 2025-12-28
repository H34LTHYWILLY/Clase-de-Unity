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
            TryToInteractWithObjectInFront();
        }

    }

    void TryToInteractWithObjectInFront()
    {
        RaycastHit raycastHit;

        bool golpeandoAlgo = Physics.Raycast(transform.position, transform.forward, out raycastHit, maxDistance);

        if (golpeandoAlgo == true)
        {
            ObjetoInteraccionable baseClass = raycastHit.transform.GetComponent<ObjetoInteraccionable>();

            if (baseClass != null)
            {
                print(raycastHit.transform.name);
                baseClass.Interaccionar();
            }
        }

    }
}
