import os
from ctypes import *
import numpy as np
import imageio


class CS_Worker:
    def __init__(self, img_array):
        self.CS_CL = cdll.LoadLibrary("./binary/native/TesseractDynamic2.dll")
        self.img_arr = img_array
        self.InitEngine = self.CS_CL.InitEngine
        self.InitEngine.argtypes = [c_char_p,c_char_p, c_char_p]
        self.RecognizeImage = self.CS_CL.RecognizeImage
        self.RecognizeImage.argtypes = [c_int64, c_int, c_int, c_int]
        self.RecognizeImage.restype = POINTER(c_char)
        self.TerminateEngine = self.CS_CL.TerminateEngine

    def run(self):
        z: int = self.img_arr.shape[0]
        y: int = self.img_arr.shape[1]
        x: int = self.img_arr.shape[2]
        base_path = os.path.abspath("binary").encode('utf-8')
        abs_path = os.path.abspath("binary/tessdata").encode('utf-8')
        lang_op = "kor+eng".encode('utf-8')
        print(base_path)
        self.InitEngine(base_path,abs_path, lang_op)
        result_pointer: POINTER(c_char) = self.RecognizeImage(self.img_arr.__array_interface__["data"][0], z, y, x)
        result_str = cast(result_pointer, c_char_p).value.decode('utf-8')

        print(result_str)
        self.TerminateEngine()


def running():
    path = "images/kor_sample.jpg"
    img_arr = imageio.imread(path)
    input_img = img_arr.astype(np.float32)
    input_img_row = input_img.shape[0]
    input_img_col = input_img.shape[1]

    if len(input_img.shape) == 3:
        if input_img.shape[2] == 3:
            plus_array = np.zeros((input_img_row, input_img_col), dtype=np.float32) + 255
            input_img = np.dstack((input_img, plus_array))

    worker = CS_Worker(input_img)
    worker.run()


# 스크립트를 실행하려면 여백의 녹색 버튼을 누릅니다.
if __name__ == '__main__':
    running()