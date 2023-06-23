using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed;
    private GameObject focalPoint;
    public bool hasPowerup;
    public float nomalpowerupStrength;
    public float powerupStrength;

    public float wait;

    public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb=GetComponent<Rigidbody>();
        focalPoint=GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float fowardInput=Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward*speed*fowardInput);
        powerupIndicator.transform.position=transform.position+new Vector3(0,1,0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            
            Rigidbody enemyRigidbody=collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer=(collision.gameObject .transform.position-transform.position);
            enemyRigidbody.AddForce(awayFromPlayer*powerupStrength,ForceMode.Impulse);
            

            //Debug.Log("Collided with "+ collision.gameObject.name+"with powerup set to"+hasPowerup);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(wait);
        hasPowerup =false;
        powerupIndicator.gameObject.SetActive(false);

    }
}
