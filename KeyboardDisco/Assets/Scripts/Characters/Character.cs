using UnityEngine;

public class Character : MonoBehaviour
{
	[SerializeField] protected CharacterAnimator animator;
	[SerializeField] protected float keyTransitionTime;

	public KeyboardScript keyboard;

	public bool IsDangerous = false;

	protected KeyScript currentKey;
	
	protected KeyPos startPos = new KeyPos(0, 0);

	public void Setup(KeyboardScript keyboardScript)
	{
		keyboard = keyboardScript;
		currentKey = keyboard.GetKeyAtPos(startPos);
		transform.position = currentKey.transform.position;
	}

	public KeyScript GetKey()
	{
		return currentKey;
	}
}
