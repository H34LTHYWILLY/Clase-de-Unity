using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : ObjetoInteraccionable
{
    float interacciones = 0;
    float cuantoHeGirado = 0;

    [SerializeField][Range(5, 200)] float rotacionASumar = 90;
    [SerializeField][Range(5, 200)] float velocidad = 60;
    [SerializeField] bool abrirHaciaAtras = false;

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
        if (AbrirPuerta())
        {
            float rotacionExtra = velocidad * Time.deltaTime;
            if (abrirHaciaAtras)
                rotacionExtra = rotacionExtra * -1;
            cuantoHeGirado += Mathf.Abs(rotacionExtra);

            transform.parent.rotation = Quaternion.Euler(
                transform.parent.rotation.eulerAngles + new Vector3(0, rotacionExtra, 0));
        }
    }

    protected virtual bool AbrirPuerta()
    {
        // Exit clause => Cuando no hayamos interaccionado (interacciones no es mayor que 0)
        if (interacciones == 0)
            return false; // Deja de ejecutar.

        if (cuantoHeGirado >= rotacionASumar) // Si el loop ha ocurrido < de 18 veces.
            return false;

        return true;
    }
}