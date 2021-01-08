﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TravellerWiki
{
    public class SubsectorModel : PageModel
    {

        [BindProperty(SupportsGet = true)] public int SubsectorX { get; set; }
        [BindProperty(SupportsGet = true)] public int SubsectorY { get; set; }

        [HttpGet("{subX}/{subY}")]
        public void OnGet(int subX, int subY)
        {
            SubsectorX = subX;
            SubsectorY = subY; 
        }
    }
}