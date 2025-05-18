// Classe que guarda os dados do player - não herda de MonoBehaviour
[System.Serializable]
public class PlayerData
{
    public int life = 3;
    public int keys = 0;
    public int attack = 2;

    public PlayerData(int life, int keys, int attack)
    {
        this.life = life;
        this.keys = keys;
        this.attack = attack;
    }
}
