namespace SuperMarketCheckout.Service
{
    public interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice();
    }
}
