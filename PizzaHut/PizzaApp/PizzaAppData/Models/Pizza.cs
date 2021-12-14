﻿using System;
using System.Collections.Generic;

namespace PizzaHut.PizzaApp.Data.Models
{
    public class Pizza
    {
        public Guid PizzaId { get; set; }
        public string PizzaName { get; set; }
        public IEnumerable<PizzaIngredient> PizzaIngredients { get; set; }
    }
}
