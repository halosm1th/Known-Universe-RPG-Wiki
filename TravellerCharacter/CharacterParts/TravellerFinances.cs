using System.Text;

namespace TravellerCharacter.CharacterParts
{
    public class TravellerFinances
    {
        public TravellerFinances(int credits, int pension, int debt, int shipMortgage, int otherIncome)
        {
            Credits = credits;
            Pension = pension;
            Debt = debt;
            ShipMortgage = shipMortgage;
            OtherIncome = otherIncome;
        }

        public int Credits { get; set; }
        public int Pension { get; set; }
        public int Debt { get; set; }
        public int ShipMortgage { get; set; }
        public int OtherIncome { get; set; }

        public bool HasEnoughCredits(int amount)
        {
            return Credits >= amount;
        }

        public void PayPension()
        {
            Credits += Pension;
        }

        public void SpendCredits(int amount)
        {
            if (Credits >= amount)
            {
                Credits -= amount;
            }
            else
            {
                amount -= Credits;
                Debt += amount;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Credits: ");
            sb.Append(Credits);
            sb.Append(". Debt: ");
            sb.Append(Debt);
            sb.Append(".");
            return sb.ToString();
        }
    }
}