using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CreateEnemyMenuItems : MonoBehaviour
{
    [SerializeField]
    private GameObject targetEnemyUnitPrefab;

    [SerializeField]
    private GameObject enemyUnitsMenu;

    private Dictionary<GameObject, GameObject> activeTargetEnemies = new Dictionary<GameObject, GameObject>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject targetEnemyUnit = Instantiate(targetEnemyUnitPrefab, enemyUnitsMenu.transform);
            SpriteRenderer enemySpriteRenderer = other.GetComponent<SpriteRenderer>();

            targetEnemyUnit.GetComponent<Button>().onClick.AddListener(() => SelectEnemyTarget(other.gameObject));
            targetEnemyUnit.GetComponent<Image>().sprite = enemySpriteRenderer.sprite;

            activeTargetEnemies.Add(other.gameObject, targetEnemyUnit);

            Debug.Log("Игрок вошел в триггер врага");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            RemoveActiveTargetEnemy(other.gameObject);
            Debug.Log("Игрок вышел из триггера врага");
        }
    }

    private void RemoveActiveTargetEnemy(GameObject enemy)
    {
        if (activeTargetEnemies.ContainsKey(enemy))
        {
            GameObject targetEnemyUnit = activeTargetEnemies[enemy];
            Destroy(targetEnemyUnit);
            activeTargetEnemies.Remove(enemy);
        }
    }

    public void SelectEnemyTarget(GameObject enemy)
    {
        Debug.Log("Выбран враг: " + enemy.name);
    }
}
