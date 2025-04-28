using UnityEngine;

public class Player : MonoBehaviour
{
	public CharacterAnimator animator;
	public float keyTransitionTime;
	
	private KeyPos startPos = new KeyPos(0, 0);
	private KeyScript currentKey;

	private float transitionStartTime = 0.0f;
	private Vector3 transitionOrigin;
	private Vector3 transitionDestination;

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
			StartMovementTransition(currentKey.transform.position, keyPressed.transform.position);
			
			currentKey.IsHighlighted = false;
			keyPressed.IsHighlighted = true;
			currentKey = keyPressed;
			transform.position = currentKey.transform.position;
		}
	}

	public void Update()
	{
		if (Time.time < transitionStartTime + keyTransitionTime)
		{
			float t = (Time.time - transitionStartTime) / keyTransitionTime;
			transform.position = Vector3.Lerp(transitionOrigin, transitionDestination, t);
		}
		else
		{
			animator.Animating = false;
		}
	}

	private void StartMovementTransition(Vector3 origin, Vector3 destination)
	{
		transitionStartTime = Time.time;
		transitionOrigin = origin;
		transitionDestination = destination;

		animator.Animating = true;
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

    public KeyScript GetKey()
    {
		return currentKey;
    }
}
