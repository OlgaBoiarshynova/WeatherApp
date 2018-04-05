using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Models
{
    public class Location
    {
        public int Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
        public string PrimaryPostalCode { get; set; }
        public Country Country { get; set; }
        public AdministrativeArea AdministrativeArea { get; set; }
        public bool IsAlias { get; set; }
        public string Description { get { return String.Format("{0} ({1}), {2}", EnglishName, AdministrativeArea.EnglishName ?? EnglishName, Country.EnglishName); } }
    }
}
