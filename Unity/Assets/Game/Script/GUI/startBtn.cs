﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startBtn : MonoBehaviour {

	public void AbrirJogo(){
        SceneManager.LoadScene("Game");
    }
    public void BacktoMenu()
    {
        SceneManager.LoadScene("MenuInicial");
    }

    public void SelectMenu()
    {
        SceneManager.LoadScene("MenuEscolha");
    }
}
