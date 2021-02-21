using System;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace SimpleRecorder
{
    public partial class Form1 : Form
    {
        WasapiCapture mCapture = null;
        ChannelInfo mChannelInfo = null;
        WaveFormat mRecordingFormat = null;
        WaveFileWriter mWriter = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var waveIn = new WasapiCapture();
            var writer = new WaveFileWriter("a.wav", waveIn.WaveFormat);
            waveIn.DataAvailable += (s, a) =>
            {
                writer.Write(a.Buffer, 0, a.BytesRecorded);
                if (writer.Position > waveIn.WaveFormat.AverageBytesPerSecond * 3)
                {
                    waveIn.StopRecording();
                }
            };
            waveIn.RecordingStopped += (s, a) =>
            {
                writer?.Dispose();
                writer = null;
            };
            waveIn.StartRecording();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reloadWaveInputDevices();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            stopRecording(true);
        }
        // 入力デバイスが変更されたときに呼ばれます
        private void inputDeviceListSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            stopRecording(true);
            var dev = (MMDevice)inputDeviceListSelector.SelectedItem;
            if (dev != null) {
                mCapture = new WasapiCapture(dev);
                var format = mCapture.WaveFormat;

                // コールバック準備
                mCapture.DataAvailable += (s, a) =>
                {
                    var blocks = mChannelInfo.ExtractSampleOfRelateChannel(a.Buffer, a.BytesRecorded);
                    mWriter.Write(blocks, 0, blocks.Length);
                };
            }
            // 入力チャネルの変更処理
            reloadWaveInputChannels();
        }
        // 入力チャネルが変更されたときに呼ばれます
        private void inputChannelSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            mChannelInfo = (ChannelInfo)inputChannelSelector.SelectedItem;
            stopRecording();
        }
        // 入力デバイスを再ロードするボタンを押したときに呼ばれます
        private void inputDeviceReloadButton_Click(object sender, EventArgs e)
        {
            reloadWaveInputDevices();
        }
        // 録音開始ボタンを押したときに呼ばれます
        private void startRecordingButton_Click(object sender, EventArgs e)
        {
            startRecording();
        }
        private void stopRecordingButton_Click(object sender, EventArgs e)
        {
            stopRecording();
        }
        // 録音終了ボタンを押したときに呼ばれます

        /// 入力デバイス情報を再読み込みします
        private void reloadWaveInputDevices()
        {
            inputDeviceListSelector.Items.Clear();

            var devices = new MMDeviceEnumerator().EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
            foreach (var dev in devices)
            {
                inputDeviceListSelector.Items.Add(dev);
            }
            if(inputDeviceListSelector.Items.Count > 0)
            {
                inputDeviceListSelector.SelectedIndex = 0;
            }
        }

        // 入力チャネル情報を再構築します。
        private void reloadWaveInputChannels()
        {
            inputChannelSelector.Items.Clear();

            if (mCapture == null) return;
            int channels = mCapture.WaveFormat.Channels;
            
            // ステレオ
            for (int i = 0; i < channels; i+=2)
            {
                var ch = new ChannelInfo(mCapture.WaveFormat, i, 2, (i + 1) + "-" + (i + 2) + "ch (ステレオ)");
                inputChannelSelector.Items.Add(ch);
            }
            // モノラル
            for (int i = 0; i < channels; ++i)
            {
                var ch = new ChannelInfo(mCapture.WaveFormat, i, 1, (i + 1) + "ch (モノラル)");
                inputChannelSelector.Items.Add(ch);
            }
            if (inputChannelSelector.Items.Count > 0)
            {
                inputChannelSelector.SelectedIndex = 0;
            }
        }

        /// 録音を開始します
        private void startRecording()
        {
            // 録音準備
            if(mCapture == null)
            {
                MessageBox.Show(this, "録音デバイスが設定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (mChannelInfo == null)
            {
                MessageBox.Show(this, "録音チャネルが設定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var f = mCapture.WaveFormat;
            mRecordingFormat = WaveFormat.CreateCustomFormat(
                f.Encoding,
                f.SampleRate,
                mChannelInfo.Channels, //f.Channels,
                (int)((float)f.AverageBytesPerSecond / f.Channels * mChannelInfo.Channels),
                (int)((float)f.BlockAlign / f.Channels * mChannelInfo.Channels),
                f.BitsPerSample
                );
            mWriter = new WaveFileWriter("a.wav", mRecordingFormat);

            // UI更新
            startRecordingButton.Enabled = false;
            stopRecordingButton.Enabled = true;
            inputDeviceListSelector.Enabled = false;
            inputChannelSelector.Enabled = false;

            // 録音開始
            mCapture.StartRecording();
        }

        /// 録音を停止します
        private void stopRecording(bool dispose = false)
        {
            if (mCapture == null) return;

            // 録音デバイスの停止
            if(mCapture.CaptureState != CaptureState.Stopped)
            {
                mCapture.StopRecording();

                // 録音内容の書き出し
                mWriter.Dispose();
                mWriter = null;
            }

            // その他録音後処理
            mRecordingFormat = null;

            // UI更新
            startRecordingButton.Enabled = true;
            stopRecordingButton.Enabled = false;
            inputDeviceListSelector.Enabled = true;
            inputChannelSelector.Enabled = true;

            // デバイスの破棄等
            if (dispose)
            {
                mCapture.Dispose();
                mCapture = null;
            }
        }

    }
}
