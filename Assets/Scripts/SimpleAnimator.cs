using UnityEngine;

public class SimpleAnimator : MonoBehaviour
{
    public Sprite[] Sprites;
    public float TimePerFrame;
    public bool IsAnimating;
    private SpriteRenderer _spriteRenderer;
    private int _index = 0;
    private float _frameTimer = 0.0f;

    void Start()
    {
        _spriteRenderer = renderer as SpriteRenderer;
    }

    void Update()
    {
        if (IsAnimating)
        {
            if (_index >= Sprites.Length)
            {
                Debug.Log("Stopping animation");
                IsAnimating = false;
                _spriteRenderer.sprite = null;
            }
            else
            {
                if (_frameTimer <= 0.0f)
                {
                    _frameTimer += TimePerFrame / 1000;
                    _spriteRenderer.sprite = Sprites[_index];
                    _index++;
                }

                _frameTimer -= Time.deltaTime;
            }
        }
    }

    public void RunAnimationOnce()
    {
        IsAnimating = true;
        _index = 0;
    }
}