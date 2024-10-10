using System.Collections;
using System.Collections.Generic; 
using UnityEngine; 
using TMPro; // Importa el espacio de nombres para TextMeshPro

public class Crono : MonoBehaviour // Define una clase llamada Crono que hereda de MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoCrono; // Campo para almacenar la referencia al componente TextMeshProUGUI para mostrar el cron�metro
    [SerializeField] private float tiempo; // Variable privada para almacenar el tiempo restante en segundos

    void Update() // M�todo que se llama una vez por frame
    {
        Cronometro(); // Llama al m�todo Cronometro para actualizar el tiempo cada frame
    }

    void Cronometro() // M�todo que maneja la l�gica del cron�metro
    {
        tiempo -= Time.deltaTime; // Reduce el tiempo restante por el tiempo transcurrido desde el �ltimo frame
        if (tiempo < 0) tiempo = 0; // Verifica si el tiempo es negativo, y si es as�, lo establece en 0 para evitar tiempos negativos

        int tiempoMinutos = Mathf.FloorToInt(tiempo / 60); // Calcula los minutos enteros del tiempo restante
        int tiempoSegundos = Mathf.FloorToInt(tiempo % 60); // Calcula los segundos restantes despu�s de los minutos
        int tiempoDecimasSegundo = Mathf.FloorToInt((tiempo % 1) * 100); // Calcula las d�cimas de segundo

        // Actualiza el texto del cron�metro con formato: MM:SS:DD
        textoCrono.text = string.Format("{0:00}:{1:00}:{2:00}", tiempoMinutos, tiempoSegundos, tiempoDecimasSegundo);
    }
}

