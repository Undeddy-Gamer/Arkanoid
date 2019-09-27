using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static int TotalPoints;
    public static Text ScoreText;
    // Start is called before the first frame update

    private void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }
    private void Update()
    {
        ScoreText.text = TotalPoints.ToString();
    }
}
