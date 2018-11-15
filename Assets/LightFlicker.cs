using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

    public Transform lightMasks;
    public float chanceToFlicker;
    public float minFlickerScale;
    public float maxFlickerScale;
    public float minFlickerDuration;
    public float maxFlickerDuration;
    public float minVarianceScale;
    public float maxVarianceScale;
    public float varianceSpeed;
    public float varianceUpdateRate;
    private Vector3 scaleVelocity;
    private Vector3 targetVariance;

    private void Start() {
        StartCoroutine(UpdateVariance(varianceUpdateRate));
    }

    private void Update() {
        if (Mathf.Pow(1 + chanceToFlicker, Time.deltaTime) - 1 > Random.Range(0, 1f))
            StartCoroutine(Flicker(Vector3.one * Random.Range(minFlickerScale, maxFlickerScale), Random.Range(minFlickerDuration, maxFlickerDuration)));
        lightMasks.localScale = Vector3.SmoothDamp(lightMasks.localScale, targetVariance, ref scaleVelocity, varianceSpeed);
    }

    private IEnumerator UpdateVariance(float updateRate) {
        var timer = new WaitForSeconds(updateRate);
        while (true) {
            targetVariance = Vector3.one * Random.Range(minVarianceScale, maxVarianceScale);
            yield return timer;
        }
    }

    private IEnumerator Flicker(Vector3 scale, float duration) {
        Vector3 originalScale = lightMasks.transform.localScale;
        lightMasks.localScale = scale;
        float endTime = Time.time + duration;
        while (endTime > Time.time)
            yield return null;
        lightMasks.localScale = originalScale;
    }
}
