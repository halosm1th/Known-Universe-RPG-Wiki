namespace WikiServices.SimpleServiceDriverCode
{
    public class HighVersianDefinition
    {
        public string Letters { get; }
        public string Meaning { get; }


        public HighVersianDefinition(string letters, string meaning)
        {
            Letters = letters.ToUpper();
            Meaning = meaning;
        }

        public override string ToString()
        {
            return $"{Letters.ToUpper()}: {Letters}";
        }
    }
}