using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : ObjetoInteraccionable
{
    private float interacciones = 0;

    [SerializeField] float rotacionASumar = 90;
    [SerializeField] float velocidad = 60;
    float cuantoHeGirado = 0;

    public override void Interaccionar()
    {
        // Exit clause.
        if (interacciones > 0)
            return; // Deja de ejecutar.

        // Si la Exit Clause es falsa.
        interacciones++;
    }

    private void Update()
    {
        // Exit clause.
        if (interacciones > 0)
            return; // Deja de ejecutar.

        if (cuantoHeGirado < rotacionASumar) // Si el loop ha ocurrido < de 18 veces.
            return;

        float rotacionExtra = velocidad * Time.deltaTime;
        cuantoHeGirado += rotacionExtra;
        transform.parent.rotation = 
            Quaternion.Euler(transform.parent.rotation.eulerAngles + new Vector3(0, rotacionExtra, 0));
    }
}