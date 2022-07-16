using UnityEngine;

public class SlidingObstacle : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right*movementSpeed*Time.deltaTime);

        if(transform.position.x>maxX)
        {
            transform.position = new Vector3(minX, transform.position.y, 0);
        }
    }
}
