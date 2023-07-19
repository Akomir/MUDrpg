using UnityEngine;

public class Stats : MonoBehaviour
{
    // ������� ����������
    public Sprite globalSprite;

    // �������� ������
    public Sprite battleSprite;

    // ������ �����
    public int maxHP = 100;
    public int attack = 10;
    public int speedAtk = 5;
    public float moveSpeed = 5f;

    // �� ������ �����
    public int gold = 0;
    public int experience = 0;

    // ������� �������� ������
    private int currentHP;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        currentHP = maxHP;

        // �������� ��������� SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        // ������������� ��������� ������ � ����������� �� globalSprite
        spriteRenderer.sprite = globalSprite;

        // ������������� Sorting Layer � Order in Layer
        spriteRenderer.sortingLayerName = "Game";
        spriteRenderer.sortingOrder = -1;
    }

    // ...
}
