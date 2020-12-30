using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class slideshow : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> slides;
    public int index;
    public string nextScene;
    public Text text;

    void Start()
    {
        index = 0;
        text.text = slides[index];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            index++;
            if(index == slides.Count)
            {
                SceneManager.LoadScene(nextScene);
            } 
            text.text = slides[index];
        }
    }
}
