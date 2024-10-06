using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Definición de la clase "PopUp" que hereda de MonoBehaviour (esto permite que sea un componente en Unity)
public class PopUp : MonoBehaviour
{
    // Referencia al GameObject "backgroundF", que puede ser asignado desde el Inspector
    [SerializeField]
    GameObject backgroundF;

    // Referencia al GameObject "background", que también puede ser asignado desde el Inspector
    [SerializeField]
    GameObject background;

    // Tiempo que tomará la animación
    [SerializeField]
    float timeAnim;

    // Tipo de curva de animación que se usará con LeanTween (por ejemplo, una curva de aceleración)
    [SerializeField]
    LeanTweenType animCurve;

    // El método Start se ejecuta una vez cuando se inicializa el script
    void Start()
    {
        // Desactiva el "background" (lo oculta)
        background.SetActive(false);

        // Desactiva el "backgroundF" (también lo oculta)
        backgroundF.SetActive(false);
    }

    // El método Update es llamado una vez por cuadro (frame), es decir, en cada actualización del juego
    void Update()
    {
        // Si el jugador presiona la tecla "Escape" del teclado
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Si "background" está activo (visible)
            if (background.activeSelf)
            {
                // Llama al método "CerrarMnu()" para cerrar el menú
                CerrarMnu();
            }
            else
            {
                // Si no está activo, llama a "ShowPoup()" para mostrar el popup
                ShowPoup();
            }
        }

        // Código comentado que no está en uso en este momento (posiblemente para pruebas)
        {
            //ShowPoup();
            //background.SetActive(true);
            //backgroundF.SetActive(true);
            //LeanTween.moveLocalY(background, -900f, 0f);
            //LeanTween.moveLocalY(background, 0f, timeAnim).setEase(animCurve);
        }
    }

    // Método para mostrar el popup
    public void ShowPoup()
    {
        // Activa el "background" (lo hace visible)
        background.SetActive(true);

        // Activa el "backgroundF" (lo hace visible)
        backgroundF.SetActive(true);

        // Mueve el "background" desde la posición Y -900 en 0 segundos (posicionándolo fuera de la pantalla)
        LeanTween.moveLocalY(background, -900f, 0f);

        // Anima el "background" moviéndolo a la posición Y = 0 en el tiempo definido por "timeAnim" y usando la curva de animación "animCurve"
        LeanTween.moveLocalY(background, 0f, timeAnim).setEase(animCurve);
    }

    // Método para cerrar el menú (ocultar el popup)
    public void CerrarMnu()
    {
        // Mueve el "background" a la posición Y = 0 en "timeAnim" segundos y usa la curva "animCurve"
        LeanTween.moveLocalY(background, 0f, timeAnim).setEase(animCurve).setOnComplete(() =>
        {
            // Una vez que la animación termina, desactiva el "background" (lo oculta)
            background.SetActive(false);
        });

        // Desvanece el "backgroundF" (Canvas) en "timeAnim" segundos y lo oculta al completar la animación
        LeanTween.alphaCanvas(backgroundF.GetComponent<CanvasGroup>(), 0f, timeAnim).setOnComplete(() =>
        {
            // Desactiva el "backgroundF" (lo oculta)
            backgroundF.SetActive(false);

            // Restablece el alpha del "backgroundF" a 1 (lo hace completamente visible de nuevo) en 0 segundos para futuras animaciones
            LeanTween.alphaCanvas(backgroundF.GetComponent<CanvasGroup>(), 1f, 0f);
        });
    }
}