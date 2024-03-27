import os
from ctypes import *
import numpy as np
import imageio


def running():
    path = "images/kor_sample.jpg"
    img_arr = imageio.imread(path)
    input_img = input_img.astype(np.float32)
    input_img_row = input_img.shape[0]
    input_img_col = input_img.shape[1]

    if len(input_img.shape) == 3:
        if input_img.shape[2] == 3:
            plus_array = np.zeros((input_img_row, input_img_col), dtype=np.float32) + 255
            input_img = np.dstack((input_img, plus_array))
           

    DotIMagick = cdll.LoadLibrary("./binary/native/DotIMagickDynamic.dll")
    DotIMagick.InitEngine.argtypes = [c_char_p]
    DotIMagick.RunDemo.argtypes = [c_int64, c_int, c_int, c_int]
    DotIMagick.RunDemo.restype = POINTER(c_char)
    
    z: int = input_img.img_arr.shape[0]
    y: int = input_img.img_arr.shape[1]
    x: int = input_img.img_arr.shape[2]
    base_path = os.path.abspath("binary").encode('utf-8')
    print(base_path)
    DotIMagick.InitEngine(base_path)
    result_pointer: POINTER(c_char) = DotIMagick.RunDemo(input_img.__array_interface__["data"][0], z, y, x)
    result_str = cast(result_pointer, c_char_p).value.decode('utf-8')

    print(result_str)
    
    DotIMagick.TerminateEngine()


# 스크립트를 실행하려면 여백의 녹색 버튼을 누릅니다.
if __name__ == '__main__':
    running()