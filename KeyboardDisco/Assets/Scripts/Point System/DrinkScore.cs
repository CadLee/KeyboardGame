using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class DrinkScore : MonoBehaviour
{
    public int scoreToBeat;

    private int currentScore=0;
    void Start()
    {
        if (scoreToBeat < 1)
        {
            scoreToBeat = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentScore >= scoreToBeat)
        {
            SceneManager.LoadScene(3);
            Debug.Log("Victory");
        }
    }

    public void ScoreUp()
    {
        currentScore++;
        Debug.Log("Drinks Drank: "+currentScore);
    }
}
