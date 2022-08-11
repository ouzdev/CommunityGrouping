using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using AutoFilterer.Types;
using CommunityGrouping.Entities;
using CommunityGrouping.Entities.Dto;

namespace CommunityGrouping.Business.Filters
{
    /// <summary>
    /// Search in **FirstName**, **LastName**.
    /// </summary>
    public class PersonFilter
    {
        public string Search { get; set; }
        [Required] public FuelTypeEnum FuelType { get; set; }

    }

    public enum FuelTypeEnum
    {
        Solid,
        Liquid
    }
}
