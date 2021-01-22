using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField]
    TMP_Text leftScoreText;
    int leftScore = 0;

    [SerializeField]
    TMP_Text rightScoreText;
    int rightScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
    }

    public void UpdateLeftScore()
    {
        leftScore++;
        leftScoreText.text = leftScore.ToString();
    }

    public void UpdateRightScore()
    {
        rightScore++;
        rightScoreText.text = rightScore.ToString();
    }
}
