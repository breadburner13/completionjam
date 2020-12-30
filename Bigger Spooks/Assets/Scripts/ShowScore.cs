using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    public GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        scoreText.text = "Your Score: " + gameManager.score.ToString();
        gameManager.score = 0;
    }
}
