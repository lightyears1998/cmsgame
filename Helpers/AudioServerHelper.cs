namespace CMSGame.Helpers
{
    internal class AudioServerHelper
    {
        public static void SetBusVolumeLinear(StringName busName, double volumeLinear)
        {
            var db = Mathf.LinearToDb(volumeLinear);
            SetBusVolumeDb(busName, db);
        }

        public static void SetBusVolumeDb(StringName busName, double volumeDb)
        {
            var busIdx = AudioServer.GetBusIndex(busName);
            if (busIdx < 0)
                throw new IndexOutOfRangeException("Bus not found.");
            AudioServer.SetBusVolumeDb(busIdx, (float)volumeDb);
        }
    }
}
