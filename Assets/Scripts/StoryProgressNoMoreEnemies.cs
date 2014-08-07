using UnityEngine;
using System.Collections;

public class StoryProgressNoMoreEnemies : MonoBehaviour {

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
        GameObject[] list = GameObject.FindGameObjectsWithTag("Enemies");
        if (list.Length == 0)
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
        if(CheckPreCondition())
        {
            GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>().ChangeValue(StoryVariable);
            if(Once)
            {
                Destroy(gameObject);
            }
        }
    }
}
