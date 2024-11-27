namespace Hospital_Management_System.DTO.RecordDTOs
{
    public class RecordRequest
    {
        public string Diagnosis {  get; set; }
        public int Quantity { get; set; } = 0;
        public string Prescription { get; set; }
        public string Notes { get; set; }

    }
}
