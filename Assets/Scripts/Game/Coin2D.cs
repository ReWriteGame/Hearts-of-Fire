using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Coin2D : MonoBehaviour
{
    public UnityEvent onTakeCoin;
    public UnityEvent onFallCoin;


    //[SerializeField] private scripts[] trekkingObj;
    private Collider2D coll;
    private void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("fall coin");
        onFallCoin.Invoke();
        destroyMe();
    }


    private void OnMouseDown()
    {
        print("take coin");
        onTakeCoin.Invoke();
        destroyMe();
    }

  


    public void destroyMe()
    {
        Destroy(gameObject);
    }
}
