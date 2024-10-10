using System.Collections;
using System.Collections.Generic; 
using UnityEngine; 
using TMPro; // Importa el espacio de nombres para TextMeshPro

public class Crono : MonoBehaviour // Define una clase llamada Crono que hereda de MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoCrono; // Campo para almacenar la referencia al componente TextMeshProUGUI para mostrar el cronómetro
    [SerializeField] private float tiempo; // Variable privada para almacenar el tiempo restante en segundos

    void Update() // Método que se llama una vez por frame
    {
        Cronometro(); // Llama al método Cronometro para actualizar el tiempo cada frame
    }

    void Cronometro() // Método que maneja la lógica del cronómetro
    {
        tiempo -= Time.deltaTime; // Reduce el tiempo restante por el tiempo transcurrido desde el último frame
        if (tiempo < 0) tiempo = 0; // Verifica si el tiempo es negativo, y si es así, lo establece en 0 para evitar tiempos negativos

        int tiempoMinutos = Mathf.FloorToInt(tiempo / 60); // Calcula los minutos enteros del tiempo restante
        int tiempoSegundos = Mathf.FloorToInt(tiempo % 60); // Calcula los segundos restantes después de los minutos
        int tiempoDecimasSegundo = Mathf.FloorToInt((tiempo % 1) * 100); // Calcula las décimas de segundo

        // Actualiza el texto del cronómetro con formato: MM:SS:DD
        textoCrono.text = string.Format("{0:00}:{1:00}:{2:00}", tiempoMinutos, tiempoSegundos, tiempoDecimasSegundo);
    }
}

