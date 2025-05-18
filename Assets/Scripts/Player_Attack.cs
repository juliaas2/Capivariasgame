using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public int attack;

    private void Start()
    {
        var data = GameManager.instance.playerData;
        attack = data.attack;
    }

    private void OnDisable()
    {
        var data = GameManager.instance.playerData;
        data.attack = attack;
    }
    void OnTriggerEnter2D(Collider2D other)

    {
        if (other.CompareTag("Ninja"))
        {
            other.GetComponent<Ninja_Controller>().life -= attack;
        }
        
        if (other.CompareTag("Boss"))
        {
            other.GetComponent<Boss_Controller>().life -= attack;
        }
    }
}