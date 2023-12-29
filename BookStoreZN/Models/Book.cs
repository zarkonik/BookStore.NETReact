namespace BookStoreZN.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Genre {  get; set; }
        public int Price { get; set; }
        public string Picture { get; set; }
        //public string ImageName { get; set; }
        //public byte[] ImageBytes { get; set; }

    }
}
