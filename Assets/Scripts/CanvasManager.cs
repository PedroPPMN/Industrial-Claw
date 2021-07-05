using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    GameObject sliders;
    GameObject index;
    GameObject button_sliders;
    GameObject button_index;
    GameObject button_play_animation;
    GameObject button_back;
    GameObject button_release;

    bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        sliders = GameObject.Find("Canvas/Sliders");
        sliders.SetActive(false);
        index = GameObject.Find("Canvas/Index");
        index.SetActive(false);
        button_sliders = GameObject.Find("Canvas/Button_Sliders");
        button_index = GameObject.Find("Canvas/Button_Index");
        button_index.SetActive(false);
        button_play_animation = GameObject.Find("Canvas/Button_Play Animation");
        button_back = GameObject.Find("Canvas/Button_BackToMainMenu");
        button_back.SetActive(false);
        button_release = GameObject.Find("Canvas/Button_Release");
        button_release.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IndexActivation()
    {
        if (!isActive)
        {
            index.SetActive(true);
            isActive = true;
        }
        else if (isActive)
        {
            index.SetActive(false);
            isActive = false;
        }
    }

    public void SetSlidersVisible()
    {      
        sliders.SetActive(true);
        button_index.SetActive(true);
        button_back.SetActive(true);
        button_release.SetActive(true);

        button_play_animation.SetActive(false);
    }

    public void GetBack()
    {       
        button_sliders.SetActive(true);
        button_play_animation.SetActive(true);

        sliders.SetActive(false);
        index.SetActive(false);
        button_index.SetActive(false);
        button_back.SetActive(false);
        button_release.SetActive(false);
    }

    public void PlayAnimation()
    {
        sliders.SetActive(false);
        button_sliders.SetActive(false);
        button_play_animation.SetActive(false);
        index.SetActive(false);
        button_index.SetActive(false);
        button_release.SetActive(false);

        button_back.SetActive(true);
    }
}
