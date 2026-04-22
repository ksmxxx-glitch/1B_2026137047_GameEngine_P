using UnityEngine;

public class EnemyTraceController : MonoBehaviour
{

    public float moveSpeed = .5f;
    public float raycastDistance = .2f;
    public float tranceDistance = 2f;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
         Vector2 direction = player.position - transform.position;

        if (direction.magnitude > tranceDistance)
            return;

        Vector2 directionNormalized = direction.normalized;

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, directionNormalized, raycastDistance);
        Debug.DrawRay(transform.position, directionNormalized * raycastDistance, Color.red);

        foreach(RaycastHit2D rHIt in hits)
        {
            if (rHIt.collider != null && rHIt.collider.CompareTag("Obstacle"))
            {
                Vector3 alternativeDirection = Quaternion.Euler(0f, 0f, 90f) * direction;
                transform.Translate(alternativeDirection * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(directionNormalized * moveSpeed * Time.deltaTime);
            }

        }


    }


}

