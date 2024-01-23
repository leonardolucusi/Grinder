using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // O transform do jogador a ser seguido
    public float smoothSpeed = 5f; // Velocidade suave de movimento da câmera
    public Vector3 offset; // Offset da posição da câmera em relação ao jogador

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
