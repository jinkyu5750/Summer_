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

        if (isCatch == false && target != null) // Ÿ�������� catch���°��ƴҶ�
        {
            patrol.enabled = false;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else if (target == null) // Ÿ�پ���������,catch�϶�
            patrol.enabled = true;

   
        if (Vector2.Distance(transform.position, swallowDestination.transform.position) < 0.1f) // swallowDestination�� ����
        {
            isCatch = false;
            target.transform.parent = null;
            returnToInit = true;

        }

        if (isCatch)
            transform.position = Vector2.MoveTowards(transform.position, swallowDestination.transform.position, speed * Time.deltaTime);

       
    }
    void OnDrawGizmos() // ���� �׸���
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
