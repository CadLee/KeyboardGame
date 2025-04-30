using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class DrinkScore : MonoBehaviour
{
    public int scoreToBeat;

    private int currentScore=0;

    public GameObject ScoreBarObject;

    private AudioSource audioSource;

    public GameObject[] snitches;
    public GameObject player;

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

        for(int i = 0; i < snitches.Length; i++)
        {

            if (snitches[i].GetComponent<Snitch>().GetKey() == player.GetComponent<Player>().GetKey())
            {
                Invoke("LoseGame", 1f);
            }
        }
    }

    public void ScoreUp()
    {
        for (int i = 0; i < snitches.Length; i++)
        {
            if (snitches[0].GetComponent<Snitch>().GetKey() == player.GetComponent<Player>().GetKey())
            {
                SceneManager.LoadScene(4);
                Debug.Log("Fail");
            }
        }

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

    private void LoseGame()
    {
        SceneManager.LoadScene(4);
        Debug.Log("Fail");
    }
}
