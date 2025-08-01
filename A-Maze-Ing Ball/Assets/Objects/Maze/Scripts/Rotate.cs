using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField]
    float rotationAngle = 30.0f;

    [SerializeField]
    float rotationTime = 00.2f;

    float currentVelocity = 00.0f;
    float targetAngle = 00.0f;

    private void OnEnable() => GameManager.Finish += OnFinishLevel;
    private void OnDisable() => GameManager.Finish = OnFinishLevel;


    private void Update()
    {
        if (GameManager.isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                AudioManager.PlaySound?.Invoke(AudioManager.ROTATE);
                targetAngle += rotationAngle;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                AudioManager.PlaySound?.Invoke(AudioManager.ROTATE);
                targetAngle -= rotationAngle;
            }
        }

        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, targetAngle, ref currentVelocity, rotationTime);
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }

    private void OnFinishLevel(bool dummy) => targetAngle = 00.0f;
}
