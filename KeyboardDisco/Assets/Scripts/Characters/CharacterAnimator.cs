using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
	[System.Serializable]
	public struct SpriteList
	{
		public Sprite[] sprites;
	};
	
	public SpriteList[] AnimationSprites;
	public int AnimationPlaying = 0;
	public bool Animating = false;
	public float AnimationFrameLength;

	private SpriteRenderer spriteRenderer;

	public void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void Update()
	{
		if (Animating)
		{
			Sprite[] spriteList = AnimationSprites[AnimationPlaying].sprites;
			int frame = (int)((Time.time / AnimationFrameLength) % (float)spriteList.Length);
			spriteRenderer.sprite = spriteList[frame];
		}
	}
}