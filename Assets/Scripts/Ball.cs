using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 startPosition;
    public Score scoreScript;
    void Start()
    {
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
      startPosition=transform.position;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("square"))
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 1;
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

        }
        if (collision.gameObject.CompareTag("halfcircle1"))
        {
            Debug.Log("Trigger Circle1");
            scoreScript.score1 += 1;
            scoreScript.scorePlyer1.text = scoreScript.score1.ToString();
            GetComponent<Transform>().position = startPosition;
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            
        }
        if (collision.gameObject.CompareTag("halfcircle2"))
        {
            Debug.Log("Trigger Circle2");
            scoreScript.score2 += 1;
            scoreScript.scorePlayer2.text = scoreScript.score2.ToString();
            GetComponent<Transform>().position = startPosition;
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }

    }
   

}
