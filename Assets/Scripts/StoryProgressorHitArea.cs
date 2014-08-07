using UnityEngine;
using System.Collections;

public class StoryProgressorHitArea : MonoBehaviour
{
    public string PreCondition;
    public string StoryVariable;
    public bool Once;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Entering");
        if (coll.gameObject.tag == "Player")
        {
            Execute();
        }
    }

    private bool CheckPreCondition()
    {
        if(string.IsNullOrEmpty(PreCondition))
        {
            return true;
        }
        else
        {
            return GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>().GetValue(PreCondition);
        }
    }


    public void Execute()
    {
        if (CheckPreCondition())
        {
            GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>().ChangeValue(StoryVariable);
            if(Once)
            {
                Destroy(gameObject);
            }
        }
    }
}
