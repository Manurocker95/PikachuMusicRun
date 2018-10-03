/// This code is personal and can't be used for commercial games.
/// Non-profit projects can use it with explicit permission and credits
/// 
/// Made by Manuel Rodríguez Matesanz.
/// You can contact me on GBATemp as Manurocker95, email: Manuelrodriguezmatesanz@gmail.com
/// or even on my web: Manuelrodriguezmatesanz.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PikachuMusicRun.Game
{
    /// <summary>
    /// This is a modified version of Brackey's Player Controller.
    /// Check his script here: https://github.com/Brackeys/2D-Character-Controller
    /// </summary>
    public class PMR_PlayerController : MonoBehaviour
    {
        /// <summary>
        /// Amount of force added when the player jumps.
        /// </summary>
        [SerializeField] private float m_JumpForce = 400f;
        /// <summary>
        /// How much to smooth out the movement
        /// </summary>
        [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
        /// <summary>
        /// Whether or not a player can steer while jumping;
        /// </summary>
        [SerializeField] private bool m_AirControl = false;
        /// <summary>
        /// Radius of the overlap circle to determine if grounded
        /// </summary>
        const float k_GroundedRadius = .2f;
        /// <summary>
        /// Whether or not the player is grounded.
        /// </summary>
        private bool m_Grounded;            
        /// <summary>
        /// A mask determining what is ground to the character
        /// </summary>
        [SerializeField] private LayerMask m_WhatIsGround;
        /// <summary>
        /// A position marking where to check if the player is grounded.
        /// </summary>
        [SerializeField] private Transform m_GroundCheck;
        [SerializeField] private Animator m_animator;
        /// <summary>
        /// Player's rigidbody
        /// </summary>
        private Rigidbody2D m_Rigidbody2D;
        /// <summary>
        /// Velocity vector
        /// </summary>
        private Vector3 m_Velocity = Vector3.zero;

        [Header("Events"), Space(10)]
        public UnityEvent OnLandEvent;

        [System.Serializable]
        public class BoolEvent : UnityEvent<bool> { }

        private void Awake()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();

            if (OnLandEvent == null)
                OnLandEvent = new UnityEvent();

            OnLandEvent.AddListener(OnLand);
        }

        private void FixedUpdate()
        {
            bool wasGrounded = m_Grounded;
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    m_Grounded = true;
                    if (!wasGrounded)
                        OnLandEvent.Invoke();
                }
            }
        }

        void OnLand()
        {
            m_animator.SetBool("jumping", false);
        }

        private void Update()
        {
            if (PMR_InputManager.PressedJumpButton())
            {
                Jump();
            }
        }
        /// <summary>
        /// We can only jump
        /// </summary>
       public void Jump()
       {
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            m_animator.SetBool("jumping", true);
       }
    }
}
