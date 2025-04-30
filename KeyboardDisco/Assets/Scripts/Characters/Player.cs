using UnityEngine;

public class Player : Character
{
	private enum Dir {Down = 0, Left = 1, Right = 2, Up = 3};
	
	private float transitionStartTime = -10.0f;
	private Vector3 transitionOrigin;
	private Vector3 transitionDestination;
	
	public void PressKey(KeyScript keyPressed)
	{
		if (currentKey.Pos.IsAdjacent(keyPressed.Pos))
		{
			MoveToKey(keyPressed);
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

	private void MoveToKey(KeyScript newKey)
	{
		animator.AnimationPlaying = AnimationToSet(currentKey.Pos, newKey.Pos);
		StartMovementTransition(currentKey.transform.position, newKey.transform.position);
		
		currentKey = newKey;
		transform.position = currentKey.transform.position;

		if (currentKey.IsDangerous(keyboard))
		{
			// Hit a snitch
			Debug.Log("Snitch");
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

	private void StartMovementTransition(Vector3 origin, Vector3 destination)
	{
		transitionStartTime = Time.time;
		transitionOrigin = origin;
		transitionDestination = destination;

		animator.Animating = true;
	}
}
