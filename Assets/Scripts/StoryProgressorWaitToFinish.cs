using UnityEngine;
using System.Collections;

public class StoryProgressorWaitToFinish : MonoBehaviour {
    public string PreCondition;
    public string StoryVariable;
    public bool Once;

    public float WaitTime;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(CheckPreCondition())
        {
            if(!GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>().TextMessagePresent)
            {
                WaitTime -= Time.deltaTime;
                if(WaitTime <= 0)
                {
                    Execute();
                }
            }
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
