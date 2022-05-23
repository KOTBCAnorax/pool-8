using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIScript : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    private int _score;

    private void Start()
    {
        _scoreText.text = "Score: 0";
        _score = 0;
    }

    public void UpdateScore()
    {
        _score += 1;
        _scoreText.text = "Score: " + _score.ToString();
    }
}
