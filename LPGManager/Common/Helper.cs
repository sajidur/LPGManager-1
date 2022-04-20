namespace LPGManager.Common
{
    public class Helper
    {

        static DateTime Epoch2UTCNow(long epoch)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epoch);
        }
        static long ToEpoch(DateTime dateTime)
        {
            var Epoch = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            return Epoch;
        }
    }
}
