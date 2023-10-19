using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace attack {
    public class attack : MonoBehaviour
    {
        public static bool isHit = false;
        private int enemyMask = 1 << 3;
        private float cooldownStart = 0f;
        private float attackCooldown = 0.3f;
        public  static string targetTag;
        private RaycastHit2D hit;
        public Rigidbody2D enemy;
        public Rigidbody2D player;
        public AudioSource punchEffect;

        
  
        // Start is called before the first frame update
        void Start()
        {
            hit = Physics2D.Raycast(transform.position, Vector2.right, 1.2f, enemyMask);  
        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
            {
                player.transform.localScale = new Vector3(-0.3303f, 0.344f, 1f); 
            }
            else if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
            {
                player.transform.localScale = new Vector3(0.3303f, 0.344f, 1f);
            }

            if (player.transform.localScale.x > 0)
            {
                hit = Physics2D.Raycast(transform.position, Vector2.left, 1.2f, ~enemyMask);
            }
            else
            {
                hit = Physics2D.Raycast(transform.position, Vector2.right, 1.2f, ~enemyMask);
            }

        
            if (Time.time >= cooldownStart + attackCooldown && Input.GetButtonDown("Attack"))
            {
					punchEffect.Play();
                cooldownStart = Time.time;
               
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.tag == enemy.gameObject.tag)
                    {
                        isHit = true;
                        targetTag = hit.collider.gameObject.tag;
                    }
                }
            }
            else
            {
                isHit = false;
            }
        }
    }
}