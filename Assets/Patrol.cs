using System.Collections;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float moveX,moveY;
    public Vector2 initPos;
    public Vector2 moveSpot;
    public float minX, maxX,minY,maxY;

    public LayerMask playerLayer; 
    public float FindRange = 4f;

    public bool isPatrol = false;
    private void Start()
    {
        initPos = transform.position;
        moveSpot = initPos;

    }

    private void Update()
    {
        isPatrol = Physics2D.OverlapCircle(transform.position, FindRange,  playerLayer);

        if (isPatrol)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);

            if (transform.position.x - moveSpot.x < 0)
                transform.localScale = new Vector3(-1, 1, 1);
            else
                transform.localScale = new Vector3(1, 1, 1);

            if (Vector2.Distance(transform.position, moveSpot) < 0.1f)
            {
                moveX = Random.Range(minX, maxX);
                moveY = Random.Range(minY, maxY);
                moveSpot = initPos + new Vector2(moveX, moveY);

            }
        }
        else if(!isPatrol)
            transform.position = Vector2.MoveTowards(transform.position, initPos, speed * Time.deltaTime);
    }
    void OnDrawGizmos() // 범위 그리기
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, FindRange);
    }

}
