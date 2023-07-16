using UnityEngine;
using UnityEngine.UI;

public class CreateEnemyMenuItems : MonoBehaviour
{
    [SerializeField]
    private GameObject targetEnemyUnitPrefab;

    private GameObject enemyUnitsMenu;
    private GameObject[] activeTargetEnemies;

    private void Start()
    {
        enemyUnitsMenu = GameObject.Find("EnemyUnitsMenu");
        activeTargetEnemies = new GameObject[0];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject targetEnemyUnit = Instantiate(targetEnemyUnitPrefab, enemyUnitsMenu.transform);
            SpriteRenderer enemySpriteRenderer = other.GetComponent<SpriteRenderer>();

            targetEnemyUnit.GetComponent<Button>().onClick.AddListener(() => SelectEnemyTarget(other.gameObject));
            targetEnemyUnit.GetComponent<Image>().sprite = enemySpriteRenderer.sprite;

            Debug.Log("Player entered enemy collider");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            RemoveActiveTargetEnemies();
            Debug.Log("Player exited enemy collider");
        }
    }

    private void RemoveActiveTargetEnemies()
    {
        foreach (GameObject targetEnemy in activeTargetEnemies)
        {
            Destroy(targetEnemy);
        }
        activeTargetEnemies = new GameObject[0];
    }

    public void SelectEnemyTarget(GameObject enemy)
    {
        Debug.Log("Selected Enemy: " + enemy.name);
    }
}
