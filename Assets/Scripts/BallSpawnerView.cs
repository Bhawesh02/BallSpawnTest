
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallSpawnerView : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer Circle;
    [SerializeField]
    private PlaneView plane;

    private int maxTry = 5000;

    private float circleRadius;

    [SerializeField]
    private TextMeshProUGUI message;
    [SerializeField]
    private Button restart;
    private void Start()
    {
        circleRadius = (Circle.bounds.size.x / 2f);
        StartCoroutine(SpawnCircles());
        restart.onClick.AddListener(() => {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }

    private IEnumerator SpawnCircles()
    {
        yield return null;
        Vector2 spawnPos = plane.transform.position;
        if (!CanSpawnCircle(spawnPos))
            yield break;
        SpawnCircleAtPos(spawnPos);
        spawnPos = GetNewSpawnPos(spawnPos);
        int tested = 1;
        while (tested <= maxTry && !CanSpawnCircle(spawnPos))
        {
            if(tested == maxTry)
            Debug.Log(tested);
            spawnPos = GetNewSpawnPos(spawnPos);
            tested++;
        }
        if(tested > maxTry)
            yield break;
        SpawnCircleAtPos(spawnPos);
        spawnPos.x = -spawnPos.x;
        SpawnCircleAtPos(spawnPos);
    }

    private Vector2 GetNewSpawnPos(Vector2 spawnPos)
    {
        spawnPos.x += circleRadius*2;
        return spawnPos;
    }

    private bool CanSpawnCircle(Vector3 spawnPos)
    {
        if (!plane.SpriteRenderer.bounds.Contains(spawnPos))
            return false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPos, circleRadius);

        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                Debug.Log(colliders[i].gameObject.name);
            }
            return false;
        }
        return true;
    }

    private void SpawnCircleAtPos(Vector2 spawnPos)
    {
        Instantiate(Circle, new Vector3(spawnPos.x, spawnPos.y, 1f), Circle.transform.rotation);
    }

}
