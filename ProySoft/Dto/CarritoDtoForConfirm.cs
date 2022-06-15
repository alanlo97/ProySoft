namespace ProySoft.Dto
{
    public class CarritoDtoForConfirm
    {
        public int Id { get; set; }

        public ICollection<BurgerDto> Burgers { get; set; }

        public ICollection<CombosDto> Combos { get; set; }
    }
}
