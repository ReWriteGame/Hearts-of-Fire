using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class Coin2D : MonoBehaviour
{
    public UnityEvent onTakeCoin;
    public UnityEvent onFallCoin;

    private ParticleSystem ps;

    [SerializeField] private float dalayDestroy;
    //[SerializeField] private scripts[] trekkingObj;
    private Collider2D coll;
    private void Start()
    {
        coll = GetComponent<Collider2D>();
        ps = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ps.Play();
        print("fall coin");
        onFallCoin.Invoke();
        StartCoroutine(destroyMe(dalayDestroy));
    }


    private void OnMouseDown()
    {
        ps.Play();
        print("take coin");
        onTakeCoin.Invoke();
        StartCoroutine(destroyMe(dalayDestroy));
    }

  


    IEnumerator destroyMe(float dalay = 0)
    {
        yield return new WaitForSeconds(dalay);
        Destroy(gameObject);
        yield break;
    }
}
