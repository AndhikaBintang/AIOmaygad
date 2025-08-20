using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;    // Target player
    public float smoothSpeed = 0.125f; // Kehalusan gerakan kamera
    public Vector3 offset;      // Jarak offset kamera dari player

    void LateUpdate()
    {
        if (player == null) return;

        // Posisi target kamera
        Vector3 desiredPosition = player.position + offset;

        // Smooth agar kamera tidak kaku
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        // Jika game 2D, pastikan kamera tetap menghadap ke arah yang benar
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }
}
