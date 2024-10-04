using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanTweenEjemplo : MonoBehaviour
{
    [SerializeField]
    float sizeToScale = 2f;
    [SerializeField]
    float durationAnim = 0.75f;
    [SerializeField]
    float positionYFinal = 0.5f;
    [SerializeField]
    float positionDosX= 2.76f;
    [SerializeField]
    float durationX = 0.90f;
    // Start is called before the first frame update
    void Start()
    {
        //LeanTween.scale(gameObject, Vector3.one * sizeToScale, durationAnim).setEase(LeanTweenType.easeInBounce);// LeanTween siempre en start
        LeanTween.moveLocalY(gameObject, positionYFinal, durationAnim).setEase(LeanTweenType.easeInOutElastic);
        LeanTween.moveLocalX(gameObject, positionDosX, durationX).setEase(LeanTweenType.easeInOutElastic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
