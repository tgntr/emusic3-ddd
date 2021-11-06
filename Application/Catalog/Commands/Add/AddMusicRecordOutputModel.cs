namespace SimpleMusicStore.Application.Catalog.Commands.Add
{
    public class AddMusicRecordOutputModel
    {
        public AddMusicRecordOutputModel(int musicRecordId)
        {
            MusicRecordId = musicRecordId;
        }

        public int MusicRecordId { get; }
    }
}
