using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class DarknessCamera : MonoBehaviour {

    private Camera viewCamera;
    public Camera darknessCamera;
    public RawImage darknessImage;
    public Transform darknessSprite;
    private RenderTexture darknessTexture;
    public int baseResolution = 512;

	// Use this for initialization
	void Awake () {
        viewCamera = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        darknessTexture = new RenderTexture(Mathf.RoundToInt(baseResolution * ((float)viewCamera.pixelWidth / viewCamera.pixelHeight)), baseResolution, 24);
        darknessCamera.orthographicSize = viewCamera.orthographicSize * 1.2f;
        darknessCamera.targetTexture = darknessTexture;
        darknessSprite.localScale = new Vector3(darknessCamera.orthographicSize * 2 * ((float)darknessCamera.pixelWidth / darknessCamera.pixelHeight), darknessCamera.orthographicSize * 2, 1);
        darknessImage.texture = darknessTexture;
    }
}
