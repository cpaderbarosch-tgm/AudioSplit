#pragma once

#include <Windows.h>
#include <mmdeviceapi.h>
#include <string>
#include <iostream>

using namespace System;
using namespace System::IO;
using namespace std;

namespace AudioCapture
{
	public ref class AudioCapture
	{
	public:
		static long Test()
		{
			int i = 2;
			cout << "i = " << i << endl;
			cout << "&i = " << &i << endl;

			int* p_i = &i;
			cout << "p_i = " << p_i << endl;
			cout << "*p_i = " << *p_i << endl;
			cout << "&p_i = " << &p_i << endl;

			int** p_p_i = &p_i;
			cout << "p_p_i = " << p_p_i << endl;
			cout << "*p_p_i = " << *p_p_i << endl;
			cout << "**p_p_i = " << **p_p_i << endl;
			cout << "&p_p_i = " << &p_p_i << endl;
		}

		static IntPtr GetDefaultAudioDevice()
		{
			
		}
	};
}

