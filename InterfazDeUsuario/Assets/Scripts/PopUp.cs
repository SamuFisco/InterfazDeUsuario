using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Definici�n de la clase "PopUp" que hereda de MonoBehaviour (esto permite que sea un componente en Unity)
public class PopUp : MonoBehaviour
{
    // Referencia al GameObject "backgroundF", que puede ser asignado desde el Inspector
    [SerializeField]
    GameObject backgroundF;

    // Referencia al GameObject "background", que tambi�n puede ser asignado desde el Inspector
    [SerializeField]
    GameObject background;

    // Tiempo que tomar� la animaci�n
    [SerializeField]
    float timeAnim;

    // Tipo de curva de animaci�n que se usar� con LeanTween (por ejemplo, una curva de aceleraci�n)
    [SerializeField]
    LeanTweenType animCurve;

    // El m�todo Start se ejecuta una vez cuando se inicializa el script
    void Start()
    {
        // Desactiva el "background" (lo oculta)
        background.SetActive(false);

        // Desactiva el "backgroundF" (tambi�n lo oculta)
        backgroundF.SetActive(false);
    }

    // El m�todo Update es llamado una vez por cuadro (frame), es decir, en cada actualizaci�n del juego
    void Update()
    {
        // Si el jugador presiona la tecla "Escape" del teclado
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Si "background" est� activo (visible)
            if (background.activeSelf)
            {
                // Llama al m�todo "CerrarMnu()" para cerrar el men�
                CerrarMnu();
            }
            else
            {
                // Si no est� activo, llama a "ShowPoup()" para mostrar el popup
                ShowPoup();
            }
        }

        // C�digo comentado que no est� en uso en este momento (posiblemente para pruebas)
        {
            //ShowPoup();
            //background.SetActive(true);
            //backgroundF.SetActive(true);
            //LeanTween.moveLocalY(background, -900f, 0f);
            //LeanTween.moveLocalY(background, 0f, timeAnim).setEase(animCurve);
        }
    }

    // M�todo para mostrar el popup
    public void ShowPoup()
    {
        // Activa el "background" (lo hace visible)
        background.SetActive(true);

        // Activa el "backgroundF" (lo hace visible)
        backgroundF.SetActive(true);

        // Mueve el "background" desde la posici�n Y -900 en 0 segundos (posicion�ndolo fuera de la pantalla)
        LeanTween.moveLocalY(background, -900f, 0f);

        // Anima el "background" movi�ndolo a la posici�n Y = 0 en el tiempo definido por "timeAnim" y usando la curva de animaci�n "animCurve"
        LeanTween.moveLocalY(background, 0f, timeAnim).setEase(animCurve);
    }

    // M�todo para cerrar el men� (ocultar el popup)
    public void CerrarMnu()
    {
        // Mueve el "background" a la posici�n Y = 0 en "timeAnim" segundos y usa la curva "animCurve"
        LeanTween.moveLocalY(background, 0f, timeAnim).setEase(animCurve).setOnComplete(() =>
        {
            // Una vez que la animaci�n termina, desactiva el "background" (lo oculta)
            background.SetActive(false);
        });

        // Desvanece el "backgroundF" (Canvas) en "timeAnim" segundos y lo oculta al completar la animaci�n
        LeanTween.alphaCanvas(backgroundF.GetComponent<CanvasGroup>(), 0f, timeAnim).setOnComplete(() =>
        {
            // Desactiva el "backgroundF" (lo oculta)
            backgroundF.SetActive(false);

            // Restablece el alpha del "backgroundF" a 1 (lo hace completamente visible de nuevo) en 0 segundos para futuras animaciones
            LeanTween.alphaCanvas(backgroundF.GetComponent<CanvasGroup>(), 1f, 0f);
        });
    }
}