using UnityEngine;

public class DrinkScript : MonoBehaviour
{
    private GameObject TargetKeyboard;
    private KeyboardScript keyboard;

    private GameObject DrinkSpawner;

    [SerializeField] Sprite[] drinkSprites;
    private Sprite newSprite;

    private GameObject Player;

    private KeyScript randomkey;

    void Start()
    {
        newSprite = drinkSprites[Random.Range(0, drinkSprites.Length)];
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;

        TargetKeyboard = GameObject.Find("Keyboard");
        keyboard = TargetKeyboard.GetComponent<KeyboardScript>();

        KeyPos randomKeypos = new KeyPos(Random.Range(1, 11), Random.Range(0, 4));
        randomkey = keyboard.GetKeyAtPos(randomKeypos);
        transform.position = randomkey.transform.position;

        Player = GameObject.Find("Player");

        DrinkSpawner = GameObject.Find("DrinkSpawner");
    }

    void Update()
    {
        if (randomkey == Player.GetComponent<Player>().GetKey())
        {
            Destroy(gameObject);
            DrinkSpawner.GetComponent<DrinkSpawner>().DrinkTaken();
        }
    }
}
