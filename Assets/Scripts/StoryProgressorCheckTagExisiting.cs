using UnityEngine;
using System.Collections;

public class StoryProgressorCheckTagExisiting : MonoBehaviour 
{

    public string PreCondition;
    public string StoryVariable;
    public bool Once;
    public string TagName;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] list = GameObject.FindGameObjectsWithTag(TagName);
        if (list.Length == 0)
        {
            Execute();
        }
    }

    private bool CheckPreCondition()
    {
        if (string.IsNullOrEmpty(PreCondition))
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
            if (Once)
            {
                Destroy(gameObject);
            }
        }
    }
}
