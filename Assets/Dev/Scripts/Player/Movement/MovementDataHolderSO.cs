using System;
using UnityEngine;

namespace Simulator.Player
{
    [CreateAssetMenu(menuName = "Simulator/Player/Movement", fileName = "MovementDataHolder")]
    public class MovementDataHolderSO : ScriptableObject
    {
        internal Action<PlayerManager> movementUpdate;

        internal MovementDataHolderSO()
        {
            movementUpdate = (playerManager) =>
            {
                playerManager.isGrounded = Physics.CheckSphere(playerManager.transform.position, 0.1f, playerManager.groundMask);
                if (playerManager.isGrounded) playerManager.verticalVelocity.y = 0;

                Vector3 horizontalVelocity =
                    (playerManager.transform.right * playerManager.horizontalInput.x + playerManager.transform.forward * playerManager.horizontalInput.y) * playerManager.movementSpeed;

                playerManager.characterController.Move(horizontalVelocity * Time.deltaTime);

                if (playerManager.isJump)
                {
                    if (playerManager.isGrounded)
                    {
                        playerManager.verticalVelocity.y = Mathf.Sqrt(-2f * playerManager.jumpHeight * playerManager.gravity);
                    }

                    playerManager.isJump = false;
                }

                playerManager.verticalVelocity.y += playerManager.gravity * Time.deltaTime;
                playerManager.characterController.Move(playerManager.verticalVelocity * Time.deltaTime);
            };
        }
    }
}