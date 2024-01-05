using BlazorServerApp.Models;

namespace BlazorServerApp.Services
{
    public class MaterialService
    {
        public static List<Color> CreateColors()
        {
            return new List<Color>
            {
                new Color { ColorName = "Blanco", ColorHex = "#FFFFFF" },
                new Color { ColorName = "Negro", ColorHex = "#000000" },
                new Color { ColorName = "Gris", ColorHex = "#808080" },
                new Color { ColorName = "Rojo", ColorHex = "#FF0000" },
                new Color { ColorName = "Azul", ColorHex = "#0000FF" },
                new Color { ColorName = "Verde", ColorHex = "#008000" },
                new Color { ColorName = "Amarillo", ColorHex = "#FFFF00" },
                new Color { ColorName = "Naranja", ColorHex = "#FFA500" },
                new Color { ColorName = "Rosa", ColorHex = "#FFC0CB" },
                new Color { ColorName = "Morado", ColorHex = "#800080" },
                new Color { ColorName = "Marrón", ColorHex = "#A52A2A" },
                new Color { ColorName = "Beige", ColorHex = "#F5F5DC" },
                new Color { ColorName = "Turquesa", ColorHex = "#40E0D0" },
                new Color { ColorName = "Violeta", ColorHex = "#EE82EE" },
                new Color { ColorName = "Oro", ColorHex = "#FFD700" },
                new Color { ColorName = "Plata", ColorHex = "#C0C0C0" },
                new Color { ColorName = "Bronce", ColorHex = "#CD7F32" },
                new Color { ColorName = "Coral", ColorHex = "#FF7F50" },
                new Color { ColorName = "Marfil", ColorHex = "#FFFFF0" },
                new Color { ColorName = "Lavanda", ColorHex = "#E6E6FA" },
                new Color { ColorName = "Cian", ColorHex = "#00FFFF" },
                new Color { ColorName = "Magenta", ColorHex = "#FF00FF" },
                new Color { ColorName = "Limón", ColorHex = "#FFFACD" },
                new Color { ColorName = "Chocolate", ColorHex = "#D2691E" },
                new Color { ColorName = "Carmesí", ColorHex = "#DC143C" },
                new Color { ColorName = "Índigo", ColorHex = "#4B0082" },
                new Color { ColorName = "Oliva", ColorHex = "#808000" },
                new Color { ColorName = "Púrpura", ColorHex = "#800080" },
                new Color { ColorName = "Aguamarina", ColorHex = "#7FFFD4" },
                new Color { ColorName = "Salmón", ColorHex = "#FA8072" },
                new Color { ColorName = "Carne", ColorHex = "#FFE4C4" },
                new Color { ColorName = "Caqui", ColorHex = "#F0E68C" },
                new Color { ColorName = "Fucsia", ColorHex = "#FF00FF" },
                new Color { ColorName = "Cereza", ColorHex = "#DE3163" },
                new Color { ColorName = "Melocotón", ColorHex = "#FFE5B4" },
                new Color { ColorName = "Cobalto", ColorHex = "#0047AB" },
                new Color { ColorName = "Esmeralda", ColorHex = "#50C878" },
                new Color { ColorName = "Jade", ColorHex = "#00A36C" },
                new Color { ColorName = "Lavanda", ColorHex = "#E6E6FA" },
                new Color { ColorName = "Mostaza", ColorHex = "#FFDB58" },
                new Color { ColorName = "Navajo", ColorHex = "#FFDEAD" },
                new Color { ColorName = "Orquídea", ColorHex = "#DA70D6" },
                new Color { ColorName = "Perla", ColorHex = "#FDEEF4" },
                new Color { ColorName = "Rubí", ColorHex = "#9B111E" },
                new Color { ColorName = "Zafiro", ColorHex = "#0F52BA" },
                new Color { ColorName = "Topacio", ColorHex = "#FFC87C" },
                new Color { ColorName = "Uva", ColorHex = "#6F2DA8" },
                new Color { ColorName = "Trigo", ColorHex = "#F5DEB3" }
            };
        }

        public static List<string> CreateWeightUnits()
        {
            return new List<string>
            {
                "Kilogramos",
                "Gramos",
                "Toneladas",
                "Libras",
                "Onzas",
                "Miligramos",
                "Centigramos",
                "Decigramos",
                "Quintales",
                "Stone"
            };
        }

        public static List<string> CreateMeasurementUnits()
        {
            return new List<string>
            {
                "Metro",
                "Centímetro",
                "Milímetro",
                "Kilómetro",
                "Pie",
                "Pulgada",
                "Milla",
                "Yarda",
                "Nanómetro",
                "Micrómetro",
                "Decímetro",
                "Decámetro",
                "Hectómetro",
                "Milla náutica"
            };
        }
    }
}
