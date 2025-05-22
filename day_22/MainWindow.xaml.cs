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
 * TabControl
 * 웹 브라우저 처럼 탭 버튼을 눌러 다른 내용의 화면 전환
 * 
 * 1. TabControl
 * - 전체 탭 컨테이너
 * - 내부의 여러개 TabItem을 가질 ㄹ수 있음
 * 
 * 2. TabItem
 * - 각각의 탭을 나타내는 항목
 * - Header : 탭 제목
 * - Content : 보여줄 컨텐츠 배치
 */

/*
 * StackPanel
 * 자식 요소들을 수직(Vertical) 또는 수평(Horizontal) 방향으로 자동으로 정렬해서 배치하는 Layout Panel
 * - 요소들을 순서대로 쌓음
 * - 마우스 조작으로 요소 이동 불가능
 * 
 * [Attribute]
 * Orientation : 쌓는 방향 지정 - Vertical(수직) : Default, Horizontal(수형)
 */

/*
 * Grid
 * 행과 열을 나눠 UI 요소를 격자 구조로 배치하도록 하는 Layout Panel
 * - 요소들이 표 형태로 정리되어야 할 때
 * - 요소들이 정확한 위치에 있어야 할 때
 * - 반응형 비율 기반 배치가 필요 할 때
 * 
 * [Attribute]
 * RowDefinition : 행(가로줄)
 * ColumnDefinition : 열(세로줄)
 * Height / Width : 
 * - Auto : 내부 요소의 크기에 맞게
 * - * : 나머지 공간을 비율로 자동 분배
 * - 숫자(px) : 고정 크기
 */

/*
 * TextBlock
 * 텍스트를 화면에 출력해주는 WPF에서 가장 기본적인 텍스트 표시용 Control
 * - 화면 읽기 전용 텍스트를 표시할 때 사용
 * - 사용자 직접 입력 X (입력은 TextBox)
 */

/*
 * GroupBox
 * 여러 개의 UI 요소를 한의 그룹으로 묶어주고, 그 그룹에 제목(label)을 붙일 수 있는 컨테이너
 * - 관련된 항목들을 시각적으로 묶어 표현할 때 사용
 */

/*
 * RadioButton
 * 
 * [Attribute]
 * GroupName : 여러 개의 라디오 버튼이 서로 다른 그룹으로 동작하도록 구분하는 속성
 * - 같은 GroupName을 가진 버튼들끼리는 서로 하나만 선택 가능
 * - 다른 GroupName을 부여하면 동시 선택 가능
 * Checked : RadioButton이 선택 될 때 연결되는 이벤트 핸들러
 * IsChecked : 현재 체크 상태를 코드로 확인할 때 사용
 */

/*
 * Slider
 * 사용자가 들래그하거나 클릭해서 숫자 값을 조절 할 수 있도록 해주는 입력 컨트롤
 * 
 * [Attribute]
 * - Minimum : 최소 값 (Default 0)
 * - Maximum : 최대 값 (Default 10)
 * - Value : 현재 값 (Default 0)
 * - Orientation : 방향 설정
 * - TickFrequency : 눈금 간격 설정
 * - IsSnapToTickEnabled : 눈금에 맞춰 조절할지 여부
 * - Ticks : 눈금 위치 설정
 */

/*
 * CheckBox
 * 여러개의 항목을 복수 선택 가능하게 할 때 사용
 * 
 * [Attribute]
 * - IsChecked : 체크 여부를 Boolean Type으로 반환
 * - 
 */

/*
 * ComboBox
 * 드롭다운 목록에서 항목을 하나 선택할 수 있게 해주는 컨트롤
 * -사용자는 미리 정의된 목록 중 하나를 선택하거나, 필요 시 직접 입력도 가능
 *
 * [Attribute]
 * -Items: 콤보박스에 표시할 항목 목록
 * -SelectedItem: 현재 선택된 항목 객체(보통 문자열)
 * -SelectedIndex: 선택된 항목의 인덱스 번호(0부터 시작)
 * -IsEditable: true면 사용자가 직접 입력 가능
 * -SelectedValue: 지정된 항목의 속성값
 */

/*
 * ListBox
 * 여러개의 항목들을 목록 형태로 나열해 보여줌.
 * 사용자가 항목을 하나 이상 선택할 수 있도록 해주는 컨트롤
 * 
 * [Diff]
 * - ComboBox : 펼쳐지는 드롭 다운 (공간 절약)
 * - ListBox : 펼처진 채로 보임 (한눈에 보기 좋음)
 * 
 * [Attriute]
 * - Items : 항목을 직접 추가할 수 있음
 * - ItemsSource : 외부 데이터 리스트를 바인딩 할 수 있음
 * - SelectedItem : 현재 선택된 항목 (기본 단일 선택)
 * - SelectedItems : 다중 선택 모드에서 선택된 모든 항목들
 * - SelectionMode : 선택 방식 (Single, Multiple, Extended)
 * 
 * [Event]
 * - SelectionChanged : 항목이 선택되거나 해제될 때 발생하는 이벤트
 */

/*
 * Data Binding
 * 1. ItemsSource
 * ListBox, ComboBox 처럼 여러 항목을 보여주는 컨트롤에 바인딩(연결) 해주는 속성
 * - 연결한 리스트의 각 항목이 ListBox 안에 자동으로 하나씩 표시됨
 * 
 * 2. ItemTemplate
 * ListBox, ComboBox등 목록 컨트롤에서 각 항목 하나를 어떻게 보여줄지 정의하는 템플릿
 * 
 * 3. DataTemplate
 * ListBox에서 각 항목이 어떻게 보일지를 정의하는 템플릿
 * - 기본적으로 항목이 ToString() 값으로 표현되지만 항목마다 원하는 UI요소 (TextBlock, ProgressBar, Image 등)을 조합해서 사용이 가능하다
 * - ItemTemplate의 속성임
 * 
 * {Binding Name}
 * - 바인딩 된 데이터의 Name 속성 값을 UI에 표시
 * 
 * {Binding Percent}
 * - 바인딩 된 데이터의 Percent 값을 꺼내서 ProgressBar의 Value로 넣는 것.
 */

/*
 * Web Beowser
 * WPF에서 제공하는 웹 페이지를 보여주는 컨트롤
 * IE 웹 엔진 기반(EOL)
 * Edge기반 WebView2를 사용하는게 좋다
 * 
 * [Attribute]
 * - Navigate(string url): 지정한 웹 주소로 이동
 * - GoBack(): 뒤로 이동
 * - GoForward(): 앞으로 이동
 */
namespace day_22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Data binding

            List<Animals> animals = new List<Animals>()
            {
                new Animals { Name = "하마", Percent = 10 },
                new Animals { Name = "타조", Percent = 20 },
                new Animals { Name = "토끼", Percent = 90 }
            };

            // listBox에 Data binding
            // - ListBox는 animals 리스트의 항목 개수만큼 줄을 만들어 화면에 표시하게 됨.
            listBox.ItemsSource = animals;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 선택된 RadioButton 확인
            string result = string.Empty;

            if (radioMale.IsChecked == true)
            {
                result = "남성을 선택했습니다.";
            }
            else if (radioFemale.IsChecked == true)
            {
                result = "여성을 선택했습니다.";
            }

            MessageBox.Show(result);
        }

        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Slider Event
            if (volumeText != null)
            {
                volumeText.Text = $"현재 값 : {volumeSlider.Value}";
            }
        }

        private void checkbox_Checked(object sender, RoutedEventArgs e)
        {
            // 체크된 한목들을 문자열로 조합
            List<string> selectedFruits = new List<string>();
            if (checkboxApple.IsChecked == true)
            {
                selectedFruits.Add("사과");
            }

            if (checkboxBanana.IsChecked == true)
            {
                selectedFruits.Add("바나나");
            }

            if (checkboxOrange.IsChecked == true)
            {
                selectedFruits.Add("오렌지");
            }

            textResult.Text = $"{string.Join(",", selectedFruits)}";
        }

        private void checkboxState_Click(object sender, RoutedEventArgs e)
        {
            bool? state = checkboxState.IsChecked;

            if (state == true)
            {
                textState.Text = "Current State : True";
            }
            else if (state == false)
            {
                textState.Text = "Current State : False";
            }
            else
            {
                textState.Text = "Current State : Null";
            }
        }

        private void comboFruits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = comboFruits.SelectedItem as ComboBoxItem;

            if (selectedItem != null)
            {
                String selectedText = selectedItem.Content.ToString();
                // selectedItem은 ComboBoxItem 클래스의 인스턴스이다
                // 그 안에 있는 Content 속성은 Object 타입임.

                textResult2.Text = $"선택한 과일 : {selectedText}";
            }


            /*
             * WPF에서 사용되는 모든 컨트롤 요소들은 전부 클래스
             * ComboboxItem item = new ComboBoxItem();
             * item.Content = "사과";
             * 
             * comboFruits.SelectedItem
             * - 사용자가 선택한 항목 가져오기
             * - 사용자가 선택한 항목(SelectedItem)은 ComboBoxItem 타입의 객체가 됨
             * 
             * as 연산자
             * - 안전하게 형변환 할 수 있게 도와주는 키워드
             * - 형변환에 실패하면 null 반환
             * 
             * as ComboBoxItem
             * - 이 항목이 실제로 ComboBoxItem 타입인지 확인하고, 맞다면 그 타입으로 변환해서 selectedItem에 넣어준다
             *  
             */
        }

        private void listColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem selectedItem = listColors.SelectedItem as ListBoxItem;

            if (selectedItem != null)
            {
                string selectedText = selectedItem.Content.ToString();
                textResult3.Text = $"선택한 색상 : {selectedText}";
            }
        }

        private void listFruits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> selectedFruits = new List<string>();
            foreach (ListBoxItem item in listFruits.SelectedItems)
            {
                selectedFruits.Add(item.Content.ToString());
            }
            textResult3.Text = $"선택한 과일 : {string.Join(", ", selectedFruits)}";
        }

        public class Animals
        {
            public string Name {  get; set; }
            public int Percent { get; set; }
        }

        private void buttonNaver_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser1.Navigate("https://www.naver.com");
        }

        private void buttonForward_Click(object sender, RoutedEventArgs e)
        {
            if (WebBrowser1.CanGoBack)
            {
                WebBrowser1.GoBack();
            }
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            if (WebBrowser1.CanGoForward)
            {
                WebBrowser1.GoForward();
            }
        }

        /*
        private void radioMale_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("남성을 선택했습니다.");
        }

        private void radioFemale_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("여성을 선택했습니다.");
        }
        */
    }
}