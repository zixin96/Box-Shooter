using UnityEngine;
using System.Collections;

public class TargetMover : MonoBehaviour {

	// define the possible states through an enumeration
	public enum motionDirections {Spin, Horizontal, Vertical, Circular, Diagonal};
	
	// store the state
	public motionDirections motionState = motionDirections.Horizontal;

	// motion parameters
	public float spinSpeed = 180.0f;
	public float motionMagnitude = 0.1f;

    // circular parameters: 5 seconds to complete a circle
    public float timeToCompleteCircle = 5.0f;
    public float radius = 5.0f;

    private float angle = 0.0f;
    private float circularSpeed = 0.0f;
    private float x = 0.0f;
    private float y = 0.0f;

    // Update is called once per frame
    void Update () {

		// do the appropriate motion based on the motionState
		switch(motionState) { 
			case motionDirections.Spin:
				// rotate around the up axix of the gameObject
				gameObject.transform.Rotate (Vector3.up * spinSpeed * Time.deltaTime);
				break;
			
			case motionDirections.Vertical:
				// move up and down over time
				gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
				break;

            case motionDirections.Horizontal:
                // move up and down over time
                gameObject.transform.Translate(Vector3.right * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
                break;


            case motionDirections.Circular:
                circularSpeed = (2.0f * Mathf.PI) / timeToCompleteCircle;
                angle += circularSpeed * Time.deltaTime;
                x = radius * Mathf.Cos(angle);
                y = radius * Mathf.Sin(angle);
                gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
                break;

            case motionDirections.Diagonal:
                gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
                gameObject.transform.Translate(Vector3.right * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
                break;
        }
	}
}
