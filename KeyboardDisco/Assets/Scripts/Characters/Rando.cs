using UnityEngine;
using System.Collections.Generic;

public class Rando : Character
{
	public float RandomMovePeriod;
	public int startX, startY;

	private float lastMove = 0.0f;
	
	public void Update()
	{
		if (Time.time > lastMove + RandomMovePeriod)
		{
			lastMove = Time.time;
			MoveInRandomDirection();
		}
	}

	public void Awake()
	{
		startPos = new KeyPos(startX, startY);
	}

	private void MoveInRandomDirection()
	{
		List<KeyPos> keys = new List<KeyPos>();
		KeyPos left = currentKey.Pos.Left();
		if (left != currentKey.Pos)
			if (keyboard.GetKeyAtPos(left).character == null)
				keys.Add(left);
		KeyPos right = currentKey.Pos.Right();
		if (right != currentKey.Pos)
			if (keyboard.GetKeyAtPos(right).character == null)
				keys.Add(right);
		KeyPos upLeft = currentKey.Pos.UpLeft();
		if (upLeft != currentKey.Pos)
			if (keyboard.GetKeyAtPos(upLeft).character == null)
				keys.Add(upLeft);
		KeyPos upRight = currentKey.Pos.UpRight();
		if (upRight != currentKey.Pos)
			if (keyboard.GetKeyAtPos(upRight).character == null)
				keys.Add(upRight);
		KeyPos downLeft = currentKey.Pos.DownLeft();
		if (downLeft != currentKey.Pos)
			if (keyboard.GetKeyAtPos(downLeft).character == null)
				keys.Add(downLeft);
		KeyPos downRight = currentKey.Pos.DownRight();
		if (downRight != currentKey.Pos)
			if (keyboard.GetKeyAtPos(downRight).character == null)
				keys.Add(downRight);

		KeyScript newKey = keyboard.GetKeyAtPos(keys[Random.Range(0, keys.Count)]);

		currentKey.character = null;
		currentKey = newKey;
		currentKey.character = this;
		transform.position = currentKey.transform.position;
	}
}
