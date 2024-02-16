using UnityEngine;
//help from chatgpt, work in progress. Doesnt work entirely as I want to and tried to fix with chatgpt
//when shooting it is not exactly the direction of the mouse but is slightly off and I want to make it work 100%
public class ShootingController : MonoBehaviour
{
    public Transform firePoint;
    public Transform playerBody; // Reference to the player's body to rotate it
    public Camera mainCamera; // Reference to the main camera

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            UpdatePlayerRotation();
            Shoot();
        }

        // Update camera position to follow player
        mainCamera.transform.position = new Vector3(playerBody.position.x, mainCamera.transform.position.y, playerBody.position.z);
    }

    void UpdatePlayerRotation()
    {
        // Raycast from mouse position to determine the point in the game world
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPoint = hit.point;
            targetPoint.y = playerBody.position.y; // Keep target point at the same y-coordinate as the player

            // Calculate direction from player to target point
            Vector3 direction = targetPoint - playerBody.position;
            direction.y = 0f; // Ignore vertical component

            // Rotate the player's body to face the target point only on x-z axis
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                playerBody.rotation = Quaternion.Lerp(playerBody.rotation, targetRotation, Time.deltaTime * 10f);
            }
        }
    }

    void Shoot()
    {
        // Raycast from mouse position to determine the point in the game world
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPoint = hit.point;
            targetPoint.y = firePoint.position.y; // Keep target point at the same y-coordinate as the fire point

            // Calculate direction from fire point to target point
            Vector3 direction = targetPoint - firePoint.position;
            direction.y = 0f; // Ignore vertical component

            // Rotate the fire point to face the target point
            Quaternion rotation = Quaternion.LookRotation(direction);

            // Create bullet
            GameObject bullet = BulletPool.Instance.GetBullet();
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = rotation; // Set the rotation to the calculated rotation
            bullet.SetActive(true);
        }
    }
}

