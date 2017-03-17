using UnityEngine;
using System.Collections;

public class CamShake : MonoBehaviour
{
    float shakeAmount;
    float shakeTimer;

    Vector3 initCamPos;

	void Start ()
    {
        initCamPos = transform.position;
	}
	
	void Update ()
    {
        if (shakeTimer >= 0)
        {
            Vector2 shakePos = Random.insideUnitCircle * shakeAmount;
            transform.position = new Vector3(transform.position.x + shakePos.x, transform.position.y + shakePos.y, transform.position.z);
            shakeTimer -= Time.deltaTime;
        }
        else if (shakeTimer <= 0)
            transform.position = initCamPos;
	}

    void ShakeCamera(float shakePwr, float shakeDur)
    {
        shakeAmount = shakePwr;
        shakeTimer = shakeDur;
    }

    public IEnumerator CamShakeProcedure(float shakePwr, float shakeDur)
    {
        ShakeCamera(shakePwr, shakeDur);
        yield return new WaitForSeconds(shakeTimer);
        Vector3 currentPos = transform.position;
        transform.position = Vector3.Lerp(currentPos, initCamPos, 100f);
    }
}
