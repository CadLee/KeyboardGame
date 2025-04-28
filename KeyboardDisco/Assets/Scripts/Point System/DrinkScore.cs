using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class DrinkScore : MonoBehaviour
{
    public int scoreToBeat;

    private int currentScore=0;

    public GameObject ScoreBarObject;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            Invoke("WinGame", 1.3f);
        }
    }

    public void ScoreUp()
    {
        currentScore++;
        Debug.Log("Drinks Drank: "+currentScore);
        try
        {
            ScoreBarObject.GetComponent<DrinkScoreBar>().BarCheck();
        }
        catch
        {
            Debug.Log(gameObject+" could not find Sprite Object");
        }
        audioSource.Play();
    }

    public int ScoreCap()
    {
        return scoreToBeat;
    }

    public int ScoreCurrent()
    {
        return currentScore;
    }

    private void WinGame()
    {
        SceneManager.LoadScene(3);
        Debug.Log("Victory");
    }
}
