using System;
using System.Diagnostics;
using NAudio.Wave;

namespace SimpleRecorder
{
    public class ChannelInfo
    {
        public ChannelInfo(WaveFormat originalFormat, int offset, int channels, string description = "")
        {
            OriginalFormat = originalFormat;
            Offset = offset;
            Channels = channels;
            Description = description;
        }

        // オリジナルのフォーマット形式
        public WaveFormat OriginalFormat { get; }

        // チャネル開始オフセット
        public int Offset { get; }

        // チャネル数
        public int Channels { get; }

        // チャネル詳細情報
        public String Description { get; }

        public override string ToString() 
        {
            return Description;
        }

        public byte[] ExtractSampleOfRelateChannel(byte[] buffer, int bytesRecorded)
        {
            // TODO 1サンプルが1バイト境界になかったり、ブロック間にパディングがあるフォーマットでは正しく扱えない
            int originalChannels = OriginalFormat.Channels;
            int originalBlockAlign = OriginalFormat.BlockAlign;

            int bytesPerSample = originalBlockAlign / originalChannels;
            int channelOffset = Offset;

            int extractedChannels = Channels;
            int extractedBlockAllgin = bytesPerSample * extractedChannels;
            
            int blocks = bytesRecorded / originalBlockAlign;

            int bytesExtracted = blocks * bytesPerSample * extractedChannels;


            byte[] ret = new byte[bytesExtracted];

            for (int i = 0; i < blocks; ++i)
            {
                Array.Copy(buffer, i * originalBlockAlign + channelOffset * bytesPerSample, ret, i * extractedBlockAllgin, extractedBlockAllgin);
            }
            return ret;
        }
    }
}
