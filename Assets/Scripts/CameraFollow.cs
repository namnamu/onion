using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;

    public float smoothSpeed = 3; // 카메라 이동 속도
    public Vector2 offset;
    public float limitMinX, limitMaxX, limitMinY, limitMaxY;
    float cameraHalfWidth, cameraHalfHeight;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform; //플레이어를 타겟으로 잡아둠
        cameraHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        cameraHalfHeight = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target)
        {
            // 캐릭터 이동하는 거에 따라 카메라 이동 좌표
            Vector3 desiredPosition = new Vector3(
                Mathf.Clamp(target.position.x + offset.x, limitMinX + cameraHalfWidth, limitMaxX - cameraHalfWidth), // X
                Mathf.Clamp(target.position.y + offset.y, limitMinY + cameraHalfHeight, limitMaxY - cameraHalfHeight), // Y
                -10); // Z
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
        }
        else
        {
            return;
        }
    }
}
