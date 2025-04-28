using UnityEngine;

public class DrinkScoreBar : MonoBehaviour
{
    public GameObject SpriteObject;
    public GameObject ScoreSystem;
    [SerializeField] Sprite[] Sprites;

    private int cap;
    private int current;

    void Start()
    {
        try
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = Sprites[0];

        }
        catch
        {
            Debug.Log(gameObject + " could not find child sprite gameobject");
        }
        cap = ScoreSystem.GetComponent<DrinkScore>().ScoreCap();
    }

    void Update()
    {
        
    }

    public void BarCheck()
    {
        current = ScoreSystem.GetComponent<DrinkScore>().ScoreCurrent();
        if (current == 0)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = Sprites[0];
        }
        else if (current < cap * 2 / 7)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = Sprites[1];

        }
        else if (current < cap * 3 / 7)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = Sprites[2];

        }
        else if (current < cap * 4 / 7)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = Sprites[3];

        }
        else if (current < cap * 5 / 7)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = Sprites[4];

        }
        else if (current < cap * 6 / 7)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = Sprites[5];

        }
        else if (current < cap - 1)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = Sprites[6];

        }
        else if (current == cap - 1)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = Sprites[7];

        }
    }
}
