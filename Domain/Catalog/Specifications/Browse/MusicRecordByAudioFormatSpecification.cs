namespace SimpleMusicStore.Domain.Catalog.Specifications.Browse
{
    using Common;
    using SimpleMusicStore.Domain.Catalog.Models;
    using System;
    using System.Linq.Expressions;

    public class MusicRecordByAudioFormatSpecification : Specification<MusicRecord>
    {
        private readonly AudioFormat? _audioFormat;

        public MusicRecordByAudioFormatSpecification(AudioFormat? audioFormat)
        {
            _audioFormat = audioFormat;
        }

        protected override bool Include => _audioFormat != null;

        public override Expression<Func<MusicRecord, bool>> Filter()
        {
            return musicRecord => musicRecord.AudioFormat == _audioFormat;
        }
    }
}
