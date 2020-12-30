using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FurnitureManager : MonoBehaviour
{
    public Furniture[] furnitures = {};
    public Transform tracking;
    public Rigidbody2D trackingRB;
    public float levelTimer;
    public GameManager gameManager;
    public Text timer;
    public string nextScene;

    void Awake() 
    {
        tracking = FindObjectOfType<Ghost>().transform;
        trackingRB = FindObjectOfType<Ghost>().GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        gameManager.furnitureManager = this;
        furnitures = FindObjectsOfType<Furniture>();
        Debug.Log(furnitures.Length);
        Debug.Log(furnitures[furnitures.Length - 1]);
    }
    void Update()
    {
        if(levelTimer <= 0)
        {
            gameManager.score += calculateScore();
            SceneManager.LoadScene(nextScene);  //change this later
            Debug.Log(gameManager.score);
        }
        levelTimer -= Time.deltaTime;
        timer.text = "Time: " + (int)levelTimer;
    }

    public int calculateScore()
    {
        int sum = 0;
        foreach(Furniture f in furnitures)
        {
            sum += f.getScore();
        }
        return sum;
    }
}
