using UnityEngine;
using TMPro;

public class GameOverController : MonoBehaviour
{
    public TMP_Text scores_tmp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scores_tmp.SetText("Score: {0}", ScoreStatic.Score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
