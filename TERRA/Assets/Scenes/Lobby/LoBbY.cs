using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoBbY : MonoBehaviour
{
    
    [SerializeField] private Button HRefiil_BTN;

    [SerializeField] private Button RecicleDJump_BTN;
    [SerializeField] private Button RecicleLJump_BTN;
    [SerializeField] private Button RecicleDash_BTN;
    [SerializeField] private Button RecicleInvisible_BTN;
    [SerializeField] private Button Recicle4Hearths_BTN;
    [SerializeField] private Button Recicle5Hearths_BTN;
    [SerializeField] private Button Recicle4Lifes_BTN;
    [SerializeField] private Button Recicle5Lifes_BTN;

    [SerializeField] private Image RecicleDJump_IMG;
    [SerializeField] private Image RecicleLJump_IMG;
    [SerializeField] private Image RecicleDash_IMG;
    [SerializeField] private Image RecicleInvisible_IMG;
    [SerializeField] private Image Recicle4Hearths_IMG;
    [SerializeField] private Image Recicle5Hearths_IMG;
    [SerializeField] private Image Recicle4Lifes_IMG;
    [SerializeField] private Image Recicle5Lifes_IMG;

    [SerializeField] private Button Equip1DJump_BTN;
    [SerializeField] private Button Equip1Lump_BTN;
    [SerializeField] private Button Equip1Dash_BTN;
    [SerializeField] private Button Equip1Invisible_BTN;
    [SerializeField] private Button Equip2DJump_BTN;
    [SerializeField] private Button Equip2Lump_BTN;
    [SerializeField] private Button Equip2Dash_BTN;
    [SerializeField] private Button Equip2Invisible_BTN;

    [SerializeField] private Image Equip1DJump_IMG;
    [SerializeField] private Image Equip1Lump_IMG;
    [SerializeField] private Image Equip1Dash_IMG;
    [SerializeField] private Image Equip1Invisible_IMG;
    [SerializeField] private Image Equip2DJump_IMG;
    [SerializeField] private Image Equip2Lump_IMG;
    [SerializeField] private Image Equip2Dash_IMG;
    [SerializeField] private Image Equip2Invisible_IMG;

    [SerializeField] private Image Equip1_IMG;
    [SerializeField] private Image Equip2_IMG;

    public Color disable = new Color(0.3584906f, 0.3584906f, 0.3584906f, 1f);

    public static bool DJEquip, LJEquip, DEquip, IEquip;
    private bool refill;

    // Start is called before the first frame update
    void Start()
    {

        refill = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (refill)
        {
            HRefiil_BTN.interactable = false;
        }

        #region Recicle
        if (GameController.DJumpUnlock)
        {
            Equip1DJump_IMG.color = Color.white;
            Equip2DJump_IMG.color = Color.white;
            RecicleDJump_IMG.color = Color.white;
            RecicleDJump_BTN.interactable = false;
        }

        if (GameController.LJumpUnlock)
        {
            Equip1Lump_IMG.color = Color.white;
            Equip2Lump_IMG.color = Color.white;
            RecicleLJump_IMG.color = Color.white;
            RecicleLJump_BTN.interactable = false;
        }

        if (GameController.DashUnlock)
        {
            Equip1Dash_IMG.color = Color.white;
            Equip2Dash_IMG.color = Color.white;
            RecicleDash_IMG.color = Color.white;
            RecicleDash_BTN.interactable = false;
        }

        if (GameController.InvisibleUnlock)
        {
            Equip1Invisible_IMG.color = Color.white;
            Equip2Invisible_IMG.color = Color.white;
            RecicleInvisible_IMG.color = Color.white;
            RecicleInvisible_BTN.interactable = false;
        }

        if (GameController.x4HeartsUnlock)
        {
            Recicle4Hearths_IMG.color = Color.white;
            Recicle4Hearths_BTN.interactable = false;
        }

        if (GameController.x5HeartsUnlock)
        {
            Recicle5Hearths_IMG.color = Color.white;
            Recicle5Hearths_BTN.interactable = false;
        }

        if (GameController.x4LifesUnlock)
        {
            Recicle4Lifes_IMG.color = Color.white;
            Recicle4Lifes_BTN.interactable = false;
        }

        if (GameController.x5LifesUnlock)
        {
            Recicle5Lifes_IMG.color = Color.white;
            Recicle5Lifes_BTN.interactable = false;
        }
        #endregion

        #region Equipment

        if (DJEquip || !GameController.DJumpUnlock)
        {

            Equip1DJump_BTN.interactable = false;
            Equip2DJump_BTN.interactable = false;
        }
        else
        {
            Equip1DJump_BTN.interactable = true;
            Equip2DJump_BTN.interactable = true;
        }

        if (LJEquip || !GameController.LJumpUnlock)
        {

            Equip1Lump_BTN.interactable = false;
            Equip2Lump_BTN.interactable = false;
        }
        else
        {

            Equip1Lump_BTN.interactable = true;
            Equip2Lump_BTN.interactable = true;
        }

        if (DEquip || !GameController.DashUnlock)
        {

            Equip1Dash_BTN.interactable = false;
            Equip2Dash_BTN.interactable = false;
        }
        else
        {

            Equip1Dash_BTN.interactable = true;
            Equip2Dash_BTN.interactable = true;
        }

        if (IEquip || !GameController.InvisibleUnlock)
        {

            Equip1Invisible_BTN.interactable = false;
            Equip2Invisible_BTN.interactable = false;
        }
        else
        {

            Equip1Invisible_BTN.interactable = true;
            Equip2Invisible_BTN.interactable = true;
        }

        #endregion
        CheckButons();
    }

    #region Windows
    public void closeHealth()
    {
        PlayerLobby.ActH = false;
    }
    public void closeRecicler()
    {
        PlayerLobby.ActR = false;
    }
    public void closeEquipment()
    {
        PlayerLobby.ActE = false;
    }
    #endregion

    //------------- Refill ----------------
    public void Refiill()
    {
        refill = true;
        GameObject go = GameObject.Find("Heart Bar - HUD_0");
        Heart_Bar ToFiil = go.GetComponent<Heart_Bar>();
        ToFiil.Refill();
    }

    //------------- Recicler ---------------
    #region Recicle
    public void UnlockDJump()
    {
        GameController.DJumpUnlock = true;
    }

    public void UnlockLJump()
    {
        GameController.LJumpUnlock = true;
    }

    public void UnlockDash()
    {
        GameController.DashUnlock = true;
    }

    public void UnlockInvisible()
    {
        GameController.InvisibleUnlock = true;
    }

    public void Unlock4Hearts()
    {
        GameController.TypeLife = 2;
        GameController.HeartsMax = 8;
        GameController.corazones = GameController.HeartsMax;
        Heart_Bar.Phearts = GameController.corazones;
        GameController.vidas = GameController.LifeMax;

        GameController.x4HeartsUnlock = true;
    }

    public void Unlock5Hearts()
    {
        GameController.TypeLife = 3;
        GameController.HeartsMax = 10;
        GameController.corazones = GameController.HeartsMax;
        Heart_Bar.Phearts = GameController.corazones;
        GameController.vidas = GameController.LifeMax;

        GameController.x4HeartsUnlock = true;
        GameController.x5HeartsUnlock = true;
    }

    public void Unlock4Lifes()
    {
        GameController.corazones = GameController.HeartsMax;
        Heart_Bar.Phearts = GameController.corazones;
        GameController.LifeMax = 4;
        GameController.vidas = GameController.LifeMax;
        Heart_Bar.life = GameController.vidas;

        GameController.x4LifesUnlock = true;
    }

    public void Unlock5Lifes()
    {
        GameController.corazones = GameController.HeartsMax;
        Heart_Bar.Phearts = GameController.corazones;
        GameController.LifeMax = 5;
        GameController.vidas = GameController.LifeMax;
        Heart_Bar.life = GameController.vidas;

        GameController.x4LifesUnlock = true;
        GameController.x5LifesUnlock = true;
    }
    #endregion

    //------------- Equipment --------------
    #region Equipment

    //------------- Equipment1--------------
    public void Equip1DJump()
    {
        GameController.H1Equip = "Double_Jump";
        LJEquip = false;
        DEquip = false;
        IEquip = false;
    }

    public void Equip1LJump()
    {
        GameController.H1Equip = "Long_Jump";
        DJEquip = false;
        DEquip = false;
        IEquip = false;
    }

    public void Equip1Dash()
    {
        GameController.H1Equip = "Dash";
        DJEquip = false;
        LJEquip = false;
        IEquip = false;
    }

    public void Equip1Invisible()
    {
        GameController.H1Equip = "Invisible";
        DJEquip = false;
        LJEquip = false;
        DEquip = false;
    }

    //------------- Equipment2--------------

    public void Equip2DJump()
    {
        GameController.H2Equip = "Double_Jump";
        LJEquip = false;
        DEquip = false;
        IEquip = false;
    }

    public void Equip2LJump()
    {
        GameController.H2Equip = "Long_Jump";
        DJEquip = false;
        DEquip = false;
        IEquip = false;
    }

    public void Equip2Dash()
    {
        GameController.H2Equip = "Dash";
        DJEquip = false;
        LJEquip = false;
        IEquip = false;
    }

    public void Equip2Invisible()
    {
        GameController.H2Equip = "Invisible";
        DJEquip = false;
        LJEquip = false;
        DEquip = false;
    }

    #endregion

    public void CheckButons()
    {
        GameObject go = GameObject.Find("InvFunc");
        radial radial = go.GetComponent<radial>();

        //------------- Refill --------------
        #region Refill
        if (radial.basura[3] < 5 || radial.basura[4] < 2 || radial.basura[2] < 3 || refill)
        {
            HRefiil_BTN.interactable = false;
        }
        else
        {
            HRefiil_BTN.interactable = true;
        }
        #endregion

        //------------- Recicle --------------
        #region Recicle

        //------------- DJ --------------
        if (radial.basura[1] < 6 || radial.basura[5] < 3 || radial.basura[2] < 4 || GameController.DJumpUnlock)
        {
            RecicleDJump_BTN.interactable = false;
        }
        else
        {
            RecicleDJump_BTN.interactable = true;
        }

        //------------- LJ --------------
        if (radial.basura[1] < 3 || radial.basura[4] < 3 || radial.basura[2] < 4 || radial.basura[3] < 4 || GameController.LJumpUnlock)
        {
            RecicleLJump_BTN.interactable = false;
        }
        else
        {
            RecicleLJump_BTN.interactable = true;
        }

        //------------- D --------------
        if (radial.basura[1] < 3 || radial.basura[5] < 6 || radial.basura[4] < 3 || radial.basura[2] < 4 || GameController.DashUnlock)
        {
            RecicleDash_BTN.interactable = false;
        }
        else
        {
            RecicleDash_BTN.interactable = true;
        }

        //------------- I --------------
        if (radial.basura[1] < 4 || radial.basura[5] < 5 || radial.basura[2] < 4 || radial.basura[3] < 2 || GameController.InvisibleUnlock)
        {
            RecicleInvisible_BTN.interactable = false;
        }
        else
        {
            RecicleInvisible_BTN.interactable = true;
        }

        //------------- x4H --------------
        if (radial.basura[5] < 3 || radial.basura[4] < 4 || radial.basura[3] < 3 || GameController.x4HeartsUnlock)
        {
            Recicle4Hearths_BTN.interactable = false;
        }
        else
        {
            Recicle4Hearths_BTN.interactable = true;
        }

        //------------- x5H --------------
        if (radial.basura[5] < 4 || radial.basura[4] < 5 || radial.basura[3] < 6 || GameController.x5HeartsUnlock)
        {
            Recicle5Hearths_BTN.interactable = false;
        }
        else
        {
            Recicle5Hearths_BTN.interactable = true;
        }

        //------------- x4L --------------
        if (radial.basura[4] < 5 || radial.basura[2] < 2 || radial.basura[3] < 4 || GameController.x4LifesUnlock)
        {
            Recicle4Lifes_BTN.interactable = false;
        }
        else
        {
            Recicle4Lifes_BTN.interactable = true;
        }

        //------------- x5L --------------
        if (radial.basura[4] < 7 || radial.basura[2] < 3 || radial.basura[3] < 5 || GameController.x5LifesUnlock)
        {
            Recicle5Lifes_BTN.interactable = false;
        }
        else
        {
            Recicle5Lifes_BTN.interactable = true;
        }
        #endregion
    }
}
