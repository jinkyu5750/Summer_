using UnityEngine;

public class TraceAndSwallow : MonoBehaviour
{
    public Patrol patrol;
    public bool isTrace;
    public float speed;
    public LayerMask playerLayer;
    public float FindRange = 4f;
    public Collider2D target;
    public bool isCatch = false;
    public GameObject swallowDestination;
    public bool returnToInit = false;

    private void Start()
    {
        patrol = GetComponent<Patrol>();
    }
    private void Update()
    {
        target = Physics2D.OverlapCircle(transform.position, FindRange, playerLayer);

        if (isCatch == false && target != null) // 타겟잡히고 catch상태가아닐때
        {
            patrol.enabled = false;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else if (target == null) // 타겟안잡혔을때,catch일때
            patrol.enabled = true;

   
        if (Vector2.Distance(transform.position, swallowDestination.transform.position) < 0.1f) // swallowDestination에 도착
        {
            isCatch = false;
            target.transform.parent = null;
            returnToInit = true;

        }

        if (isCatch)
            transform.position = Vector2.MoveTowards(transform.position, swallowDestination.transform.position, speed * Time.deltaTime);

       
    }
    void OnDrawGizmos() // 범위 그리기
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, FindRange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
       
            isCatch = true;
            collision.transform.SetParent(transform);
        }
    }
}
