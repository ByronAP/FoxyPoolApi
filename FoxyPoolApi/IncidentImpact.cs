using System;
using System.Drawing;

namespace FoxyPoolApi
{
    public enum IncidentImpact
    {
        None,
        Minor,
        Major,
        Critical,
        Maintenance
    }

    public static class IncidentImpactExtensions
    {
        public static Color GetColor(this IncidentImpact value)
        {
            return value switch
            {
                IncidentImpact.None => Color.Black,
                IncidentImpact.Minor => Color.Yellow,
                IncidentImpact.Major => Color.Orange,
                IncidentImpact.Critical => Color.Red,
                IncidentImpact.Maintenance => Color.Blue,
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            };
        }
    }
}
