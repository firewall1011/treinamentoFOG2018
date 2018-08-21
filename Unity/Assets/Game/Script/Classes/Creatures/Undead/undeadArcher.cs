﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadArcher : Creature {
   public static GameObject prefab;

   const string _name = "Archer";
   const string _teamName = "Undeads";
   static string[] _skillsNames = new string[1] {"Tóxico"};
   static string[] _skillsDescriptions = new string[1] { @"Tóxico: (CD = 4) (AP = 0) (Alcance = nulo)
Nesse turno ao invés do ataque conceder apenas 1 contador do veneno (aumentar em 5 qualquer que seja o valor de veneno atual) ele envenenará ao máximo o alvo. Qualquer unidade a 1 de alcance do alvo também recebera veneno, no entanto sendo apenas um 1 contador.
"};

    const int _maxHealth = 300;
   const int _maxActionPoints = 3;
   const int _baseDodge = 15;
   const int _defenseHeal = 30;
   const int _defenseResistance = 20;
   const int _attackDamage = 30;
   const int _attackRange = 2;

   const int _venomDuration = 3;
   private Creature venomTarget = null;
   private int venomDamage = 0;
   private int venomTurnsRemaining = 0;

   const int _maxToxicCooldown = 4;
   private int toxicCooldown = 0;
   private bool isUsingToxic = false;

   public UndeadArcher(int x, int y, int team) : base(prefab, x, y, _maxActionPoints, team, _maxHealth, _attackDamage, _attackRange, _defenseHeal, _defenseResistance, _baseDodge, _name, _teamName, _skillsNames, _skillsDescriptions) {

   }

   public override void newTeamTurn(){
      base.newTeamTurn();
   }

   public override void newTurn(int turn){
      base.newTurn(turn);
      if(venomTarget != null){
         venomTarget.changeHealth(-venomDamage);
         Debug.Log("applying " + venomDamage + " as venom damage");
         venomTurnsRemaining--;
         if(venomTurnsRemaining <= 0){
            venomTarget = null;
            venomDamage = 0;
         }
      }
      isUsingToxic = false;
   }

   public override void attack(Creature victim){
      base.attack(victim);
      if(victim == venomTarget){
         venomDamage += 5;
         if(venomDamage > 20 || isUsingToxic)
            venomDamage = 20;
      }
      else{
         venomDamage = 5;
      }
      venomTurnsRemaining = _venomDuration;
      venomTarget = victim;
   }

   public void toxic(){
      if(toxicCooldown > 0){
         Debug.Log("wait " + toxicCooldown + " turns");
      }
      toxicCooldown = _maxToxicCooldown;
      isUsingToxic = true;
      Debug.Log("using toxic");
   }
}
