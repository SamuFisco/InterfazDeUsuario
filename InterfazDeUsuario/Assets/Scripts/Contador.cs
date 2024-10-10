using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour
{
    
    [SerializeField]
    GameObject objetoTexto;
    
    [SerializeField]
    TextMeshProUGUI etiquetaTexto;
    
    [SerializeField]
    int cuenta = 0;


    

   
    // Update is called once per frame
    public void AumentarCuenta()
    {
        cuenta++;
        etiquetaTexto.text = cuenta.ToString();
        LeanTween.scale(objetoTexto, Vector3.one * 0.5f, 0.0f);
        LeanTween.scale(objetoTexto, Vector3.one, 0.8f).setEaseOutElastic();


    }
}
