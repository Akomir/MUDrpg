using UnityEngine;

public class Stats : MonoBehaviour
{
    // Картина глобальная
    public Sprite globalSprite;

    // Картинка боевая
    public Sprite battleSprite;

    // Боевые статы
    public int maxHP = 100;
    public int attack = 10;
    public int speedAtk = 5;
    public float moveSpeed = 5f;

    // Не боевые статы
    public int gold = 0;
    public int experience = 0;

    // Текущие значения статов
    private int currentHP;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        currentHP = maxHP;

        // Получаем компонент SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Устанавливаем начальный спрайт в зависимости от globalSprite
        spriteRenderer.sprite = globalSprite;

        // Устанавливаем Sorting Layer и Order in Layer
        spriteRenderer.sortingLayerName = "Game";
        spriteRenderer.sortingOrder = -1;
    }

    // ...
}
