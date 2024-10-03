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
    // Start is called before the first frame update
    void Start()
    {
        //LeanTween.scale(gameObject, Vector3.one * sizeToScale, durationAnim).setEase(LeanTweenType.easeInBounce);// LeanTween siempre en start
        LeanTween.moveLocalY(gameObject, positionYFinal, durationAnim).setEase(LeanTweenType.easeInOutElastic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
