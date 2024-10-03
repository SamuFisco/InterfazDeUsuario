using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    [SerializeField]
    GameObject backgroundF;
    [SerializeField]
    GameObject background;
    [SerializeField]
    float timeAnim;
    [SerializeField]
    LeanTweenType animCurve;
    // Start is called before the first frame update
    void Start()
    {
        background.SetActive(false);
        backgroundF.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))        
        {
            background.SetActive(true);
            backgroundF.SetActive(true);
            LeanTween.moveLocalY(background, -900f, 0f);
            LeanTween.moveLocalY(background, 0f, timeAnim).setEase(animCurve);
        }

    }
}
