//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }
        public double GetProductionCost()
        {
            double total=0;
            foreach (Step step in this.steps)
            {
                total+=(step.Input.UnitCost +(step.Time * step.Equipment.HourlyCost));
            }
            return total;
        }
        /*
        double  GetProductCost() elegí agregarlo a la clase Recipe porque tiene la información necesaria
        para lograr obtener el costo total. Esto porque nos interesa ver los steps, con el fin de sacar
        la información de los mismos,y esta clase es la encargada de crear y eliminar los steps. Por esta
        razón cumple con el Expert. 
        */

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"Costo total ={GetProductionCost()}:");

        }
    }
}