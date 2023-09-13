using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public int scoreAmount = 2;
    [SerializeField] private GameObject deadEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.score += scoreAmount;
            Destroy(gameObject);
            // yukarýda ki kod objeleri silmek için kullanýlýr
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.score += scoreAmount;
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        Instantiate(deadEffect, transform.position, transform.rotation);
    }
}
