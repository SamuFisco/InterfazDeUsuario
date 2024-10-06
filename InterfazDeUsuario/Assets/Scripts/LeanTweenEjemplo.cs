using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanTweenEjemplo : MonoBehaviour
{
    // Duración de cada animación
    [SerializeField]   // Esto permite que se vea en el Inspector de Unity para ajustar sin modificar el código
    float durationX = 0.90f;  // Duración de la animación para cada transición

    // Definición de las posiciones clave en las que se moverá el objeto
    Vector3 startPosition = new Vector3(3.14f, -0.99f, 0f);   // Posición inicial (X = 3.14, Y = -0.99, Z = 0) Variable de posicion
    Vector3 positionA = new Vector3(3.14f, 1.01f, 0f);        // Primera posición de destino (X = 3.14, Y = 1.01) Variable de posicion
    Vector3 positionB = new Vector3(-2.84f, 1.01f, 0f);       // Segunda posición de destino (X = -2.84, Y = 1.01) Variable de posicion
    Vector3 positionC = new Vector3(-2.84f, -0.99f, 0f);      // Tercera posición de destino (X = -2.84, Y = -0.99) Variable de posicion

    // Start es llamado cuando el objeto se inicia en Unity
    void Start()
    {
        // Coloca el GameObject en la posición inicial definida (X = 3.14, Y = -0.99)
        gameObject.transform.localPosition = startPosition;

        // Inicia la primera animación: mueve el objeto de la posición inicial a la primera posición (X = 3.14, Y = 1.01)
        LeanTween.moveLocal(gameObject, positionA, durationX)
            .setEase(LeanTweenType.easeInOutElastic)  // Usa un tipo de animación suave (easeInOutElastic)
            .setOnComplete(() =>                     // Cuando la primera animación termine, ejecuta lo siguiente:
            {
                // Segunda animación: mueve el objeto a la segunda posición (X = -2.84, Y = 1.01)
                LeanTween.moveLocal(gameObject, positionB, durationX)
                    .setEase(LeanTweenType.easeInOutElastic)  // De nuevo, usa el easing suave
                    .setOnComplete(() =>                     // Cuando la segunda animación termine:
                    {
                        // Tercera animación: mueve el objeto a la tercera posición (X = -2.84, Y = -0.99)
                        LeanTween.moveLocal(gameObject, positionC, durationX)
                            .setEase(LeanTweenType.easeInOutElastic)  // Mantiene el mismo easing
                            .setOnComplete(() =>                     // Cuando la tercera animación termine:
                            {
                                // Cuarta animación: vuelve el objeto a la posición inicial (X = 3.14, Y = -0.99)
                                LeanTween.moveLocal(gameObject, startPosition, durationX)
                                    .setEase(LeanTweenType.easeInOutElastic)  // Usa el mismo easing
                                    .setOnComplete(() =>                     // Cuando la cuarta animación termine:
                                    {
                                        // Aquí puedes agregar más acciones si es necesario. Por ejemplo, mostrar un mensaje en la consola.
                                        Debug.Log("Animación completa");  // Indica que la animación completa ha terminado.
                                    });
                            });
                    });
            });
    }

    // Update es llamado una vez por cuadro, pero en este caso no se usa
    void Update()
    {
        // No hay nada en el Update porque todo se maneja en el Start y en la secuencia de LeanTween
    }
}