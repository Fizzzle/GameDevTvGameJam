using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform[] PathPoints;
    public float Speed;

    private Vector3[] newPosition;

    private int curPos;
    private bool movementStarted;

    private void Start()
    {
        newPosition = NewPositionByPath(PathPoints);
        movementStarted = false;
    }

    private void Update()
    {
        if (!movementStarted && Input.anyKeyDown)
        {
            transform.position = newPosition[0];
            movementStarted = true;
            curPos = 0;
        }

        if (movementStarted && curPos < newPosition.Length)
        {
            MoveTowardsNextPosition();
        }
    }

    void MoveTowardsNextPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, newPosition[curPos], Speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, newPosition[curPos]) < 0.2f)
        {
            curPos++;
        }
    }

    Vector3[] NewPositionByPath(Transform[] pathPos)
    {
        Vector3[] pathPositions = new Vector3[pathPos.Length];
        for (int i = 0; i < pathPos.Length; i++)
        {
            pathPositions[i] = pathPos[i].position;
        }

        return pathPositions;
    }

    public void MoveAfterRotate()
    {
        newPosition = NewPositionByPath(PathPoints);
        curPos = 0;
        transform.position = newPosition[0];
        movementStarted = false;
    }
}
