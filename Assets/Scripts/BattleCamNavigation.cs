using UnityEngine;

public class BattleCamera : MonoBehaviour
{
    public float dragSpeed = 2f; // Скорость перетаскивания камеры
    public float moveSpeed = 10f; // Скорость перемещения камеры с помощью WASD
    public float minZoom = 2f; // Минимальное значение приближения камеры
    public float maxZoom = 10f; // Максимальное значение приближения камеры

    private Camera cam;
    private Vector3 dragOrigin;
    private Vector3 prevMousePosition;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        HandleMovementInput();
        HandleZoomInput();
    }

    private void HandleMovementInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, vertical, 0f);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = GetWorldMousePosition();
            prevMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 moveDelta = prevMousePosition - currentMousePosition;
            transform.Translate(moveDelta * dragSpeed * Time.deltaTime);
            prevMousePosition = currentMousePosition;
        }
    }

    private Vector3 GetWorldMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -cam.transform.position.z;
        return cam.ScreenToWorldPoint(mousePosition);
    }

    private void HandleZoomInput()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        ZoomCamera(scroll);
    }

    private void ZoomCamera(float scroll)
    {
        float zoomAmount = scroll * dragSpeed;
        float newZoom = cam.orthographicSize - zoomAmount;
        newZoom = Mathf.Clamp(newZoom, minZoom, maxZoom);
        cam.orthographicSize = newZoom;
    }
}
