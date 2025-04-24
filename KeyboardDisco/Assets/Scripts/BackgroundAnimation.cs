using UnityEngine;

public class BackgroundAnimation : MonoBehaviour
{
	public Sprite[] AnimationSprites;
	public float AnimationFrameLength = 0.25f;

	private SpriteRenderer spriteRenderer;

	public void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void Update()
	{
		int frame = (int)((Time.time / AnimationFrameLength) % AnimationSprites.Length);
		spriteRenderer.sprite = AnimationSprites[frame];
	}
}