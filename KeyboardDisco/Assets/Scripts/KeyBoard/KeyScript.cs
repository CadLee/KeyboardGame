using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class KeyScript : MonoBehaviour
{
	public KeyCode Key;
	public KeyPos Pos;

	private bool _highlighted = false;

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
