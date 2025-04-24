using UnityEngine;

public class Player : MonoBehaviour
{
	private KeyPos startPos = new KeyPos(0, 0);
	private KeyScript currentKey;

	public void Setup(KeyboardScript keyboard)
	{
		currentKey = keyboard.GetKeyAtPos(startPos);
		transform.position = currentKey.transform.position;
	}

	public void PressKey(KeyScript keyPressed)
	{
		if (currentKey.Pos.IsAdjacent(keyPressed.Pos))
		{
			currentKey.IsHighlighted = false;
			keyPressed.IsHighlighted = true;
			currentKey = keyPressed;
			transform.position = currentKey.transform.position;
		}
	}
}
