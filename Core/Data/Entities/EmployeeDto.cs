namespace Core.Data.Entities
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public decimal Neto { get; set; }
        public decimal Bruto { get; set; }
        public AssociatedCostDto AssociatedCost { get; set; }
    }
}
