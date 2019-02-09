using System;
using System.Collections;
using NAudio.Wave;

namespace AudioSplit
{
	/// <summary>
	/// A wrapper for the WasapiLoopbackCapture that will implement basic recording to a file that is overwrite only.
	/// </summary>
	public class LoopbackRecorder
	{
		private IWaveIn _waveIn;
		private WaveFileWriter _writer;
		private bool _isRecording = false;
		public bool IsRecording { get => _isRecording; }
		private string _fileName;
		public string FileName { get => _fileName; }

		public LoopbackRecorder() {}

		public void StartRecording(string fileName)
		{
			if (_isRecording == true)
			{
				return;
			}
			_fileName = fileName;
			_waveIn = new WasapiLoopbackCapture();
			_writer = new WaveFileWriter(fileName, _waveIn.WaveFormat);
			_waveIn.DataAvailable += OnDataAvailable;
			_waveIn.RecordingStopped += OnRecordingStopped;
			_waveIn.StartRecording();
			_isRecording = true;
		}

		public void StopRecording()
		{
			if (_waveIn == null)
			{
				return;
			}
			_waveIn.StopRecording();
		}

		void OnRecordingStopped(object sender, StoppedEventArgs e)
		{
			// Writer Close() needs to come first otherwise NAudio will lock up.
			if (_writer != null)
			{
				_writer.Close();
				_writer = null;
			}
			if (_waveIn != null)
			{
				_waveIn.Dispose();
				_waveIn = null;
			}
			_isRecording = false;
			if (e.Exception != null)
			{
				throw e.Exception;
			}
		} // end void OnRecordingStopped

		void OnDataAvailable(object sender, WaveInEventArgs e)
		{
			_writer.Write(e.Buffer, 0, e.BytesRecorded);
			//int secondsRecorded = (int)(_writer.Length / _writer.WaveFormat.AverageBytesPerSecond);
		}
	}
}