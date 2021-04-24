using UnityEngine;
using System.Collections;

public class SimpleProjectile : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float velocity;
    [SerializeField] private float damage;
    [SerializeField] private float selfdestructTime = 10;

    [SerializeField] private GameObject electricBall;  

    private void Start()
    {
        _rigidbody.velocity = transform.forward * velocity;
        Destroy(gameObject, selfdestructTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamagable damagable))
        {
            // basic attack landed on enemy  -> 
            //StartCoroutine(HitEffect());
            damagable.TakeDamage(damage);
            Instantiate(electricBall, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    //private IEnumerator HitEffect()
    //{
    //    var effect = Instantiate(electricBall, transform.position, Quaternion.identity);

    //    var particleSys = effect.GetComponent<ParticleSystem>();
    //    //particleSys.Play();

    //    yield return new WaitForSeconds(particleSys.main.duration);
    //    Destroy(effect);
    //}
}
