
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] float cameraSpeed;
    [SerializeField] float padding;
    private bool isCameraChlick = true;
    private Vector3 moverDir;
    private Vector3 mousDir;

    private void Update()
    {
        Move();

    }
    private void OnEnable()
    {
        // Confined는 마우스가 보이면서 화면밖으로 안나가게 해줌
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    private void Move()
    {
        transform.Translate(moverDir * cameraSpeed * Time.deltaTime, Space.World);
        transform.Translate(mousDir * cameraSpeed * Time.deltaTime, Space.World);
    }

    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moverDir.x = input.x;
        moverDir.z = input.y;

    }

    private void OnPointer(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        // 마우스는 Vector2에서는 왼쪽 아래가 0,0이다.
        //Debug.Log(input);
        if (isCameraChlick == true)
        {
            if (input.y < padding)
            {
                mousDir.z = -1;
            }
            else if (input.y > Screen.height - padding)
            {
                mousDir.z = 1;
            }
            else
            {
                mousDir.z = 0;
            }

            if (input.x < padding)
            {
                mousDir.x = -1;
            }
            else if (input.x > Screen.width - padding)
            {
                mousDir.x = 1;
            }
            else
            {
                mousDir.x = 0;
            }
        }


    }


    private void OnChlick(InputValue value)
    {
        if (isCameraChlick == true)
        {
            isCameraChlick = false;
        }
        else
        {
            isCameraChlick = true;
        }
    }
}