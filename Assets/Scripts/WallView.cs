
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D),typeof(SpriteRenderer))]
public class WallView : MonoBehaviour
{
    [field: SerializeField]
    public WallType WallType { get;private set; }

    private BoxCollider2D boxCollider;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
}
