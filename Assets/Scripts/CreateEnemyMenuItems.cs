using UnityEngine;
using UnityEngine.UI;

public class CreateEnemyMenuItems : MonoBehaviour
{
    [SerializeField]
    private GameObject targetEnemyUnitPrefab;

    private GameObject enemyUnitsMenu;

    private void Start()
    {
        enemyUnitsMenu = GameObject.Find("EnemyUnitsMenu");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject targetEnemyUnit = Instantiate(targetEnemyUnitPrefab, enemyUnitsMenu.transform);
            SpriteRenderer enemySpriteRenderer = other.GetComponent<SpriteRenderer>();

            targetEnemyUnit.GetComponent<Button>().onClick.AddListener(() => SelectEnemyTarget(other.gameObject));
            targetEnemyUnit.GetComponent<Image>().sprite = enemySpriteRenderer.sprite;

            Debug.Log("Игрок вошел в триггер врага");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            RemoveActiveTargetEnemies();
            Debug.Log("Игрок вышел из триггера врага");
        }
    }

    private void RemoveActiveTargetEnemies()
    {
        Transform enemyUnitsTransform = enemyUnitsMenu.transform;
        int childCount = enemyUnitsTransform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            Transform child = enemyUnitsTransform.GetChild(i);
            if (child.name == "TargetEnemy(Clone)")
            {
                Destroy(child.gameObject);
            }
        }
    }

    public void SelectEnemyTarget(GameObject enemy)
    {
        Debug.Log("Выбран враг: " + enemy.name);
    }
}
