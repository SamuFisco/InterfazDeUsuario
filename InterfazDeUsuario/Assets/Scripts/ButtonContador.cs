using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonContador : MonoBehaviour
{
    public int contadorDeClicks = 0;
    public TextMeshProUGUI contadorClcks;

    public void cuentaClicks()
    {
        contadorDeClicks++;
        contadorClcks.text = contadorDeClicks.ToString();

        // Cambiar el tamaño del texto usando LeanTween
        LeanTween.scale(contadorClcks.rectTransform, new Vector3(1.5f, 1.5f, 1), 0.5f).setEase(LeanTweenType.easeOutBounce)
            .setOnComplete(() => {
                LeanTween.scale(contadorClcks.rectTransform, Vector3.one, 0.5f); // Volver al tamaño original
            });
    }
}

