using System;
using System.Collections.Generic;


namespace Game
{
    public class LifeController
    {
        private int currentLife;
        private int maxLife;

        public bool IsAlive => currentLife > 0; // crea funcion esta vivo si la vida actual es mayor a 0, utilizando el comando amba =>

        public int CurrentLife
        {
            get => currentLife; // pide el dato de la vida actual

            set
            {
                currentLife = value;
                if (!IsAlive) //si la funcion "esta vivo" es falsa lo farmeamos
                {
                    Kill();
                }

                if (currentLife > maxLife) // si la vida actual es mayor al max lo iguala al maximo
                {
                    currentLife = maxLife;
                }
            }
        }

        public LifeController(int maxLife)
        {
            this.maxLife = maxLife;
            CurrentLife = maxLife;
        }

        public void GetDamage(int damage)
        {
            CurrentLife -= damage; // el -= es lo mismo que decir CurrentLife= CurrentLife - damage
        }

        public void GetHeal(int heal)
        {
            CurrentLife += heal;

        }

        private void Kill()
        {
            //pa mas adelante
        }

    }
}