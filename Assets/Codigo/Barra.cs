using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra : MonoBehaviour
{

    public float velocidad = 20.0f; // Esto sera para la velocidad de movimiento de la barra
    private Vector3 posicionInicial; // Para almacenar el valor inicial de la barra


    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Start"); // Prueba para ver cuantas veces se ejecuta

        // Se inicializa el valor inicial de la barra
        posicionInicial = transform.position; // valor actual de la posicion de la barra.


        
    }


    public void Resert()
    {
        transform.position = posicionInicial; // esto es para reinicial la posicion de la barra
    }


    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Update"); // Prueba para ver cuantas veces se ejecuta

        /* Esto sera para agregar el nombre del eje que se encargara del movimiento horizontal y sera 'Horizontal', este dato ya viene predefinido en:
         * Unity ir a la pestaña 'Edit' ==>> Project Settings ==>> Input ==>> Axes ==>> aqui se veran todas las variables que hay disponibles para los 
         * ejes          */
        float tecladoHorizontal = Input.GetAxisRaw("Horizontal"); // 

        // Aqui se configurara el movimiento de la barra por medio de la variable 'x' 
        float posX = transform.position.x + (tecladoHorizontal * velocidad * Time.deltaTime); //
        /* Aqui se aplica el movimiento a la barra.
         * Con el metodo Mathf se pondra un limite de movimiento para la barra, esto sera para que se no se salga de las paredes.
         * Tambien se puede hacer usando la condifional if.       
         * Ademas se le agrega un Rigibody para que el collider de la barra no sea statico, ademas hay que quitandole el gravity y agregando kinematic */
        transform.position = new Vector3(Mathf.Clamp(posX, -7.7f, 7.7f), transform.position.y, transform.position.z);

        //




    }
}
