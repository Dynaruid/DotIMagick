import os
import platform
import time
from ctypes import *

from PIL import Image
import numpy as np
import matplotlib.pyplot as plt


def running():
    #path = "images/Spirited-Away-landscape-Studio-Ghibli-anime-clouds-water.jpg"
    path = "images/kor_sample.jpg"
    loaded_img = Image.open(path).convert("RGB")
    input_img = np.array(loaded_img)
    
    input_img_row = input_img.shape[0]
    input_img_col = input_img.shape[1]

    if len(input_img.shape) == 3:
        if input_img.shape[2] == 3:
            plus_array = np.zeros((input_img_row, input_img_col), dtype=np.uint8) + 255
            input_img = np.dstack((input_img, plus_array))
        else:
            print(input_img.shape);
            
  
    plt.imshow(input_img)
    plt.show()
    
    os_name = platform.system()
    library_path = ""
    if os_name == 'Windows':
        library_path = "./binary/native/DotIMagickDynamic.dll"
    elif os_name == 'Linux':
       library_path = "./binary/native/DotIMagickDynamic.so"
    elif os_name == 'Darwin':
        library_path = "./binary/native/DotIMagickDynamic.dylib"
    else:
        print("unknown "+os_name)
        return
    DotIMagick = cdll.LoadLibrary(library_path)
    DotIMagick.InitEngine.argtypes = [c_char_p]
    DotIMagick.RunDemoBulrRightHalfImage.argtypes = [c_int64, c_int, c_int, c_int]
    
    z: int = input_img.shape[0]
    y: int = input_img.shape[1]
    x: int = input_img.shape[2]
    base_path = os.path.abspath("binary").encode('utf-8')
    start_time = time.time()
    DotIMagick.InitEngine(base_path)
    DotIMagick.RunDemoBulrRightHalfImage(input_img.__array_interface__["data"][0], z, y, x)
    end_time = time.time()
    elapsed_time = end_time - start_time
    print(f"Function execution time: {elapsed_time} seconds")
    plt.imshow(input_img)
    plt.show()
    

if __name__ == '__main__':
    running()