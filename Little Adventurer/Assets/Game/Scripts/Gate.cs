using System.Collections;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject GateVisual;
    private Collider _gateCollider;
    public float OpenDuration = 2f;
    public float OpenTargetY = -1.5f;

    private void Awake()
    {
        _gateCollider = GetComponent<Collider>();
    }

    IEnumerator OpenGateAnimation()
    {
        float currentOpenDuration = 0;
        Vector3 startPos = GateVisual.transform.position;
        Vector3 targetPos = startPos + Vector3.up * OpenTargetY;

        while (currentOpenDuration < OpenDuration)
        {
            currentOpenDuration += Time.deltaTime;
            float t = currentOpenDuration / OpenDuration;
            GateVisual.transform.position = Vector3.Lerp(startPos, targetPos, t);

            yield return null;
        }

        _gateCollider.enabled = false; // Disable the collider after opening
    }

    public void Open()
    {
        StartCoroutine(OpenGateAnimation());
    }
}
