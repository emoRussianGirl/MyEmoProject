# MyEmoProject
**MyEmoProject** - это WPF-приложение, которое позволяет вводить и выводить информацию о пользователе.

## Краткое описание проекта
**MyEmoProject** - это WPF-приложение, которое позволяет вводить и выводить информацию о пользователе. Работает только на ПК.

### Функционал приложения

-Приложение является одностраничным. </br>
-Можно вводить данные о пользователе и сохранять.</br>
-Введенные данные сразу записываются в БД.</br>
-Информацию о каждом пользователе можно посмотреть во второй колонке.</br>
На кнопку повешано действие перехода к следующему пользователю.</br>
``` C#
 private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Count++;
            Button_Click_1(sender, e);
        }
```
-Каждый созданный пользователь сразу отображается в выводе информации о пользователях.</br>


### Установка

Для запуска данной программы необходимы следующие условия:


1. Установленная на компьютере среда разработки Visual Studio*.
2. В Visual Studio необходимо скачать дополнительные компоненты, такие как:
2.1 Среда выполнения .Net 6.0
2.2 Разработка классических приложений .Net
3. Наличие подключения к сети Интернет.

***Visual Studio** — это стартовая площадка для написания, отладки и сборки кода, а также последующей публикации приложений.

Завершите пример получением некоторых данных о системе или использования их для небольшой демонстрации

## Авторы

* **Billie Thompson** - *Initial work* - [PurpleBooth](https://github.com/PurpleBooth)

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.
