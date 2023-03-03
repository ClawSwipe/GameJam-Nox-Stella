using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public
class swipe : MonoBehaviour
{
    Vector2 firstPressPos,secondPressPos;
    Vector3 currentSwipe;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        func();
    }

public void func()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                // save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                // save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                // create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                // normalize the 2d vector
                currentSwipe.Normalize();

                // swipe upwards
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    Debug.Log("up swipe");
                }
                // swipe down
                if (currentSwipe.y<0 && currentSwipe.x> - 0.5f && currentSwipe.x < 0.5f)
                {
                    Debug.Log("down swipe");
                }
                // swipe left
                if (currentSwipe.x<0 && currentSwipe.y> - 0.5f && currentSwipe.y < 0.5f)
                {
                    Debug.Log("left swipe");
                }
                // swipe right
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    Debug.Log("right swipe");
                }
            }
        }
    }
}
