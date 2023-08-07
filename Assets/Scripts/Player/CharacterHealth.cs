using System;
using UnityEngine;

public class CharacterHealth : PlayerHealth
{
        public bool Death { get; private set; }
        public bool canHealth => Health < maxHealth;
        private BoxCollider2D _boxCollider2D;
        private Animator _animation;
        private PlayerMove _playerMove;

        [SerializeField] private GameObject restartPanal;

        private static readonly int Dead = Animator.StringToHash("Dead");
        //private bool isOver = false;

        private void Awake()
        {
                _boxCollider2D = GetComponent<BoxCollider2D>();
                _animation = GetComponent<Animator>();
                _playerMove = GetComponent<PlayerMove>();
        }
        protected override void Start()
        {
                base.Start();
                UpdateHealthBar(Health,maxHealth);
        }
        private void Update()
        {
                
                // if (Input.GetKeyDown(KeyCode.T))
                // {
                //         Debug.Log("Press T");
                //         takeDamage(10);
                // }
                //
                // if (Input.GetKeyDown(KeyCode.R))
                // {
                //         Debug.Log("Press R");
                //         RestoreHealth(10);
                // }
                if (Input.GetKeyDown(KeyCode.T))
                {
                        Debug.Log("Press T");
                        takeDamage(10);
                }
        }

        public void RestoreHealth(float amount)
        {
                if (Death)              
                {
                    return;    
                }
                if (canHealth)
                {
                        Health += amount;
                        if (Health> maxHealth)
                        {
                                Health = maxHealth;
                        }
                        
                        UpdateHealthBar(Health, maxHealth);
                }
        }

        protected override void CharacterDeath()
        {        
                
                
                Death = true;
                Die();

        }

        public void Die()
        {
                if (Death)
                {
                      Debug.Log("Dead");
                      restartPanal.SetActive(true);
                      _boxCollider2D.enabled = false;
                      _animation.SetTrigger(Dead);
                      _playerMove.enabled = false;
                      this.enabled = false;
                }
        }
        public void RestoreCharacter()
        {
                _boxCollider2D.enabled = true;
                Death = false;
                Health = currenyHealth;
                UpdateHealthBar(Health, currenyHealth);
        }
        protected override void UpdateHealthBar(float updateHealth, float maxHealth)
        {
                UIManager.Instance.UpdateHealthCharacter(updateHealth, maxHealth);
        }
}