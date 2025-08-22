using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField] float rotationAngle = 30.0f;

    [SerializeField] float rotationTime = 00.2f;

    private float currentVelocity = 00.0f;
    private float targetAngle = 00.0f;

    private void OnEnable() => GameManager.Finish += OnFinishLevel;
    private void OnDisable() => GameManager.Finish = OnFinishLevel;

    #if UNITY_ANDROID || UNITY_IOS
    Touch touch;
    private float touchX, touchY;
    private readonly float screenMid = Screen.width / 2;
    private readonly float screenTop = Screen.height * 5 / 6;
    #endif

    private void Update()
    {
        if (GameManager.isPlaying)
        {
            #if UNITY_ANDROID || UNITY_IOS
            if (Input.touchCount == 1)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began && touch.position.y <= screenTop)
                {
                    if (touch.position.x > screenMid) Right();
                    else Left();
                }
            }
            #else
            if (Input.GetKeyDown(KeyCode.LeftArrow)) Left();
            else if (Input.GetKeyDown(KeyCode.RightArrow)) Right();
            #endif
        }

        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, targetAngle, ref currentVelocity, rotationTime);
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }

    private void Left()
    {
        AudioManager.PlaySound?.Invoke(AudioManager.SFXName.ROTATE);
        targetAngle += rotationAngle;
    }

    private void Right()
    {
        AudioManager.PlaySound?.Invoke(AudioManager.SFXName.ROTATE);
        targetAngle -= rotationAngle;
    }

    private void OnFinishLevel(bool dummy) => targetAngle = 00.0f;
}
