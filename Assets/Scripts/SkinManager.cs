// SkinManager.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinManager : MonoBehaviour
{
    public static SkinManager Instance { get; private set; }
    
    // Propriedades para armazenar a skin selecionada
    public AnimatorOverrideController selectedSkinController { get; private set; }
    public Sprite selectedSkinSprite { get; private set; }
    
    // Referências para as skins disponíveis
    public AnimatorOverrideController defaultSkinController;
    public AnimatorOverrideController alternativeSkinController;
    public Sprite defaultSkinSprite;
    public Sprite alternativeSkinSprite;
    
    // Índice da cena do menu (em vez do nome)
    public int menuSceneIndex = 0; // Geralmente o menu é a cena 0
    
    // Índice da skin selecionada (0 = default, 1 = alternative)
    private int currentSkinIndex = 0;
    private bool isInGameScene = false;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            // Inicializa com a skin padrão
            selectedSkinController = defaultSkinController;
            selectedSkinSprite = defaultSkinSprite;
            
            // Registra o evento de mudança de cena
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void OnDestroy()
    {
        // Remove o evento ao destruir para evitar vazamentos de memória
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Verifica se estamos entrando no menu ou em um nível do jogo
        if (scene.buildIndex == menuSceneIndex)
        {
            // Se estamos voltando para o menu, restaura a skin padrão
            if (isInGameScene)
            {
                ResetToDefaultSkin();
                isInGameScene = false;
            }
        }
        else
        {
            // Estamos em um nível do jogo
            isInGameScene = true;
        }
        
        // Atualiza todos os jogadores na nova cena
        NotifyPlayerSkinChanged();
    }
    
    // Método para trocar a skin
    public void ChangeSkin(int skinIndex)
    {
        currentSkinIndex = skinIndex;
        
        if (skinIndex == 0)
        {
            selectedSkinController = defaultSkinController;
            selectedSkinSprite = defaultSkinSprite;
        }
        else if (skinIndex == 1)
        {
            selectedSkinController = alternativeSkinController;
            selectedSkinSprite = alternativeSkinSprite;
        }
        
        // Notifica que a skin foi alterada
        NotifyPlayerSkinChanged();
    }
    
    // Método para restaurar a skin padrão (usado ao voltar para o menu)
    private void ResetToDefaultSkin()
    {
        selectedSkinController = defaultSkinController;
        selectedSkinSprite = defaultSkinSprite;
        currentSkinIndex = 0;
    }
    
    // Método para obter o índice da skin atual
    public int GetCurrentSkinIndex()
    {
        return currentSkinIndex;
    }
    
    // Método para notificar todos os jogadores ativos sobre a mudança de skin
    private void NotifyPlayerSkinChanged()
    {
        // Encontra todos os objetos PlayerSkinHandler na cena
        PlayerSkinHandler[] skinHandlers = FindObjectsOfType<PlayerSkinHandler>();
        
        // Atualiza cada um deles
        foreach (PlayerSkinHandler handler in skinHandlers)
        {
            handler.UpdatePlayerSkin();
        }
    }
}