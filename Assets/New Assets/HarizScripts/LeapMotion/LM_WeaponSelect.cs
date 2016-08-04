/* The MIT License (MIT)

Copyright (c) 2016 Joshua Corvinus

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE. */

using UnityEngine;
using System.Collections;

public class LM_WeaponSelect : MonoBehaviour
{
    #region Weapon Selection
    [Header("Weapon Selection")]
    public GameObject pistol;
    public GameObject rifle;
    public GameObject sword;
    #endregion

    #region Button Variables
    [Header("Button Variables")]
    public FingerButton SelectLasPistol;
    public FingerButton SelectSword;
    public FingerButton SelectRifle;
    //public FingerButton SelectStunGrenade;
    #endregion

    #region Hand Variables
    [Header("Hand Variables")]
    public Transform Forearm;
    public Vector3 LocalOffset;
    public GameObject hand;
    //public GameObject leftHand;
    #endregion

    [Header("Visibility Variables")]
    public bool Visible = true;

    void OnEnable()
    {
        SelectLasPistol.ButtonActivated += SelectLasPistol_ButtonActivated;
        SelectRifle.ButtonActivated += SelectRifle_ButtonActivated;
        SelectSword.ButtonActivated += SelectSword_ButtonActivated;
        //SelectStunGrenade.ButtonActivated += SelectStunGrenade_ButtonActivated;
    }

    void OnDisable()
    {
        SelectLasPistol.ButtonActivated -= SelectLasPistol_ButtonActivated;
        SelectRifle.ButtonActivated -= SelectRifle_ButtonActivated;
        SelectSword.ButtonActivated -= SelectSword_ButtonActivated;
        //SelectStunGrenade.ButtonActivated -= SelectStunGrenade_ButtonActivated;
    }

    void Start()
    {
        transform.SetParent(Forearm);
        transform.localPosition = LocalOffset;
        pistol.SetActive(false);
        sword.SetActive(false);
        rifle.SetActive(false);
    }

    public void SelectLasPistol_ButtonActivated(FingerButton sender)
    {
        pistol.SetActive(true);
        sword.SetActive(false);
        rifle.SetActive(false);

        pistol.transform.parent = hand.transform;
        pistol.transform.localPosition = new Vector3(0.0f, -0.01f, -0.05f);
        pistol.transform.localRotation = Quaternion.identity;
        pistol.transform.localRotation = Quaternion.Euler(90, 90, 0);
    }

    public void SelectRifle_ButtonActivated(FingerButton sender)
    {
        pistol.SetActive(false);
        sword.SetActive(false);
        rifle.SetActive(true);

        rifle.transform.parent = hand.transform;
        rifle.transform.localPosition = new Vector3(-0.001f, 0.112f, -0.138f);
        rifle.transform.localRotation = Quaternion.identity;
        rifle.transform.localRotation = Quaternion.Euler(270, 0, 0);
    }

    public void SelectSword_ButtonActivated(FingerButton sender)
    {
        sword.SetActive(true);
        pistol.SetActive(false);
        rifle.SetActive(false);

        sword.transform.parent = hand.transform;
        sword.transform.localPosition = new Vector3(-0.02f, 0.06f, 0f);
        sword.transform.localRotation = Quaternion.identity;
        sword.transform.localRotation = Quaternion.Euler(0f, 90f, 180f);
    }

    public void SelectLasPistol_ButtonDeactivated()
    {
        pistol.SetActive(false);

        pistol.transform.parent = hand.transform;
        pistol.transform.localPosition = new Vector3(0.0f, -0.01f, -0.05f);
        pistol.transform.localRotation = Quaternion.identity;
        pistol.transform.localRotation = Quaternion.Euler(90, 90, 0);
    }

    public void SelectRifle_ButtonDeactivated()
    {
        rifle.SetActive(false);

        rifle.transform.parent = hand.transform;
        rifle.transform.localPosition = new Vector3(-0.001f, 0.112f, -0.138f);
        rifle.transform.localRotation = Quaternion.identity;
        rifle.transform.localRotation = Quaternion.Euler(270, 0, 0);
    }

    public void SelectSword_ButtonDeactivated()
    {
        sword.SetActive(false);

        sword.transform.parent = hand.transform;
        sword.transform.localPosition = new Vector3(-0.02f, 0.06f, 0f);
        sword.transform.localRotation = Quaternion.identity;
        sword.transform.localRotation = Quaternion.Euler(0f, 90f, 180f);
    }

    /*
    void SelectStunGrenade_ButtonActivated(FingerButton sender)
    {

    }
    */

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, (Visible) ? Vector3.one : Vector3.zero, Time.deltaTime * 4.5f);
    }

    public void Show()
    {
        Visible = true;
        SetButtonVisibility(Visible);
    }

    public void Hide()
    {
        Visible = false;
        SetButtonVisibility(Visible);
    }

    public void SetButtonVisibility(bool visible)
    {
        SelectLasPistol.gameObject.SetActive(Visible);
        SelectRifle.gameObject.SetActive(Visible);
        SelectSword.gameObject.SetActive(Visible);
        //SelectStunGrenade.gameObject.SetActive(Visible);
    }
}
