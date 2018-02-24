using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float damage = 0;
	public float speed = 0;
	public GameObject player;
	private Vector3 forward;
	private int timer = 1500;
	private Rigidbody rb;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.AddForce(transform.forward*speed*3,ForceMode.Impulse);
		forward = transform.forward;
	}
	
	void Update ()
    {
	
		rb.AddForce(forward*speed*3,ForceMode.Impulse);

		transform.rotation = Quaternion.Euler(rb.velocity);
		if(timer==0)
		{
			Destroy(gameObject);
		}
		else
		{
			timer--;
		}
    }
    
    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.name != "Bullet(Clone)"&& col.gameObject.name != "Ship")
        {
			Destroy(gameObject);
        }
    }
    
}
