using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float score = 0;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);       
    }

    public void tutorialLevel()
    {
        SceneManager.LoadScene("tutorialLevel");
        Debug.Log("telephone card");
        Debug.Log(score);
    }

    public void testAddScore()
    {
        score += 10;
        Debug.Log("heatbreak mermaid");
        Debug.Log(score);
    }
}
