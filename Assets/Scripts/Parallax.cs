using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    //Make an array of elements that parallax applies to (background/foreground)
    public Transform[] backgrounds;
    // Stores parallax scales - proportion of cameras movement to move backgrounds by
    private float[] parallaxScales;
    // How smooth the parallax is going to be - make sure to set this above 0
    public float smoothing = 1f;
    // Reference to main camera's transform
    private Transform cam;
    // Stores position of camera in previous frame
    private Vector3 previousCamPosition;

    // Awake is called before Start() but after game objects are set up - great for references
    private void Awake() {
        // Set up camera reference
        cam = Camera.main.transform;
    }

    // Use this for initialization
    void Start () {
        // Store previous frame
        previousCamPosition = cam.position;
        // Assigning corrresponding parallax scales
        parallaxScales = new float[backgrounds.Length];

        for (int i=0; i<backgrounds.Length; i++) {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
		for (int i=0; i < backgrounds.Length; i++) {
            // The parallax is the opposite of the camera movement because previous frame multiplied by scale
            float parallax = (previousCamPosition.x - cam.position.x) * parallaxScales[i];

            // Set a target x position which is current position + parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            // Create a target position which is the background's current position with its target x position
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        // Set the previous cam position to the camera's position at the end of the frame
        previousCamPosition = cam.position;
	}
}
