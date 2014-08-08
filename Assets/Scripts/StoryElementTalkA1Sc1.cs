using UnityEngine;
using System.Collections;

public class StoryElementTalkA1Sc1 : MonoBehaviour {

    StoryManager mng;
	// Use this for initialization
	void Start () 
    {

        StoryProgressorHitArea prog = new StoryProgressorHitArea();
        prog.PreCondition = "";
        prog.Once = true;
        prog.StoryVariable = "A1S1Talk1";
        prog.Execute();

        StoryProgressorWaitToFinish prog2 = new StoryProgressorWaitToFinish();
        prog2.PreCondition = "A1S1Talk1";
        prog2.StoryVariable = "A1S1Talk2";
        prog2.Once = true;
	}


    bool finished = false;

	
	// Update is called once per frame
	void Update () 
    {
      
	}
}
