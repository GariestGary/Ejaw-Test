// GENERATED AUTOMATICALLY FROM 'Assets/Controls/Controls.inputactions'

using System;
using UnityEngine;
using UnityEngine.Experimental.Input;


[Serializable]
public class Controls : InputActionAssetReference
{
    public Controls()
    {
    }
    public Controls(InputActionAsset asset)
        : base(asset)
    {
    }
    private bool m_Initialized;
    private void Initialize()
    {
        // Player
        m_Player = asset.GetActionMap("Player");
        m_Player_Click = m_Player.GetAction("Click");
        m_Player_Position = m_Player.GetAction("Position");
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        m_Player = null;
        m_Player_Click = null;
        m_Player_Position = null;
        m_Initialized = false;
    }
    public void SetAsset(InputActionAsset newAsset)
    {
        if (newAsset == asset) return;
        if (m_Initialized) Uninitialize();
        asset = newAsset;
    }
    public override void MakePrivateCopyOfActions()
    {
        SetAsset(ScriptableObject.Instantiate(asset));
    }
    // Player
    private InputActionMap m_Player;
    private InputAction m_Player_Click;
    private InputAction m_Player_Position;
    public struct PlayerActions
    {
        private Controls m_Wrapper;
        public PlayerActions(Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click { get { return m_Wrapper.m_Player_Click; } }
        public InputAction @Position { get { return m_Wrapper.m_Player_Position; } }
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
    }
    public PlayerActions @Player
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new PlayerActions(this);
        }
    }
    private int m_MouseTouchSchemeIndex = -1;
    public InputControlScheme MouseTouchScheme
    {
        get

        {
            if (m_MouseTouchSchemeIndex == -1) m_MouseTouchSchemeIndex = asset.GetControlSchemeIndex("Mouse&Touch");
            return asset.controlSchemes[m_MouseTouchSchemeIndex];
        }
    }
}
