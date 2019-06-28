using UnityEngine;

public class SwipeDrawer : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private float zOffset = 10;

    public GameObject bookObject = null;
    private BookControl bookControl = null;

    void Start()
    {
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
        lineRenderer = GetComponent<LineRenderer>();
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        Vector3[] positions = new Vector3[2];
        positions[0] = Camera.main.ScreenToWorldPoint(new Vector3(data.StartPosition.x, data.StartPosition.y, zOffset));
        positions[1] = Camera.main.ScreenToWorldPoint(new Vector3(data.EndPosition.x, data.EndPosition.y, zOffset));
        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(positions);

       
    }
}