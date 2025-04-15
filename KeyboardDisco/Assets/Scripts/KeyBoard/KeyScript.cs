using Unity.VisualScripting;
using UnityEngine;

public class KeyScript : MonoBehaviour
{

    private KeyState state;

    public bool isStartKey;

    public KeyCode key;

    public GameObject[] AdjacentKeys;

    public Material[] Materials; // 0 is default, 1 is Pressed, 2 is Unlocked, 3 is Locked Press
    Renderer rend;

    public float LockDelay;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = Materials[0];

        state = KeyState.Idle;
    }

    void Update()
    {
        if (state != KeyState.Pressed &&isStartKey && !Input.anyKeyDown)
        {
            state = KeyState.Unlocked;
        }

        if (Input.GetKeyDown(key))
        {
            if(state == KeyState.Unlocked || state == KeyState.Pressed)
            {
                state = KeyState.Pressed;
                //AdjacentUnlock();
                Debug.Log("Pressed " + key);
            }
            else
            {
                state = KeyState.Locked;
            }
                
            
        }

        if (Input.GetKeyUp(key))
        {
            if(state == KeyState.Pressed)
            {
                //Invoke("AdjacentLock", LockDelay);
                state = KeyState.Unlocked;
            }
            state = KeyState.Idle;
            Debug.Log("Released " + key);
        }

        if (state != KeyState.Pressed && !isStartKey)
        {
            state = KeyState.Idle;
            if (state == KeyState.Idle && AdjacentCheck())
            {
                state = KeyState.Unlocked;
            }
        }

        //color    
        switch (state)
        {
            case KeyState.Idle:
                rend.sharedMaterial = Materials[0];
                break;

            case KeyState.Pressed:
                rend.sharedMaterial = Materials[1];
                break;

            case KeyState.Unlocked:
                rend.sharedMaterial = Materials[2];
                break;

            case KeyState.Locked:
                rend.sharedMaterial = Materials[3];
                break;
        }

    }

    private void AdjacentUnlock()
    {
        for (int i = 0; i < AdjacentKeys.Length; i++)
        {
            AdjacentKeys[i].GetComponent<KeyScript>().state = KeyState.Unlocked;
        }
    }

    private void AdjacentLock()
    {
        for (int i = 0; i < AdjacentKeys.Length; i++)
        {
            if(AdjacentKeys[i].GetComponent<KeyScript>().state == KeyState.Unlocked)
            {
                AdjacentKeys[i].GetComponent<KeyScript>().state = KeyState.Idle;
            }
        }
    }

    private bool AdjacentCheck()
    {
        for (int i = 0; i < AdjacentKeys.Length; i++)
        {
            if (AdjacentKeys[i].GetComponent<KeyScript>().state == KeyState.Pressed)
            {
                return true;
            }
        }
        return false;
    }
    private enum KeyState
    {
        Idle,
        Pressed,
        Unlocked,
        Locked
    }
}
