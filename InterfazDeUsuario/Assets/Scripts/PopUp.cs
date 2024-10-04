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
            if (background.activeSelf)
            {
                CerrarMnu();
            }
            else
            {
                ShowPoup();
            }
        }
       
        {
            //ShowPoup();
            //background.SetActive(true);
            //backgroundF.SetActive(true);
            //LeanTween.moveLocalY(background, -900f, 0f);
            //LeanTween.moveLocalY(background, 0f, timeAnim).setEase(animCurve);
        }

    }
    public void ShowPoup()
    {
        background.SetActive(true);
        backgroundF.SetActive(true);
        LeanTween.moveLocalY(background, -900f, 0f);
        LeanTween.moveLocalY(background, 0f, timeAnim).setEase(animCurve);
    }
    public void CerrarMnu()
    {
        
        
        //LeanTween.moveLocalY(background, -900f, 0f);
        LeanTween.moveLocalY(background, 0f, timeAnim).setEase(animCurve).setOnComplete(() =>
        {
            background.SetActive(false);
        });
        LeanTween.alphaCanvas(backgroundF.GetComponent<CanvasGroup>(), 0f, timeAnim).setOnComplete(() =>
        {
        backgroundF.SetActive(false);
            //Poner el alpha del canvas a 1, hacerlo en 0 segundos
            LeanTween.alphaCanvas(backgroundF.GetComponent<CanvasGroup>(), 1f, 0f);

        });
        //backgroundF.SetActive(false);
    }
}
