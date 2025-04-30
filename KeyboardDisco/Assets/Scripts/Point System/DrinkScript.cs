using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrinkScript : MonoBehaviour
{
    private Animator anim;

    private GameObject TargetKeyboard;
    private KeyboardScript keyboard;

    private GameObject DrinkSpawner;

    [SerializeField] Sprite[] drinkSprites;
    private Sprite newSprite;

    private GameObject Player;

    private KeyScript randomkey;

    private int randomNumber;

    void Start()
    {
        randomNumber = Random.Range(0, drinkSprites.Length);
        newSprite = drinkSprites[randomNumber];
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;

        try
        {
            TargetKeyboard = GameObject.Find("Keyboard");
            keyboard = TargetKeyboard.GetComponent<KeyboardScript>();

            KeyPos randomKeypos = new KeyPos(Random.Range(1, 11), Random.Range(0, 4));
            randomkey = keyboard.GetKeyAtPos(randomKeypos);
            transform.position = randomkey.transform.position;
        }
        catch
        {
            Debug.Log(gameObject+" could not find Keyboard Object");
        }

        try
        {
            Player = GameObject.Find("Player");
        }
        catch
        {
            Debug.Log(gameObject + " could not find Player");
        }

        try
        {
            DrinkSpawner = GameObject.Find("DrinkSpawner");
        }
        catch
        {
            Debug.Log(gameObject + " could not find DrinkSpawner");
        }

        try
        {
            anim = GameObject.Find("GlassPour").GetComponent<Animator>();
        }
        catch
        {
            Debug.Log(gameObject + " could not find Animator");
        }
    }

    void Update()
    {
        if (randomkey == Player.GetComponent<Player>().GetKey())
        {
            Destroy(gameObject);
            DrinkSpawner.GetComponent<DrinkSpawner>().DrinkTaken();

            anim.SetInteger("GetAnim",randomNumber);

            anim.SetBool("DrinkDrank", true);
            //StopAnim();
        }

        if (anim.GetBool("DrinkDrank"))
        {
            StartCoroutine(DelayStop());
        }
    }

    IEnumerator DelayStop()
    {
        yield return null;
        StopAnim();
    }

    void StopAnim()
    {
        Debug.Log("stop anim");
        anim.SetBool("DrinkDrank", false);
    }
}
