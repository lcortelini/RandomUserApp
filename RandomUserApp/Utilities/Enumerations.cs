namespace RandomUserApp.Utilities
{
    public enum Gender
    {
        Male = 0,
        Female = 1,
        Other = 2,
    }

    public static class GenderHelper
    {
        public static string GetDescription(this Gender gender)
        {
            switch (gender)
            {
                case Gender.Male: return "Masculino";
                case Gender.Female: return "Feminino";
                case Gender.Other: return "Outro";
                default: return string.Empty;
            }
        }

        public static Gender GetGender(this string gender)
        {
            switch (gender)
            {
                case "male": return Gender.Male;
                case "female": return Gender.Female;
                default: return Gender.Other;
            }
        }
    }
}
