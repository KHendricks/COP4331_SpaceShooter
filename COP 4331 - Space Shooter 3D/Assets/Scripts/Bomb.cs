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
    private int bombRadius = 50;

    public GameObject explosion;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        forward = transform.forward;

        shootDir = new Ray(transform.position, transform.forward);

        StartCoroutine(TickTick());

        Physics.IgnoreLayerCollision(0, 0);
    }

    void Update()
    {
        rb.AddForce(forward * speed / 10, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().health -= (damage * 2);
            //Destroy(col.gameObject);
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
        Physics.IgnoreLayerCollision(0, 0, false);
        gameObject.AddComponent<SphereCollider>().radius = bombRadius;
        Instantiate(explosion, transform.position, transform.rotation);
        yield return new WaitForSecondsRealtime(1);
        Destroy(gameObject);
    }
}
