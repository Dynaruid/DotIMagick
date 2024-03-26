# DotIMagick

이 프로젝트는 ImageMagick의 닷넷 레퍼 [Magick.NET](https://github.com/dlemstra/Magick.NET)라이브러리를 닷넷AOT(Ahead-Of-Time compilation)로 빌드할수있게 만든 프로젝트 입니다.
또한 닷넷런타임을 통한 JIT실행도 가능 합니다.
현재 닷넷AOT빌드의 특성상 AOT빌드된 라이브러리가 P/Invoke하는 네이티브 라이브러리를 상대경로로 찾지못하는 특성때문에 따로 노출되는 초기화 함수를 만들어 라이브러리의 절대경로를 초기화 할수있게 하였습니다.


## 빌드시 확인 사항
해당 프로젝트로 빌드된 라이브러리를 사용하기위해서는 Magick.Native을 통해 Magick.NET의 네이티브 라이브러리가 필요합니다.
그것을 위해서는 이 프로젝트 디렉토리의 src/Magick.Native에서 Magick.NET의 [Install Magick.Native](https://github.com/dlemstra/Magick.NET/blob/main/Building.md#install-magicknative)지침을 따르십시오.

### DotIMagick 프로젝트에서 직접 빌드
DotIMagick솔루션에서 DotIMagick프로젝트를 빌드하는것 자체는 Magick.Native의 libraries가 꼭 필요하지는 않습니다. 하지만 DotIMagick빌드 결과물의 사용을 위해서는 Magick.Native의 libraries가 필요합니다.

## DotIMagick 패키지를 자신의 프로젝트에서 사용하기
DotIMagick와 함께 프로젝트를 빌드하면 빌드 출력경로에 magickNativeFiles디렉토리가 생성됩니다. 이 디렉토리에는 Magick.Native의 libraries에서 복사된 네이티브 라이브러리가 위치합니다.
DotIMagick의 닷넷라이브러리 또는 nuget을 통해 DotIMagick을 설치하였고 Magick.Native의 libraries를 자신의 프로젝트 루트에 위치했다면 
이제 DotIMagick를 사용하기 위해 초기화가 필요합니다.
```
DotIMagick.NativeConstants.InitBaseLibraryPath(basePath);
```
여기서 basePath는 magickNativeFiles의 상위폴더의 절대경로가 되어야합니다. 이 위치는 동적으로 지정할수있음으로 프로그램 시작시에 지정하면 됩니다. 한번 초기화후에 다시 초기화함수를 호출해서는 안됩니다.

```
MagickImage image = new MagickImage(MagickColors.White, width, height);
```
초기화 이후 부터는 자유롭게 사용가능합니다.

## Supported platforms

|.NET Version|Platform|Platform specific|AnyCPU|OpenMP|
|-|-|:-:|:-:|:-:|
|**.NET8**|windows (x64)|✅|✅|✅|
||windows (arm64)|✅|✅|✅|
||linux (x64)|✅|✅|✅|
||linux-arm64 (arm64)|✅|✅|✅|
||linux-musl (x64)|✅|✅|✅|
||macOS (x64)|✅|✅|❌|
||macOS (arm64)|✅|✅|❌|
||windows (x86)|✅|✅|❌|



## Extra libraries

Besides the quantum specific packages there are also some extra libraries in this project. One of these libraries is the [Magick.NET.Core](https://www.nuget.org/packages/Magick.NET.Core/) library that is a dependency of the quantum specific packages. This library can be used to add extra functionality and interact with the Magick.NET libraries. Two examples are [Magick.NET.SystemDrawing](https://www.nuget.org/packages/Magick.NET.SystemDrawing/) and [Magick.NET.SystemWindowsMedia](https://www.nuget.org/packages/Magick.NET.SystemWindowsMedia/) that can be used to interact with `System.Drawing` and `System.Windows.Media`.
