using System.Collections;
using UnityEngine;

public class SwipeLogger : MonoBehaviour
{
    public static int _direction;
    public GameObject bookObject = null;
    private BookControl bookControl = null;
    private int activePage;
    public GameObject Timeline;

    void Start()
    {
        activePage = 0;
        // We need to find the book game object
        if (bookObject != null)
        {
            // Just store the book control so we can work with it directly.
            bookControl = (BookControl)bookObject.GetComponent<BookControl>();
        }
        else
        {

        }
    }

    private void Awake()
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }
    IEnumerator TimelineDeactivator()
    {
        yield return new WaitForSecondsRealtime(3);
        Timeline.SetActive(false);
    }
    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        Debug.Log("Swipe in Direction: " + data.Direction);
        if (data.Direction == SwipeDirection.Up)
        {
            Timeline.SetActive(true);
            StartCoroutine(TimelineDeactivator());
        }

        if (bookControl == null)
            return; // we don't have the book set.

        // is the book open ?
        if (!bookControl.IsOpen())
        {
            if (data.Direction == SwipeDirection.Left && activePage == 0)
            {
                // Open the book
                bookControl.Open_Book();
                activePage =1;
                Debug.Log(activePage);
            }
        }
        else
        {
            if (data.Direction == SwipeDirection.Right && activePage == 1) 
            {
                // Close the book
                bookControl.Close_Book();
                activePage--;
                Debug.Log(activePage);

            }

            // Check to see if we can turn the page
            if (bookControl.CanTurnPage())
            {     
                if (data.Direction == SwipeDirection.Left && activePage <4)
                {
                    // Turn the page
                    bookControl.Turn_Page();
                    activePage++;
                    Debug.Log(activePage);

                }

            }

            // Check to see if we can turn back the page.
            if (bookControl.CanGoBackAPage())
            {
                
                // Turn back the page.
                if (data.Direction == SwipeDirection.Right && activePage > 0)
                {
                    bookControl.Turn_BackPage();
                    activePage--;
                    Debug.Log(activePage);

                }

            }
        }
    }
}