namespace LPGManager.Common
{
    public enum ProductNameEnum
    {
        Bottle=1,
        Refill= 2,
    }
    public enum TenantType
    {
        Retailer=1,
        Consumer=2,
        Supplier=3,
        Company=4
        //1=for retailer 2=consumer 3=supplier/dealer  4=company
    }
    public enum DeliveryEnum
    {
        Pending,
        Delivered
    }
    public enum TransactionTypeEnum
    {
        Sell=1,
        Payment=2,
        Receive=4,
        Purchase=3
    }
}
