using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanTweenEjemplo : MonoBehaviour
{
    // Duraci�n de cada animaci�n
    [SerializeField]   // Esto permite que se vea en el Inspector de Unity para ajustar sin modificar el c�digo
    float durationX = 0.90f;  // Duraci�n de la animaci�n para cada transici�n

    // Definici�n de las posiciones clave en las que se mover� el objeto
    Vector3 startPosition = new Vector3(3.14f, -0.99f, 0f);   // Posici�n inicial (X = 3.14, Y = -0.99, Z = 0) Variable de posicion
    Vector3 positionA = new Vector3(3.14f, 1.01f, 0f);        // Primera posici�n de destino (X = 3.14, Y = 1.01) Variable de posicion
    Vector3 positionB = new Vector3(-2.84f, 1.01f, 0f);       // Segunda posici�n de destino (X = -2.84, Y = 1.01) Variable de posicion
    Vector3 positionC = new Vector3(-2.84f, -0.99f, 0f);      // Tercera posici�n de destino (X = -2.84, Y = -0.99) Variable de posicion

    // Start es llamado cuando el objeto se inicia en Unity
    void Start()
    {
        // Coloca el GameObject en la posici�n inicial definida (X = 3.14, Y = -0.99)
        gameObject.transform.localPosition = startPosition;

        // Inicia la primera animaci�n: mueve el objeto de la posici�n inicial a la primera posici�n (X = 3.14, Y = 1.01)
        LeanTween.moveLocal(gameObject, positionA, durationX)
            .setEase(LeanTweenType.easeInOutElastic)  // Usa un tipo de animaci�n suave (easeInOutElastic)
            .setOnComplete(() =>                     // Cuando la primera animaci�n termine, ejecuta lo siguiente:
            {
                // Segunda animaci�n: mueve el objeto a la segunda posici�n (X = -2.84, Y = 1.01)
                LeanTween.moveLocal(gameObject, positionB, durationX)
                    .setEase(LeanTweenType.easeInOutElastic)  // De nuevo, usa el easing suave
                    .setOnComplete(() =>                     // Cuando la segunda animaci�n termine:
                    {
                        // Tercera animaci�n: mueve el objeto a la tercera posici�n (X = -2.84, Y = -0.99)
                        LeanTween.moveLocal(gameObject, positionC, durationX)
                            .setEase(LeanTweenType.easeInOutElastic)  // Mantiene el mismo easing
                            .setOnComplete(() =>                     // Cuando la tercera animaci�n termine:
                            {
                                // Cuarta animaci�n: vuelve el objeto a la posici�n inicial (X = 3.14, Y = -0.99)
                                LeanTween.moveLocal(gameObject, startPosition, durationX)
                                    .setEase(LeanTweenType.easeInOutElastic)  // Usa el mismo easing
                                    .setOnComplete(() =>                     // Cuando la cuarta animaci�n termine:
                                    {
                                        // Aqu� puedes agregar m�s acciones si es necesario. Por ejemplo, mostrar un mensaje en la consola.
                                        Debug.Log("Animaci�n completa");  // Indica que la animaci�n completa ha terminado.
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