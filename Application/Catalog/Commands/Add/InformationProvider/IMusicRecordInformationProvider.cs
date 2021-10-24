namespace SimpleMusicStore.Application.Catalog.Commands.Add.InformationProvider
{
    using System.Threading.Tasks;

    public interface IMusicRecordInformationProvider
    {

        Task<MusicRecordInformation> ExtractInformationFromUrl(string url);
    }
}

