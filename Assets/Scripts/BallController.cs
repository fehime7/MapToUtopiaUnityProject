using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject Timeline;

    private void Awake()
    {
        Timeline.SetActive(false);
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        Debug.Log("Swipe in Direction: " + data.Direction);

        if (data.Direction == SwipeDirection.Up)
        {
            //Make the ball move
            Debug.Log("Ball kicked");
            Timeline.SetActive(true);
            StartCoroutine(TimelineDeactivator());
        }
    }
    IEnumerator TimelineDeactivator()
    {
        yield return new WaitForSecondsRealtime(3);
        Timeline.SetActive(false);
    }
}
