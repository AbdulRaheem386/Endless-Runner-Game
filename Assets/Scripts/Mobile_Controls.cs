using UnityEngine;

public class SwipeInput : MonoBehaviour
{
    private Vector2 startTouchPos;
    private Vector2 endTouchPos;

    public float minSwipeDistance = 50f;

    public PlayerMovement player;

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
            player.StartGame();

        if (Input.GetKeyDown(KeyCode.A))
            player.MoveLeft();

        if (Input.GetKeyDown(KeyCode.D))
            player.MoveRight();

        if (Input.GetKeyDown(KeyCode.Space))
            player.Jump();
#endif

        // Mobile
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // 👉 TAP TO START
            if (touch.phase == TouchPhase.Began)
            {
                player.StartGame();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                endTouchPos = touch.position;

                Vector2 delta = endTouchPos - startTouchPos;

                if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
                {
                    if (Mathf.Abs(delta.x) > minSwipeDistance)
                    {
                        if (delta.x > 0)
                            player.MoveRight();
                        else
                            player.MoveLeft();
                    }
                }
                else
                {
                    if (delta.y > minSwipeDistance)
                        player.Jump();
                }
            }

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPos = touch.position;
            }
        }
    }
}
