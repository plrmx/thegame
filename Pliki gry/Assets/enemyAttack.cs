using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace enemyAttack {
    public class enemyAttack : MonoBehaviour
    {    public Rigidbody2D enemy;
        public Rigidbody2D player;
        private int enemyMask = 1 << 7;
        public static bool isHit = false;
        private float cooldownStart = 0f;
        private float attackCooldown = 0.8f;
        public  static string targetTag;
        private RaycastHit2D attack;
        public AudioSource punchEffect;
        public SpriteRenderer sprite;
        public Sprite attackSprite;
        public Sprite normalSprite;
        
        IEnumerator spriteChange()
        {
        
            yield return new WaitForSeconds(0.3f);
            sprite.sprite = normalSprite;

        }
		IEnumerator hit(){
 				yield return new WaitForSeconds(0.1f);
				punchEffect.Play();
                sprite.sprite = attackSprite;
                StartCoroutine(spriteChange());
                cooldownStart = Time.time;
  				StartCoroutine(countHit());
		}
		IEnumerator countHit(){
 			yield return new WaitForSeconds(0.1f);
			if (attack.collider != null)
			{
				if(attack.collider.gameObject.tag == player.gameObject.tag)
				{
					isHit = true;
					targetTag = attack.collider.gameObject.tag;
				}
			}	
		}

        // Start is called before the first frame update
        void Start()
        {
            enemy.transform.localScale = new Vector3(-1f, 1f, 1f);
            attack = Physics2D.Raycast(transform.position, Vector2.left, 1.9f, ~enemyMask);
        }

        // Update is called once per frame
        void Update()
        {


            if (player.transform.position.x > enemy.transform.position.x)
            {

                attack = Physics2D.Raycast(transform.position, Vector2.right, 1.5f, ~enemyMask);
                enemy.transform.localScale = new Vector3(1f, 1f, 1f); 
            }
            else if (player.transform.position.x < enemy.transform.position.x)
            {

                attack = Physics2D.Raycast(transform.position, Vector2.left, 1.5f, ~enemyMask);
                enemy.transform.localScale = new Vector3(-1f, 1f, 1f);
            }

			if(attack.collider  != null && Time.time >= cooldownStart + attackCooldown){
   				 cooldownStart = Time.time;
				StartCoroutine(hit());
			} else if (Time.time >= cooldownStart + 3f)
            {
					punchEffect.Play();
                    sprite.sprite = attackSprite;
                    StartCoroutine(spriteChange());
                    cooldownStart = Time.time;
					StartCoroutine(countHit());
            }
            else
            {
                isHit = false;
            }
        }
    }
}
