using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    private Rigidbody rigidbody; // si se pone publico se puede dar la referencia al objeto desde la misma vista en unity

    public float velocidadInicial = 600f; //

    private bool enJuego = false; //

    private Vector3 posicionInicial; // Para almacenar el valor inicial de la pelota

    private Transform barra; // para poder obtener el transfor de la clase 'Barra'

    



    // Awake is called when the script instance is being loaded
    private void Awake() // este siempre se ejecuta antes que el metodo Start(), 
    {
        // Aqui se asigna la referencia al componente del rigibody de la paelota y a otros componentes que haya disponibles
        rigidbody = GetComponent<Rigidbody>();


        // Para buscar transfor del objeto padre que sera la barra
        barra = GetComponentInParent<Transform>();
        
    }




    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
    }

    public void Resert()
    {
        transform.position = posicionInicial; // esto es para reinicial la posicion de la barra

        transform.SetParent(barra); // aqui se indica que el padre de la pelota sea la barra
        enJuego = false; // esto sera para poder dispara de nuevo la pelota

        DetenerMovimiento();


    }

    public void DetenerMovimiento()
    {
        rigidbody.isKinematic = true; // lo vielve a activar
        rigidbody.velocity = Vector3.zero; // se pone le movimiento de la pelota a cero
    }

    // Update is called once per frame
    void Update()
    {
        if(!enJuego && Input.GetButtonDown("Fire1")) //
        {
            enJuego = true;
            transform.SetParent(null); // Aqui se indica que la pelota deje de ser hija de la barra y se le pueda aplicar movimiento independiente
            rigidbody.isKinematic = false; // esto es para desactivar el iskinematic de la pelota

            // Aplicar el movimiento a la pelota
            rigidbody.AddForce(new Vector3(velocidadInicial, velocidadInicial, 0));
            // luego en la vista de unity hay que el material 'rebotar' a todos los collider de cada objeto en la vista, asi se asegura que rebote siempre
        }
        
    }
}
