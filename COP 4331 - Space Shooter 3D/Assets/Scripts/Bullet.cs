using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float damage = 0;
	public float speed = 0;
	public GameObject player;
	private int timer = 1500;
	private Rigidbody rb;
	void Start()
	{
		GetComponent<Rigidbody>().AddForce(transform.forward*speed*3,ForceMode.Impulse);
		rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
		Vector3 temp = GetClosestEnemy(GameObject.FindGameObjectsWithTag("Enemy")).position - transform.position;
		temp.Normalize();
		 
	
		rb.AddForce(temp*speed);
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
    
	Transform GetClosestEnemy(GameObject[] enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in enemies)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t.transform;
                minDist = dist;
            }
        }
        return tMin;
        
    }
    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.name != "Bullet(Clone)"&& col.gameObject.name != "Ship")
        {
			Destroy(gameObject);
        }
    }
    
}
