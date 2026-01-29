namespace Touch_Bistro_App.Models
{
    public class Table
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Status { get; set; } = "Free"; // Free, Occupied, Reserved, Bill Printed
        public int CurrentOrderId { get; set; }
    }
}
