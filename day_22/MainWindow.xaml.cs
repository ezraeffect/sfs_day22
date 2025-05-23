using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


/*
 * Image
 * WPF에서 사진, 아이콘, 일러스트 등 Bitmap 기반 이미지 리소스를 렌더링 할 때 사용하는 UI 컨트롤
 * System.Windows.Controls.Image Class임
 * 
 * 이미지 파일 관리 => 폴더에 모아서 관리
 * - Assets : 보편적이고 시각적인 리소스 포함하는 느낌
 * - Images : 이미지 전용 폴더로 직관적인 느낌
 * 
 * [Attribute]
 * - Source: 표시할 이미지 경로 or URI
 * - Stretch : 이미지 크기 조정 방식 (None, Fill, Uniform[Default], UniformToFill)
 */

/*
 * 이미지 접근 방식
 * 1. Resource 사용
 * - 이미지 파일을 실행 프로그램(.exe)에 포함시켜 배포하는 방식
 * - 프로그램 안에 이미지가 포함 되어 있는 형태라서 외부 파일을 따로 챙길 필요가 없음
 * - 수정은 불가능하지만, 정적인 리소스(아이콘, 배경, 버튼 등)에 매우 적합함
 * 
 * [주의]
 * - WPF에서 Resource 파일 접근 시 반드시 Pack URI 형식 사용 권장.
 * - XAML에서는 상대경로처럼 보여도 내부적으로 Pack URI로 해석됨.
 * 
 * [특징]
 * - 배포 간편
 * - 경로 문제 없음
 * - 유지보수 용이
 * 
 * [사용법]
 * - 솔루션 탐색기에서 프로젝트 우클릭
 * - 추가 -> 기존항목 클릭
 * - 파일 속성 -> 빌드 작업에서 Resource로 변경
 * - 출력 디렉토리로 복사 -> '사용안함'으로 변경
 * XAML 또는 C# 코드에서 Source="파일명" 으로 간단하겍 이미지 사용 가능.
 * VS 프로젝트의 루트 기준 상대경로로 동작함
 * 
 * [XAML]
 * - 이미지가 바뀌지 않을떄, 즉. 고정된 화면에 정적인 이미지를 보여줄 때 사용
 * 
 * [C#]
 * - 동적으로 이미지 제어 할 때 사용
 * 
 * 2. Content 방식
 * - 이미지 파일을 실행 파일이 있는 폴더에 복사해 놓고, 거기서 직접 불러오는 방식
 * 
 * [특징]
 * - 실행 파일 외부에 따로 존재하는 이미지
 * - 프로그램이 실행될 때 이미지 파일을 같이 복사해서 사용하는 구조
 * 
 * [How]
 * - 이미지 추가
 * - 속성의 '빌드 작업'에서 'Content'로 변경
 * - '출력 디렉토리에 복사'에서 'Copy if newer'로 변경 (권장)
 * - Do not copy : 복사 안함
 * - Copy if newer : 새로 고칠때만 복사 (원본이 바귀었을떄)
 * - Always copy : 항상 복사
 * 
 * 3. Pack URI 방식
 * - WPF에서 Resource 방식으로 등록된 이미지 파일을 "정확하게 식별"하고 로드 할 수 있게 해주는 전용 URI 방식
 * - WPF의 스타일, 리소스, 외부 DLL 등 다양한 곳에서 이미지와 리소스를 참조할 떄 필수로 사용됩니다.
 * 
 * [특징]
 * - Resource 방식 이미지에 대한 절대 경로 지정 가능
 * - 외부 DLL에 포함된 리소스도 접근 가능
 * - UriKind.Absolute 와 함께 사용됨 (필수)
 * 
 * [When]
 * - 외부 라이브러리(DLL)에 포함된 리소스 접근할 때
 * - C# 코드에서 Resource 이미지에 대해 명확한 식별이 필요할 때
 * - 프로젝트 구조가 복잡하거나 리소스 공유가 많을 때 안정적
 * 
 * [Pack URI 문법 형식]
 * pack://application:,,,/[경로]
 * 
 * [How]
 * - 이미지 추가
 * - 속성의 '빌드 작업'에서 'Resource'로 변경
 * - '출력 디렉토리에 복사'에서 '복사 안함'
 * 
 * 
 * 
 * 
 * [보충설명]
 * - 앱 개발자가 미리 넣어두는 이미지 -> 빌드 시 포함되어 배포 : Resource, Content
 * - 앱 실행 중 사용자 입력으로 생긴 이미지 -> 외부 경로에서 접근 : 절대경로(Uri.Absolute)
 * 
 * [Resource VS Content]
 * Resource
 * - 빌드 결과 : 어셈블리 안에 내장 됨 (Assamblyinfo.cs)
 * - 경로 접근 : pack URI 방식
 * - 파일 존재 위치 : 실행중에는 실제 파일 없음 (메모리 상에 존재)
 * - 수정/삭제 : 불가능(읽기 전용)
 * - 대표 용도 : 아이콘, UI 배경 이미지, 버튼 배경 이미지 등 Static Resource
 * 
 * Content
 * - 빌드 결과 : 실행파일 옆에 복사 됨
 * - 경로 접근 : 상대/절대 경로
 * - 파일 존재 위치 : 실행 폴더에 파일이 있음
 * - 수정/삭제 : 가능
 * - 대표 용도 : 설명 이미지, 문서, 동영상 등 실제 파일이 필요할 때
 *  ㄴ 실행 중 수정 가능 -> 유저 설정 바꿀 떄 (ex. 게임 세이브 데이터 저장)
 *  ㄴ 용량 이슈 / 관리 용이성
 *      ㄴ Resource : 실행파일 크기가 점점 커짐
 *      ㄴ Content : 실행파일이 가볍고, 메모리 사용도 가벼워짐 -> 파일은 옆에 따로 존재
 *          ㄴ 유지보수 시 Content는 파일만 바꾸면 되므로 유리
 * 
 * [Build Action vs Urikind]
 * - Resource, Content는 "파일의 빌드 방식"에 대한 설정
 * - Urikind는 해당 파일을 어떻게 접근할지에 대한 설정 방식
 *  => 둘은 직접적인 관련이 없음
 *  
 *  Resource - Pack URI => Urikind.absolute
 *  Content - 상대/절대 경로 => Urikind.absolute, Relative
 *  (외부 파일) - 물리 경로 or URL => 보통 absolute 사용
 *  
 *  [Resource를 Pack URI로 써야하는 이유?]
 *  - ..exe 안에 있는 리소스 파일을 찾을 수 있도록 Pack URI라는 전용 주소 체계를 사용하는 것
 *  
 *  [@]
 *  - 이스케이스 시퀀스 무시
 *  => 일반 문자열에서 백슬래시가 이스크에프 문자로 사용되는데 파일 경로에서는 경로 구분자로 사용되기 떄문에 백슬래시를 두 번 입력해야함
 *      @을 사용하면 백슬래시를 한번만 입력해도 됨. @가 붙은 문자열은 백슬래시를 이스케이프 시퀀스로 해석하지 않고 일반 문자로 해석함
 *  - 보통 절대경로에서 사용
 *  
 *  [escape sequence]
 *  - 프로그래밍 언어나 텍스트 형식에서 특수한 의미를 가지는 문자를 일반 문자처럼 취급, 특수 문자를 표현하기 위해 사용되는 문자
 *  - 보통 백슬래시와 함께 사용되어 일련의 이스케이프 시퀀스를 만듦.
 *  
 *  => 문자열 내에서 특수문자를 표현하기 위해, ""가 문자열의 시작과 끝을 나타내듯
 *      \ 도 출력시 특별한 동작을 지시하기 위해서 사용
 */
namespace day_22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isAngry = true;

        private Uri uriAngryImage = new Uri("pack://application:,,,/Assets/6.png", UriKind.Absolute);
        private Uri uriHappyImage = new Uri("pack://application:,,,/Assets/5.png", UriKind.Absolute);
        public MainWindow()
        {
            InitializeComponent();

            // 초기 이미지 설정
            imgTest.Source = new BitmapImage(new Uri("Assets/1.jpeg", UriKind.Relative));
            imgTest2.Source = new BitmapImage(new Uri("Assets/3.png", UriKind.Relative));
            imgTest3.Source = new BitmapImage(uriAngryImage);
            /*
             * new Uri(...) - 이미지 파일의 경로를 Uri 객체로 만듦.
             * 
             * UriKind
             * - Relative: 실행 파일 기준 경로
             * - Absolute: 전체 경로 명시
             * - RelativeOrAbsolute: 둘 중 맞는걸 자동 판정
             * 
             * new BitmapImage(...) - Uri를 통해 실제 이미지 객체 생성
             */
        }

        private void buttonImg_Click(object sender, RoutedEventArgs e)
        {
            imgTest.Source = new BitmapImage(new Uri("Assets/2.jpeg", UriKind.Relative));
        }

        private void buttonImg2_Click(object sender, RoutedEventArgs e)
        {
            string path = "Assets/4.png";
            imgTest2.Source = new BitmapImage(new Uri(path, UriKind.Relative));
        }

        private void buttonImg3_Click(object sender, RoutedEventArgs e)
        {
            imgTest3.Source = isAngry ? new BitmapImage(uriAngryImage) : new BitmapImage(uriHappyImage);
            isAngry = !isAngry;
        }
    }
}