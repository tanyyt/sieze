using UnityEngine;

public class Map : MonoBehaviour
{
    public SpriteRenderer mapRenderer;
    public EdgeCollider2D edgeCollider;
    public float width;
    public float height;
    public float mapThickness = 1f;

    void Start()
    {
        mapRenderer.size = new Vector2(width, height);
        float left = (width - mapThickness) * 0.5f;
        float top = (height - mapThickness) * 0.5f;
        edgeCollider.points = new[] { new Vector2(left, top), new Vector2(-left, top), new Vector2(-left, -top), new Vector2(left, -top), new Vector2(left, top) };
    }
}
