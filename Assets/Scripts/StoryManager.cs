using UnityEngine;
using System.Collections;
using System.Reflection;

public class StoryManager : MonoBehaviour 
{

    public bool Act1Finished = false;
    public bool A1S1Finished = false;

    public bool A1S2Finished = false;
    public bool A1S2_TalkRad = false;
    public bool A1S2_TalkSca = false;
    public bool A1S2_KilledE = false;
    public bool A1S2_TookRing = false;

    public bool A1S3Finished = false;

    public bool Act2Finished = false;

    public bool Act3Finished = false;

	// Use this for initialization
	void Start () 
    {
        DontDestroyOnLoad(gameObject);
	}

    public void ChangeValue(string str)
    {
        Debug.Log("Change Property " + str + " from " + GetType().GetField(str).GetValue(this) + " to True");
        this.GetType().GetField(str).SetValue(this, true);
    }

    public bool GetValue(string str)
    {
        return (bool)(this.GetType().GetField(str).GetValue(this));
    }

	
	// Update is called once per frame
	void Update () 
    {
	    
	}
}
