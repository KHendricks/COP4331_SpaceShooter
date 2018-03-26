using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    public int damage = 50;
    public float speed = 0;
    public GameObject player;
    private Vector3 forward;
    private Rigidbody rb;
    public Ray shootDir;
    private int timer = 2;
    private int bombRadius = 10;

    public GameObject explosion;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        forward = transform.forward;

        shootDir = new Ray(transform.position, transform.forward);

        StartCoroutine(TickTick());
    }

    void Update()
    {
        rb.AddForce(forward * speed / 10, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().health -= damage;
        }
    }

    IEnumerator TickTick()
    {
        bool flag = true;

        while(flag)
        {
            yield return new WaitForSecondsRealtime(1);
            timer--;

            if (timer == 0)
                flag = false;
        }

        Debug.Log("BOOM");
        GetComponent<SphereCollider>().radius = bombRadius;
        yield return new WaitForSecondsRealtime(1);

        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
