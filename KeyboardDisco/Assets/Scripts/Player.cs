using UnityEngine;

public class Player : MonoBehaviour
{
	public CharacterAnimator animator;
	
	private KeyPos startPos = new KeyPos(0, 0);
	private KeyScript currentKey;

	private enum Dir {Down = 0, Left = 1, Right = 2, Up = 3};

	public void Setup(KeyboardScript keyboard)
	{
		currentKey = keyboard.GetKeyAtPos(startPos);
		transform.position = currentKey.transform.position;
	}

	public void PressKey(KeyScript keyPressed)
	{
		if (currentKey.Pos.IsAdjacent(keyPressed.Pos))
		{
			animator.AnimationPlaying = AnimationToSet(currentKey.Pos, keyPressed.Pos);
			
			currentKey.IsHighlighted = false;
			keyPressed.IsHighlighted = true;
			currentKey = keyPressed;
			transform.position = currentKey.transform.position;
		}
	}

	private int AnimationToSet(KeyPos oldPos, KeyPos newPos)
	{
		if (newPos.y < oldPos.y)
			return (int)Dir.Up;

		if (newPos.y > oldPos.y)
			return (int)Dir.Down;

		if (newPos.y == oldPos.y)
		{
			if (newPos.x < oldPos.x)
				return (int)Dir.Left;

			if (newPos.x > oldPos.x)
				return (int)Dir.Right;
		}

		return 0;
	}
}
