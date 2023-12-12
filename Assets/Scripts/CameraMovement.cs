using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float velocidadMovimiento;
    public float movSmootness;    
    public float rotationSpeed;
    public float zoomSpeed;
    public float zoomTimer;
    public float zoomSmootness;
    private float originalSize;
    private Camera mainCamera;
    private bool isRightMouseButtonDown = false;
    private Vector3 lastMousePosition;
    public Transform target;

    void Start()
    {
        mainCamera = Camera.main;
        originalSize = mainCamera.orthographicSize;
    }

    void Update()
    {
        MoverCamara();
        RotarCamara();
        ZoomConRueda();
    }

    void MoverCamara()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRightMouseButtonDown = true;
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isRightMouseButtonDown = false;
        }

        if (isRightMouseButtonDown)
        {
            Vector3 deltaMouse = Input.mousePosition - lastMousePosition;
            lastMousePosition = Input.mousePosition;

            Vector3 movimiento = new Vector3(deltaMouse.x, 0f, deltaMouse.y) * velocidadMovimiento * Time.deltaTime;
            transform.Translate(movimiento, Space.World);
        }
        else
        {
            if (target != null)
            {
                transform.localPosition = Vector3.Lerp(transform.position, target.position, Time.deltaTime * movSmootness);
            }
        }
    }

    void RotarCamara()
    {
        if (Input.GetKey(KeyCode.E))
        {
            RotateSmoothly(-1);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            RotateSmoothly(1);
        }
    }

    void RotateSmoothly(int direction)
    {
        Quaternion targetRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + (direction * 90), 0);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void ZoomConRueda()
    {
        float zoom = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        float newOrthographicSize = Mathf.Clamp(mainCamera.orthographicSize - zoom, 1f, 10f);

        if (zoom != 0)
        {
            zoomTimer = 5f;
        }

        zoomTimer -= Time.deltaTime;

        if (zoomTimer <= 0f)
        {
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, originalSize, Time.deltaTime * zoomSmootness);
        }
        else
        {
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, newOrthographicSize, Time.deltaTime * zoomSmootness);
        }
    }
}