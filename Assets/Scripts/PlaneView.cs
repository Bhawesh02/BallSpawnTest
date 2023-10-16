
using UnityEngine;

public class PlaneView : MonoBehaviour
{
    [SerializeField]
    private Collider2D topWall;
    [SerializeField]
    private Collider2D bottomWall;
    [SerializeField]
    private Collider2D leftWall;
    [SerializeField]
    private Collider2D rightWall;

    private float maxScale = 9f;
    private float wallWidth = 0.0095f;
    private float wallPosInRespectiveAxis = 0.4952f;
    public SpriteRenderer SpriteRenderer { get; private set; }

    public float ResizeScalePercentage { get; private set; }
    private void Awake()
    {
        SetRandomScale();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        SetAllWallWidthAndPos();
    }

    private void SetRandomScale()
    {
        float newScale = Random.Range(1, maxScale);
        ResizeScalePercentage = newScale / transform.localScale.x;
        transform.localScale = new(newScale, newScale);
    }


    private void SetAllWallWidthAndPos()
    {
        SetWallPosAndWidth(topWall, WallType.Top);
        SetWallPosAndWidth(bottomWall, WallType.Bottom);
        SetWallPosAndWidth(rightWall, WallType.Right);
        SetWallPosAndWidth(leftWall, WallType.Left);


    }

    private void SetWallPosAndWidth(Collider2D wall, WallType wallType)
    {

        Vector2 wallPos = Vector2.zero;
        Vector2 wallScale = Vector2.one;
        switch (wallType)
        {
            case WallType.Top:
                wallPos.y = wallPosInRespectiveAxis;
                wallScale.y = wallWidth;
                break;
            case WallType.Bottom:
                wallPos.y = -wallPosInRespectiveAxis;
                wallScale.y = wallWidth;
                break;
            case WallType.Left:
                wallPos.x = -wallPosInRespectiveAxis;
                wallScale.x = wallWidth;
                break;
            case WallType.Right:
                wallPos.x = wallPosInRespectiveAxis;
                wallScale.x = wallWidth;
                break;
        }
        wall.transform.localPosition = wallPos;
        wall.transform.localScale = wallScale;
    }
}
