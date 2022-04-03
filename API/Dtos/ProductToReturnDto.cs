namespace API.Dtos
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string PictureUrl { get; set; }

        public string ProdutType { get; set; }
        public string ProdutBrand { get; set; }
    }
}
