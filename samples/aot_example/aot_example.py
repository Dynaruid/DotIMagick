import os
import platform
import time
from ctypes import *
from tkinter import Tk, Label
from PIL import Image,ImageTk
import numpy as np

def show_image(image_arr):
    image = Image.fromarray(image_arr)
    target_width = 500
    width_percent = (target_width / float(image.size[0]))
    target_height = int((float(image.size[1]) * float(width_percent)))
    # 이미지 크기 조절
    resized_image = image.resize((target_width, target_height))
    window = Tk()
    window.title("viewer")
    window.geometry("600x500+100+150")

    photo = ImageTk.PhotoImage(resized_image)
    # 이미지를 표시할 레이블 생성 및 배치
    label = Label(window, image=photo)
    label.pack(expand=True)
    # GUI 실행
    window.mainloop()

def running():
    #path = "images/Spirited-Away-landscape-Studio-Ghibli-anime-clouds-water.jpg"
    path = "images/kor_sample.jpg"
    loaded_img = Image.open(path).convert("RGBA")
    input_img = np.array(loaded_img)
    
    input_img_row = input_img.shape[0]
    input_img_col = input_img.shape[1]

    if len(input_img.shape) == 3:
        if input_img.shape[2] == 3:
            plus_array = np.zeros((input_img_row, input_img_col), dtype=np.uint8) + 255
            input_img = np.dstack((input_img, plus_array))
        else:
            print(input_img.shape)

    show_image(input_img)
  
    
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
    show_image(input_img)
    

if __name__ == '__main__':
    running()