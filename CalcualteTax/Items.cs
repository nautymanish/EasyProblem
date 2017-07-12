namespace CalcualteTax
{
    public class Items
    {
        public double Cost { get; set; }
        public string Type { get; set; }
        public Items(double cost, string type)
        {
            this.Cost = cost;
            this.Type = type;
        }
    }
}