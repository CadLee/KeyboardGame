using UnityEngine;
using TMPro;

public struct KeyPos
{
	public int x, y;

	private static int maxX0 = 13;
	private static int maxX1 = 13;
	private static int maxX2 = 12;
	private static int maxX3 = 11;

	public KeyPos(int _x, int _y)
	{
		x = _x;
		y = _y;
	}

	public bool IsAdjacent(KeyPos pos)
	{
		if (pos.y == y)
			if (pos.x + 1 == x || pos.x - 1 == x)
				return true;
		
		if (pos.x == x)
			if (pos.y + 1 == y || pos.y - 1 == y)
				return true;

		if (pos.y == y + 1)
			if (pos.x == x - 1)
				return true;

		if (pos.y == y - 1)
			if (pos.x == x + 1)
				return true;

		return false;
	}

	public KeyPos Left(int count = 1)
	{
		int newX = x - count;
		if (newX < 0) newX = 0;
		
		return new KeyPos(newX, y);
	}

	public KeyPos Right(int count = 1)
	{
		int newX = x + count;
		switch (y)
		{
			case 0:
				if (newX > maxX0)
					newX = maxX0;
				break;
			case 1:
				if (newX > maxX1)
					newX = maxX1;
				break;
			case 2:
				if (newX > maxX2)
					newX = maxX2;
				break;
			case 3:
				if (newX > maxX3)
					newX = maxX3;
				break;
		}
		
		return new KeyPos(newX, y);
	}

	public KeyPos UpLeft(int count = 1)
	{
		int newY = y - count;
		if (newY < 0) newY = 0;

		return new KeyPos(x, newY);
	}

	public KeyPos UpRight(int count = 1)
	{
		KeyPos newPos = new KeyPos(x, y);

		for (int i = 0; i < count; i++)
		{
			newPos = newPos.UpLeft();
			newPos = newPos.Right();
		}

		return newPos;
	}

	public KeyPos DownRight(int count = 1)
	{
		int newY = y + count;
		if (newY > 3) newY = 3;

		return new KeyPos(x, newY);
	}

	public KeyPos DownLeft(int count = 1)
	{
		KeyPos newPos = new KeyPos(x, y);

		for (int i = 0; i < count; i++)
		{
			newPos = newPos.DownRight();
			newPos = newPos.Left();
		}

		return newPos;
	}
}

public class KeyboardScript : MonoBehaviour
{
	public Player player;
	
	private KeyScript[][] keys;
	private KeyCode[][] keycodes =
	{
		new KeyCode[] {
			KeyCode.BackQuote,
			KeyCode.Alpha1,
			KeyCode.Alpha2,
			KeyCode.Alpha3,
			KeyCode.Alpha4,
			KeyCode.Alpha5,
			KeyCode.Alpha6,
			KeyCode.Alpha7,
			KeyCode.Alpha8,
			KeyCode.Alpha9,
			KeyCode.Alpha0,
			KeyCode.Minus,
			KeyCode.Equals,
			KeyCode.Backspace
		},
		new KeyCode[] {
			KeyCode.Tab,
			KeyCode.Q,
			KeyCode.W,
			KeyCode.E,
			KeyCode.R,
			KeyCode.T,
			KeyCode.Y,
			KeyCode.U,
			KeyCode.I,
			KeyCode.O,
			KeyCode.P,
			KeyCode.LeftBracket,
			KeyCode.RightBracket,
			KeyCode.Backslash
		},
		new KeyCode[] {
			KeyCode.CapsLock,
			KeyCode.A,
			KeyCode.S,
			KeyCode.D,
			KeyCode.F,
			KeyCode.G,
			KeyCode.H,
			KeyCode.J,
			KeyCode.K,
			KeyCode.L,
			KeyCode.Semicolon,
			KeyCode.Quote,
			KeyCode.Return
		},
		new KeyCode[] {
			KeyCode.LeftShift,
			KeyCode.Z,
			KeyCode.X,
			KeyCode.C,
			KeyCode.V,
			KeyCode.B,
			KeyCode.N,
			KeyCode.M,
			KeyCode.Comma,
			KeyCode.Period,
			KeyCode.Slash,
			KeyCode.RightShift
		}
	};

	public void Start()
	{
		FindKeys();
		player.Setup(this);
	}

	private void FindKeys()
	{
		int rowNumber = 0;
		keys = new KeyScript[4][];
		for (int i = 0; i < transform.childCount; i++)
		{
			if (transform.GetChild(i).name == "row")
			{
				keys[rowNumber] = new KeyScript[transform.GetChild(i).childCount];
				for (int j = 0; j < transform.GetChild(i).childCount; j++)
				{
					KeyScript newKey = transform.GetChild(i).GetChild(j).GetComponent<KeyScript>();
					if (newKey != null)
					{
						keys[rowNumber][j] = newKey;
						keys[rowNumber][j].Setup(keycodes[rowNumber][j], new KeyPos(rowNumber, j));
					}
				}
				rowNumber++;
			}
		}
	}

	public void Update()
	{
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 14; j++)
			{
				if (j >= keycodes[i].Length)
					continue;
				
				if (Input.GetKeyDown(keys[i][j].Key))
				{
					player.PressKey(keys[i][j]);
				}
			}
		}
	}

	public KeyScript GetKeyAtPos(KeyPos pos)
	{
		if (keys != null)
			return keys[pos.x][pos.y];
		else
			return null;
	}
}