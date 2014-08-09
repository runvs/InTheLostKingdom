using UnityEngine;
using System.Collections;

public class TriggerPArticlesOnColission : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (gameObject.GetComponent<StoryProgressorHitArea>().CheckPreCondition())
        {
            if (coll.gameObject.tag == "Player")
            {
                GetComponent<ParticleSystem>().Play();
            }
        }
    }
}
