using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float score = 0;
    public FurnitureManager furnitureManager;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);       
    }

    void Update()
    {
        Debug.Log(furnitureManager);
        if(furnitureManager)
        {
            furnitureManager.calculateScore();
            Debug.Log(score);
            // Debug.Log("pocket belluni");
        }
    }

    public void tutorialLevel()
    {
        SceneManager.LoadScene("SampleScene"); //change this and add more scene transitions later
    }

    public void LoadMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLose()
    {
        Debug.Log("Rrrrrrrr");
        SceneManager.LoadScene("LoseScreen");
    }

    public void testAddScore()
    {
        score += 10;
        // Debug.Log("heatbreak mermaid");
        Debug.Log(score);
    }

    void showScore()
    {

    }
}
