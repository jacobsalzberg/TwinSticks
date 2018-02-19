using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private const int bufferFrames = 100; //change replay time
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody rigidBody;
    private GameManager manager;


	void Start () {
        //TEST: 
        //MyKeyFrame testKey = new MyKeyFrame(1.0f, Vector3.up, Quaternion.identity);
        //print(testKey.frameTime);
        rigidBody = GetComponent<Rigidbody>();
        manager = GameObject.FindObjectOfType<GameManager>();
	}
	
	void Update ()
    {
        if (manager.recording)
        {

            Record();
        }
        else
        {
            PlayBack();
        }
    }

    void PlayBack ()
    {
        rigidBody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
       // print("Reading Frame" + frame);
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }

    private void Record()
    {
        rigidBody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
       // print("Writing frame" + frame);
        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }

}

public struct MyKeyFrame
{
    public float frameTime;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame (float aTime, Vector3 aPosition, Quaternion aRotation)
    {
        frameTime = aTime;
        position = aPosition;
        rotation = aRotation;
    }
}
