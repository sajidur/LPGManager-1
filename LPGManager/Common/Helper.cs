namespace LPGManager.Common
{
    public class Helper
    {

       public static DateTime Epoch2UTCNow(long epoch)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epoch);
        }
       public static long ToEpoch(DateTime dateTime)
        {
            var Epoch = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            return Epoch;
        }
    }
    public enum ProductTypeEnum
    {
        Bottle=1,
        Riffile=2,
    }
}
