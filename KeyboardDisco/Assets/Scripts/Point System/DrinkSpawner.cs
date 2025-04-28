using UnityEngine;

public class DrinkSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public GameObject scoreSystem;

    public int drinkAmount;

    private int currentAmount = 0;
    

    void Update()
    {
        if (currentAmount < drinkAmount)
        {
            Instantiate(objectPrefab);

            currentAmount++;
        }
    }

    public void DrinkTaken()
    {
        currentAmount--;
        scoreSystem.GetComponent<DrinkScore>().ScoreUp();
    }
}
