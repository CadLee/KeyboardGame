using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class KeyScript : MonoBehaviour
{
	public KeyCode Key;
	public KeyPos Pos;
	public Character character = null;

	private bool _highlighted = false;

	public bool IsDangerous(KeyboardScript keyboard)
	{
		Character c;
		c = keyboard.GetKeyAtPos(Pos.Left()).character;
		if (c != null && c.IsDangerous)
			return true;
		c = keyboard.GetKeyAtPos(Pos.Right()).character;
		if (c != null && c.IsDangerous)
			return true;
		c = keyboard.GetKeyAtPos(Pos.UpLeft()).character;
		if (c != null && c.IsDangerous)
			return true;
		c = keyboard.GetKeyAtPos(Pos.UpRight()).character;
		if (c != null && c.IsDangerous)
			return true;
		c = keyboard.GetKeyAtPos(Pos.DownLeft()).character;
		if (c != null && c.IsDangerous)
			return true;
		c = keyboard.GetKeyAtPos(Pos.DownRight()).character;
		if (c != null && c.IsDangerous)
			return true;

		return false;
	}

	public bool IsHighlighted
	{
		get
		{
			return _highlighted;
		}
		set
		{
			if (value == true)
			{
				// Make highlighted
				_highlighted = true;
				rend.sharedMaterial = Materials[1];
			}
			else
			{
				// Make not highlighted
				_highlighted = false;
				rend.sharedMaterial = Materials[0];
			}
		}
	}

	public void Setup(KeyCode key, KeyPos pos)
	{
		Key = key;
		Pos = pos;
	}

	// 0 is default, 1 is Pressed, 2 is Unlocked, 3 is Locked Press
	public Material[] Materials;
	Renderer rend;

	void Start()
	{
		rend = GetComponent<Renderer>();
		rend.enabled = true;
		rend.sharedMaterial = Materials[0];
	}
}
