using System.Collections;
using UnityEngine;
using System.Collections.Generic;



public class totallynotchatgpt : MonoBehaviour
{
    private List<Vector3> touchPositions = new List<Vector3>();
    private bool isMoving = false;

    [SerializeField]
    private float moveSpeed = 5f;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchPositions.Clear();
                touchPositions.Add(GetTouchPosition(touch));
                isMoving = true;
            }

            if (touch.phase == TouchPhase.Moved && isMoving)
            {
                touchPositions.Add(GetTouchPosition(touch));
            }

            if (touch.phase == TouchPhase.Ended && isMoving)
            {
                isMoving = false;
                StartCoroutine(MoveAlongPath());
            }
        }
    }

    private Vector3 GetTouchPosition(Touch touch)
    {
        Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane);
        return Camera.main.ScreenToWorldPoint(touchPosition);
    }

    private IEnumerator MoveAlongPath()
    {
        for (int i = 0; i < touchPositions.Count; i++)
        {
            Vector3 targetPosition = touchPositions[i];
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
}
